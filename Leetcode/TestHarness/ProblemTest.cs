using Leetcode.Models;
using System.Collections;
using System.Diagnostics;

namespace Leetcode.TestHarness
{
    public class ProblemTest<TInput, TOutput>
    {
        public record TestResult(bool IsPass, TInput Input, TOutput Expected, TOutput Actual, double TimeMicros);
        public record TestCase(TInput Input, TOutput Expected, bool ValidateBySum = false, bool ValidateByCount = false);
        public bool IsInPlace { get; }

        private readonly Func<TInput, TOutput> _solver;
        private readonly Func<TOutput, TOutput, bool> _comparer;

        public ProblemTest(Func<TInput, TOutput> solver, Func<TOutput, TOutput, bool>? comparer = null, bool isInPlace = false)
        {
            _solver = solver;
            _comparer = comparer ?? ((a, b) => EqualityComparer<TOutput>.Default.Equals(a, b));
            IsInPlace = isInPlace;
        }

        public void RunTests(List<TestCase> cases, int iterations = 1)
        {
            List<TestResult> results = new();
            int passed = 0;
            double totalTimeMicros = 0;

            foreach (var testcase in cases)
            {
                double totalTicks = 0;
                TOutput result = default!;
                bool isPass = true;

                for (int i = 0; i < iterations; i++)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    // Prevents test case corruption in in-place update algorithms
                    var input = IsInPlace ? Clone(testcase.Input) : testcase.Input;
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    result = _solver(input);
                    watch.Stop();
                    totalTicks += watch.ElapsedTicks;
                    isPass = testcase.ValidateBySum
                        ? ValidateBySum(input, result, testcase.Expected)
                        : _comparer(result, testcase.Expected);

                    isPass = isPass && testcase.ValidateByCount
                        ? (result is IEnumerable rEnum && testcase.Expected is IEnumerable eEnum && rEnum.Cast<object>().Count() == eEnum.Cast<object>().Count())
                        : isPass;

                }

                double avgMicros = totalTicks / iterations / Stopwatch.Frequency * 1_000_000;

                results.Add(new TestResult(isPass, testcase.Input, testcase.Expected, result, avgMicros));
                totalTimeMicros += avgMicros;
                if (isPass) passed++;
            }

            PrintSummary(results, passed, cases.Count, totalTimeMicros);
        }

        private bool ValidateBySum(TInput input, TOutput actual, TOutput expected)
        {
            if (input is ThreeSumInput ts && actual is List<List<int>> triplet)
            {
                if (triplet.Count == 0 || triplet?.FirstOrDefault()?.Count != 3 || triplet?.FirstOrDefault()?.Sum() != ts.Target) return false;

                var inputFreq = ts.Numbers.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
                var tripletFreq = triplet?.FirstOrDefault()?.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

                foreach (var kv in tripletFreq)
                {
                    if (!inputFreq.TryGetValue(kv.Key, out int count) || count < kv.Value)
                        return false;
                }

                return true;
            }

            // fallback for TwoSum-style inputs
            if (actual is not int[] indices || indices.Length != 2)
                return false;

            return input switch
            {
                TwoSumInput ti => ti.Numbers[indices[0]] + ti.Numbers[indices[1]] == ti.Target,
                TwoSumSortedInput ti => ti.Numbers[indices[0] - 1] + ti.Numbers[indices[1] - 1] == ti.Target,
                _ => false
            };
        }
        private void PrintSummary(List<TestResult> results, int passed, int total, double totalTimeMicros)
        {
            Console.WriteLine($"Summary: {passed}/{total} tests passed.");
            Console.WriteLine($"Total Time: {totalTimeMicros:F2} µs");
            Console.WriteLine($"Avg Time/Test: {totalTimeMicros / total:F2} µs");

            var failed = results.Where(r => !r.IsPass).ToList();
            if (failed.Any())
            {
                Console.WriteLine($"\nFailed Cases:");
                foreach (var fail in failed)
                {
                    Console.WriteLine($"Input: {Format(fail.Input)}");
                    Console.WriteLine($"Expected: {Format(fail.Expected)}");
                    Console.WriteLine($"Actual:   {Format(fail.Actual)}");
                    Console.WriteLine($"Time:     {fail.TimeMicros:F2} µs\n");
                }
            }
        }
        private string Format(object? obj)
        {
            if (obj == null) return "null";

            if (obj is IEnumerable<int[]> listOfArrays)
            {
                var formattedArrays = listOfArrays
                    .Select(arr => $"[{string.Join(", ", arr)}]");
                return $"[{string.Join(", ", formattedArrays)}]";
            }

            if (obj is IEnumerable enumerable && obj is not string)
            {
                var items = enumerable.Cast<object>()
                    .Select(item => Format(item)); // recursive
                return $"[{string.Join(", ", items)}]";
            }

            // Fallback for single objects
            return obj.ToString() ?? "null";
        }

        static T Clone<T>(T input)
        {
            if (input is int[] arr)
                return (T)(object)arr.ToArray();
            throw new NotSupportedException("Clone not implemented for this type.");
        }
    }
}
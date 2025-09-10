using Leetcode.Models;
using System.Collections;

namespace Leetcode.TestHarness
{
    public class ProblemTest<TInput, TOutput>
    {
        public record TestResult(bool IsPass, TInput Input, TOutput Expected, TOutput Actual, long TimeMs);
        public record TestCase(TInput Input, TOutput Expected, bool ValidateBySum = false, bool ValidateByCount = false);

        private readonly Func<TInput, TOutput> _solver;
        private readonly Func<TOutput, TOutput, bool> _comparer;

        public ProblemTest(Func<TInput, TOutput> solver, Func<TOutput, TOutput, bool>? comparer = null)
        {
            _solver = solver;
            _comparer = comparer ?? ((a, b) => EqualityComparer<TOutput>.Default.Equals(a, b));
        }

        public void RunTests(List<TestCase> cases)
        {
            List<TestResult> results = new();
            int passed = 0;
            long totalTime = 0;

            foreach (var test in cases)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var result = _solver(test.Input);
                watch.Stop();

                bool isPass = test.ValidateBySum
                    ? ValidateBySum(test.Input, result, test.Expected)
                    : _comparer(result, test.Expected);
                isPass = isPass && test.ValidateByCount ? (result is IEnumerable rEnum && test.Expected is IEnumerable eEnum && rEnum.Cast<object>().Count() == eEnum.Cast<object>().Count())
                    : isPass;

                results.Add(new TestResult(isPass, test.Input, test.Expected, result, watch.ElapsedMilliseconds));
                totalTime += watch.ElapsedMilliseconds;
                if (isPass) passed++;
            }

            PrintSummary(results, passed, cases.Count, totalTime);
        }

        private bool ValidateBySum(TInput input, TOutput actual, TOutput expected)
        {
            if (input is ThreeSumInput ts && actual is List<int[]> triplet)
            {
                if (triplet.Count == 0 || triplet?.FirstOrDefault()?.Length != 3 || triplet?.FirstOrDefault()?.Sum() != ts.Target) return false;

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

        private void PrintSummary(List<TestResult> results, int passed, int total, long totalTime)
        {
            Console.WriteLine($"\nSummary: {passed}/{total} tests passed.");
            Console.WriteLine($"Total Time: {totalTime} ms");
            Console.WriteLine($"Avg Time/Test: {totalTime / (double)total:F2} ms");

            var failed = results.Where(r => !r.IsPass).ToList();
            if (failed.Any())
            {
                Console.WriteLine($"\nFailed Cases:");
                foreach (var fail in failed)
                {
                    Console.WriteLine($"Input: {Format(fail.Input)}");
                    Console.WriteLine($"Expected: {Format(fail.Expected)}");
                    Console.WriteLine($"Actual:   {Format(fail.Actual)}");
                    Console.WriteLine($"Time:     {fail.TimeMs} ms\n");
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
    }
}
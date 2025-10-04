using Leetcode.Interfaces;
using Leetcode.Models;
using System.Collections;
using System.Diagnostics;

namespace Leetcode.TestHarness
{
    public class ProblemTest<TInput, TOutput>
    {
        public record BenchmarkSummary(string ProblemName, string StrategyName, int Passed, int Total, double TotalTimeMicros, double AvgTimeMicros) : IBenchmarkSummary;
        public record TestResult(bool IsPass, TInput Input, TOutput Expected, TOutput Actual, double TimeMicros);
        public record TestCase(TInput Input, TOutput Expected, bool ValidateBySum = false, bool ValidateByCount = false);
        public bool IsInPlace { get; }
        public bool HasDuplicates { get; }

        private readonly Func<TInput, TOutput> _solver;
        private readonly Func<TestCase, TOutput, bool> _comparer;
        private readonly string _problemName;
        public ProblemTest(Func<TInput, TOutput> solver, Func<TestCase, TOutput, bool> comparer, bool isInPlace = false, bool hasDuplicates = false, string problemName = "UnknownProblem")
        {
            _solver = solver;
            _comparer = comparer;
            IsInPlace = isInPlace;
            HasDuplicates = hasDuplicates;
            _problemName = problemName;
        }

        public BenchmarkSummary RunTests(List<TestCase> cases, int iterations = 1)
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
                        : _comparer(testcase, result);

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
            var summary = new BenchmarkSummary(
                                        ProblemName: _problemName,
                                        StrategyName: _solver.Method.DeclaringType?.Name ?? "UnknownStrategy",
                                        Passed: passed,
                                        Total: cases.Count,
                                        TotalTimeMicros: totalTimeMicros,
                                        AvgTimeMicros: totalTimeMicros / cases.Count
                                    );
            var failedCases = results.Where(r => !r.IsPass).ToList();

            if (failedCases.Any())
            {
                Console.WriteLine($"\n❌ Failed Test Cases for {summary.StrategyName}:");
                foreach (var fail in failedCases)
                {
                    Console.WriteLine($"Input:    {Format(fail.Input)}");
                    Console.WriteLine($"Expected: {Format(fail.Expected)}");
                    Console.WriteLine($"Actual:   {Format(fail.Actual)}");
                    //Console.WriteLine($"Time:     {fail.TimeMicros:F2} µs\n");
                }
            }
            return summary;
        }

        private bool ValidateBySum(TInput input, TOutput actual, TOutput expected)
        {
            if (input is ThreeSumInput ts && actual is List<List<int>> triplet)
            {
                if (triplet.Count == 0 || triplet?.FirstOrDefault()?.Count != 3 || triplet?.FirstOrDefault()?.Sum() != ts.Target) return false;
                var inputFreq = ts.Numbers.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

                var firstTriplet = triplet?.FirstOrDefault();
                if (firstTriplet == null) return false;

                var tripletFreq = firstTriplet
                    .GroupBy(x => x)
                    .ToDictionary(g => g.Key, g => g.Count());

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

            if (obj is ContainsDuplicateInput inputWithK)
                return $"[{string.Join(", ", inputWithK.Numbers)}], K: {inputWithK.K}";

            if (obj is ProblemInput<int[]> inputWithTarget)
                return $"[{string.Join(", ", inputWithTarget.Numbers)}], Target: {inputWithTarget.Target}";

            if (obj is MergeSortedArraysInput mergeInput)
                return $"Nums1: [{string.Join(", ", mergeInput.Nums1)}], M: {mergeInput.M}, " +
                       $"Nums2: [{string.Join(", ", mergeInput.Nums2)}], N: {mergeInput.N}";

            if (obj is int[] arr)
                return $"[{string.Join(", ", arr)}]";

            if (obj is IEnumerable<int[]> listOfArrays)
            {
                var formattedArrays = listOfArrays.Select(arr => $"[{string.Join(", ", arr)}]");
                return $"[{string.Join(", ", formattedArrays)}]";
            }

            if (obj is IEnumerable enumerable && obj is not string)
            {
                var items = enumerable.Cast<object>().Select(item => Format(item));
                return $"[{string.Join(", ", items)}]";
            }

            return obj.ToString() ?? "null";
        }
        static T Clone<T>(T input)
        {
            switch (input)
            {
                case int[] arr:
                    return (T)(object)arr.ToArray();

                case List<int> list:
                    return (T)(object)new List<int>(list);

                case RemoveElementInput rei:
                    return (T)(object)new RemoveElementInput(rei.Numbers.ToArray(), rei.Target);

                case MergeSortedArraysInput mergeInput:
                    return (T)(object)new MergeSortedArraysInput(
                        nums1: mergeInput.Nums1.ToArray(),
                        m: mergeInput.M,
                        nums2: mergeInput.Nums2.ToArray(),
                        n: mergeInput.N
                    );

                default:
                    throw new NotSupportedException($"Clone not implemented for type: {typeof(T).Name}");
            }
        }
    }
}
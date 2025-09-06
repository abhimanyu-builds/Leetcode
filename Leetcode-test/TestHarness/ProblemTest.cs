using Leetcode_test.Models;
using System.Collections;

namespace Leetcode_test.TestHarness
{
    public class ProblemTest<TInput, TOutput>
    {
        public record TestResult(bool IsPass, TInput Input, TOutput Expected, TOutput Actual, long TimeMs);
        public record TestCase(TInput Input, TOutput Expected, bool ValidateBySum = false);

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
                    ? ValidateBySum(test.Input, result)
                    : _comparer(result, test.Expected);

                results.Add(new TestResult(isPass, test.Input, test.Expected, result, watch.ElapsedMilliseconds));
                totalTime += watch.ElapsedMilliseconds;
                if (isPass) passed++;
            }

            PrintSummary(results, passed, cases.Count, totalTime);
        }
        private bool ValidateBySum(TInput input, TOutput actual)
        {
            if (input is TwoSumInput ts && actual is int[] indices && indices.Length == 2)
            {
                var nums = ts.Numbers;
                return nums[indices[0]] + nums[indices[1]] == ts.Target;
            }
            return false;
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
            return obj is IEnumerable enumerable && obj is not string
                ? $"[{string.Join(", ", enumerable.Cast<object>())}]"
                : obj.ToString() ?? "null";
        }
    }
}
using Leetcode.Common;
using Leetcode.Models;
using System.Collections;
using System.Diagnostics;

namespace Leetcode.TestHarness
{
    public class StrategyBenchmark<TInput, TOutput>
    {
        public record BenchmarkResult(string StrategyName, double AvgMicroseconds, bool IsCorrect);

        public List<BenchmarkResult> Run(
            IEnumerable<IProblemStrategy<TInput, TOutput>> strategies,
            List<(TInput input, TOutput expected)> testCases,
            Func<TOutput, TOutput, bool> comparer,
            int iterations = 1000)
        {
            var results = new List<BenchmarkResult>();

            foreach (var strategy in strategies)
            {
                long totalTicks = 0;
                bool allPass = true;

                foreach (var (input, expected) in testCases)
                {
                    for (int i = 0; i < iterations; i++)
                    {
                        GC.Collect(); // Optional: reduce GC noise
                        GC.WaitForPendingFinalizers();
                        GC.Collect();

                        var sw = Stopwatch.StartNew();
                        var actual = strategy.Implementation.Solve(input);
                        sw.Stop();
                        totalTicks += sw.ElapsedTicks;

                        if (i == 0 && !comparer(actual, expected)) allPass = false;
                    }
                }

                double avgMicroseconds = (double)totalTicks / (iterations * testCases.Count) / Stopwatch.Frequency * 1_000_000;
                results.Add(new BenchmarkResult(strategy.Name, avgMicroseconds, allPass));
            }

            return results;
        }
    }
}
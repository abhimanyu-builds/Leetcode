using Leetcode.Interfaces;
using Leetcode.TestHarness;

namespace Leetcode.Helpers
{
    public static class BenchmarkFormatter
    {
        public static void PrintTable<TInput, TOutput>(string problemName, List<ProblemTest<TInput, TOutput>.BenchmarkSummary> summaries)
        {
            var (p25, p50, p75) = GetPercentileThresholds(summaries.Cast<IBenchmarkSummary>().ToList());

            Console.WriteLine($"{$"\n\n=== {problemName} ===",-61} {"Pass",7} {"Total",6} {"Avg µs",10} {"Total µs",12}");
            Console.WriteLine(new string('-', 95));

            var sorted = summaries.OrderBy(s => s.AvgTimeMicros).ToList();
            foreach (var s in sorted)
            {
                if (s.AvgTimeMicros <= p25)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (s.AvgTimeMicros <= p50)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (s.AvgTimeMicros <= p75)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"{s.StrategyName,-60} {s.Passed,5} {s.Total,5} {s.AvgTimeMicros,10:F2} {s.TotalTimeMicros,12:F2}");
                Console.ResetColor();
            }
        }
        public static void PrintSummary(IEnumerable<IBenchmarkSummary> summaries)
        {
            var fastest = summaries.OrderBy(s => s.AvgTimeMicros).FirstOrDefault();
            var slowest = summaries.OrderByDescending(s => s.AvgTimeMicros).FirstOrDefault();

            Console.WriteLine($"\n=== Benchmark Summary ===");
            Console.WriteLine($"Total Strategies Evaluated: {summaries.Count()}");
            Console.WriteLine($"\n{"",-20}{"Problem",-30} {"Strategy",-40} {"Avg µs",10} {"Total µs",12}");
            Console.WriteLine(new string('-', 110));

            Console.WriteLine($"Fastest Strategy: {"",-2}{fastest.ProblemName,-30} {fastest.StrategyName,-40} {fastest.AvgTimeMicros,10:F2} {fastest.TotalTimeMicros,12:F2}");
            Console.WriteLine($"Slowest Strategy: {"",-2}{slowest.ProblemName,-30} {slowest.StrategyName,-40} {slowest.AvgTimeMicros,10:F2} {slowest.TotalTimeMicros,12:F2}");

            //foreach (var s in summaries.OrderBy(s => s.ProblemName).ThenBy(s => s.AvgTimeMicros))
            //{
            //    Console.WriteLine($"{s.ProblemName,-30} {s.StrategyName,-40} {s.AvgTimeMicros,10:F2} {s.TotalTimeMicros,12:F2}");
            //}
        }
        public static void ExportSummaryAsMarkdown(IEnumerable<IBenchmarkSummary> summaries)
        {
            Console.WriteLine("\n### Benchmark Summary (Markdown Export)\n");
            Console.WriteLine("| Problem | Strategy | Pass | Total | Avg µs | Total µs |");
            Console.WriteLine("|---------|----------|------|-------|--------|-----------|");

            foreach (var s in summaries.OrderBy(s => s.ProblemName).ThenBy(s => s.AvgTimeMicros))
            {
                Console.WriteLine($"| {s.ProblemName} | {s.StrategyName} | {s.Passed} | {s.Total} | {s.AvgTimeMicros:F2} | {s.TotalTimeMicros:F2} |");
            }
        }

        private static (double p25, double p50, double p75) GetPercentileThresholds(List<IBenchmarkSummary> summaries)
        {
            var sorted = summaries.Select(s => s.AvgTimeMicros).OrderBy(x => x).ToList();
            int count = sorted.Count;

            double p25 = sorted[(int)(0.25 * count)];
            double p50 = sorted[(int)(0.50 * count)];
            double p75 = sorted[(int)(0.75 * count)];

            return (p25, p50, p75);
        }
    }
}
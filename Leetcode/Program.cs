using Leetcode.Common;
using Leetcode.Helpers;
using Leetcode.Interfaces;
using Leetcode.Metadata;
using Leetcode.Models;
using Leetcode.TestHarness;

class Program
{
    static void Main()
    {
        Console.Clear();

        var allSummaries = new List<IBenchmarkSummary>();
        var problemTypesToRun = new ProblemType[]
        {
            ProblemType.HillAndValleyCount
        };
        //var problemTypesToRun = Enum.GetValues(typeof(ProblemType)).Cast<ProblemType>();

        foreach (var type in problemTypesToRun)
        {
            switch (type)
            {
                case ProblemType.SearchInsertPosition:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<SearchInsertPositionInput, int>(type) ?? []);
                    break;

                case ProblemType.RotatedArray:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<RotatedArrayInput, int>(type) ?? []);
                    break;

                case ProblemType.MaxAvgSubArrayI:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<MaxAvgSubArrayInput, double>(type) ?? []);
                    break;

                case ProblemType.MaxConsecutive1s:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<int[], int>(type) ?? []);
                    break;

                case ProblemType.LongestSubarrayAfterOneDeletion:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<int[], int>(type) ?? []);
                    break;

                case ProblemType.MaxConsecutive1sIII:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<MaxConsecutive1sIIIInput, int>(type) ?? []);
                    break;

                case ProblemType.TwoSum:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<TwoSumInput, int[]>(type) ?? []);
                    break;

                case ProblemType.ContainsDuplicateI:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<ContainsDuplicateInput, bool>(type) ?? []);
                    break;

                case ProblemType.ContainsDuplicateII:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<ContainsDuplicateInput, bool>(type) ?? []);
                    break;

                case ProblemType.LongestHarmoniousSubsequence:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<int[], int>(type) ?? []);
                    break;

                case ProblemType.TwoSumSorted:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<TwoSumSortedInput, int[]>(type) ?? []);
                    break;

                case ProblemType.ThreeSum:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<ThreeSumInput, List<List<int>>>(type) ?? []);
                    break;

                case ProblemType.RemoveElement:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<RemoveElementInput, int>(type) ?? []);
                    break;

                case ProblemType.RemoveDuplicatesFromSortedArray:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<int[], int>(type) ?? []);
                    break;

                case ProblemType.MergeSortedArrays:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<MergeSortedArraysInput, int[]>(type) ?? []);
                    break;

                case ProblemType.ValidMountainArray:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<int[], bool>(type) ?? []);
                    break;

                case ProblemType.FindMountainPeak:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<int[], int>(type) ?? []);
                    break;
                case ProblemType.FindPeakElement:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<int[], int>(type) ?? []);
                    break;
                case ProblemType.HillAndValleyCount:
                    allSummaries.AddRange(RunProblemDynamicAndReturnSummary<int[], int>(type) ?? []);
                    break;

                default:
                    Console.WriteLine($"⚠️ Skipping {type} — no type mapping defined.");
                    break;
            }
        }

        BenchmarkFormatter.PrintSummary(allSummaries);
        BenchmarkFormatter.ExportSummaryAsMarkdown(allSummaries);

    }

    static List<IBenchmarkSummary>? RunProblemDynamicAndReturnSummary<TInput, TOutput>(ProblemType type, int iterations = 1)
    {
        var providerObj = TestCaseProviderRegistry.GetProvider(type);
        var strategyObjs = StrategyRegistry.GetStrategies(type);

        if (providerObj is ITestCaseProvider<TInput, TOutput> provider &&
            strategyObjs.All(s => s is IProblemStrategy<TInput, TOutput>))
        {
            var strategies = strategyObjs.Cast<IProblemStrategy<TInput, TOutput>>();
            var comparer = ComparerResolver.GetComparer<TInput, TOutput>(type);

            var summaries = RunTestSuiteAndReturnSummary(type, provider.GetTestCases(), strategies, comparer, iterations);
            return summaries.Cast<IBenchmarkSummary>().ToList();
        }

        Console.WriteLine($"❌ Type mismatch or missing registry entries for {type}");
        return null;
    }

    static List<ProblemTest<TInput, TOutput>.BenchmarkSummary> RunTestSuiteAndReturnSummary<TInput, TOutput>(
        ProblemType type,
        List<ProblemTest<TInput, TOutput>.TestCase> testCases,
        IEnumerable<IProblemStrategy<TInput, TOutput>> strategies,
        Func<ProblemTest<TInput, TOutput>.TestCase, TOutput, bool> comparer,
        int iterations)
    {
        var summaries = new List<ProblemTest<TInput, TOutput>.BenchmarkSummary>();

        foreach (var strategy in strategies)
        {
            if (strategy is not ProblemStrategy<TInput, TOutput> typed) continue;

            var testHarness = new ProblemTest<TInput, TOutput>(
                typed.Implementation.Solve,
                comparer,
                typed.IsInPlace,
                typed.HasDuplicates,
                problemName: type.ToString()
            );

            var summary = testHarness.RunTests(testCases, iterations);
            summaries.Add(summary);

        }

        BenchmarkFormatter.PrintTable(type.ToString(), summaries);

        return summaries;
    }
}
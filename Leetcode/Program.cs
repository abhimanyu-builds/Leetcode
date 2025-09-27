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

        RunProblem(ProblemType.SearchInsertPosition);
        RunProblem(ProblemType.RotatedArray);

        RunProblem(ProblemType.MaxAvgSubArrayI);
        RunProblem(ProblemType.MaxConsecutive1s);

        RunProblem(ProblemType.TwoSum);
        RunProblem(ProblemType.ContainsDuplicateI);
        RunProblem(ProblemType.ContainsDuplicateII);
        RunProblem(ProblemType.LongestHarmoniousSubsequence);

        RunProblem(ProblemType.TwoSumSorted);
        RunProblem(ProblemType.ThreeSum);

        RunProblem(ProblemType.RemoveElement);
        RunProblem(ProblemType.RemoveDuplicatesFromSortedArray);
    }

    static void RunProblem(ProblemType type, int iterations = 1)
    {
        Console.WriteLine($"\n=== Running tests for {type} ===");

        switch (type)
        {

            case ProblemType.SearchInsertPosition:
                RunProblemDynamic<SearchInsertPositionInput, int>(type, iterations);
                break;
            case ProblemType.RotatedArray:
                RunProblemDynamic<RotatedArrayInput, int>(type, iterations);
                break;

            case ProblemType.MaxAvgSubArrayI:
                RunProblemDynamic<MaxAvgSubArrayInput, double>(type, iterations);
                break;
            case ProblemType.MaxConsecutive1s:
                RunProblemDynamic<int[], int>(type, iterations);
                break;

            case ProblemType.TwoSum:
                RunProblemDynamic<TwoSumInput, int[]>(type, iterations);
                break;
            case ProblemType.ContainsDuplicateI:
                RunProblemDynamic<ContainsDuplicateInput, bool>(type, iterations);
                break;
            case ProblemType.ContainsDuplicateII:
                RunProblemDynamic<ContainsDuplicateInput, bool>(type, iterations);
                break;
            case ProblemType.LongestHarmoniousSubsequence:
                RunProblemDynamic<int[], int>(type, iterations);
                break;

            case ProblemType.TwoSumSorted:
                RunProblemDynamic<TwoSumSortedInput, int[]>(type, iterations);
                break;
            case ProblemType.ThreeSum:
                RunProblemDynamic<ThreeSumInput, List<List<int>>>(type, iterations);
                break;

            case ProblemType.RemoveElement:
                RunProblemDynamic<RemoveElementInput, int>(type, iterations);
                break;
            case ProblemType.RemoveDuplicatesFromSortedArray:
                RunProblemDynamic<int[], int>(type, iterations);
                break;

            default:
                Console.WriteLine($"Unsupported problem type {type}");
                break;
        }
    }

    static void RunProblemDynamic<TInput, TOutput>(ProblemType type, int iterations = 1)
    {
        var providerObj = TestCaseProviderRegistry.GetProvider(type);
        var strategyObjs = StrategyRegistry.GetStrategies(type);

        if (providerObj is ITestCaseProvider<TInput, TOutput> provider &&
            strategyObjs.All(s => s is IProblemStrategy<TInput, TOutput>))
        {
            var strategies = strategyObjs.Cast<IProblemStrategy<TInput, TOutput>>();
            RunTestSuite<TInput, TOutput>(
                provider.GetTestCases(),
                strategies,
                ComparerResolver.GetComparer<TInput, TOutput>(type),
                iterations
            );
        }
        else
        {
            Console.WriteLine($"❌ Type mismatch or missing registry entries for {type}");
        }
    }

    static void RunTestSuite<TInput, TOutput>(
        List<ProblemTest<TInput, TOutput>.TestCase> testCases,
        IEnumerable<IProblemStrategy<TInput, TOutput>> strategies,
        Func<ProblemTest<TInput, TOutput>.TestCase, TOutput, bool> comparer,
        int iterations)
    {
        foreach (var strategy in strategies)
        {
            Console.WriteLine($"\nRunning strategy: {strategy.Name} (x{iterations} iterations per test)");
            var testHarness = new ProblemTest<TInput, TOutput>(strategy.Implementation.Solve, comparer, strategy.IsInPlace);
            testHarness.RunTests(testCases, iterations);
        }
    }
}
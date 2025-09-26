using Leetcode.Common;
using Leetcode.Helpers;
using Leetcode.Metadata;
using Leetcode.Models;
using Leetcode.TestHarness;

class Program
{
    static void Main()
    {
        Console.Clear();

        RunProblem(ProblemType.LongestHarmoniousSubsequence,1);
        //RunProblem(ProblemType.SearchInsertPosition);
        //RunProblem(ProblemType.MaxConsecutive1s);
        //RunProblem(ProblemType.MaxAvgSubArrayI);
        //RunProblem(ProblemType.ContainsDuplicateII);
        //RunProblem(ProblemType.ContainsDuplicateI);
        //RunProblem(ProblemType.RotatedArray);
        //RunProblem(ProblemType.RemoveElement);
        //RunProblem(ProblemType.RemoveDuplicatesFromSortedArray);
        //RunProblem(ProblemType.TwoSum);
        //RunProblem(ProblemType.TwoSumSorted);
        //RunProblem(ProblemType.ThreeSum);
    }

    static void RunProblem(ProblemType type, int iterations = 1)
    {
        Console.WriteLine($"\n=== Running tests for {type} ===");

        switch (type)
        {
            case ProblemType.TwoSum:
                RunTestSuite<TwoSumInput, int[]>(
                    ProblemTestCaseFactory.GetTwoSumTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetTwoSumStrategies(),
                    ComparerResolver.GetComparer<TwoSumInput, int[]>(type),
                    iterations
                );
                break;

            case ProblemType.TwoSumSorted:
                RunTestSuite<TwoSumSortedInput, int[]>(
                    ProblemTestCaseFactory.GetTwoSumSortedTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetTwoSumSortedStrategies(),
                    ComparerResolver.GetComparer<TwoSumSortedInput, int[]>(type),
                    iterations
                );
                break;

            case ProblemType.ThreeSum:
                RunTestSuite<ThreeSumInput, List<List<int>>>(
                    ProblemTestCaseFactory.GetThreeSumTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetThreeSumStrategies(),
                    ComparerResolver.GetComparer<ThreeSumInput, List<List<int>>>(type),
                    iterations
                );
                break;

            case ProblemType.RemoveDuplicatesFromSortedArray:
                RunTestSuite<int[], int>(
                    ProblemTestCaseFactory.GetRemoveDuplicatesTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetRemoveDuplicatesStrategies(),
                    ComparerResolver.GetComparer<int[], int>(type),
                    iterations
                );
                break;

            case ProblemType.RemoveElement:
                RunTestSuite<RemoveElementInput, int>(
                    ProblemTestCaseFactory.GetRemoveElementTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetRemoveElementStrategies(),
                    ComparerResolver.GetComparer<RemoveElementInput, int>(type),
                    iterations
                );
                break;

            case ProblemType.RotatedArray:
                RunTestSuite<RotatedArrayInput, int>(
                    ProblemTestCaseFactory.GetRotatedArrayTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetRotatedArrayStrategies(),
                    ComparerResolver.GetComparer<RotatedArrayInput, int>(type),
                    iterations
                );
                break;

            case ProblemType.ContainsDuplicateI:
                RunTestSuite<ContainsDuplicateInput, bool>(
                    ProblemTestCaseFactory.GetContainsDuplicateITestCases().GetTestCases(),
                    ProblemStrategyFactory.GetContainsDuplicateIStrategies(),
                    ComparerResolver.GetComparer<ContainsDuplicateInput, bool>(type),
                    iterations
                );
                break;

            case ProblemType.ContainsDuplicateII:
                RunTestSuite<ContainsDuplicateInput, bool>(
                    ProblemTestCaseFactory.GetContainsDuplicateIITestCases().GetTestCases(),
                    ProblemStrategyFactory.GetContainsDuplicateIIStrategies(),
                    ComparerResolver.GetComparer<ContainsDuplicateInput, bool>(type),
                    iterations
                );
                break;
            case ProblemType.MaxAvgSubArrayI:
                RunTestSuite<MaxAvgSubArrayInput, double>(
                    ProblemTestCaseFactory.GetMaxAvgSubArrayITestCases().GetTestCases(),
                    ProblemStrategyFactory.GetMaxAvgSubArrayIStrategies(),
                    ComparerResolver.GetComparer<MaxAvgSubArrayInput, double>(type),
                    iterations
                );
                break;
            case ProblemType.MaxConsecutive1s:
                RunTestSuite<int[], int>(
                    ProblemTestCaseFactory.GetMaxConsecutive1sTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetMaxConsectuive1sStrategies(),
                    ComparerResolver.GetComparer<int[], int>(type),
                    iterations
                );
                break;
            case ProblemType.SearchInsertPosition:
                RunTestSuite<SearchInsertPositionInput, int>(
                    ProblemTestCaseFactory.GetSearchInsertPositionTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetSearchInsertPositionStrategies(),
                    ComparerResolver.GetComparer<SearchInsertPositionInput, int>(type),
                    iterations
                );
                break;
            case ProblemType.LongestHarmoniousSubsequence:
                RunTestSuite<int[], int>(
                    ProblemTestCaseFactory.GetLongestHarmoniousSubsequenceTestCases().GetTestCases(),
                    ProblemStrategyFactory.GetLongestHarmoniousSubsequenceStrategies(),
                    ComparerResolver.GetComparer<int[], int>(type),
                    iterations
                );
                break;
                
            default:
                Console.WriteLine($"Unsupported problem type {type}");
                break;
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
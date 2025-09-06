public class TwoSumTest
{
    public record TwoSumCase(int[] Array, int[] Expected);
    public TwoSumTest()
    {
        List<TwoSumCase> cases = GenerateTestCases();

        int passed = 0, total = 0;
        bool isPass = false;
        foreach (var testCase in cases)
        {
            total++;
            isPass = RunTest(testCase);
            if (isPass) passed++;
        }
        Console.WriteLine($"\nSummary: {passed}/{total} tests passed.");
    }

    private static List<TwoSumCase> GenerateTestCases()
    {
        var cases = new List<TwoSumCase>
        {
            new([3, 2, 4], [1, 2]),                //to catch off-by-one error
            new([-2, -1, 0, 1, 2], [3, 4]),
            new([2, 7, 11, 15], [0, 1]),           // Basic match
            new([1, 2, 3, 4, 6], [3, 4]),          // Match at end
            new([5, 75, 25], [1, 2]),              // Match in middle
            new([3, 3], [0, 1]),                   // Duplicate values
            new([0, 4, 3, 0], [0, 3]),             // Zeroes
            new([-1, -2, -3, -4, -5], [2, 4]),     // All negative
            new([-10, 20, 10, -5], [0, 2]),        // Mixed signs
            new([1, 2], [0, 1]),                   // Minimum length
            new([1, 1, 1, 1, 1, 1], [0, 1]),       // Repeated values
            new([3, 3], [0, 1]),                   // Repeated values & Minimum length
            new(Enumerable.Range(1, 100000).ToArray(), [99998, 99999]), // Large input
        };

        Random rand = new();
        int size = rand.Next(10, 1000), min = rand.Next(-10000, 0), max = rand.Next(min, 10000);
        Console.WriteLine($"Array Size: {size}, Min Value: {min}, Max Value: {max}");
        int[] array = GenerateRandomArray(size, min, max);
        for (int t = 0; t < rand.Next(10, 100); t++)
        {
            //Doesn't guarantee unique solution. But the solution is guaranteed to be present. Result to be verified with sum match
            int i = rand.Next(0, size - 1), j = rand.Next(i + 1, size);
            cases.Add(new TwoSumCase(array, [i, j]));                     // Basic match
            cases.Add(new TwoSumCase(array, [size - 2, size - 1]));       // Match at end
        }

        return cases;
    }

    public static int[] GenerateRandomArray(int size, int minValue, int maxValue)
    {
        int[] array = new int[size];
        Random rand = new();
        for (int i = 0; i < size; i++)
        {
            array[i] = rand.Next(minValue, maxValue + 1);
        }
        return array;
    }

    public static bool RunTest(TwoSumCase testCase)
    {
        (int[] array, int[] expected) = testCase;
        var (i, j) = (expected[0], expected[1]);
        int target = array[i] + array[j];
        On2TwoLoopSolution solution = new();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        int[] result = solution.TwoSum(array, target);
        watch.Stop();
        bool isPass = (array[result[0]] + array[result[1]] == target);
        PrintTestResult(isPass, testCase, result, watch.ElapsedMilliseconds);
        return isPass;
    }
    public static void PrintTestResult(bool isPass, TwoSumCase testCase, int[] result, long timeMs)

    {
        int[] array = testCase.Array;
        var (i, j) = (testCase.Expected[0], testCase.Expected[1]);
        int target = array[i] + array[j];

        Console.WriteLine($@"{"Result:",-12} {(isPass ? "Pass" : "Fail"),-10} | {"Target:",-12} {target,-10}
                            {"Expected:",-12} [{i},{j}] ({array[i],3} + {array[j],3} = {array[i] + array[j],4})
                            {"Actual:",-12} [{result[0]},{result[1]}] ({array[result[0]],3} + {array[result[1]],3} = {array[result[0]] + array[result[1]],4})
                            {"Time taken:",-12} {timeMs} ms
                            ");
    }
}

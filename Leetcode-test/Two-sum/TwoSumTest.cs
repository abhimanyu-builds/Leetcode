using System;

public class TwoSumTest
{
    public TwoSumTest()
    {
        Random rand = new();
        int size = rand.Next(10,1000), min = rand.Next(-10000,0), max = rand.Next(min,10000);
        Console.WriteLine($"Array Size: {size}, Min Value: {min}, Max Value: {max}");
        int[] array = GenerateRandomArray(size, min, max);
        for (int t = 0; t < rand.Next(10,100); t++)
        {
            //Doesn't guarantee unique solution. But the solution is guaranteed to be present. Result to be verified with sum match
            int i = rand.Next(0, size), j = rand.Next(i, size);
            RunTest(array, i, j);
        }
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

    public static void RunTest(int[] array, int i, int j)
    {
        int target = array[i] + array[j];
        Solution solution = new();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        int[] result = solution.TwoSum(array, target);
        watch.Stop();
        Console.WriteLine($@"{"Result:",-12} {(array[i] + array[j] == array[result[0]] + array[result[1]] ? "Pass" : "Fail"),-10} | {"Target:",-12} {target,-10}
                            {"Expected:",-12} [{i},{j}] ({array[i],3} + {array[j],3} = {array[i] + array[j],4})
                            {"Actual:",-12} [{result[0]},{result[1]}] ({array[result[0]],3} + {array[result[1]],3} = {array[result[0]] + array[result[1]],4})
                            {"Time taken:",-12} {watch.ElapsedMilliseconds} ms
                            ");
    }
}

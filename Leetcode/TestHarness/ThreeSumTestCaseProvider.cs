using Leetcode.Interfaces;
using Leetcode.Models;
using Leetcode.TestHarness;

public class ThreeSumTestCaseProvider : ITestCaseProvider<ThreeSumInput, List<List<int>>>
{
    public List<ProblemTest<ThreeSumInput, List<List<int>>>.TestCase> GetTestCases()
    {
        List<ProblemTest<ThreeSumInput, List<List<int>>>.TestCase> cases = GetStaticTestCases();
        //cases.AddRange(GenerateRandomizedCases());
        //cases.AddRange(GenerateEdgeCases());
        return cases;
    }
    private static List<ProblemTest<ThreeSumInput, List<List<int>>>.TestCase> GetStaticTestCases()
    {
        // Manually defined test cases accounting for ambiguity
        var cases = new List<ProblemTest<ThreeSumInput, List<List<int>>>.TestCase>
        {
            // Empty input
            new(new ThreeSumInput(new List<int> { }, 0), new List<List<int>>()),

            // Single and double element cases
            new(new ThreeSumInput(new List<int> { 0 }, 0), new List<List<int>>()),
            new(new ThreeSumInput(new List<int> { 0, 0 }, 0), new List<List<int>>()),

            // Triple zero case
            new(new ThreeSumInput(new List<int> { 0, 0, 0 }, 0), new List<List<int>> { new List<int>() { 0, 0, 0 } }),

            // Simple valid triplet
            new(new ThreeSumInput(new List<int> { -1, 0, 1 }, 0), new List<List<int>> { new List<int> { -1, 0, 1 } }),
            new(new ThreeSumInput(new List<int> { -2, 0, 2, -1, 1 }, 0), new List<List<int>>
            {
                new List<int> { -2, 0, 2 },
                new List<int> { -1, 0, 1 }
            }, ValidateBySum:true, ValidateByCount:true),

            new(new ThreeSumInput(new List<int> { 1, 0, 1 }, 0), new List<List<int>> ()),

            // Multiple valid triplets
            new(new ThreeSumInput(new List<int> { -2, 0, 2, -1, 0, 1 }, 0), new List<List<int>>
            {
                new List<int> { -2, 0, 2 },
                new List<int> { -1, 0, 1 }
            }, ValidateBySum:true, ValidateByCount:true),

            // Mix of negatives and positives
            new(new ThreeSumInput(new List<int> { -3, -2, -1, 0, 0, 1, 2, 3 }, 0), new List<List<int>>
            {
                new List<int> { -3, 0, 3 },
                new List<int> { -2, -1, 3 },
                new List<int> { -3, 1, 2 },
                new List<int> { -2, 0, 2 },
                new List<int> { -1, 0, 1 }
            }, ValidateBySum:true, ValidateByCount:true),
            //ambiguous case - depending on implementation, could return more or fewer triplets
            new(new ThreeSumInput(new List<int> { -3, -2, -1, 0, 1, 2, 3 }, 0), new List<List<int>>
            {
                new List<int> { -3, 0, 3 },
                new List<int> { -3, 1, 2 },
                new List<int> { -2, -1, 3 },
                new List<int> { -2, 0, 2 },
                new List<int> { -1, 0, 1 }
            }, ValidateBySum:true, ValidateByCount:true),

            // Duplicates with symmetry
            new(new ThreeSumInput(new List<int> { -4, -2, -2, 0, 0, 2, 2, 4 }, 0), new List<List<int>>
            {
                new List<int> { -4, 2, 2 },
                new List<int> { -2, -2, 4 },
                new List<int> { -4, 0, 4 },
                new List<int> { -2, 0, 2 }
            }, ValidateBySum:true, ValidateByCount:true),

            // Multiple zeros and duplicates
            new(new ThreeSumInput(new List<int> { -2, -2, 0, 0, 2, 2 }, 0), new List<List<int>>
            {
                new List<int> { -2, 0, 2 }
            }, ValidateBySum:true, ValidateByCount:true),

            // All negative, no valid triplet
            new(new ThreeSumInput(new List<int> { -5, -4, -3, -2, -1 }, 0), new List<List<int>>()),

            // All positive, no valid triplet
            new(new ThreeSumInput(new List<int> { 1, 2, 3, 4, 5 }, 0), new List<List<int>>()),

            // Classic LeetCode-style input
            new(new ThreeSumInput(new List<int> { -1, 0, 1, 2, -1, -4 }, 0), new List<List<int>>
            {
                new List<int> { -1, -1, 2 },
                new List<int> { -1, 0, 1 }
            }, ValidateBySum:true, ValidateByCount:true),

            // Overlapping triplets
            new(new ThreeSumInput(new List<int> { -2, -1, 1, 2, 3, -3 }, 0), new List<List<int>>
            {
                new List<int> { -2, -1, 3 },
                new List<int> { -3, 1, 2 }
            }, ValidateBySum:true, ValidateByCount:true),

            // Quadruple zero, only one valid triplet
            new(new ThreeSumInput(new List<int> { 0, 0, 0, 0 }, 0), new List<List<int>>
            {
                new List<int> { 0, 0, 0 }
            }),

            // Repeated values, multiple valid sets
            new(new ThreeSumInput(new List<int> { -1, -1, -1, 2, 2, 2 }, 0), new List<List<int>>
            {
                new List<int> { -1, -1, 2 }
            }),

            // Large input with valid triplet near end
            new(new ThreeSumInput(new List<int> { 1, 2, 3, 99996, 99997, 99998 }, 300000), new List<List<int>>()),

            // Large input with valid triplet
            new(new ThreeSumInput(new List<int> { -100000, 0, 100000 }, 0), new List<List<int>>
            {
                new List<int> { -100000, 0, 100000 }
            })
        };

        return cases;
    }
    private List<ProblemTest<ThreeSumInput, List<List<int>>>.TestCase> GenerateRandomizedCases()
    {
        var testCases = new List<ProblemTest<ThreeSumInput, List<List<int>>>.TestCase>();
        Random rand = new();

        int numberOfCases = rand.Next(10, 30); // Total test cases to generate

        for (int t = 0; t < numberOfCases; t++)
        {
            int size = rand.Next(10, 1000);
            int min = rand.Next(-10000, 0);
            int max = rand.Next(min + 100, 10000);

            List<int> nums = new();

            // Generate a guaranteed valid triplet
            int a = rand.Next(min, max);
            int b = rand.Next(min, max);
            int c = -a - b; // Ensures a + b + c == 0

            nums.AddRange([a, b, c]);

            // Add random noise
            for (int i = 0; i < size - 3; i++)
            {
                nums.Add(rand.Next(min, max));
            }

            // Shuffle the array
            List<int> array = nums.OrderBy(_ => rand.Next()).ToList();

            testCases.Add(new(new ThreeSumInput(array, 0), [], ValidateBySum: true));
        }

        return testCases;
    }
    private List<ProblemTest<ThreeSumInput, List<List<int>>>.TestCase> GenerateEdgeCases()
    {
        var testCases = new List<ProblemTest<ThreeSumInput, List<List<int>>>.TestCase>();
        Random rand = new();

        //All Zeros: Vary count from 0 to 100
        for (int count = 0; count <= 100; count += rand.Next(5, 20))
        {
            List<int> zeros = Enumerable.Repeat(0, count).ToList();
            testCases.Add(new(new ThreeSumInput(zeros, 0), [], ValidateBySum: true));
        }

        //All Negatives: Vary count and range
        for (int count = 5; count <= 100; count += rand.Next(10, 30))
        {
            List<int> negatives = Enumerable.Range(-count, count).ToList();
            testCases.Add(new(new ThreeSumInput(negatives, 0), [], ValidateBySum: true));
        }

        //All Positives: Vary count and range
        for (int count = 5; count <= 100; count += rand.Next(10, 30))
        {
            List<int> positives = Enumerable.Range(1, count).ToList();
            testCases.Add(new(new ThreeSumInput(positives, 0), [], ValidateBySum: true));
        }

        //Duplicates with Valid Triplet: Randomized sets
        for (int i = 0; i < 10; i++)
        {
            int x = rand.Next(-10, 10);
            int y = rand.Next(-10, 10);
            int z = -x - y;
            List<int> array = Enumerable.Repeat(x, rand.Next(2, 5))
                .Concat(Enumerable.Repeat(y, rand.Next(2, 5)))
                .Concat(Enumerable.Repeat(z, rand.Next(2, 5)))
                .ToList();
            testCases.Add(new(new ThreeSumInput(array, 0), [], ValidateBySum: true));
        }

        //Multiple Zeros + Symmetric Pairs
        for (int i = 0; i < 10; i++)
        {
            int val = rand.Next(1, 100);
            int zeroCount = rand.Next(1, 10);
            List<int> array = Enumerable.Repeat(-val, 2)
                .Concat(Enumerable.Repeat(0, zeroCount))
                .Concat(Enumerable.Repeat(val, 2))
                .ToList();
            testCases.Add(new(new ThreeSumInput(array, 0), [], ValidateBySum: true));
        }

        //Large Input, No Valid Triplet
        testCases.Add(new(new ThreeSumInput(Enumerable.Range(1, 100000).ToList(), 0), [], ValidateBySum: true));

        //Valid Triplet at End
        List<int> endTriplet = Enumerable.Range(1, 1000).Concat(new[] { 99996, 99997, -199993 }).ToList();
        testCases.Add(new(new ThreeSumInput(endTriplet, 0), [], ValidateBySum: true));

        //Valid Triplet with Duplicates
        List<int> dupTriplet = Enumerable.Repeat(-3, 2).Concat(Enumerable.Repeat(0, 2)).Concat(Enumerable.Repeat(3, 2)).ToList();
        testCases.Add(new(new ThreeSumInput(dupTriplet, 0), [], ValidateBySum: true));

        return testCases;
    }
}

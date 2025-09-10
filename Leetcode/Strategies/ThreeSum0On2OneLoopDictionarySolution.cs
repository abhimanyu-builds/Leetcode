using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.Strategies
{
    public class ThreeSum0On2OneLoopDictionarySolution : IProblemSolution<ThreeSumInput, List<int[]>>
    {
        public List<int[]> Solve(ThreeSumInput input)
        {
            //Submission: https://leetcode.com/submissions/detail/

            //Analysis:
            //nums can have -ve/0/+ve numbers in any order
            //find sets of 3 elements whose sum equals target. Trivial case target = 0
            //indices need not be returned, actual elements to be retuned - any order is okay
            //strict uniqueness - no duplicate sets in result not allowed - not explicitly mentioned but will self-enforce

            //Approach: 
            //Create Frequency Dictionary with elements.
            //Consider how many zeros are available so that symmetric integer pairs (-x and x) can be matched
            //Check duplicates and negative doubles to be matched
            //check sums to match with negative sums
            //Update dictionary as the array is traversed to reduce lookups

            //Solution:
            //priority-based triplet assembler
            //- Symmetric triplets first (clean, balanced)
            //-Duplicate - based triplets next(less flexible)
            //-General triplets last(most expressive, but riskier for reuse)
            //-Unique triplet combinations



            bool strictuniqueness = true;

            var (nums, target) = (input.Numbers, input.Target);
            //trivial case target=0;
            Dictionary<int, int> pool = CreateDictionary(nums);

            List<int[]> result = new();
            HashSet<(int, int, int)> seen = new();

            List<int> triplet = new();

            foreach (int key in pool.Keys)
            {
                if (key == target || pool[key] == 0) continue;
                //first pass for symmetrics
                if (pool.TryGetValue(target, out int targetCount) && targetCount > 0 && strictuniqueness)
                {
                    if (pool.TryGetValue(-key, out int negKeyCount) && pool[key] > 0 && negKeyCount > 0 && pool[target] > 0)
                    {
                        triplet = [-key, target, key];
                        triplet.Sort();
                        var tripletSignature = (triplet[0], triplet[1], triplet[2]);
                        if (seen.Contains(tripletSignature)) continue;

                        seen.Add(tripletSignature);
                        result.Add(triplet.ToArray());
                        pool[key]--;
                        pool[-key]--;
                        pool[target]--;
                    }
                }
                //second pass for duplicates
                if (pool[key] > 1 && pool.TryGetValue(target - key * 2, out int doubleKeyCount) && strictuniqueness)
                {
                    if (doubleKeyCount > 0)
                    {
                        triplet = [key, key, target - key * 2];
                        triplet.Sort();
                        var tripletSignature = (triplet[0], triplet[1], triplet[2]);
                        if (seen.Contains(tripletSignature)) continue;

                        seen.Add(tripletSignature);

                        result.Add(triplet.ToArray());
                        pool[key] -= 2;
                        pool[target - key * 2]--;
                    }
                }
            }
            List<int> remainingKeys = pool.Where(kv => kv.Key != target && kv.Value > 0).Select(kv => kv.Key).ToList();
            for (int i = 0; i < remainingKeys.Count - 1; i++)
            {
                for (int j = i + 1; j < remainingKeys.Count; j++)
                {
                    int a = remainingKeys[i];
                    int b = remainingKeys[j];
                    int c = target - a - b;
                    if (pool[a] > 0 && pool[b] > 0 && pool.TryGetValue(c, out int cCount) && cCount > 0 && c != a && c != b)
                    {
                        triplet = [a, b, c];
                        triplet.Sort();
                        var tripletSignature = (triplet[0], triplet[1], triplet[2]);
                        if (seen.Contains(tripletSignature)) continue;

                        seen.Add(tripletSignature);
                        result.Add(triplet.ToArray());
                        pool[a]--;
                        pool[b]--;
                        pool[c]--;
                    }
                }
            }
            //if (target == 0 && pool.TryGetValue(0, out int zeroCount) && zeroCount >= 3)
            //{
            //    triplet = [0, 0, 0];
            //    var tripletSignature = (0, 0, 0);
            //    if (!seen.Contains(tripletSignature))
            //    {
            //        seen.Add(tripletSignature);
            //        result.Add(triplet.ToArray());
            //    }
            //}
            int third = target / 3;
            if ((3 * third == target) && pool.TryGetValue(third, out int count) && count >= 3)
            {
                triplet = [third, third, third];
                var tripletSignature = (third, third, third);
                if (!seen.Contains(tripletSignature))
                {
                    seen.Add(tripletSignature);
                    result.Add(triplet.ToArray());
                }
            }

            return result;
        }

        private static Dictionary<int, int> CreateDictionary(int[] nums)
        {
            Dictionary<int, int> lookup = new();
            for (int i = 0; i < nums.Length; i++)
            {
                lookup[nums[i]] = lookup.GetValueOrDefault(nums[i], 0) + 1;
                //if (lookup.ContainsKey(nums[i])) { lookup[nums[i]]++; }
                //else { lookup[nums[i]] = 1; }
            }
            return lookup;
        }
    }
}
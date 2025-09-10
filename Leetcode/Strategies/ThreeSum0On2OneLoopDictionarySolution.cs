using Leetcode.Interfaces;
using Leetcode.Models;

namespace Leetcode.Strategies
{
    public class ThreeSum0On2OneLoopDictionarySolution : IProblemSolution<ThreeSumInput, List<List<int>>>
    {
        public List<List<int>> Solve(ThreeSumInput input)
        {
            //Submission: https://leetcode.com/problems/3sum/submissions/1765620859

            // Analysis:
            // The array can contain negative, zero, and positive numbers in any order.
            // The goal is to find all unique triplets that sum to a given target (usually 0).
            // No need to return indices—just the actual values. Order doesn't matter.
            // Uniqueness isn't explicitly required, but it's enforced to avoid duplicate sets.

            // Approach:
            // Build a frequency dictionary to track how many times each number appears.
            // Use that to explore different triplet types based on structure and availability.

            // Triplet types considered:
            // - Symmetric: [-x, 0, x] style, where both x and -x exist and 0 is available.
            // - Duplicate-based: [x, x, y] or [y, x, x], where x appears at least twice.
            // - Triplets of thirds: [t/3, t/3, t/3] if target is divisible by 3 and that value appears ≥ 3 times.
            // - General: combinations of three distinct elements that sum to the target.

            // Each category is handled separately, and triplets are tracked using a HashSet to enforce uniqueness.
            // The dictionary allows constant-time lookups and helps avoid overusing elements.

            bool strictuniqueness = true;

            var (nums, target) = (input.Numbers, input.Target);
            //trivial case target=0;
            Dictionary<int, int> pool = CreateDictionary(nums);

            List<List<int>> result = new();
            List<List<int>> potentials = new();
            HashSet<(int, int, int)> seen = new();

            List<int> triplet = new();
            int targetCount = 0;
            Dictionary<int, int> copy = new(pool);
            if (pool.TryGetValue(target, out targetCount) && pool.Keys.Any(k => pool.TryGetValue(-k, out int negCount)))
            {
                List<List<int>> symmetrics = GetSymmetricTriplets(pool, target, strictuniqueness, seen);
                result.AddRange(symmetrics);
            }
            if (pool.Keys.Any(k => pool[k] > 1))
            {
                List<List<int>> duplicates = GetDuplicateTriplets(pool, target, strictuniqueness, seen);
                result.AddRange(duplicates);
            }
            if (target == 3 * ((int)(target / 3)) && pool.TryGetValue((int)(target / 3), out int thirdCount) ? thirdCount > 1 : false)
            {
                List<List<int>> thirds = GetTripletsOfThirds(pool, target, strictuniqueness, seen);
                result.AddRange(thirds);
            }
            if (pool.Keys.Count >= 3)
            {
                List<List<int>> uniques = GetUniqueElementTriplets(pool, target, strictuniqueness, seen);
                result.AddRange(uniques);
            }

            return result;
        }

        private List<List<int>> GetTripletsOfThirds(Dictionary<int, int> pool, int target, bool strictuniqueness, HashSet<(int, int, int)> seen)
        {

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

            List<List<int>> result = [];

            List<int> triplet = [];
            int third = target / 3;
            if ((3 * third == target) && pool.TryGetValue(third, out int count) && count >= 3)
            {
                triplet = [third, third, third];
                var tripletSignature = (third, third, third);
                if (!seen.Contains(tripletSignature))
                {
                    seen.Add(tripletSignature);
                    result.Add(triplet);
                }
            }
            return result;
        }

        private List<List<int>> GetUniqueElementTriplets(Dictionary<int, int> pool, int target, bool strictuniqueness, HashSet<(int, int, int)> seen)
        {
            List<List<int>> result = [];

            List<int> triplet = [];
            var keys = pool.Keys.Where(k => pool[k] > 0).Order().ToList();
            for (int i = 0; i < keys.Count - 1; i++)
            {
                for (int j = i + 1; j < keys.Count; j++)
                {
                    int a = keys[i];
                    int b = keys[j];
                    int c = target - a - b;
                    if (pool[a] > 0 && pool[b] > 0 && pool.TryGetValue(c, out int cCount) && cCount > 0 && c != a && c != b)
                    {
                        triplet = [a, b, c];
                        triplet.Sort();
                        var tripletSignature = (triplet[0], triplet[1], triplet[2]);
                        if (seen.Contains(tripletSignature)) continue;

                        seen.Add(tripletSignature);
                        result.Add(triplet);
                    }
                }
            }
            return result;
        }

        private List<List<int>> GetDuplicateTriplets(Dictionary<int, int> pool, int target, bool strictuniqueness, HashSet<(int, int, int)> seen)
        {
            List<List<int>> result = [];

            List<int> triplet = [];
            foreach (int key in pool.Keys)
            {
                if (key == target || pool[key] == 0) continue;
                if (pool[key] > 1 && pool.TryGetValue(target - key * 2, out int doubleKeyCount) && strictuniqueness)
                {
                    if (doubleKeyCount > 0)
                    {
                        triplet = [key, key, target - key * 2];
                        triplet.Sort();
                        var tripletSignature = (triplet[0], triplet[1], triplet[2]);

                        if (seen.Contains(tripletSignature)) continue;
                        seen.Add(tripletSignature);

                        result.Add(triplet);
                    }
                }
            }
            return result;
        }

        private List<List<int>> GetSymmetricTriplets(Dictionary<int, int> pool, int target, bool strictuniqueness, HashSet<(int, int, int)> seen)
        {
            List<List<int>> result = [];
            List<int> triplet = [];

            foreach (int key in pool.Keys)
            {
                if (key == target || pool[key] == 0) continue;
                if (pool.TryGetValue(target, out int targetCount) && targetCount > 0 && strictuniqueness)
                {
                    if (pool.TryGetValue(-key, out int negKeyCount) && pool[key] > 0 && negKeyCount > 0 && pool[target] > 0)
                    {
                        triplet = [-key, target, key];
                        triplet.Sort();
                        var tripletSignature = (triplet[0], triplet[1], triplet[2]);

                        if (seen.Contains(tripletSignature)) continue;
                        seen.Add(tripletSignature);

                        result.Add(triplet);
                    }
                }
            }
            return result;
        }

        private static Dictionary<int, int> CreateDictionary(List<int> nums)
        {
            Dictionary<int, int> lookup = new();
            for (int i = 0; i < nums.Count; i++)
            {
                lookup[nums[i]] = lookup.GetValueOrDefault(nums[i], 0) + 1;
                //if (lookup.ContainsKey(nums[i])) { lookup[nums[i]]++; }
                //else { lookup[nums[i]] = 1; }
            }
            return lookup;
        }
    }
}
public class OnOneLoopDictionarySolution : ITwoSumSolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        //Analysis:
        //nums can have -ve/0/+ve numbers in any order
        //find 2 elements whose sum equals target
        //indices need to be returned - any order is okay

        //Approach: 
        //For each element, find its complement in the rest of the array. Create Dictionary with complements to match with element

        //Solution:
        //Build Dictionary with complements. Do a lookup with complement and return when found
        //Outer loop i runs 1 time to create Dictionary. Dictionary lookup is O(1) on average.
        Dictionary<int, int> lookup = [];
        int complement = 0, complementIx = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            complement = target - nums[i];
            if (lookup.TryGetValue(complement, out complementIx))
            {
                //Exactly 1 solution => return after finding a match
                return [complementIx, i];
            }
            else { lookup[nums[i]] = i; }
        }
        //Exactly 1 solution => Always has solution => ideally never get executed. Only for compilation
        return [0, 0];
    }
}

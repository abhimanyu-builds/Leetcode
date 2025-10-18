namespace Leetcode.Metadata
{
    public enum PivotDepth
    {
        None,       // Fully sorted
        Shallow,    // Rotated near start
        Medium,     // Rotated mid-array
        Deep        // Rotated near end
    }

    public enum DensityLevel
    {
        None,       // 0% targets or duplicates
        Low,        // ~0–10%
        Medium,     // ~25–50%
        High,       // ~66–90%
        VeryHigh    // ~90–100%
    }

    public enum JumpDistribution
    {
        FrontLoaded,
        MidLoaded,
        TailLoaded,
        UniformRandom
    }

    public enum ProblemType
    {
        None,

        //Search / Binary Search
        SearchInsertPosition,
        RotatedArray,

        //Sliding Window
        MaxAvgSubArrayI,
        MaxConsecutive1s,
        LongestSubarrayAfterOneDeletion,
        MaxConsecutive1sIII,

        //Hashing / Frequency Maps
        TwoSum,
        ContainsDuplicateI,
        ContainsDuplicateII,
        LongestHarmoniousSubsequence,

        //Two-Pointer / Sorting
        TwoSumSorted,
        ThreeSum,

        //In-place Mutation
        RemoveElement,
        RemoveDuplicatesFromSortedArray,
        MergeSortedArrays,
        ValidMountainArray,
        FindMountainPeak,
        FindPeakElement,
        HillAndValleyCount,
        JumpGame,
        JumpGameII,
        JumpGameIII,
        JumpGameIV,
        ValidAnagram,
        GroupAnagrams,
    }
}
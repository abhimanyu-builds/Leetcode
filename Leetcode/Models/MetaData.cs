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

    public enum ProblemType
    {
        TwoSum,
        TwoSumSorted,
        ThreeSum,
        RemoveDuplicatesFromSortedArray,
        RemoveElement,
        RotatedArray
    }
}
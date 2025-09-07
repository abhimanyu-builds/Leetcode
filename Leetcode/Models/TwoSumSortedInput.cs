namespace Leetcode.Models
{
    public class TwoSumSortedInput
    {
        public int[] Numbers { get; init; }
        public int Target { get; init; }

        public TwoSumSortedInput(int[] numbers, int target)
        {
            Numbers = numbers;
            Target = target;
        }

        public override string ToString() => $"[{string.Join(", ", Numbers)}], Target: {Target}";
    }
}
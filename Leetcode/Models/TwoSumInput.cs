namespace Leetcode.Models
{
    public class TwoSumInput
    {
        public int[] Numbers { get; init; }
        public int Target { get; init; }

        public TwoSumInput(int[] numbers, int target)
        {
            Numbers = numbers;
            Target = target;
        }

        public override string ToString() => $"[{string.Join(", ", Numbers)}], Target: {Target}";
    }
}
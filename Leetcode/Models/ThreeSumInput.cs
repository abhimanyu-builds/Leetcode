namespace Leetcode.Models
{
    public class ThreeSumInput
    {
        public int[] Numbers { get; init; }
        public int Target { get; init; }

        public ThreeSumInput(int[] numbers, int target)
        {
            Numbers = numbers;
            Target = target;
        }

        public override string ToString() => $"[{string.Join(", ", Numbers)}], Target: {Target}";
    }
}
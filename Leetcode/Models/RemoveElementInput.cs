namespace Leetcode.Models
{
    public class RemoveElementInput
    {
        public int[] Numbers { get; init; }
        public int Target { get; init; }

        public RemoveElementInput(int[] numbers, int target)
        {
            Numbers = numbers;
            Target = target;
        }

        public override string ToString() => $"[{string.Join(", ", Numbers)}], Target: {Target}";
    }
}
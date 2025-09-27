namespace Leetcode.Interfaces
{
    public interface IBenchmarkSummary
    {
        string ProblemName { get; }
        string StrategyName { get; }
        int Passed { get; }
        int Total { get; }
        double AvgTimeMicros { get; }
        double TotalTimeMicros { get; }
    }
}
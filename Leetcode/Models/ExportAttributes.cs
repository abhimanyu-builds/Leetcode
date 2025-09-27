namespace Leetcode.Metadata
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class StrategyExportAttribute : Attribute
    {
        public ProblemType Problem { get; }
        public string Name { get; }
        public bool IsInPlace { get; set; } = false;
        public bool HasDuplicates { get; set; } = false;

        public StrategyExportAttribute(ProblemType problem, string name)
        {
            Problem = problem;
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TestCaseProviderExportAttribute : Attribute
    {
        public ProblemType Problem { get; }

        public TestCaseProviderExportAttribute(ProblemType problem)
        {
            Problem = problem;
        }
    }
}
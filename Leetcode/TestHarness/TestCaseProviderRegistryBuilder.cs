using Leetcode.Interfaces;
using Leetcode.Metadata;
using System.Reflection;

namespace Leetcode.TestHarness
{
    public static class TestCaseProviderRegistryBuilder
    {
        public static Dictionary<ProblemType, object> Build()
        {
            var providerMap = new Dictionary<ProblemType, object>();

            var providerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(t => t.GetCustomAttribute<TestCaseProviderExportAttribute>() != null)
                .Where(t => !t.IsAbstract && ImplementsITestCaseProvider(t));

            foreach (var type in providerTypes)
            {
                var attr = type.GetCustomAttribute<TestCaseProviderExportAttribute>();
                var instance = Activator.CreateInstance(type);
                if (instance != null)
                    providerMap[attr.Problem] = instance;
            }

            return providerMap;
        }

        private static bool ImplementsITestCaseProvider(Type type)
        {
            return type.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ITestCaseProvider<,>));
        }
    }
    public static class TestCaseProviderRegistry
    {
        private static readonly Dictionary<ProblemType, object> _registry = TestCaseProviderRegistryBuilder.Build();

        public static object GetProvider(ProblemType problem)
            => _registry.TryGetValue(problem, out var provider) ? provider : null;
    }
}
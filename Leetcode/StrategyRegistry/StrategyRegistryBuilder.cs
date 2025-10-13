using Leetcode.Interfaces;
using Leetcode.Metadata;
using System.Reflection;

namespace Leetcode.Common
{
    public static class StrategyRegistryBuilder
    {
        public static Dictionary<ProblemType, List<object>> Build()
        {
            var strategyMap = new Dictionary<ProblemType, List<object>>();

            var strategyTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(t => t.GetCustomAttribute<StrategyExportAttribute>() != null)
                .Where(t => !t.IsAbstract && ImplementsIProblemSolution(t));

            foreach (var type in strategyTypes)
            {
                var attr = type.GetCustomAttribute<StrategyExportAttribute>();
                var interfaceType = type.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IProblemSolution<,>));
                var genericArgs = interfaceType.GetGenericArguments();

                var strategyType = typeof(ProblemStrategy<,>).MakeGenericType(genericArgs);
                var implementation = Activator.CreateInstance(type);
                var strategy = Activator.CreateInstance(strategyType, attr.Name, implementation, attr.IsInPlace, attr.HasDuplicates);

                if (!strategyMap.ContainsKey(attr.Problem))
                    strategyMap[attr.Problem] = new List<object>();

                strategyMap[attr.Problem].Add(strategy);
            }

            return strategyMap;
        }

        private static bool ImplementsIProblemSolution(Type type)
        {
            return type.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IProblemSolution<,>));
        }
    }
    public static class StrategyRegistry
    {
        private static readonly Dictionary<ProblemType, List<object>> _registry = StrategyRegistryBuilder.Build();

        public static IEnumerable<object> GetStrategies(ProblemType problem)
            => _registry.TryGetValue(problem, out var list) ? list : Enumerable.Empty<object>();
    }
}
## Documentation Gallery

A visual overview of the architecture, execution flow, and design patterns used in this project.
## Execution Flow

- **Test Case Flow – Sequence Diagram**  
  Illustrates how strategies are executed against test cases, including validation and result logging.  
  ![Test Case Flow](https://raw.githubusercontent.com/abhimanyu-builds/Leetcode/main/Leetcode/Documentation/diagrams/sequence-diagram-test-case-flow.svg)  
  [View PlantUML Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/diagrams/sequence-diagram-test-case-flow.puml)

- **Strategy Registration – Sequence Diagram**  
  Shows how strategies are registered and retrieved based on problem type.  
  ![Strategy Registration](https://raw.githubusercontent.com/abhimanyu-builds/Leetcode/main/Leetcode/Documentation/diagrams/sequence-diagram-strategy-registration.svg)  
  [View PlantUML Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/diagrams/strategy-registration-sequence-diagram.puml)

---

## Architecture & Design

- **Core Class Diagram**  
  Shows relationships between core interfaces, models, and strategy wrappers.  
  ![Core Diagram](https://raw.githubusercontent.com/abhimanyu-builds/Leetcode/main/Leetcode/Documentation/diagrams/class-core.svg)  
  [View Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/diagrams/class-core.puml)

- **Strategy Implementations**  
  Groups all strategy classes by problem domain.  
  ![Strategies](https://raw.githubusercontent.com/abhimanyu-builds/Leetcode/main/Leetcode/Documentation/diagrams/class-strategies.svg)  
  [View Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/diagrams/class-strategies.puml)

- **Test Harness Components**  
  Captures test execution, benchmarking, and result validation.  
  ![Test Harness](https://raw.githubusercontent.com/abhimanyu-builds/Leetcode/main/Leetcode/Documentation/diagrams/class-testharness.svg)  
  [View Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/diagrams/class-testharness.puml)

- **Factory & Registry Wiring**  
  Shows how strategies and test cases are orchestrated.  
  ![Factories](https://raw.githubusercontent.com/abhimanyu-builds/Leetcode/main/Leetcode/Documentation/diagrams/class-factories.svg)  
  [View Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/diagrams/class-factories.puml)

- **Modular Component Diagram**  
  Highlights separation of concerns across orchestration, strategy, test provisioning, and documentation.  
  ![Modular Architecture](https://raw.githubusercontent.com/abhimanyu-builds/Leetcode/main/Leetcode/Documentation/diagrams/modular-component-diagram.svg)  
  [View Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/diagrams/modular-component-diagram.puml)

- **System Architecture Overview**  
  High-level flow of control and component interaction.  
  ![Architecture](https://raw.githubusercontent.com/abhimanyu-builds/Leetcode/main/Leetcode/Documentation/diagrams/component-architecture.svg)  
  [View Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/diagrams/component-architecture.puml)

## Description

A modular and scalable testing framework designed for algorithmic problem solving. It supports:

- Multiple problem types via a unified `ProblemType` enum and extensible strategy registry
- Benchmarking of diverse strategies using `StrategyBenchmark<TInput, TOutput>` for performance profiling
- Detailed failure logging with contextual input, expected vs actual output, and timing via `TestResult`
- Flexible validation through delegate-based comparers resolved by `ComparerResolver` (e.g., strict equality, sum-based, set-based)
- Plug-and-play extensibility for adding new problems, strategies, and test cases with minimal changes

Ideal for experimentation, validation, and empirical comparison of algorithmic approaches.


## Architecture Overview

## 🧠 Architecture Overview

This project implements a modular, extensible strategy framework for solving algorithmic problems such as Two Sum, Two Sum Sorted, Three Sum, Rotated Array Search, Remove Element, Remove Duplicates, Contains Duplicate, Max Avg Subarray, and more. It supports:

- 🧩 Strategy registration and metadata encapsulation
- 🧪 Test harness execution with comparer-based validation
- 📊 Benchmarking with performance and correctness metrics
- 🔍 Problem-specific test case generation

### 🏗️ Layered Component Breakdown

| **Layer**              | **Component**                                          | **Role / Responsibility**                                                                         |
|------------------------|--------------------------------------------------------|---------------------------------------------------------------------------------------------------|
| **Orchestration**      | `Program.cs`                                           | Entry point that orchestrates test loading, strategy execution, comparer resolution, and output   |
| **Test Harness**       | `ProblemTest<TInput, TOutput>`                         | Executes test cases, applies validation logic, logs failures, and measures execution time         |
|                        | `TestCase`                                             | Encapsulates input, expected output, and validation flags (e.g. sum-based, count-based)           |
|                        | `TestResult`                                           | Captures pass/fail status, actual vs expected output, and timing metrics                          |
| **Validation**         | `ComparerResolver`                                     | Maps `ProblemType` to appropriate comparer logic                                                  |
|                        | `ComparerHelper`                                       | Provides reusable comparison utilities (e.g. array equality, triplet set matching)                |
| **Benchmarking**       | `StrategyBenchmark<TInput, TOutput>`                   | Evaluates multiple strategies over test cases, reporting correctness and average execution time   |
|                        | `BenchmarkResult`                                      | Records strategy name, correctness status, and average microseconds per test                      |
| **Test Case Provider** | `ITestCaseProvider<TInput, TOutput>`                   | Interface for generating problem-specific test cases                                              |
|                        | `*TestCaseProvider.cs`                                 | One per problem type (e.g. `TwoSumTestCaseProvider`, `ThreeSumTestCaseProvider`)                 |
| **Strategy Layer**     | `IProblemSolution<TInput, TOutput>`                    | Interface for implementing algorithmic solutions                                                  |
|                        | `*Solution.cs`                                         | One or more per problem type (e.g. `OnOneLoopDictionarySolution`, `TwoPointerSolution`)          |
| **Strategy Registry**  | `IProblemStrategy<TInput, TOutput>`                    | Wraps strategy with metadata (name, implementation)                                               |
|                        | `ProblemStrategyFactory`                               | Returns all registered strategies for a given problem type                                        |
|                        | `*Strategies.cs`                                       | One per problem type (e.g. `TwoSumStrategies`, `ThreeSumStrategies`)                             |

### 📁 Directory Mapping

| **Folder**             | **Purpose**                                                                 |
|------------------------|------------------------------------------------------------------------------|
| `Strategies/`          | Contains all algorithmic implementations grouped by problem type            |
| `TestHarness/`         | Contains test harness, benchmark runner, and test case providers             |
| `StrategyRegistry/`    | Contains strategy wrappers and factory logic                                 |
| `Interfaces/`          | Core interfaces for strategy, test case, and benchmarking                    |
| `Helpers/`             | Utility classes for comparison, formatting, and documentation                |
| `Models/`              | Input/output models and metadata structures                                  |
| `Documentation/`       | Diagrams, markdown playbooks, and PlantUML sources                           |

### 🧪 Supported Problems

- Two Sum / Two Sum Sorted
- Three Sum
- Rotated Array Search (I & II)
- Remove Element / Remove Duplicates
- Contains Duplicate (I & II)
- Max Avg Subarray I
- Max Consecutive 1s
- Longest Harmonious Subsequence
- Search Insert Position

---

For visual diagrams, see:

- `Documentation/diagrams/component-architecture.svg`
- `Documentation/diagrams/class-strategies.svg`
- `Documentation/diagrams/sequence-diagram-test-case-flow.svg`
## 🔗 How It All Connects

- `Program.cs` serves as the central orchestrator. It selects the `ProblemType`, retrieves registered strategies and test cases, resolves the comparer, and coordinates execution and benchmarking.
- `ProblemStrategyFactory` and `TestCaseProviderRegistryBuilder` use the Factory Pattern to supply strategy wrappers and test case providers based on the selected `ProblemType`.
- Each strategy implements the core algorithm using the Strategy Pattern via `IProblemSolution<TInput, TOutput>`. These are wrapped in `ProblemStrategy<TInput, TOutput>` to include metadata like name and complexity.
- Strategy registrars such as `TwoSumStrategies`, `ThreeSumStrategies`, `RotatedArrayStrategies`, `RemoveElementStrategies`, and `RemoveDuplicatesStrategies` organize and expose strategies per domain.
- The test harness (`ProblemTest<TInput, TOutput>`) runs all strategies against all test cases using a Template Method Pattern. It handles execution, validation, logging, and timing in a consistent workflow.
- Validation logic is resolved via `ComparerResolver`, which maps each `ProblemType` to a delegate function. These delegates (e.g., array equality, sum-based validation, triplet set comparison) are implemented in `ComparerHelper`.
- `StrategyBenchmark<TInput, TOutput>` runs performance benchmarks across strategies, measuring average execution time and correctness. Results are formatted via `BenchmarkFormatter`.
- All test case providers (e.g., `TwoSumTestCaseProvider`, `ThreeSumTestCaseProvider`, `RotatedArrayTestCaseProvider`) implement `ITestCaseProvider<TInput, TOutput>` and are registered via `TestCaseProviderRegistryBuilder`.
- Diagrams and documentation are auto-rendered via `.github/workflows/render-diagrams.yml`, ensuring reproducibility and CI/CD integration.

Together, these components form a cohesive and extensible framework for solving algorithmic problems, validating correctness, and benchmarking performance.

---

## 🧩 Design Patterns Summary

This project integrates several key design patterns to ensure modularity, scalability, and maintainability across problem-solving, testing, and benchmarking workflows.

### 1. Strategy Pattern
Encapsulates multiple algorithmic approaches for each problem (e.g., Two Sum, Three Sum, Rotated Array, Remove Element).  
Each strategy implements `IProblemSolution<TInput, TOutput>` and can be dynamically selected or benchmarked at runtime.

**Benefit:** Promotes the open/closed principle—new strategies can be added without modifying existing logic. Enables clean separation of concerns and extensible experimentation.

---

### 2. Factory Pattern
Centralizes the creation of test cases and strategy instances.  
`ProblemStrategyFactory` and `TestCaseProviderRegistryBuilder` abstract instantiation logic and expose problem-specific components based on `ProblemType`.

**Benefit:** Simplifies object creation, improves separation of concerns, and supports plug-and-play extensibility.

---

### 3. Template Method Pattern
`ProblemTest<TInput, TOutput>` defines a reusable testing workflow that accepts a strategy and a comparer.  
The structure of test execution is fixed, while specific logic (e.g., input types, validation rules) is injected via delegates and configuration.

**Benefit:** Ensures consistent testing behavior while allowing flexibility in validation and input modeling.

---

### 4. Adapter Pattern
`ProblemStrategy<TInput, TOutput>` acts as a wrapper that adapts raw solution implementations to the unified `IProblemStrategy` interface.  
It encapsulates metadata (e.g., name, complexity) alongside the execution logic.

**Benefit:** Enables polymorphic handling of diverse strategies and simplifies integration into registries and benchmarks.

---

### 5. Enum-Based Dispatcher
The `ProblemType` enum in `Program.cs` serves as a lightweight command router, directing execution flow to the appropriate strategy and test case provider.

**Benefit:** Improves readability, centralizes control flow, and supports future extensibility with minimal branching logic.

---

### 6. Functional Composition
Validation logic is passed as delegates (e.g., `CompareArrays`, `ValidateBySum`, `EqualityComparer<T>.Default`).  
These are resolved via `ComparerResolver`, and reusable comparison utilities are implemented in `ComparerHelper`.

**Benefit:** Decouples behavior from structure, enhances testability, and promotes clean separation of logic.

---

### 7. Benchmarking Integration
`StrategyBenchmark<TInput, TOutput>` runs multiple strategies against a shared test suite and reports average execution time and correctness.  
Results are formatted via `BenchmarkFormatter` for markdown export and CI/CD visibility.

**Benefit:** Enables empirical evaluation of strategies, supports optimization, and provides actionable insights for algorithm selection.

---
Together, these patterns form a robust and extensible framework for solving algorithmic problems, validating correctness, and benchmarking performance—while maintaining clean architecture as the codebase evolves.

## 🚀 Extending the Framework

To add a new problem type, follow this modular workflow:

1. **Define the Input Model**  
   Create a new class in `Models/` to represent the problem's input structure (e.g., `NewProblemInput.cs`).

2. **Implement a Test Case Provider**  
   Create a new class in `TestHarness/` that implements `ITestCaseProvider<TInput, TOutput>`.  
   This provider should supply static and/or randomized test cases (e.g., `NewProblemTestCaseProvider.cs`).

3. **Add Strategy Implementations**  
   Create one or more strategy classes in `Strategies/NewProblem/` that implement `IProblemSolution<TInput, TOutput>`.  
   Each strategy should encapsulate a distinct algorithmic approach.

4. **Wrap Strategies with Metadata**  
   Wrap each strategy in a `ProblemStrategy<TInput, TOutput>` and register them in a dedicated registrar (e.g., `NewProblemStrategies.cs` in `StrategyRegistry/`).

5. **Extend the Dispatcher Enum**  
   Add a new value to the `ProblemType` enum to represent the new problem.

6. **Update Strategy Factory**  
   Modify `ProblemStrategyFactory.cs` to return strategies for the new `ProblemType`.

7. **Update Test Case Registry**  
   Modify `TestCaseProviderRegistryBuilder.cs` to register the new test case provider.

8. **Add Validation Logic**  
   Add a comparer function to `ComparerResolver.cs` to validate outputs for the new problem.  
   Use or extend utilities in `ComparerHelper.cs` as needed.

9. **Update Program Entry Point**  
   Modify `Program.cs` to dispatch the new problem type via `RunProblem()` and `RunTestSuite()`.


## Diagram Automation

All PlantUML diagrams in [`Leetcode/Documentation/diagrams/`](Leetcode/Documentation/diagrams/) are **automatically rendered to SVG** using GitHub Actions.  
Whenever a `.puml` file is updated or added, the workflow generates the corresponding `.svg` and commits it back to the repository.

- **Workflow:** [.github/workflows/render-diagrams.yml](https://github.com/abhimanyu-builds/Leetcode/blob/main/.github/workflows/render-diagrams.yml)
- **Source:** `.puml` files in [`Leetcode/Documentation/diagrams/`](Leetcode/Documentation/diagrams/)
- **Output:** `.svg` diagrams in the same folder

This ensures all diagrams in the documentation are always up-to-date with the latest source.
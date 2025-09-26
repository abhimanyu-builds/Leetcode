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

This project implements a modular strategy framework for solving algorithmic problems like Two Sum, Two Sum Sorted, Three Sum, Rotated Array Search, Remove Element, and Remove Duplicates. It supports extensible strategy registration, test harness execution, comparer-based validation, and benchmarking.

| **Layer**              | **Component**                                          | **Role / Responsibility**                                                                         |
|------------------------|--------------------------------------------------------|---------------------------------------------------------------------------------------------------|
| **Orchestration**      | `Program.cs`                                           | Central controller that loads test cases, resolves comparers, runs strategies, and prints results |
| **Test Harness**       | `ProblemTest<TInput, TOutput>`                         | Executes test cases, applies comparer logic, logs failures, and measures performance              |
|                        | `TestCase`                                             | Holds input, expected output, and validation flags (e.g. sum-based, count-based)                  |
|                        | `TestResult`                                           | Captures pass/fail status, actual vs expected output, and execution time                          |
| **Validation**         | `ComparerResolver`                                     | Maps `ProblemType` to a comparer function for validating strategy output                          |
|                        | `ComparerHelper`                                       | Provides reusable comparison utilities (e.g. array equality, triplet set matching)                |
| **Benchmarking**       | `StrategyBenchmark<TInput, TOutput>`                   | Runs multiple strategies over test cases and reports average execution time and accuracy          |
|                        | `BenchmarkResult`                                      | Records strategy name, correctness, and average microseconds per test                             |
| **Test Case Provider** | `ITestCaseProvider<TInput, TOutput>`                   | Interface for generating test cases per problem                                                   |
|                        | `TwoSumTestCaseProvider`                               | Supplies static and randomized test cases for Two Sum                                             |
|                        | `TwoSumSortedTestCaseProvider`                         | Supplies static and data-driven test cases for Two Sum Sorted                                     |
|                        | `ThreeSumTestCaseProvider`                             | Supplies static and edge-case test cases for Three Sum                                            |
|                        | `RotatedArrayTestCaseProvider`                         | Supplies test cases for rotated array search problems                                             |
|                        | `RemoveElementTestCaseProvider`                        | Supplies test cases for element removal problems                                                  |
|                        | `RemoveDuplicatesSortedTestCaseProvider`               | Supplies test cases for duplicate removal problems                                                |
| **Strategy Layer**     | `IProblemSolution<TInput, TOutput>`                    | Interface for solving a problem with a specific algorithm                                         |
|                        | `TwoSumOnOneLoopDictionarySolution`                    | Fast O(n) solution using hash map                                                                 |
|                        | `TwoSumOn2TwoLoopSolution`                             | Brute-force O(n²) solution                                                                        |
|                        | `TwoSumSortedTwoPointerSolution`                       | O(n) solution using two-pointer technique                                                         |
|                        | `TwoSumSortedBinarySearchSolution`                     | O(nlogn) solution using binary search                                                             |
|                        | `ThreeSum0On2OneLoopDictionarySolution`                | Dictionary-based frequency analysis                                                               |
|                        | `ThreeSum0On2SortingTwoPointerSolution`                | Sorting + two-pointer approach                                                                    |
|                        | `ThreeSum0On2Hashset2SumComplementSolution`            | Embedded 2Sum with HashSet complement lookup                                                      |
|                        | `RotatedArrayOlognTwoPointerSolution`                  | Binary search in rotated array without duplicates                                                 |
|                        | `RotatedArrayOnBruteForceSolution`                     | Linear scan for rotated array search                                                              |
|                        | `RotatedArrayIIOlognTwoPointerSolution`                | Binary search with duplicate handling                                                             |
|                        | `RotatedArrayIIOnBruteForceSolution`                   | Brute-force search with duplicate tolerance                                                       |
|                        | `RemoveElementFwdPointerOverwriteSolution`             | Overwrite forward pointer approach                                                                |
|                        | `RemoveElementSwapWithEndPointerSolution`              | Swap with end pointer approach                                                                    |
|                        | `RemoveElementTwoPointerPartitioningSolution`          | Partitioning logic with two pointers                                                              |
|                        | `RemoveDuplicatesSortedTwoPointerSolution`             | Classic two-pointer duplicate removal                                                             |
|                        | `RemoveDuplicatesAllowNTimesSortedTwoPointerSolution`  | Allows up to N duplicates using pointer logic                                                     |
| **Strategy Registry**  | `IProblemStrategy<TInput, TOutput>`                    | Wraps a strategy with metadata like name and implementation                                       |
|                        | `ProblemStrategyFactory`                               | Returns all available strategies for a given problem type                                         |
|                        | `TwoSumStrategies`                                     | Holds the list of Two Sum strategies                                                              |
|                        | `TwoSumSortedStrategies`                               | Holds the list of strategies for Two Sum Sorted                                                   |
|                        | `ThreeSumStrategies`                                   | Holds the list of strategies for Three Sum                                                        |
|                        | `RotatedArrayStrategies`                               | Holds the list of strategies for Rotated Array search                                             |
|                        | `RemoveElementStrategies`                              | Holds the list of strategies for Remove Element                                                   |
|                        | `RemoveDuplicatesStrategies`                           | Holds the list of strategies for Remove Duplicates                                                |
## How It All Connects

- `Program.cs` serves as the central dispatcher. It selects the `ProblemType`, retrieves the appropriate strategies and test cases, resolves the comparer, and orchestrates execution and benchmarking.
- `ProblemStrategyFactory` and `ProblemTestCaseFactory` use the Factory Pattern to provide the correct strategy implementations and test cases based on the selected `ProblemType` enum.
- Each strategy implements the core algorithm using the Strategy Pattern via the `IProblemSolution<TInput, TOutput>` interface. These strategies are wrapped in `ProblemStrategy<TInput, TOutput>` to include metadata like name and complexity.
- Strategy registrars like `TwoSumStrategies`, `ThreeSumStrategies`, `RotatedArrayStrategies`, `RemoveElementStrategies`, and `RemoveDuplicatesStrategies` organize and expose strategies per problem domain.
- The test harness (`ProblemTest<TInput, TOutput>`) runs all strategies against all test cases using a Template Method Pattern. It handles execution, validation, and result logging in a consistent workflow.
- Validation and comparison logic are resolved via `ComparerResolver`, which maps each `ProblemType` to a delegate function. These delegates (e.g., equality checks, sum-based validation, triplet set comparison) are implemented in `ComparerHelper`.
- `StrategyBenchmark<TInput, TOutput>` runs performance benchmarks across strategies, measuring average execution time and correctness. This enables empirical comparison of algorithmic efficiency.

Together, these components form a cohesive and extensible framework for solving algorithmic problems, validating correctness, and benchmarking performance.

## Design Patterns Summary

This project integrates several key design patterns to ensure modularity, scalability, and maintainability across problem-solving, testing, and benchmarking workflows.

### 1. Strategy Pattern
Encapsulates multiple algorithmic approaches for each problem (e.g., Two Sum, Two Sum Sorted, Three Sum, Rotated Array, Remove Element, Remove Duplicates).  
Each strategy implements the shared interface `IProblemSolution<TInput, TOutput>` and can be dynamically selected or benchmarked at runtime.

**Benefit:** Promotes the open/closed principle—new strategies can be added without modifying existing logic. Enables clean separation of concerns and extensible experimentation.

---

### 2. Factory Pattern
Centralizes the creation of test cases and strategy instances.  
`ProblemStrategyFactory` and `ProblemTestCaseFactory` abstract away instantiation logic and expose problem-specific components based on the `ProblemType` enum.

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
The `ProblemType` enum in `Program.cs` serves as a lightweight command router, directing execution flow to the appropriate strategy and test case factory.

**Benefit:** Improves readability, centralizes control flow, and supports future extensibility with minimal branching logic.

---

### 6. Functional Composition
Validation and comparison logic are passed as delegates (e.g., `CompareArrays`, `ValidateBySum`, `EqualityComparer<T>.Default`).  
These are resolved via `ComparerResolver`, which maps each `ProblemType` to the appropriate comparer function.  
Reusable comparison utilities are implemented in `ComparerHelper`.

**Benefit:** Decouples behavior from structure, enhances testability, and promotes clean separation of logic.

---

### 7. Benchmarking Integration
`StrategyBenchmark<TInput, TOutput>` runs multiple strategies against a shared test suite and reports average execution time and correctness.  
It supports performance profiling and comparative analysis across algorithmic approaches.

**Benefit:** Enables empirical evaluation of strategies, supports optimization, and provides actionable insights for algorithm selection.

---

Together, these patterns form a robust and extensible framework for solving algorithmic problems, validating correctness, and benchmarking performance—while maintaining clean architecture as the codebase evolves.

## Extending the Framework

To add a new problem:

- Create a new `InputModel` class to represent the problem's input structure.
- Implement a corresponding `TestCaseProvider` that supplies static and/or randomized test cases.
- Implement one or more strategy classes that solve the problem using the `IProblemSolution<TInput, TOutput>` interface.
- Wrap each strategy in a `ProblemStrategy<TInput, TOutput>` and register them in a dedicated strategy registrar (e.g., `NewProblemStrategies`).
- Add a new value to the `ProblemType` enum to represent the new problem.
- Update `ProblemStrategyFactory` to return strategies for the new `ProblemType`.
- Update `ProblemTestCaseFactory` to return test cases for the new `ProblemType`.
- Add a comparer function to `ComparerResolver` to validate outputs for the new problem.
- Update `Program.cs` to dispatch the new problem type through `RunProblem()` and `RunTestSuite()`.

This modular flow ensures that new problems can be added with minimal changes to existing code, while maintaining consistency across testing, validation, and benchmarking.


[PlantUML Sequence Diagram: Test Case Flow](//www.plantuml.com/plantuml/png/VLF1Rjim3BthAtYRWpL3Xs6NO0cwPSiMe8SWANPNP2OHAak6HBLnltwo7GbMdDM03oOVtoCVwGT7t9Al5Fi0Zxmnde3h4Ypg4gtKHpZ8CphcdgMkkUKL2CMT-qvavTuJheNHE_c6S3-0k1ClpMjNp9N3GKP9ZTJK2CRIoGmIPItXotqW4LmXVFxqbN5FHljgZvOnaXIYJ-W8bjmX_3gZy2IDXfKohum53f92rbmJRAmv1iOijYFB2O_DYWiojiboBMjBUYktD5NuHBj5PzGBsb7X7surEdTJB0l-vKgMd4nEyGErE5NSFZCsdyDQIv81zyQxqJQdTjJvdB7BI31TN4y2C_YDT0bAT4LjpLvXzHGydh1hy3GGHAuPF4f7tzQRlY125vbQz2PJYy4hiHX-Hon2Cf6HoRrAZEOY8sok8YvfE7WjMXDRN-ErP9OgOsfO6Gl8nGbSN1c49vi_hJYmBoq6L171TqbkydxTrkisu0gAparOLv4tqMP1X3I3_ibe1hiFbBjs-aBgsjCamRaW-H8G2PWogN8wQivu2YG9MUAOvN_zf9k6MLnYqTFT0Pvh58Hbwcw07ZTXqNdLDu6wPE7j5fT-3wcFQNV3qqc0tkN2fH_X3fBPmpsbWbldcPBRhfr5ryFELo7KZELpWf_IrOetu2xmZt3WKc7PBTI5Jv9Lc8AnXp2ShzG_)

[sequence-diagram-test-case-flow](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/plantuml-sequence-diagram-test-case-flow.png)

[PlantUML Class Diagram](//www.plantuml.com/plantuml/png/hLTVRzis47_NfpZqfGwM35c7lHX5qFn9LWDf4yJ6-Z0C0oDTP2uIgP4dEzxGxpvIf6pQv1hPw1jrVtxtk-FvZlwWYIbgwofx2xTi9Li29WfGA0fKN9Jmn5zGP_gPYuOfLaDUCQtFYHH_R0adkHHJ_W_2QM2YvwoGoywPLHe3JSK5qgf1a8hcCb0K3OUVJq-p2fy8I8BYvPoWu0fpub9aEcSLmay__f8PdfTI8Km4eNfYkI77_T48xvLyhB2UoggrVkzd4z6qT0opkvRCuImJaj2ZowV8Fhl29ovG0yqHZ7218su1Zg16GxZ8K1HW8R9KK5ACi5mD3khjio-ADHeOQCy2bfpcDY8h6B5qp1bgkcGQ3TQ25wXU2nevPFwWWOm6SgFIy2GLC2Zv0WKqZcKG_YtqbC5IRWn8rmtmMW60rutHeo0TPG__PW009_2PrJW6JRRhl6ZIkp5Rbd5yNLz3KZlcEcjO_inAX3UpfOHfMx_fOZdAHcGaT-9EuAsKpHNl-eofLO-TvEnr4SexSx0mIUUOTCGCfb8H5Z519pVdUzbT_W7i7CG5xv93flBv_Ypd2Z6ge1KQsQb9_-0gHaYMBHTbaF6XI1-PdckaT-RpKlQ-UwV-88aH5d2k55k1grzO1Q_lr7ULBCK1p2CSSQ5QmXkfSZmOP3A9w1oE51BQku9OomN2jJCEQ-SqNd6pB3pHkmMgfU8qFFS8RBfapHTEyslHWnwEjQdWFLF4hI4NvQ5bk6gRYkUCKCULsEWE_zadmCwhIYu_ptXz4AuVidPzm4Uc16gzFVMj9fxu_LJ_KzijgiPmqugyb-MoRfZQalu03wsmK7f4VbFfCTnoY-s_puuCbUsj5b38hbymRsbhdxb5AfjkA5MmO1KlcFq8bfhBfO-nvjtbCmQNbvTTlpIO4nRZFaql_ytXuiNAp9enF4fPHPfBsGhokgzXr0VKRKMRkFhUQ9pX0LJESsfPjIkrT_-9vqeQu4AsfcGR3ltsl42HpskcdjDtwMzef9qvHtqC_gBiiR_HO-24oktV8tz_QsINwjacTgW9Yz1pIZm9pXUbomHpAOfDFdtrBgLIc0ULDiz5pmrkPSbp7xeNFg1hq7MIloBrkb7ZsslLu97hrVUsA65rZhj0FgSG-2DMJG3RJL9z_NVBgj6HbyqKRogaATAEOgkXZBHBuuRb91L7dNvqEVKgpCFl__MDZKmIaslHrgYOSOqCk-4mnDnlsG6cuHuPOXuEti7smTnCk_X-3ylM_-3_jspUm2D5h-TaxGRx-08EjG-hEDWdBEL0fwYUh_XjFxyViEJQVAY-GzENdwNsTLgRkjZrCkh6jQUI3BbBDrnoKIufLeS2n9jyFoIJuITPOAKpzcWBcXDizMutdz_Fpg9brOzxfaeqt_BnBymfM3UsLPttvbzNMp-YqcFWWdx_OmV0oFfH9QVT51uTzVDu5zOb-lt1_K_bkmE7dUB0yOLG53jLxWAS3GxiyADE6i3UpFmMrnXluOhhXb4-3_zabuhLwqdrYN7XDyQ9NSsUzeXMZS6v3rQNj_4Fh6dB2TrIGT7MeQN7TXVgZi7TMe6_3wyDQ-W4OT9M4lqURfHqSCxBvVg0bNiop7cZipxHavEpa5maZvTVP18C-bTCGddqECYoTBmKbM-PfWVYDpt2WkxZaXwTSKrwjtWCfOtZH8RwHUdiuJXmh6ubwBBQALHaq4Ea5Fvj7gcYzjWLUAlm8HYraBM9_sjbqNCydKRQRESzdNr0KRHrzHy0) visualized ([PNG](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/class-diagram.png))

[PlantUML Modular Component Diagram](//www.plantuml.com/plantuml/png/bLRBRjim4BphAuXSSagHfkYro2Cn4Y2jZJX03uKFBBMH25Eai5pP4Oe0_OV-OR-af6p5oY8KgXkbcTbPBgc1pZr9fAOosR6ubwrhI4YR2mIR0sfRY2Vz33xpQsrhYR8IobMris1fIQs1G5GaRM5WG37Q0hKr28TKkW6GrrfyEZtD33oH82TG5oM9NCSYsjdCAsb0VFpmESj8KrX-TNbZ98ghtbHSQrd4Kdz__n5BGabGj68Mti3MuJhBZWCNexCgmKSyrgsbMii2n5743kmZyIiJuiS2NIovsgz_6gZwoZEfo64xX1x1qvNqa82wvrv-2LQLbSJrAXiQYPEJBqch994PZnFVGTzfwYNCwp3579wqrN5W_Z2n7esN0x2RMAhrlS_ZrYsR7jFWL_-hS4YGJzAL233Hwy6H33ONYBATf8FARU0cu61fkl2wgOrM0VP3RH2_3fgFRJTgqKzdRkSMxfshhtNthKXibyuqSRbwopiBYqWSmY_SYi-R6_PmM2-SjWJ8tGQaIzsr0n9LcNRbfpLmxA7JqFteDXatscjRf9iSS6-bBptGMNYCQR8_o6Itx9xmZeVmtBZ29dfWJ7k93S7CeO8HsjtTU4d6JHHb--7tbszeYC-s-TvvlW7SeYRUxjjoMrb_rrJUs5usnZviQo6HTAHfMuntpZyWtZodZDzTJhymncs_FUfgNFcooyiOhq993w96jz5-r_yXCJiy1ZMFJ1xYF01xR17Bve2hSHqBpWbg5fyJbIn49wfvb4wL9m-RrzaTriqpgEu0kx-QZJGwPxy41qRYkFQsTopbL-_JOhP817m0xyncln_-ad5lmTI0YJ-7j7kI_FeS_1f3tIZEmUPDPVu1)

[PlantUML Strategy Registration Sequence Diagram](//www.plantuml.com/plantuml/dpng/fLNlRjem4F_kfxYF8D4zm3IgLbtPAcrI1Ns1mpc8DSVEx3CqU_ev2KuJWwgAHW8Ht_t-tDa-xZoZur1fWO6j2TMMdF1_bAdHOGM-nC8UbTd33hMdKKGhGzpK1DPnQSSG-Xl8IFfDtkEUxhNQ6v1acDo5hEUehgIgqJ04Kv1hUOLWnPfWmmwPzWsiQQzy-wAi0JG5FBwI3DtRIjkZ4FM8vjdPVPIOh2Mc5KgshhaOwqMou8EjuYkvDNch3-GcmHVo_1ET8Uzp1rjDLIAUgbdT6HTYkOHDr_mQdalq1CkbC9O9RDH9LIpEh9y2e8nYXLhz8mzS4lZKBDzufWgsJKmvsDZnVHVVzVWlWam1hOuOg6vkSnNu2ay3_smkHiQopCLv_nA7wnR8UK2j0G-eD6xru5IHXvrrG2XBgFkMGNkanXOpjR7Lf1UzhazAivUZtOIXyVChuTOn5TUJb8xeCoxMbcEik7SEc-j9gB87UjHKaU5FidmFjLOIcVmRaJY3tLmwHjEhAwtPALVXsmKWJR8BNNC5N3j4FFlyH27ucgJQAPcVguyT_H_4cu5nThhDBv7Xe_rR4SioTpNY-MZpViNWjwTidDnc9dfmAgZjE0TdHkgJQlE1rfURLgV5vhcPa3o5OHUCJ5kQHlFxMpePdObHEa8c3mWSer3sOJWg7dhPTDC_2OytL5jRmogDavGk83wZwaUoiO27Jd2MaXS3yVnzt3gOTi7FMfyFwCdFHOUOcEYha34ie7ycD94rszX-A-2fgljRsr-JXCsJ8pxzbqHW_7cWcJ9ruFa0GSdgW4n3uX0Pa3SNRTZ0aMZ8BYXZUizMrgrq7XFdfLvSFfTfQTOZ5q2lDKccOYZm77IkxiW7tPT2fX3jHzp5xr3f_m00)

[project-visualization-diagram.drawio](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/project-visualization-diagram.png)
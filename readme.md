



## Documentation Gallery

A visual overview of the architecture, execution flow, and design patterns used in this project.

### Execution Flow

- **Test Case Flow – Sequence Diagram**  
  Illustrates how strategies are executed against test cases, including validation and result logging.  
  ![Test Case Flow](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/plantuml-sequence-diagram-test-case-flow.png)  
  [View PlantUML Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/plantuml-sequence-diagram-test-case-flow.puml)

---

### Architecture & Design

- **Class Diagram – System Structure**  
  Shows relationships between core interfaces, strategy implementations, and factories.  
  ![Class Diagram](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/class-diagram.png)  
  [View PlantUML Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/class-diagram.puml)

- **Modular Component Diagram**  
  Highlights separation of concerns across orchestration, strategy, test case provisioning, and execution.  
  ![Modular Component Diagram](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/plantuml-modular-component-diagram.png)  
  [View PlantUML Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/plantuml-modular-component-diagram.puml)

- **Strategy Registration – Sequence Diagram**  
  Shows how strategies are registered and retrieved based on problem type.  
  ![Strategy Registration](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/plantuml-strategy-registration-sequence-diagram.png)  
  [View PlantUML Source](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/plantuml-strategy-registration-sequence-diagram.puml)



Description: 
Mini scalable testing framework that:
- Supports multiple problems
- Benchmarks different strategies
- Logs failures with context
- Validates flexibly (strict or relaxed)


## Architecture Overview

This project implements a modular strategy framework for solving algorithmic problems like Two Sum, Two Sum Sorted, and Three Sum. It supports extensible strategy registration, test harness execution, and benchmarking.

| **Layer**              | **Component**                          | **Role / Responsibility**                                                                  |
|------------------------|----------------------------------------|--------------------------------------------------------------------------------------------|
| **Orchestration**      | `Program.cs`                           | Central controller that loads test cases, runs strategies, benchmarks, and prints results  |
| **Test Harness**       | `ProblemTest<TInput, TOutput>`         | Executes test cases, validates results, logs failures, and measures performance            |
|                        | `TestCase`                             | Holds input, expected output, and validation flags (e.g. sum-based, count-based)           |
|                        | `TestResult`                           | Captures pass/fail status, actual vs expected output, and execution time                   |
| **Benchmarking**       | `StrategyBenchmark<TInput, TOutput>`   | Runs multiple strategies over test cases and reports average execution time and accuracy   |
|                        | `BenchmarkResult`                      | Records strategy name, correctness, and average microseconds per test                      |
| **Test Case Provider** | `ITestCaseProvider<TInput, TOutput>`   | Interface for generating test cases per problem                                            |
|                        | `TwoSumTestCaseProvider`               | Supplies static and randomized test cases for Two Sum                                      |
|                        | `TwoSumSortedTestCaseProvider`         | Supplies static and data-driven test cases for Two Sum Sorted                              |
|                        | `ThreeSumTestCaseProvider`             | Supplies static and edge-case test cases for Three Sum                                     |
| **Strategy Layer**     | `IProblemSolution<TInput, TOutput>`    | Interface for solving a problem with a specific algorithm                                  |
|                        | `TwoSumOnOneLoopDictionarySolution`    | Fast O(n) solution using hash map                                                          |
|                        | `TwoSumOn2TwoLoopSolution`             | Brute-force O(n²) solution                                                                 |
|                        | `TwoSumSortedTwoPointerSolution`       | O(n) solution using two-pointer technique                                                  |
|                        | `TwoSumSortedBinarySearchSolution`     | O(nlogn) solution using binary search                                                      |
|                        | `ThreeSum0On2OneLoopDictionarySolution`| Dictionary-based frequency analysis                                                        |
|                        | `ThreeSum0On2SortingTwoPointerSolution`| Sorting + two-pointer approach                                                             |
|                        | `ThreeSum0On2Hashset2SumComplementSolution` | Embedded 2Sum with HashSet complement lookup                                          |
| **Strategy Registry**  | `IProblemStrategy<TInput, TOutput>`    | Wraps a strategy with metadata like name and implementation                                |
|                        | `ProblemStrategyFactory`               | Returns all available strategies for a given problem type                                  |
|                        | `TwoSumStrategies`                     | Holds the list of Two Sum strategies                                                       |
|                        | `TwoSumSortedStrategies`               | Holds the list of strategies for Two Sum Sorted                                            |
|                        | `ThreeSumStrategies`                   | Holds the list of strategies for Three Sum                                                 |


## How It All Connects

- `Program.cs` serves as the central dispatcher. It selects the problem type, retrieves the appropriate strategies and test cases, and orchestrates execution and benchmarking.
- `ProblemStrategyFactory` and `ProblemTestCaseFactory` use the Factory Pattern to provide the correct strategy implementations and test cases based on the selected `ProblemType` enum.
- Each strategy implements the core algorithm using the Strategy Pattern via the `IProblemSolution<TInput, TOutput>` interface. These strategies are wrapped in `ProblemStrategy<TInput, TOutput>` to include metadata like name and complexity.
- The test harness (`ProblemTest<TInput, TOutput>`) runs all strategies against all test cases using a Template Method Pattern. It handles execution, validation, and result logging in a consistent workflow.
- Validation and comparison logic are passed as delegates (e.g., equality checks, sum-based validation), allowing flexible behavior across different problem types and output formats.
- `StrategyBenchmark<TInput, TOutput>` runs performance benchmarks across strategies, measuring average execution time and correctness. This enables empirical comparison of algorithmic efficiency.

Together, these components form a cohesive and extensible framework for solving algorithmic problems, validating correctness, and benchmarking performance.


## Design Patterns Summary

This project integrates several key design patterns to ensure modularity, scalability, and maintainability across problem-solving, testing, and benchmarking workflows.

### 1. Strategy Pattern
Encapsulates multiple algorithmic approaches for each problem (e.g., Two Sum, Two Sum Sorted, Three Sum).  
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
This allows test behavior to be customized without altering the test harness structure.

**Benefit:** Decouples behavior from structure, enhances testability, and promotes clean separation of logic.

---

### 7. Benchmarking Integration
`StrategyBenchmark<TInput, TOutput>` runs multiple strategies against a shared test suite and reports average execution time and correctness.  
It supports performance profiling and comparative analysis across algorithmic approaches.

**Benefit:** Enables empirical evaluation of strategies, supports optimization, and provides actionable insights for algorithm selection.

---

Together, these patterns form a robust and extensible framework for solving algorithmic problems, validating correctness, and benchmarking performance—while maintaining clean architecture as the codebase evolves.

Extending the Framework
To add a new problem:
- Create a new InputModel and TestCaseProvider
- Implement one or more strategies
- Register them in the appropriate factories
- Add a new ProblemType enum value
- Update Program.cs to dispatch it




[PlantUML Sequence Diagram: Test Case Flow](VLHDRzim3BthL_3ee0cmSx44tRgc2z13qHIxAp8R2vKbGwBQkh--b1r_9fs174m-FZu-Chu993t5qeZmgcqblIn16Hd2BoAl3v5mfvpTwq-47oD8A6JkthKzmeiq0KSPeorINI4uJuKJCfApiJoW5u8q6OHd30ItCY3SVQ2Af9s5hN7lGZ01QQKhQGaUlJiotIIs9oy9Z_LMAdA-dkGIQoBzBlTNUeiXNEIR1Fz9etF979FeRxIgAAL_5MAzXftLf1dtAHlrZqMQPhqMugGQLfkvMBY6UwHJK6F85cAEM75LHt0D3phGpns_7moM7NGpQJ6RkMtH1LE7EU12XmwoQGORDZBCP9ohOEiye5G5XCupu6UcvUGnKzzwP5JMWPUWNCbseb_yl-ufsXG86NLJB4HJCHMHig0utUJICwOPcS-KUsVUCEFhZBJeuUo7VcF4S09TfgzSdObpaPYaH-PuplATdlweaZUj5LbBjmJyg50HveEw0NqkmcE8fXM1DXVfbnRNtsVwI_Qx6_dS0rgNkzNm9IwXDtkyfw7WmjNqoQT6Jdiy-rXogBxGVaBmHuVAo1h22Nx5dn1jC6yM6lYLTCbJ2773m_67wGi0)

[sequence-diagram-test-case-flow](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/plantuml-sequence-diagram-test-case-flow.png)

[PlantUML Class Diagram](hLVTRzCm47_tNt5lwyGceJrMQDedh19Zqrh10qB8IwwDHM97jjEj8FvtpecT9gspTa2V7D_vTx_xj7jcBDUsAd9cVWXPSiqBI79kpBcrMZnM5YU9abFn4-5jHyLaF5LFGYvWpdE37Kak9DfLYQ2qpHHZ1t2fDC94MjHpdg1X8YnXSg_LOux5LEML5Kg-cqraMTaZcDrLbXQdJ2gBeCKYiw3cM_hi2kTape3D46XpYIFX00wXG3AUCfGfE0WMCserjxXOxMtKwxClcfS6E1ZF0fw4pPn5ddBBupPdQEmbDqXOIv6Ytcbqym3p2_AL992GoC1SQUAn44kKK3OiE-OF8506Hxaaa3gpi2i088gIv2YjsV8UVZ6Wtp5yuWMEmL2Ho8NVceHZt8Lbl9sktprIVNNZoSsUrBGgxkITn8zAbLSYSLAkLm4boYvOw6ESqCA1lFheb8eNKrhVgpg9Vmbm8MhYo7MIlGOYquW4yfOy-ASmT70S8ShKtxdKmRdX9ZDeJ-ZpKeMJUs5HwbrHmmtNrBAcNujEibs7eTQ-6zVRUWplAvc4lOJCSztRVGCFbNHGPcHz_vWnV1GEst-V7b8LzdkjGu5TFsD2Cw_NPNLxgxAEVmvBdekqhjXEg_auUHijxzgVCJH--Rthvn8JgernSDFlVsvmyM95eHt3erBvbkHILT9wsU-krGSqLMxNTiqzINeWhw5odjYAvvkxCr7WhKYq8k1KLHIoDOVGqnSeawpW-iTGBkiCZKoZBj0SGPke8mWPFG911TfCXKEVlnQvSVLqRNj3qWOXS8eCglFbel44wMvBr_w4wD6DfIaowqWVm7kUMAM9SNo6Dk9Lw-K7j7uGjAwEo9N9jQmASYqOwohM4sCVTT-DmwfjQ3gLxK8yI38eD4XRLq-KwTvdFDqT-dMGRrMAUVyYgCjeVUbKnIDgIXYDiA_VGc5olK1RxtcpCpMjq-rC-SIlswNZm_y7zyx-H-03k1Acv3R9klVtmZsrGXvlkP2ZGuzB_UNJFdBFi75R1FJHqN49c5RKPoCt46cKLKLNqsCtmUeicxWr6zxNXkG3vat3Pg8qB30yFZxjeiRsDpeeUhHVlqCgZ0qqPSGQ6sWDfnfzUmNbHkC5j5eX84G5pPpQ9Di7RY_DhSaQ9n1NsnYDZEr-N4LP3BwdNj0UV4BjF1DzDSLFxVLGsdbq-6sqy-ZBpw5uIi_etK1_kFu0) visualized ([PNG](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/class-diagram.png))

[PlantUML Modular Component Diagram](dLJBQiCm4BmR_0yYbvu29HzGGjA65W89TUYbvA3AMrlObema9pKb_rx9hoho8xGtIJEhsLdjQYaL5gh8Kj-J2MKv5ZX3X6SvPy1KeCeKa02YC8jIi3afPQ3A710NAkQ-vtjtQCs5sPCOf19OKSvyBySamH6WMGLkT2YSkKXcwDlt47hV2nxfisEx-KWX2qmmHEK64yL5UOKTzDLhB64Cgm_Q6rR0I9nXaHnDWfOSciyVRkhrcMFgmymXU2YpIrsz5a8XV596JVcaLRyEtk8IX5M_8GkrsE7CWwB5ACZ9Ab-5w4U5y6-1iG1mrKnOPy3Dfh60Mj4Tsp7OSfu_KcBCOr46F2tCykWG5tfXc5VuPLZFiUAgrhXUxpbb2iImPCrQqIefmBh5fwLxnR1a6-nUsxXjs2AR72YB9bAroCzOnXBKGc_NUfhrivbnTd9k6i_qAYAwhL4k-8bApT0wLkjL1DFtWxtd3eNTI2ssDnU782PdkT-1_mblYZ0GsjXz-W9IbG5X5g8JJcde_bM_b373ZTgBCnFz_wZclNKgMnvHClPBJLqwnkxsho2BLBK-by12_Qt_0000)

[PlantUML Strategy Registration Sequence Diagram](dLJ1ReCm3BtdAtoaX_x0DAfUrgdI3jNQ7qZ1XMWXGOdJZdtz30sKKWvLEQ38zdj-VfYiFKb7eT921h8cL4TqmlyeKqidA_2bpEr5cG9EKdiSPRGoI4sDO1sLLWYEaifKBGt1pjc2Q-vYUtAIi6WsCYFhcjdSDnRAqoJ9P4UDLLzp3xGwaB96Y3HbbdQI6dQbz0XfAaJK0SlLj3symTOeKbAhFqmMOfeU8NfH3BaUqIM7Yzs7GTAhS7OEyzT9IeSugsAeNiuE7jEoDGuoQqxALVBc8chCkjIJFduYnQ12dyIlTU3DU7QY3L9MWXyuu6GTZ7YUdUkBa-_RoRgi7aKmk1-eDOE2CwFkdGaVlvY5YGdQsXesB0tbJMuZW9-HFvFsLtzWMzKSH4DNdoFchh0TAMupW_XuneJ_jK2Bhfp5gpDNtbQ-ZGw8vMnh6uW9kieSvnaUPCov4tdGv4Ai-StNnJy0)

[project-visualization-diagram.drawio](https://github.com/abhimanyu-builds/Leetcode/blob/main/Leetcode/Documentation/project-visualization-diagram.png)
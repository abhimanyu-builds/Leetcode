# 🧠 Strategy Playbook

A consolidated reference of all strategy tradeoffs across problems.

## 📋 Table of Contents

### Search / Binary Search
- [Search-insert-position](#search-insert-position)
- [Search-rotated-sorted-array](#search-rotated-sorted-array)

### Sliding Window
- [Max-consecutive-1s](#max-consecutive-1s)
- [Longest-subarray-after-one-deletion](#longest-subarray-after-one-deletion)
- [Max-consecutive-1s-III](#max-consecutive-1s-iii)
- [Max-average-subarray-I](#max-average-subarray-I)

### Hashing / Frequency Maps
- [Two-sum](#two-sum)
- [Contains-duplicate-I](#contains-duplicate-i)
- [Contains-duplicate-II](#contains-duplicate-ii)
- [Longest-harmonious-subsequence](#longest-harmonious-subsequence)

### Two-Pointer / Sorting
- [Two-sum-sorted](#two-sum-sorted)
- [Three-sum](#three-sum)

### In-place Mutation
- [Remove-duplicates](#remove-duplicates)
- [Remove-element](#remove-element)

### Strategy Tradeoffs
- [Merge-sorted-arrays](#merge-sorted-arrays)

### Directional Traversal / State Machines
- [Valid-mountain-array](#valid-mountain-array)
- [Find-mountain-peak](#valid-mountain-array)
- [Find-peak-element](#find-peak-element)
- [Hill-and-valley-count](#hill-and-valley-count)
- [Jump-game](#jump-game)
- [Jump-game-II](#jump-game-ii)
- [Jump-game-III](#jump-game-iii)

- 
---
- ## Jump-Game-III
<a name="jump-game-iii"></a>

📘 [Problem Description](./Problems/JumpGameIII-Description.md)

Approaches
----------
| Rank | Approach                          | Time Complexity | Space Complexity | Notes                                                                 |
|------|-----------------------------------|-----------------|------------------|-----------------------------------------------------------------------|
| 1    | Breadth-First Search (BFS)        | O(n)            | O(n)             | Safest for large inputs; avoids stack overflow; ideal for deep paths |
| 2    | Depth-First Search (DFS)          | O(n)            | O(n)             | Fastest for small inputs; must guard against cycles and deep stacks  |
| 3    | Hybrid (DFS + BFS fallback)       | O(n)            | O(n)             | Combines DFS speed with BFS safety; adds branching logic overhead    |

Limitations
-----------
- DFS may overflow on long linear paths (e.g., `[1]*49999 + [0]`)
- BFS incurs queue overhead and may be slower on shallow graphs
- Hybrid adds complexity and may be slower on small inputs

Use Cases
---------
- Use **DFS** for small arrays or shallow graphs
- Use **BFS** for large arrays, cyclic traps, or deep traversal
- Use **Hybrid** in production-grade systems requiring resilience across input types

---
## Jump-Game-II  
<a name="jump-game-ii"></a>  

📘 [Problem Description](./Problems/Jump-Game-II-Description.md)  

Approaches  
----------  
| Rank | Approach             | Time Complexity | Space Complexity |  
|------|----------------------|-----------------|------------------|  
| 1    | Greedy (Jump Window) | O(n)            | O(1)             |  
| 2    | Bottom-Up DP         | O(n²)           | O(n)             |  
| 3    | Memoized DFS         | O(n²)           | O(n)             |  
| 4    | BFS Traversal        | O(n²)           | O(n)             |   
---

## Jump Game  
<a name="jump-game"></a>

📘 [Problem Description](./Problems/JumpGame-Description.md)

Approaches  
----------  
| Rank | Approach               | Time Complexity | Space Complexity |
|------|------------------------|-----------------|------------------|
| 1    | Greedy (Max Reach)     | O(n)            | O(1)             |
| 2    | Bottom-up DP           | O(n²) worst     | O(n)             |
| 3    | Memoized DFS           | O(n²) worst     | O(n)             |

---

## Search Insert Position
<a name="search-insert-position"></a>

| Strategy              | Match Behavior					| Insert Behavior								| Time Complexity	| Space	| Idiomatic Use Case						| Notes                                                             |
|-----------------------|-----------------------------------|-----------------------------------------------|-------------------|-------|-------------------------------------------|-------------------------------------------------------------------|
| Hybrid Binary Search  | Returns exact match if found		| Returns insert index if not found				| O(log n)			| O(1)  | Explicit match vs insert logic            | Slightly more verbose, but useful for logging/debugging           |
| Lower Bound           | Returns first index ≥ target		| Returns correct insert index					| O(log n)			| O(1)  | STL-style semantics (`std::lower_bound`)  | Clean, branchless, ideal for sorted arrays                        |
| Stateful Traversal    | Tracks insert index during scan	| Returns insert index when target not found	| O(n)				| O(1)  | Small arrays or streaming-style traversal | Useful when binary search is overkill or array is nearly sorted   |

---

## Search-rotated-sorted-array
<a name="search-rotated-sorted-array"></a>

📘 [Problem Description](./Problems/Search-rotated-sorted-array-Description.md)

Approaches
----------

| Rank	| Approach							| Time Complexity	| Space Complexity	| Pros                                              | Cons                                                  |
|-------|-----------------------------------|-------------------|-------------------|---------------------------------------------------|-------------------------------------------------------|
| 1		| Two Pointer Binary Search			| O(logn)			| O(1)              | Fast and efficient. Ideal for large inputs.		| Requires careful handling of rotation logic.			|
|		|									|					|					| Leverages sorted structure.						| Harder to implement correctly.						|
| 2		| Brute Force						| O(n)				| O(1)              | Simple to write and debug.						| Inefficient for large arrays.							|
|		|									|					|					| Works regardless of rotation or duplicates.		| Doesn't leverage sorted structure.					|

---

## Max-consecutive-1s
<a name="max-consecutive-1s"></a>

📘 [Problem Description](./Problems/Max-consecutive-1s-Description.md)

Approaches
----------

| Rank | Approach                  | Time Complexity | Space Complexity | Pros                                           | Cons                                                  |
|------|---------------------------|------------------|-------------------|------------------------------------------------|--------------------------------------------------------|
| 1    | Streaming Scan            | O(n)             | O(1)              | Clean, idiomatic, and branch-efficient.        | May do redundant comparisons on long zero blocks.      |
|      |                           |                  |                   | Handles all edge cases naturally.              | Slightly less optimized for skipping zero segments.    |
| 2    | Manual Index Traversal    | O(n)             | O(1)              | Can skip zero blocks aggressively.             | Requires careful index control and loop management.    |
|      |                           |                  |                   | Works well for clustered 1s.                   | More error-prone and harder to read.                   |

---

## MaxConsecutive1sIII  
<a name="max-consecutive-1s-iii"></a>  

📘 [Problem Description](./Problems/Max-consecutive-1s-III-Description.md)  

Approaches  
----------  

| Rank | Approach                    | Time Complexity	| Space Complexity	| Pros                                                       | Cons                                                       |
|------|-----------------------------|------------------|-------------------|------------------------------------------------------------|------------------------------------------------------------|
| 1    | Stateful Traversal Scan     | O(n)             | O(1)              | Fastest, minimal memory, ideal for production              | Less explicit about flip positions, harder to visualize    |
| 2    | Zero Index Queue            | O(n)             | O(k)              | Precise rollback, great for onboarding and debugging       | Slower due to queue overhead and memory allocation         |

---

## LongestSubarrayAfterOneDeletion  
<a name="longest-subarray-after-one-deletion"></a>  

📘 [Problem Description](./Problems/Longest-subarray-after-one-deletion-Description.md)  

Approaches  
----------  

| Rank | Approach								| Time Complexity | Space Complexity | Pros                                                                 | Cons                                                                 |
|------|----------------------------------------|-----------------|------------------|----------------------------------------------------------------------|----------------------------------------------------------------------|
| 1    | Adjacent Block Merge					| O(n)            | O(1)             | Fastest in benchmarks, minimal branching, high cache locality        | Slightly less intuitive, requires careful bridge logic               |
|      |										|                 |                  |                                                                      | Optimized for sequential access                                      |
| 2    | Sliding Window with Stateful Traversal | O(n)			  | O(1)             | Conceptually clean, generalizable to k-deletion variants             | Slightly slower due to backtracking and nested loop overhead         |
| 3    | Prefix/Suffix Scan						| O(n)            | O(n)             | Modular, easy to visualize and extend for multiple deletions         | Requires extra space, less performant for single-deletion case       |


---

## Max-average-subarray-I
<a name="max-average-subarray-I"></a>

📘 [Problem Description](./Problems/Max-average-subarray-I-Description.md)

Approaches
----------

| Rank | Approach        | Time Complexity | Space Complexity | Pros                                           | Cons                                                  |
|------|------------------|------------------|-------------------|------------------------------------------------|--------------------------------------------------------|
| 1    | Sliding Window   | O(n)             | O(1)              | Efficient for large arrays.                    | Requires careful window management.                    |
|      |                  |                  |                   | Avoids recomputation by reusing previous sum.  | Slightly harder to implement than brute force.         |
| 2    | Brute Force      | O(n × k)         | O(1)              | Simple and intuitive.                          | Very slow for large `n` or large `k`.                  |
|      |                  |                  |                   | Easy to debug and verify.                      | Recomputes sum for every window.                       |

---
## Two-sum
<a name="two-sum"></a>

📘 [Problem Description](./Problems/Two-sum-Description.md)

Approaches
----------
| Rank   | Approach                      | Time Complexity  | Space Complexity  | Pros                                             | Cons                                    |
|--------|-------------------------------|------------------|-------------------|--------------------------------------------------|-----------------------------------------|
| 1      | Hash Map (Dictionary)         | O(n)             | O(n)              | Fast, preserves indices, ideal for unsorted input| Uses extra space                        |
| 2      | Two-Pointer (Sorted Input)    | O(n log n)       | O(1)              | Elegant, efficient for value-based checks        | Requires sorting, loses original indices|
| 3      | Set-Based Lookup              | O(n)             | O(n)              | Simple, great for value-only checks              | Doesn^2t track indices                   |
| 4      | Binary Search After Sorting   | O(n log n)       | O(1)              | Works well with sorted data                      | More complex, index tracking needed     |
| 5      | Brute Force (Nested Loops)    | O(n^2)            | O(1)              | Easy to understand and implement                 | Very slow for large inputs              |

Variants
--------
- Three Sum / K Sum: Extend the logic to find triplets or k-sized combinations.
- Two Sum II: Sorted input, return indices (Leetcode variant).
- Two Sum Less Than K: Find max sum < K.
- Two Sum with Multiplicity: Count pairs considering duplicates.
- Two Sum with Constraints: Find pairs with additional constraints (e.g., indices difference).
- Two Sum with Range Queries: Support multiple queries efficiently.
- Two Sum with Sliding Window: Find pairs in a sliding window of the array.
- Two Sum with Duplicates: Return all unique pairs.
- Two Sum with Modulo: Find pairs whose sum is congruent to a target modulo a number.
- Two Sum with Approximation: Find pairs approximately equal to target.

- Two Sum in a Circular Array: Handle wrap-around cases.
- Two Sum in a Matrix: Find pairs in a 2D matrix.
- Two Sum in a BST: Use in-order traversal and two-pointer technique.
- Two Sum with Set Data Structure: Use sets for O(1) lookups.
- Two Sum in a Linked List: Use hash map or two-pointer technique.
- Two Sum with Heaps: Use heaps for specific scenarios.
- Two Sum with Custom Data Structures: Implement custom structures for specific needs.

- Two Sum with Floating Points: Handle precision issues with floats.
- Two Sum with Sorting and Binary Search: Sort and use binary search for complements.
- Two Sum with Bit Manipulation: Use XOR for specific cases.
- Two Sum with Frequency Count: Use frequency array for limited range of numbers.
- Two Sum with Updates: Handle dynamic updates to the array.
- Two Sum with Prefix Sums: Use prefix sums for specific scenarios.
- Two Sum with Backtracking: Explore combinations recursively.
- Two Sum with Graph Representation: Model the problem as a graph.
- Two Sum with Dynamic Programming: Use DP for specific constraints.
- Two Sum with Parallel Processing: Use concurrency for large datasets.

---

## Contains-duplicate-I
<a name="contains-duplicate-i"></a>

📘 [Problem Description](./Problems/Contains-duplicate-I-Description.md)

Approaches
----------
| Rank | Approach       | Time Complexity	| Space Complexity	|
|------|----------------|-------------------|-------------------|
| 1    | HashSet        | O(n)				| O(n)              |
| 2    | Sort and Scan  | O(n log n)		| O(1)              |
| 3    | Brute Force    | O(n^2)			| O(1)              |

---

### 📊 Strategy Tradeoffs — Contains Duplicate II
<a name="contains-duplicate-ii"></a>

| Strategy                      | Time Complexity | Space Complexity | Description                                                                 |
|------------------------------|------------------|-------------------|------------------------------------------------------------------------------|
| Brute Force (O(nk))          | O(nk)            | O(1)              | Checks every pair within distance `k`. Simple but slow for large inputs.     |
| HashSet Sliding Window       | O(n)             | O(k)              | Maintains a window of size `k` using a HashSet. Fast and memory-efficient.   |
| Dictionary Index Tracking    | O(n)             | O(n)              | Stores last seen index of each value. Flexible and handles large `k` well.   |

---

### 📊 Strategy Tradeoffs — Longest Harmonious Subsequence
<a name="longest-harmonious-subsequence"></a>

| Strategy               | Time Complexity	| Real-World Speed | Memory Usage | Notes						|
|------------------------|------------------|------------------|--------------|-----------------------------|
| Frequency Map          | O(n)             | Slower           | Higher       | Optimal for dense keys		|
| Sort + Scan            | O(n log n)       | Faster           | Lower        | Cache-friendly, tight loop	|



---

## Two-sum-sorted
<a name="two-sum-sorted"></a>

📘 [Problem Description](./Problems/Two-sum-sorted-Description.md)

Approaches
----------
| Rank   | Approach             | Time Complexity  | Space Complexity  |
|--------|----------------------|------------------|-------------------|
| 1      | Two Pointers			| O(n)             | O(1)              |
| 2      | Binary Search per i	| O(n log n)       | O(1)              |

Tradeoffs
---------

|							|				Two Pointers								|				Binary Search per i							|
|---------------------------|-----------------------------------------------------------|-----------------------------------------------------------|
| Instruction Overhead		| Just one comparison per step and moves a single pointer	| Multiple comparisons										|
|							|															| Repeated recalculation of the midpoint					|
|							|															| Constant updates to left and right pointers				|
| Poor Cache Locality		| Walks through the array sequentially						| Jumps around the array, accessing elements non-linearly	|
|							| Aligns perfectly with how CPUs cache memory				| Disrupts caching and causes slowdown						|
| Branch Prediction Penalty	| Predictable: either moves left or right					| Has more branching and less predictability				|
|							| CPUs correctly guess which way the code will branch 		| CPU's wrong guesses lead to performance hits				|
| Nested Loop Cost			| Single linear scan, no nested loops - O(n) overall		| One pass + log n search for each element - O(n log n)		|

---

## Three-sum
<a name="three-sum"></a>

📘 [Problem Description](./Problems/Three-sum-Description.md)

Approaches
----------
| Rank  |		Approach                    | Time Complexity   | Space Complexity  | Pros														| Cons												|
|-------|-----------------------------------|-------------------|-------------------|-----------------------------------------------------------|---------------------------------------------------|
| 1		| Sorting + Two-Pointer				|		O(n^2)		|		O(1)		| Efficient, easy to implement, handles duplicates well		| Requires sorting, only works on sorted arrays		|
|		|	Sorting							|		O(n log n)	|		O(1)		| Array.Sort() uses Introsort, a hybrid of					|													|
|		|									|					|					|		Quicksort for fast average performance				|													|
|		|									|					|					|		Heapsort to avoid Quicksort's worst-case behavior	|													|
|		|									|					|					|		Insertion Sort for small arrays for efficiency		|													|
| 2		| Hash Set for Two-Sum within 3Sum	|		O(n^2)		|		O(n)		| Fast lookups, avoids sorting								| Duplicate handling can be tricky					|
| 3		| Dictionary-Based Lookup			|		O(n^2)		|		O(n)		| Good for tracking complements, flexible					| Can get messy with duplicate keys					|
|		|	Dictionary Overall 				|		O(n+k^2)	|		O(k)		|															|													|
|		|		Dictionary Creation			|		O(n)		|		O(k)		|															|													|
|		|		Triplet Generation Methods	|		O(k^2)		|		O(n^2)		|															|													|
| 4		| Recursive K-Sum					|		O(n^{k-1})	|		O(k)		| Generalizes to any K, elegant structure					| Slower for large K, more complex to code			|
| 5		| Meet-in-the-Middle				|		O(n^{k/2})	|		O(n^{k/2})	| Powerful for large K, parallelizable						| High space usage, not ideal for small K			|
| 6		| Brute Force						|		O(n^2)		|		O(1)		| Simple to understand and implement						| Extremely inefficient for large inputs			|

Input test cases
----------------
Negative Target
Reverse-sorted arrays
Arrays with clustered duplicates
Adversarial Inputs to stress duplicate handling or early pruning

Variants
--------
- Two Sum Less Than K: Find max sum < K.
- Two Sum with Multiplicity: Count pairs considering duplicates.
- Two Sum with Constraints: Find pairs with additional constraints (e.g., indices difference).
- Two Sum with Range Queries: Support multiple queries efficiently.
- Two Sum with Sliding Window: Find pairs in a sliding window of the array.
- Two Sum with Duplicates: Return all unique pairs.
- Two Sum with Modulo: Find pairs whose sum is congruent to a target modulo a number.
- Two Sum with Approximation: Find pairs approximately equal to target.

- Two Sum in a Circular Array: Handle wrap-around cases.
- Two Sum in a Matrix: Find pairs in a 2D matrix.
- Two Sum in a BST: Use in-order traversal and two-pointer technique.
- Two Sum with Set Data Structure: Use sets for O(1) lookups.
- Two Sum in a Linked List: Use hash map or two-pointer technique.
- Two Sum with Heaps: Use heaps for specific scenarios.
- Two Sum with Custom Data Structures: Implement custom structures for specific needs.

- Two Sum with Floating Points: Handle precision issues with floats.
- Two Sum with Sorting and Binary Search: Sort and use binary search for complements.
- Two Sum with Bit Manipulation: Use XOR for specific cases.
- Two Sum with Frequency Count: Use frequency array for limited range of numbers.
- Two Sum with Updates: Handle dynamic updates to the array.
- Two Sum with Prefix Sums: Use prefix sums for specific scenarios.
- Two Sum with Backtracking: Explore combinations recursively.
- Two Sum with Graph Representation: Model the problem as a graph.
- Two Sum with Dynamic Programming: Use DP for specific constraints.
- Two Sum with Parallel Processing: Use concurrency for large datasets.

---


## Remove-duplicates
<a name="remove-duplicates"></a>

📘 [Problem Description](./Problems/Remove-duplicates-Description.md)

Approaches
----------
| Rank   | Approach             | Time Complexity  | Space Complexity  |
|--------|----------------------|------------------|-------------------|
| 1      | Two Pointers			| O(n)             | O(1)              |

---

## Remove-element
<a name="remove-element"></a>

📘 [Problem Description](./Problems/Remove-element-Description.md)

Approaches
----------

| Rank	| Approach							| Time Complexity	| Space Complexity	| Pros                                              | Cons                                                  |
|-------|-----------------------------------|-------------------|-------------------|---------------------------------------------------|-------------------------------------------------------|
| 1		| Forward Overwrite					| O(n)				| O(1)              | Simple, preserves order, easy to implement        | May perform unnecessary writes before first match.	|
|		|									|					|					|													|	Optimized in implementation							|
| 2		| Swap with End Pointer				| O(n)				| O(1)              | Fewer writes when target is frequent              | Does not preserve order, trickier to debug            |
| 3		| Two-Pointer Partitioning			| O(n)				| O(1)              | Efficient in-place partitioning                   | Requires careful handling of edge cases,				|
|		|									|					|					|													|	Does not preserve order								|

---
## Merge Sorted Arrays  
<a name="merge-sorted-arrays"></a>

| Strategy               | Time Complexity | Space | In-place	| Mutation Safety			| Idiomatic Use Case                     | Notes                                                            |
|------------------------|-----------------|-------|------------|---------------------------|----------------------------------------|------------------------------------------------------------------|
| Reverse Merge          | O(m + n)        | O(1)  | ✅			| ✅ (no overwrites)		| Reference-grade, sorted merge          | Merges from back using 3 pointers; optimal and clean             |
| Forward Merge + Queue  | O(n²)           | O(n)  | ❌			| ❌ (cascading shifts)		| Educational or exploratory             | Risks Hilbert’s hotel behavior; inefficient for large arrays		|
| Forward Merge + Buffer | O(m + n)        | O(m)  | ❌			| ✅ (safe staging)			| Readable, but violates constraints     | Copies `nums1[0..m]` to temp; merges into `nums1`                |
| Bubble Merge           | O(m × n)        | O(1)  | ✅			| ❌ (repeated shifting)	| Adversarial or brute-force scenarios   | Works in-place but inefficient; useful for stress testing        |
| Two-Pass Index Mapping | O(m + n)        | O(1)  | ✅			| ✅ (if carefully staged)	| Complex merge logic                    | Requires precomputing insert positions; harder to maintain       |


---
## Valid-Mountain-Array  
<a name="valid-mountain-array"></a>

📘 [Problem Description](./Problems/Valid-Mountain-Array-Description.md)

Benchmarked Strategies  
----------------------  
| Rank | Strategy Name                          | Time Complexity | Space Complexity	| Notes												|
|------|----------------------------------------|------------------|--------------------|---------------------------------------------------|
| 1    | OnSinglePassClassicSolution            | O(n)             | O(1)				| Tight loop and minimal branching					|
| 2    | OnSinglePassStateSolution              | O(n)             | O(1)				| Tracks direction changes with state variables		|
| 3    | OnSinglePassMultiplePeakStateSolution  | O(n)             | O(1)				| Generalized for multiple peaks, more branching	|

---

## Find-Mountain-Peak
<a name="find-mountain-peak"></a>

📘 [Problem Description](./Problems/Find-Mountain-Peak-Description.md)

Benchmarked Strategies  
----------------------  
| Rank | Strategy Name                     | Time Complexity | Space Complexity | Notes                                                       |
|------|-----------------------------------|------------------|------------------|-------------------------------------------------------------|
| 1    | OlognLowerBoundBinarySearch        | O(log n)         | O(1)             | Slope-aware binary search that converges on peak index      |
| 2    | OnLinearScanFirstPeak             | O(n)             | O(1)             | Returns first peak found via strict neighbor comparison     |

---

## Find Peak Element
<a name="find-peak-element"></a>

| Strategy                   | Peak Detection Logic                          | Search Direction Based on Slope             | Time Complexity  | Space	| Idiomatic Use Case                        | Notes																		|
|----------------------------|-----------------------------------------------|---------------------------------------------|------------------|---------|-------------------------------------------|---------------------------------------------------------------------------|
| Slope-Based Binary Search  | Compare `nums[mid]` with `nums[mid+1]`        | Ascending → right, Descending → left        | O(log n)         | O(1)	| Strict inequality, multiple peaks allowed | Optimal for local maxima, avoids recursion, loop invariant guarantees		|
| Recursive Divide & Conquer | Check mid and recurse into promising half     | Based on neighbor comparisons               | O(log n)         | O(log n)| Educational recursion patterns            | Equivalent logic, but adds stack overhead and branching complexity		|
| Linear Scan                | Check each element against neighbors          | N/A                                         | O(n)             | O(1)	| Small arrays or relaxed constraints       | Disqualified by problem constraint; useful for debugging or brute force	|

---
## Hill-and-Valley-Count
<a name="hill-and-valley-count"></a>

📘 [Problem Description](./Problems/Hill-and-Valley-Count-Description.md)

Approaches
----------
| Rank | Approach								| Time Complexity	| Space Complexity |
|------|----------------------------------------|-------------------|------------------|
| 1    | O(n) Plateau Collapse Linear Search	| O(n)				| O(n)             |
| 2    | O(n) Two-Pointer Linear Search			| O(n)				| O(1)             |
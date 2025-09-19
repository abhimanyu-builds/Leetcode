# 🧠 Strategy Playbook

A consolidated reference of all strategy tradeoffs across problems.

## 📋 Table of Contents

- [Contains-duplicate-I](#contains-duplicate-i)
- [Remove-duplicates](#remove-duplicates)
- [Remove-element](#remove-element)
- [Search-rotated-sorted-array](#search-rotated-sorted-array)
- [Three-sum](#three-sum)
- [Two-sum](#two-sum)
- [Two-sum-sorted](#two-sum-sorted)

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
| 3    | Brute Force    | O(n^2)				| O(1)              |

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


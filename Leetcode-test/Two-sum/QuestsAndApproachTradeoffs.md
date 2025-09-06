Approaches
----------
| Rank   | Approach                      | Time Complexity  | Space Complexity  | Pros                                             | Cons                                    |
|--------|-------------------------------|------------------|-------------------|--------------------------------------------------|-----------------------------------------|
| 1      | Hash Map (Dictionary)         | O(n)             | O(n)              | Fast, preserves indices, ideal for unsorted input| Uses extra space                        |
| 2      | Two-Pointer (Sorted Input)    | O(n log n)       | O(1)              | Elegant, efficient for value-based checks        | Requires sorting, loses original indices|
| 3      | Set-Based Lookup              | O(n)             | O(n)              | Simple, great for value-only checks              | Doesn’t track indices                   |
| 4      | Binary Search After Sorting   | O(n log n)       | O(1)              | Works well with sorted data                      | More complex, index tracking needed     |
| 5      | Brute Force (Nested Loops)    | O(n²)            | O(1)              | Easy to understand and implement                 | Very slow for large inputs              |

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
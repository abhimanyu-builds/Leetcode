Approaches
----------
| Rank  |		Approach                    | Time Complexity   | Space Complexity  | Pros														| Cons												|
|-------|-----------------------------------|-------------------|-------------------|-----------------------------------------------------------|---------------------------------------------------|
| 1		| Sorting + Two-Pointer				|		O(n²)		|		O(1)		| Efficient, easy to implement, handles duplicates well		| Requires sorting, only works on sorted arrays		|
| 2		| Hash Set for Two-Sum within 3Sum	|		O(n²)		|		O(n)		| Fast lookups, avoids sorting								| Duplicate handling can be tricky					|
| 3		| Dictionary-Based Lookup			|		O(n²)		|		O(n)		| Good for tracking complements, flexible					| Can get messy with duplicate keys					|
|		|	Dictionary Overall 				|		O(n+k^2)	|		O(k)		|															|													|
|		|		Dictionary Creation			|		O(n)		|		O(k)		|															|													|
|		|		Triplet Generation Methods	|		O(k^2)		|		O(n^2)		|															|													|
| 4		| Recursive K-Sum					|		O(n^{k-1})	|		O(k)		| Generalizes to any K, elegant structure					| Slower for large K, more complex to code			|
| 5		| Meet-in-the-Middle				|		O(n^{k/2})	|		O(n^{k/2})	| Powerful for large K, parallelizable						| High space usage, not ideal for small K			|
| 6		| Brute Force						|		O(n³)		|		O(1)		| Simple to understand and implement						| Extremely inefficient for large inputs			|
|-------|-----------------------------------|-------------------|-------------------|-----------------------------------------------------------|---------------------------------------------------|


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
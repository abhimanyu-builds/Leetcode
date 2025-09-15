Approaches
----------

| Rank	| Approach							| Time Complexity	| Space Complexity	| Pros                                              | Cons                                                  |
|-------|-----------------------------------|-------------------|-------------------|---------------------------------------------------|-------------------------------------------------------|
| 1		| Forward Overwrite					| O(n)				| O(1)              | Simple, preserves order, easy to implement        | May perform unnecessary writes before first match.	|
|		|									|					|					|													|	Optimized in implementation							|
| 2		| Swap with End Pointer				| O(n)				| O(1)              | Fewer writes when target is frequent              | Does not preserve order, trickier to debug            |
| 3		| Two-Pointer Partitioning			| O(n)				| O(1)              | Efficient in-place partitioning                   | Requires careful handling of edge cases,				|
|		|									|					|					|													|	Does not preserve order								|
|-------|-----------------------------------|-------------------|-------------------|---------------------------------------------------|-------------------------------------------------------|
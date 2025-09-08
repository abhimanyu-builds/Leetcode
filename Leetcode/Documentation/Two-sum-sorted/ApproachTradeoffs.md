Approaches
----------
|--------|----------------------|------------------|-------------------|
| Rank   | Approach             | Time Complexity  | Space Complexity  |
|--------|----------------------|------------------|-------------------|
| 1      | Two Pointers			| O(n)             | O(1)              |
| 2      | Binary Search per i	| O(n log n)       | O(1)              |
|--------|----------------------|------------------|-------------------|

Tradeoffs
---------
|---------------------------|-----------------------------------------------------------|-----------------------------------------------------------|							
|							|				Two Pointers								|				Binary Search per i							|
|---------------------------|-----------------------------------------------------------|-----------------------------------------------------------|
| Instruction Overhead		| Just one comparison per step and moves a single pointer	| Multiple comparisons										|
|							|															| Repeated recalculation of the midpoint					|
|							|															| Constant updates to left and right pointers				|
|---------------------------|-----------------------------------------------------------|-----------------------------------------------------------|
| Poor Cache Locality		| Walks through the array sequentially						| Jumps around the array, accessing elements non-linearly	|
|							| Aligns perfectly with how CPUs cache memory				| Disrupts caching and causes slowdown						|
|---------------------------|-----------------------------------------------------------|-----------------------------------------------------------|
| Branch Prediction Penalty	| Predictable: either moves left or right					| Has more branching and less predictability				|
|							| CPUs correctly guess which way the code will branch 		| CPU's wrong guesses lead to performance hits				|
|---------------------------|-----------------------------------------------------------|-----------------------------------------------------------|
| Nested Loop Cost			| Single linear scan, no nested loops - O(n) overall		| One pass + log n search for each element - O(n log n)		|
|---------------------------|-----------------------------------------------------------|-----------------------------------------------------------|

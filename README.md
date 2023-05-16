# Recent Item Queue
This data structure is not like queue. It is more closer to stack. It is a data structure which has stack-like behavior and most-recent-hit on top behavior.
Let's see the following examples to understand the details.

## Examples

### Example 1 - Stack-like behavior under size limit
```
// Initialize the data strcuture with size of 5
RecentItemQueue<int> queue = new(5);
```
```
// insert 3 integers
queue.SetItem(1);
queue.SetItem(2);
queue.SetItem(3);
```  
```
// retrieve the elements
IReadOnlyList<int> results = queue.GetItems();

// The count of results is 3
// The first element of results is 3
// The second element of results is 2
// The thrid element of results is 1
```

### Example 2 - Stack-like behavior over size limit
```
// Initialize the data strcuture with size of 4
RecentItemQueue<int> queue = new(4);
```
```
// insert 5 integers
queue.SetItem(1);
queue.SetItem(2);
queue.SetItem(3);
queue.SetItem(4);
queue.SetItem(5);
```
```
// retrieve the elements
IReadOnlyList<int> results = queue.GetItems();

// The count of results is 4
// The first element of results is 5
// The second element of results is 4
// The thrid element of results is 3
// The fourth element of results is 2
// Integer 1 is gone because the size of the data structure is 4.
```

### Example 3 - Most-recent-hit on top behavior
```
// Initialize the data strcuture with size of 10
RecentItemQueue<int> queue = new(10);
```
```
// insert 4 integers
queue.SetItem(1);
queue.SetItem(2);
queue.SetItem(3);
queue.SetItem(1);
```
```
// retrieve the elements
IReadOnlyList<int> results = queue.GetItems();

// The count of results is 3 because integer 1 was hit (no duplicate counting)
// The first element of results is 1 (it's on the top because of hit)
// The second element of results is 3
// The thrid element of results is 2
// Integer 1 was hit (which means it had existed in the data structure) so it poped to the top.
```

You can see more examples in unit test file.

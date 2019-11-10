# RecentUsedQueue

Example:
Initialize this data strcuture in size of 5

SetItem(1)
SetItem(2)
SetItem(3)
GetItems() returns 3,2,1

SetItem(4)
SetItem(5)
GetItems() returns 5,4,3,2,1

SetItem(6)
SetItem(7)
GetItems() returns 7,6,5,4,3

SetItem(5)
GetItems() returns 5,7,6,4,3

SetItem(3)
GetItems() returns 3,5,7,6,4

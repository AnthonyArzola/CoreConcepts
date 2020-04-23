Core Concepts
===========
Basic implementation of core Computer Science algorithms and data structures written in C# and packaged as [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/) assembly. Hence, the choice to use `core` :-)

This project was primarily influenced by the following [StackOverflow question and popular answer](https://softwareengineering.stackexchange.com/questions/155639/which-algorithms-data-structures-should-i-recognize-and-know-by-name?answertab=votes#tab-top), my desire to create a cross-platform library and more importantly, help anyone interested in learning the fundamentals.

## Goals
* Provide implementations to standard algorithms/data structures
* Include unit tests to verify functionality
* Write clean and straightforward code with helpful comments
* No dependency on third-party libraries

## Implementations
* Algorithms
  - Sorting
    - Bubble Sort [implementation](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts/Algorithms/Sorting/BubbleSort.cs) and [tests](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts.Tests/Algorithms/Sorting/BubbleSortTests.cs)
    - Insertion Sort [implementation](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts/Algorithms/Sorting/InsertionSort.cs) and [tests](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts.Tests/Algorithms/Sorting/InsertionSortTests.cs)
    - Selection Sort [implementation](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts/Algorithms/Sorting/SelectionSort.cs) and [tests](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts.Tests/Algorithms/Sorting/SelectionSortTests.cs)
    - Merge Sort [implementation](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts/Algorithms/Sorting/MergeSort.cs) and [tests](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts.Tests/Algorithms/Sorting/MergeSortTests.cs)
    - Quick Sort [implementation](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts/Algorithms/Sorting/QuickSort.cs) and [tests](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts.Tests/Algorithms/Sorting/QuickSortTests.cs)
  - Searching
    - Binary Search [implementation](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts/Algorithms/Searching/BInarySearch.cs) and [tests](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts.Tests/DataStructures/Graphs/UndirectedGraphTests.cs)

* Data structures
  - Linked List [implementation](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts/DataStructures/Linear/LinkedList.cs) and [tests](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts.Tests/DataStructures/Linear/LinkedListTests.cs)
  - Double Linked List (coming soon!)
  - Queue [implementation](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts/DataStructures/Linear/Queue.cs)
  - Stack [implementation](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts/DataStructures/Linear/Stack.cs) and [tests](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts.Tests/DataStructures/Linear/StackTests.cs)
  - Graphs
    - [Undirected](https://github.com/AnthonyArzola/CoreConcepts/blob/master/CoreConcepts/DataStructures/Graphs/UndirectedGraph.cs) (implemented using Adjacency List)
      - Depth First Search [implementation](https://github.com/AnthonyArzola/CoreConcepts/blob/de954a7c0d8aec10460a7c16d6a2b1ee6eb0967f/CoreConcepts/DataStructures/Graphs/UndirectedGraph.cs#L79)
      - Breadth First Search [implementation](https://github.com/AnthonyArzola/CoreConcepts/blob/de954a7c0d8aec10460a7c16d6a2b1ee6eb0967f/CoreConcepts/DataStructures/Graphs/UndirectedGraph.cs#L158)
    - Directed (coming soon!)
  - Min Heap (coming soon!)
  - Max Heap (coming soon!)

## Notes
* The goal of this project is to implement solutions, __not__ leverage LINQ or make use of latest-and-greatest [syntactic sugar](https://en.wikipedia.org/wiki/Syntactic_sugar) provided by .NET Core to reduce code.

* It should also be noted, I have __not__ provided a solution to '[RegEx match open tags except XHTML self-contained tags](https://stackoverflow.com/questions/1732348/regex-match-open-tags-except-xhtml-self-contained-tags)'. Use an XML parser instead :-)

## Sample
* Binary Search
```csharp
int[] array = new int[] { 1, 2, 15, 35, 46, 78, 100 };
int index = BinarySearch.Search(array, 35);
// Will return 3
```

* Bubble Sort
```csharp
int[] unsortedArray = new[] { 300, 5, 1, 8, 100, 2, 10 };
BubbleSort.Sort(unsortedArray);
// Will produce [1, 2, 5, 8, 10, 100, 300]
```

* Insertion Sort
```csharp
int[] unsortedArray = new int[] { 38, 27, 43, 3, 9, 82, 10 };
InsertionSort.Sort(unsortedArray);
// Will produce [3, 9, 10, 27, 38, 43, 82]
```

* Selection Sort
```csharp
int[] unsortedArray = new int[] { 300, 5, 1, 8, 100, 2, 10 };
SelectionSort.Sort(unsortedArray);
// Will produce [1, 2, 5, 8, 10, 100, 300]
```

* Stack
```csharp
using Core = CoreConcepts.DataStructures.Linear;

Core.Stack<int> stack = new Core.Stack<int>();

int itemsToPush = 5;
for (int i = 1; i <= itemsToPush; i++)
{
    stack.Push(i);
}

for (int i = itemsToPush; i > 0; i--)
{
    int value = stack.Pop();
}
```
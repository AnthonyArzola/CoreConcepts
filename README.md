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
    - Bubble Sort
    - Insertion Sort
  - Searching
    - Binary Search

* Data structures (coming soon!)

## Notes
* The goal of this project is to implement solutions, __not__ leverage LINQ or make use of latest-and-greatest [syntactic sugar](https://en.wikipedia.org/wiki/Syntactic_sugar) provided by .NET Core to reduce code.

* It should also be noted, I have __not__ provided a solution to '[RegEx match open tags except XHTML self-contained tags](https://stackoverflow.com/questions/1732348/regex-match-open-tags-except-xhtml-self-contained-tags)'. Use an XML parser instead :-)

## Sample
To perform a Binary Search, call static method `Search` on `BinarySearch` class. If value is found, it will return index or -1.

```csharp
int[] array = new int[] { 1, 2, 15, 35, 46, 78, 100 };
int index = BinarySearch.Search(array, 35); // Would return 3
```

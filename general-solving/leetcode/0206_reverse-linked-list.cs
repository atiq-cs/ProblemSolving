/***************************************************************************
* Title : Reverse a Linked List (recurse and iteration)
* URL   : https://leetcode.com/problems/two-sum-iv-input-is-a-bst
* Date  : 2015-07-29
* Author: Atiq Rahman
* Comp  : O(N); O(1), O(N) in stack
* Status: Accepted
* Notes : We discuss here both of recursive and iterative solutions
*   Recursive Concept,
*   uses the idea that all the nodes of the linked list are pushed into heap
*   during recursive calls. So when we are return from those calls we utilize
*   store nodes to change the link each time. This changes linked list's head's
*   next as well. So we cannot find the new Head which is the tail of original
*   list. To keep a copy of that tail we use a global/class member variable
*   head.
*   During recursion, we take care of the case when head.next is null.
*   if head is null we don't need to reverse anything.
*   
*   All classes are assigned and passed to functions by reference whereas
*   structures instantiate a new object and copies the content
*   
*   Code updated on occassion Den meetup 2018-04-21
*   Based on 'ds/linked-list/reverse-linked-list-demo.cpp'
*   
*   Iterative Concept,
*   Iteratively traverse the linked list and keeps reversing the next pointers
*   consider when changing the next pointer the next chain is lost, so use a
*   temporary variable to keep previous node before losing chain.
*   
*   Technical - Understanding of reference assignment, ref:
*   http://stackoverflow.com/q/1219664
*   This, however, is not possible for strings(immutable)
*   http://stackoverflow.com/q/9792776
*
The note below I put when I was learning C#. Helps to understand how class
objects/references are managed in C#. However, C++ class objects are real
objects, copy by value is predominant.

A class is a reference type. When an object of the class is created, the
variable to which the object is assigned holds only a reference to that memory.
When the object reference is assigned to a new variable, the new variable
refers to the original object. Changes made through one variable are reflected
in the other variable because they both refer to the same data.

A struct is a value type. When a struct is created, the variable to which the
struct is assigned holds the struct's actual data. When the struct is assigned
to a new variable, it is copied. The new variable and the original variable
therefore contain two separate copies of the same data. Changes made to one
copy do not affect the other copy. (similar to C++ classes/structs)

draft note is at bottom and Code at 'ds/linked-list/reverse.cs'
ref: https://msdn.microsoft.com/en-us/library/vstudio/ms173109.aspx
*   Code at 'ds/linked-list/reverse.cs'
* meta  : tag-ds-linked-list, tag-recursion
***************************************************************************/

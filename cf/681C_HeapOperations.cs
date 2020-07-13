/***************************************************************************************************
* Title : Heap Operations
* URL   : http://codeforces.com/problemset/problem/681/C
* Occasn: Codeforces Round #357 (Div. 2)
* Date  : 2017-09-11
* Comp  : O(n) 280ms, O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Goal of this problem (to note),
*   1. heap should not be empty during getMin or removeMin
*   a. getMin or removeMin operations may be incorrect, as the heap is empty at the moment they
*   are applied.
*   b. the result of each getMin operation is equal to the result in the record, and the heap is
*   non-empty when getMin and removeMin are applied
*   
*   Chunk output is faster, therefore the advantage of maintaining HeapOpList
*
*   msdn exceptions ref:
*   https://docs.microsoft.com/en-us/dotnet/csharp/
*   programming-guide/exceptions/creating-and-throwing-exceptions
* meta  : tag-ds-heap, tag-algo-greedy, tag-graph-tree
***************************************************************************************************/
using System;
using System.Collections.Generic;

// Heap is at 'ds/Heap.cs'
class HeapDemo {
  private List<string> HeapOpList;
  Heap minHp;

  public void TakeInput() {
    int T = int.Parse(Console.ReadLine());
    minHp = new Heap((a, b) => { return a < b; });
    HeapOpList = new List<string>();

    while (T-- > 0) {
      string line = Console.ReadLine();
      string[] tokens = line.Split();
      switch (tokens[0]) {
        case "insert":  // insert
          minHp.Insert(int.Parse(tokens[1]));
          HeapOpList.Add(line);
          break;
        case "removeMin":  // remove minimum
          /*
           * inserting anything into the heap is okay
           * Goal: make the heap non-empty
           * non-empty heap makes online-judge happy
           */
          if (minHp.HeapSize() == 0)
            HeapOpList.Add("insert 1");
          else
            minHp.ExtractMin();
          HeapOpList.Add(line);
          break;
        case "getMin":  // print minimum
          AdjustHeapOps(int.Parse(tokens[1]));
          HeapOpList.Add(line);
          break;
        default: // should not be here
          break;
      }
    }
  }
  /*
   * Complexity:
   *  The function can extract n items in worst case each of them having cost
   *  O(log n)
   *  Therefore, overall time complexity: O(n log n)
   */
  private void AdjustHeapOps(int expectedMin) {
    // remove min till it becomes >= to expected
    while (minHp.HeapSize() > 0 && minHp.Peek() < expectedMin) {
      minHp.ExtractMin();
      HeapOpList.Add("removeMin");
    }
    // Greater or equal to here
    // for top item greater than expected we insert
    if (minHp.HeapSize() == 0 || minHp.Peek() > expectedMin) {
      minHp.Insert(expectedMin);
      HeapOpList.Add("insert " + expectedMin);
    }
    // for the case where top item = expectedMin; we do nothing
  }
  // return the output string
  private string ListHeapOps() { return string.Join("\r\n", HeapOpList); }
  public void OutputHeapOpsList() {
    Console.WriteLine(HeapOpList.Count);
    Console.WriteLine(ListHeapOps());
  } 
}

public class CFSolution {
  private static void Main() {
    HeapDemo demo = new HeapDemo();
    demo.TakeInput();
    demo.OutputHeapOpsList();
  }
}

/*
Sample input,
1
removeMin
*/

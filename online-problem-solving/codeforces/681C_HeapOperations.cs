/***************************************************************************
* Title       : Heap Operations
* URL         : http://codeforces.com/problemset/problem/681/C
* Occasion    : Codeforces Round #357 (Div. 2)
* Date        : Sep 11 2017
* Complexity  : O(n) 280ms, Space O(n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Goal of this problem (to note),
*               1. heap should not be empty during getMin or removeMin
*               a. getMin or removeMin operations may be incorrect, as the heap
*                is empty at the moment they are applied.
*               b. the result of each getMin operation is equal to the result
*               in the record, and the heap is non-empty when getMin ad
*                removeMin are applied
*
*              HeapMin implementation is based on,
*               hackerrank\CCI\DataStructure\008_find-the-running-median.cs
*              For exceptions look at,
*               https://docs.microsoft.com/en-us/dotnet/csharp/
*               programming-guide/exceptions/creating-and-throwing-exceptions
* meta        : tag-heap, tag-easy
***************************************************************************/
using System;
using System.Collections.Generic;

class MinHeap {
  protected List<int> Arr;
  protected int Size;
  public MinHeap() {
    Arr = new List<int>();
    Size = 0;
  }
  protected int GetParent(int i) { return (i - 1) / 2; }
  protected int GetLeftChild(int i) { return 2 * i + 1; }
  protected int GetRightChild(int i) { return 2 * i + 2; }

  public int HeapSize() { return Size; }
  public int Peek() {
    if (Size == 0)
      throw new InvalidOperationException("MinHeap is empty!");
    return Arr[0];
  }
  protected void Swap(int i, int j) {
    int tmp = Arr[i];
    Arr[i] = Arr[j];
    Arr[j] = tmp;
  }

  public void Insert(int item) {
    if (Size < Arr.Count)
      Arr[Size] = item;
    else
      Arr.Add(item);
    int  i = Size++;
    // Similar to Decrease Key
    while (i > 0 && Arr[GetParent(i)] > Arr[i]) {
      Swap(i, GetParent(i));
      i = GetParent(i);
    }
  }
  protected void Heapify(int i) {
    int l = GetLeftChild(i);
    int r = GetRightChild(i);
    int smallest = i;
    if (l < Size && Arr[l] < Arr[smallest])
      smallest = l;
    if (r< Size && Arr[r] < Arr[smallest])
      smallest = r;
    if (smallest != i) {
      Swap(smallest, i);
      Heapify(smallest);
    }
  }

  public int ExtractMin() {
    if (Size == 0)
      throw new InvalidOperationException("MinHeap is empty!");
    int max = Arr[0];
    Arr[0] = Arr[--Size];
    Heapify(0);
    return max;
  }
}

/*
 * Advantage of maintaining HeapOpList
 * In C# usually chunk output is faster
 * 
 */
class HeapDemo {
  private List<string> HeapOpList;
  MinHeap min_heap;

  public void TakeInput() {
    int T = int.Parse(Console.ReadLine());
    min_heap = new MinHeap();
    HeapOpList = new List<string>();

    while (T-- > 0) {
      string line = Console.ReadLine();
      string[] tokens = line.Split();
      switch (tokens[0]) {
        case "insert":  // insert
          min_heap.Insert(int.Parse(tokens[1]));
          HeapOpList.Add(line);
          break;
        case "removeMin":  // remove minimum
          /*
           * inserting anything into the heap is okay
           * Goal: make the heap non-empty
           * non-empty heap makes online-judge happy
           */
          if (min_heap.HeapSize() == 0)
            HeapOpList.Add("insert 1");
          else
            min_heap.ExtractMin();
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
    while (min_heap.HeapSize() > 0 && min_heap.Peek() < expectedMin) {
      min_heap.ExtractMin();
      HeapOpList.Add("removeMin");
    }
    // Greater or equal to here
    // for top item greater than expected we insert
    if (min_heap.HeapSize() == 0 || min_heap.Peek() > expectedMin) {
      min_heap.Insert(expectedMin);
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

public class CF_Solution {
  private static void Main() {
    HeapDemo heap_demo = new HeapDemo();
    heap_demo.TakeInput();
    heap_demo.OutputHeapOpsList();
  }
}

/*
 Sample input,
 1
 removeMin

*/
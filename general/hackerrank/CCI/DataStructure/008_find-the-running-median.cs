/***************************************************************************************************
* Title : Heaps: Find the Running Median
* URL   : https://www.hackerrank.com/challenges/ctci-find-the-running-median
* Date  : 2017-09-11
* Comp  : Add Item O(log n); Get-Median O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
*   Limitations: the implementation would fail if there are duplicate numbers in input set
*   
*   Consider critical cases when MinHp's count or MaxHp's count are 0.

* rel   : 'hackerrank\data-structures\heap_01_qheap.cs'
* meta  : tag-ds-heap, tag-easy
***************************************************************************************************/
using System;
using System.Collections.Generic;

class MedianFinder {
  Heap MinHp;
  Heap MaxHp;
  int count;

  public MedianFinder() {
    count = 0;
    MinHp = new Heap((a, b) => { return a < b; });
    MaxHp = new Heap((a, b) => { return a > b; });
  }

  /* For efficient operations,
   * left side: max heap
   * right side: min heap
   * 
   * Maintain the invariant that
   *  max of max heap is smaller than min of min heap
   *  
   * Assumption,
   *  There are no duplicates since this is a heap problem 
   */
  public void Add(int item) {
    // assuming there are no duplicates since this is a heap problem
    // should go into left/max heap
    if (item < (MaxHp.Count == 0 ? -1 : MaxHp.Peek())) {
      // left_size > right_size
      // then we need to extract one item and push into the right side
      if (MaxHp.Count > MinHp.Count)
        MinHp.Insert(MaxHp.ExtractMin());
      MaxHp.Insert(item);
    }
    else if (item > (MinHp.Count == 0 ? -1 : MinHp.Peek())) {
      // left_size > right_size
      // then we need to extract one item and push into the right side
      if (MaxHp.Count < MinHp.Count)
        MaxHp.Insert(MinHp.ExtractMin());
      MinHp.Insert(item);
    }
    else { // lies in between; pushing into either left or right is valid
      if (MaxHp.Count > MinHp.Count)
        MinHp.Insert(item);
      else
        MaxHp.Insert(item);
    }
    count++;
  }

  public float GetMedian() {
    if (count % 2 == 1)
      return (MaxHp.Count > MinHp.Count) ? MaxHp.Peek() : MinHp.Peek();
    return ((float)MaxHp.Peek() + MinHp.Peek()) / 2;
  }
}


/*
 * Based on abstract class we derive
 * two classes: MaxHeap and MinHeap
 * This can be replaced with a single class named Heap specifying a comparator
 * or specifier whether a few functions such as ExtractMin, Heapify should
 * behave as for minHeap or as for maxHeap
 *
abstract class Heap {
  protected List<int> Arr;
  protected int Size;
  public Heap() { }
  protected int GetParent(int i) { return (i - 1) / 2; }
  protected int GetLeftChild(int i) { return 2 * i + 1; }
  protected int GetRightChild(int i) { return 2 * i + 2; }

  public int Peek() { return Size > 0 ? Arr[0] : 0; }
  abstract public void Insert(int item);
  abstract protected void Heapify(int i);

  protected void Exchange(int i, int j);
}

class MinHeap and MaxHeap Override,
  1. Insert
  2. Heapify
  3. ExtractMin/Max
*/

class HKSolution {
  static void Main(String[] args) {
    MedianFinder MF = new MedianFinder();

    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      MF.Add(int.Parse(Console.ReadLine()));
      Console.WriteLine("{0:F1}",MF.GetMedian());
    }
  }
}

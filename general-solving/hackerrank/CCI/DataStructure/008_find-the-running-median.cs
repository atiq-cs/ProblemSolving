/***************************************************************************
* Title       : Heaps: Find the Running Median
* URL         : https://www.hackerrank.com/challenges/ctci-find-the-running-median
* Date        : Sep 11 2017
* Complexity  : Add Item O(log n)
*               Get-Median O(1)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : 
*               Limitations: the implementation would fail if there are
*               duplicate numbers in input set
*               
* Related     : Based on hackerrank\data-structures\heap_01_qheap.cs
* meta        : tag-heap, tag-easy, tag-minheap
***************************************************************************/
using System;
using System.Collections.Generic;

class MedianFinder {
  MinHeap MinHp;
  MaxHeap MaxHp;
  int count;

  public MedianFinder() {
    count = 0;
    MinHp = new MinHeap();
    MaxHp = new MaxHeap();
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
    if (item < MaxHp.Peek()) {
      // left_size > right_size
      // then we need to extract one item and push into the right side
      if (MaxHp.HeapSize() > MinHp.HeapSize())
        MinHp.Insert(MaxHp.ExtractMax());
      MaxHp.Insert(item);
    }
    else if (item > MinHp.Peek()) {
      // left_size > right_size
      // then we need to extract one item and push into the right side
      if (MaxHp.HeapSize() < MinHp.HeapSize())
        MaxHp.Insert(MinHp.ExtractMin());
      MinHp.Insert(item);
    }
    else { // lies in between; pushing into either left or right is valid
      if (MaxHp.HeapSize() > MinHp.HeapSize())
        MinHp.Insert(item);
      else
        MaxHp.Insert(item);
    }
    count++;
  }

  public float GetMedian() {
    if (count % 2 == 1)
      return (MaxHp.HeapSize() > MinHp.HeapSize()) ? MaxHp.Peek() : MinHp.Peek();
    return ((float)MaxHp.Peek() + MinHp.Peek()) / 2;
  }
}

/*
 * Based on abstract class we derive
 * two classes: MaxHeap and MinHeap
 * This can be replaced with a single class named Heap specifying a comparator
 * or specifier whether a few functions such as ExtractMin, Heapify should
 * behave as for minHeap or as for maxHeap
 */
abstract class Heap {
  protected List<int> Arr;
  protected int Size;
  public Heap() {
    Arr = new List<int>();
    Size = 0;
  }

  protected int GetParent(int i) { return (i - 1) / 2; }
  protected int GetLeftChild(int i) { return 2 * i + 1; }
  protected int GetRightChild(int i) { return 2 * i + 2; }

  public int HeapSize() { return Size; }
  public int Peek() { return Size > 0 ? Arr[0] : 0; }
  abstract public void Insert(int item);
  abstract protected void Heapify(int i);

  protected void Swap(int i, int j) {
    int tmp = Arr[i];
    Arr[i] = Arr[j];
    Arr[j] = tmp;
  }
}

class MinHeap : Heap {
  public override void Insert(int item) {
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

  protected override void Heapify(int i) {
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
    int max = Arr[0];
    Arr[0] = Arr[--Size];
    Heapify(0);
    return max;
  }
}

class MaxHeap : Heap {
  public override void Insert(int item) {
    if (Size < Arr.Count)
      Arr[Size] = item;
    else
      Arr.Add(item);
    int i = Size++;
    // Similar to Increase Key
    while (i > 0 && Arr[GetParent(i)] < Arr[i]) {
      Swap(i, GetParent(i));
      i = GetParent(i);
    }
  }

  protected override void Heapify(int i) {
    int l = GetLeftChild(i);
    int r = GetRightChild(i);
    int largest = i;
    if (l < Size && Arr[l] > Arr[largest])
      largest = l;
    if (r< Size && Arr[r] > Arr[largest])
      largest = r;
    if (largest != i) {
      Swap(largest, i);
      Heapify(largest);
    }
  }

  public int ExtractMax() {
    int max = Arr[0];
    Arr[0] = Arr[--Size];
    Heapify(0);
    return max;
  }
}

class Solution {
  static void Main(String[] args) {
    MedianFinder MF = new MedianFinder();

    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      MF.Add(int.Parse(Console.ReadLine()));
      Console.WriteLine("{0:F1}",MF.GetMedian());
    }
  }
}

/***************************************************************************************************
* Title : Heap Data Structure
* URL   : http://www.cs.cmu.edu/~jxc/Heaps.pdf
* Date  : 2017-09
* Author: Atiq Rahman
* Comp  :
*   Insert Item O(log n)
*   Delete Item O(n) + O(log n) = O(n)
*   FindMin or Print Minimum O(1)
*   Extract Min O(log n), Space O(n)
* Notes : Heaps is a partially ordered complete binary tree. It is a balanced binary trees with
*   priority P(k1), P(k2), ...., P(kn). It is the implementation of the priority queue. It is an
*   array, visualized as a nearly complete binary tree.
* 
* Based on the comparer provided in the constructor Heap class can
*   behave as MinHeap and MaxHeap
* Ref   : C.L.R.S Ch#6
*   https://www.cs.cmu.edu/~ckingsf/bioinfo-lectures/heaps.pdf (note the terms are slightly
*   different)
*   https://www.cs.cmu.edu/~ckingsf/bioinfo-lectures/heaps.pdf (some illustrated examples of ops)
* meta  : tag-ds-heap, tag-ds-core
***************************************************************************************************/
using System;
using System.Collections.Generic;

// accepts lambda comparer to define whether the heap will behave as Min Heap
// or Max Heap
delegate bool CmpDelegate(int a, int b);

class Heap {
  private List<int> A;
  private int heapSize;   // C.L.R.S calls it 'heap-size'
  private CmpDelegate cmpDel;

  public Heap(CmpDelegate del) {
    A = new List<int>();
    heapSize = 0;
    this.cmpDel = del;
  }

  // C.L.R.S p#152
  private int GetParent(int i) { return (i-1) / 2; }
  private int GetLeftChild(int i) { return 2*i + 1; }
  private int GetRightChild(int i) { return 2*i + 2; }

  // getter only property
  public int Count { get { return heapSize; } }

  /// <summary>
  /// O(1)
  /// </summary>
  /// <returns> Returns min/max based on type of Heap </returns>
  public int Peek() {
    if (heapSize == 0)
      throw new InvalidOperationException("Heap is empty!");
    return A[0];
  }

  public void Insert(int item) {
    if (heapSize < A.Count)
      A[heapSize] = item;
    else
      A.Add(item);
    BubbleUp(heapSize++);
  }

  protected void BubbleUp(int i) {
    while (i > 0 && cmpDel(A[i], A[GetParent(i)])) {
      Exchange(i, GetParent(i));
      i = GetParent(i);
    }
  }

  /// <summary>
  /// C.L.R.S p#154
  /// </summary>
  /// <param name="i"></param>
  private void Heapify(int i) {
    int l = GetLeftChild(i);
    int r = GetRightChild(i);
    int smallest = i;
    if (l < heapSize && cmpDel(A[l], A[smallest]))
      smallest = l;
    if (r < heapSize && cmpDel(A[r], A[smallest]))
      smallest = r;
    if (smallest != i) {
      Swap(smallest, i);
      Heapify(smallest);
    }
  }

  /// <summary>
  /// May be a different name for Max Heaps
  /// </summary>
  /// <returns></returns>
  public int ExtractMin() {
    if (heapSize == 0)
      throw new InvalidOperationException("Heap underflow!");
    // O(N) https://msdn.microsoft.com/en-us/library/5cw9x18z.aspx
    // A.RemoveAt(heapSize);

    /* Save in a temp variable min, because after Heapify this might get
     * swapped and returning A[0] might not return Minimum any more*/
    int min = A[0];
    A[0] = A[--heapSize];
    Heapify(0);
    return min;
  }

  // Naive implementation with O(N) complexity
  public void DeleteItem(int item) {
    int i = 0;
    for (; i < heapSize; i++)
      if (A[i] == item)
        break;
    A[i] = A[--heapSize];
    Heapify(i);
  }

  private void Exchange(int i, int j) {
    int tmp = A[i];
    A[i] = A[j];
    A[j] = tmp;
  }

  /// <summary>
  /// O(N)
  /// </summary>
  /// <param name="item"></param>
  /// <returns> returns index; -1 if not found </returns>
  protected int heapSearch(LRUItem item) {
    for (int i = 0; i < heapSize; i++) {
        LRUItem aItem = A[i];
        if (item.Value == aItem.Value)
            return i;
    }
    return -1;
  }

  /// <summary>
  /// C.L.R.S p#152
  /// </summary>
  /// <param name="item"></param>
  private void buildHeap() {
    for (int i = heapSize / 2; i >= 0; i--)
      Heapify(i);
  }

  private void heapSort() {
    int temp = heapSize;
    buildHeap();

    for (int i = heapSize - 1; i >= 1; i--) {
        Exchange(0, i);
        heapSize--;
        Heapify(0);
    }
    heapSize = temp;
  }
}

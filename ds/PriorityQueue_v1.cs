/***************************************************************************
* Title : Priority Queue based on Heap
* URL   : 
* Date  : 2017-12
* Author: Atiq Rahman
* Comp  : 
* Status: 
* Notes : Doesn't use dictionary, does not implement DecreaseKey
* meta  : tag-priority-queue
***************************************************************************/
using System;
using System.Collections.Generic;
/*
 * Due to generic class implementation of 'PriorityQueue' it cannot access
 * members of the passed type. To reach an agreement with the class what
 * members must exist inside the type use following interface to inherit
 * specify should exist members inside the interface
 */
interface PriorityQueueElement {
  // Access to index is not required to the 'PriorityQueue' class
  // int GetIndex();
  /* 
   * enables access to distance member to 'PriorityQueue' class so that the
   * class can do comparison based on distance and keep the heap arranged
   * accordingly
   */
  uint GetValue();
}

class PriorityQueue <T> where T:PriorityQueueElement {
  protected List<T> Arr;
  protected int Size;

  public PriorityQueue() {
    Arr = new List<T>();
    Size = 0;
  }

  protected int GetParent(int i) { return (i - 1) / 2; }
  protected int GetLeftChild(int i) { return 2 * i + 1; }
  protected int GetRightChild(int i) { return 2 * i + 2; }

  // getter only property
  public int Count { get { return Size; } }

  public T Peek() {
    if (Size == 0)
      throw new InvalidOperationException("MinHeap is empty!");
    return Arr[0];
  }

  protected void Swap(int i, int j) {
    T tmp = Arr[i];
    Arr[i] = Arr[j];
    Arr[j] = tmp;
  }

  public void Enqueue(T item) {
    if (Size < Arr.Count)
      Arr[Size] = item;
    else
      Arr.Add(item);
    int i = Size++;
    // Similar to Decrease Key
    while (i > 0 && Arr[GetParent(i)].GetValue() > Arr[i].GetValue()) {
      Swap(i, GetParent(i));
      i = GetParent(i);
    }
  }

  protected void Heapify(int i) {
    int l = GetLeftChild(i);
    int r = GetRightChild(i);
    int smallest = i;
    if (l < Size && Arr[l].GetValue() < Arr[smallest].GetValue())
      smallest = l;
    if (r< Size && Arr[r].GetValue() < Arr[smallest].GetValue())
      smallest = r;
    if (smallest != i) {
      Swap(smallest, i);
      Heapify(smallest);
    }
  }

  public T Dequeue() {
    if (Size == 0)
      throw new InvalidOperationException("MinHeap underflow!");
    T max = Arr[0];
    Arr[0] = Arr[--Size];
    Heapify(0);
    return max;
  }
}

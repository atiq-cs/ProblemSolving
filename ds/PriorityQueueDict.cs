/***************************************************************************
* Title : Priority Queue based on Heap
* URL   : 
* Date  : 2018-06 (update)
* Author: Atiq Rahman
* Comp  : 
* Status: 
* Notes : Use map to optimize time for 'DecreaseKey'
* meta  : tag-priority-queue, tag-heap
***************************************************************************/
using System;
using System.Collections.Generic;

class PriorityQueue : Heap {
  Vertex[] Vertices;
  public PriorityQueue(Vertex[] Vertices) : base((a, b) => {
      return Vertices[a].d < Vertices[b].d;
    }) {
    this.Vertices = Vertices;
  }

  public void Enqueue(int item) {
    Insert(item);
  }

  public int Dequeue() {
    return ExtractMin();
  }
}


/*
 * Due to generic class implementation of 'PriorityQueue' it cannot access
 * members of the passed type. To reach an agreement with the class what
 * members must exist inside the type use following interface to inherit
 * specify should exist members inside the interface
 * 
 * Another example how we can implement this interface is at,
 *  'spoj/23132_TRVCOST.cs'
 */
interface PriorityQueueElement {
  // Access to index is not required to the 'PriorityQueue' class
  int Index { get; }
  /* 
   * enables access to distance member to 'PriorityQueue' class so that the
   * class can do comparison based on distance and keep the heap arranged
   * accordingly
   */
  uint Value { get; set; }
}

class PriorityQueue <T> where T:PriorityQueueElement {
  protected List<T> Arr;
  protected int Size;
  Dictionary<int, int> dict;

  public PriorityQueue() {
    Arr = new List<T>();
    Size = 0;
    dict = new Dictionary<int, int>();
  }

  private void Swap(int i, int j) {
    T tmp = Arr[i];
    Arr[i] = Arr[j];
    Arr[j] = tmp;
    // after swap fix indices
    dict[Arr[i].Index] = i;
    dict[Arr[j].Index] = j;
  }

  public void Enqueue(T item) {
    if (Size < Arr.Count)
      Arr[Size] = item;
    else
      Arr.Add(item);
    dict.Add(item.Index, Size);
    BubbleUp(Size);  Size++;
  }

  private void BubbleUp(int i) {
    while (i > 0 && Arr[GetParent(i)].Value > Arr[i].Value) {
      Swap(i, GetParent(i));
      i = GetParent(i);
    }
  }

  private void Heapify(int i) {
    int l = GetLeftChild(i);
    int r = GetRightChild(i);
    int smallest = i;
    if (l < Size && Arr[l].Value < Arr[smallest].Value)
      smallest = l;
    if (r< Size && Arr[r].Value < Arr[smallest].Value)
      smallest = r;
    if (smallest != i) {
      Swap(smallest, i);
      Heapify(smallest);
    }
  }

  public T Dequeue() {    // ExtractMin
    if (Size == 0)
      throw new InvalidOperationException("MinHeap underflow!");
    T max = Arr[0];
    Arr[0] = Arr[--Size];
    dict.Remove(max.Index);
    dict[Arr[0].Index] = 0;
    Heapify(0);
    return max;
  }

  public void DecreaseKey(T item) {
    if (!dict.ContainsKey(item.Index)) {
      Enqueue(item);
      return ;
    }
    int i = dict[item.Index];
    if (Arr[i].Value > item.Value)
      Arr[i].Value = item.Value;
    BubbleUp(i);
  }
}

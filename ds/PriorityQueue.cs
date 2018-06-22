/***************************************************************************
* Title : Priority Queue based on Heap
* URL   : 
* Date  : 2018-06 (update)
* Author: Atiq Rahman
* Comp  : Check Heap Implementation
* Status: 
* Notes : doesn't use map to optimize time for 'DecreaseKey'
*   Heap is 'ds/Heap.cs'
*
*   tested using 'spoj/23132_TRVCOST.cs'
* meta  : tag-priority-queue, tag-heap
***************************************************************************/
class PriorityQueue : Heap {
  Vertex[] Vertices;    // required for 'spoj/23132_TRVCOST.cs'
  public PriorityQueue(Vertex[] Vertices) : base((a, b) => {
      return Vertices[a].d < Vertices[b].d;
    }) {
    this.Vertices = Vertices;
  }

  // Due to this 'Insert' can be protected in Heap
  public void Enqueue(int item) {
    Insert(item);
  }

  // Due to this 'ExtractMin' can be protected
  public int Dequeue() {
    return ExtractMin();
  }

  /* Min Priority Queue for 'hackerrank/contests/justcode_lru.cs'
   * Since provided priority is greatest (as we are now incrementing priority
   * number in this algorithm to solve this LRU problem) right now, heapify
   * down to bring it down to the last level of the tree/Heap.
   * 
   * What should be general case for any priority value?
   * Try to bubble up, if that has no effect heapify?
   */
  public void IncreaseKey(int index, LRUItem item) {
    if (A[index].Value == item.Value)
      A[index].Priority = item.Priority;
    // BubbleUp(index);
    Heapify(index);
  }
}

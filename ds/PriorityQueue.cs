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

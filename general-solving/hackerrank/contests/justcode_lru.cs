/***************************************************************************
* Title       : LRU Cache
* URL         : https://www.hackerrank.com/contests/justcode/challenges/
*               lru-implementtion
* Occasion    : contests/justcode
* Date        : Aug 18, 2017
* Complexity  : O(n log n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Solved using 'Priority Queue' Data Structure.
*   Initial concept: Max Priority Queue: Lower number has
*   higher priority. We start assigning priority starting from int max value
*   while reading inputs and inserting them into the queue.
*   An item that appeared later has therefore higher priority as we decrease
*   priority value every time we insert an item.
*   In the contrary, we can start with min value and increment priority over
*   time. In that case, changing the conditional operator for comparing
*   priority will help.
* 
*   Priority Queue Implementation for this problem:
*   This version supercesdes previous implementation of Priority Queue in
*   '1840_PQUEUE.cs' to solve SPOJ problem
*   That version has following bug,
*   Right after extract min the result come wrong if Enqueue is done or better
*   way to say it is that some operations would give inconsistent result if
*   they are performed right after 'ExtractMin' Operation of the Priority Queue
*                
*   Based on binary heap, we use C# List as the dynamic array
*   Previous Implementation Ref
*     https://code.msdn.microsoft.com/Dijkstras-Single-Soruce-69faddb3
*     
*   Previously solved using Max Heap and priority Value starting from INF and
*   decrementing every time we insert a new item.
*   
*   For MinHeap start with 0 and increment priority value every time for new
*   items.
*
* Modification: Due to the issue mentioned above I remove the last element
*               in the last line of 'ExtractMin' implementation          
*   
*   Concept: [update 2018-06] min Heap based Priority Queue
*   Improved Insert time complexity to O(1)
*   Decrease Key is O(lg N)
*   
*   Like graph problems we don't have a preliminary list of vertices or LRU
*   items. We might be able to store all of them in an array but would that be
*   space efficient solution for this type of problems. Therefore, went with
*   storing LRUItem in Queue instead.
*   
* meta        : tag-data-structure, tag-priority-queue, tag-heap, tag-LRU
***************************************************************************/
using System;
using System.Collections.Generic;

class LRUItem {
  public int Value;
  public int Priority;    // member used to resolve prirority
  public LRUItem(int key, int pr) { Value = key; Priority = pr; }
}

delegate bool CmpDelegate(LRUItem a, LRUItem b);

class Heap {
  /* Usually Bubble Up
   * However, in this solution, priority coming up later are always greater.
   * Therefore, Bubble-Up is not required, making insert constant time.
   */
  protected void Insert(LRUItem item) {
    // BubbleUp(heapSize++);
  }
}

class PriorityQueue : Heap {
  public PriorityQueue() : base((LRUItem a, LRUItem b) => {
      return a.Priority < b.Priority;
    }) {
  }

  public int find(LRUItem item) {
    return heapSearch(item);
  }
  /* For rest of the methods int type changed to LRUItem since we are not going
   * with the Generics any more; we are using lambda delegates wto figure out
   * whether it's Min Heap or Max Heap */
}

/* Items with greater priority number stay, items with smaller priority gets
 * kicked out. That is what expected from an ExtractMin of a Priority Queue
 * based on Min Heap */
class Solution {
  static void Main(String[] args) {
    string[] tokens = Console.ReadLine().Split();
    int N = int.Parse(tokens[0]);
    int S = int.Parse(tokens[1]);

    PriorityQueue pQueue = new PriorityQueue();
    int pr = 0;
    int countPF = 0;

    for (int T=N; T > 0;) {
      tokens = Console.ReadLine().Split();
      T -= tokens.Length;
      for (int i=0; i<tokens.Length; i++) {
        int val = int.Parse(tokens[i]);
        LRUItem item = new LRUItem(val, pr++);
        // With hash-table this can be O(1)
        int pos = pQueue.find(item);
        if (pos == -1) {
          if (pQueue.Count == S)
            pQueue.Dequeue();
          pQueue.Enqueue(item);
          countPF++;
        }
        else
          pQueue.IncreaseKey(pos, item);
      }
    }

    int[] res = new int[pQueue.Count];
    Console.WriteLine(countPF);
    for (int i=0; pQueue.Count > 0; i++)
      res[i] = pQueue.Dequeue().Value;
    Array.Reverse(res);
    Console.WriteLine(string.Join(" ", res));
  }
}

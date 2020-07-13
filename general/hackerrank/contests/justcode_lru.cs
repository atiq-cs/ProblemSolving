/***************************************************************************************************
* Title : LRU Cache
* URL   : https://hackerrank.com/contests/justcode/challenges/lru-implementtion
* Occasn: contests/justcode
* Date  : 2018-08-25
* Comp  : O(n)
* Status: Accepted
* Notes : For special cases, check comment in code.
* Ack   : Daniel Lee at InnoWorld mentioned this to me first.. 2 months back
* rel   : lt#146, https://leetcode.com/problems/lru-cache
* meta  : tag-ds-linked-list, tag-ds-doubly-linked-list, tag-ds-hash-table, tag-ds-heap, 
*   tag-ds-priority-queue, tag-algo-LRU-cache
***************************************************************************************************/
using System;
using System.Collections.Generic;

// represents a node in doubly linked list
class ListNode {
  public int key { get; private set; }
  public ListNode prev { get; set; }
  public ListNode next { get; set; }

  public ListNode(int key, ListNode prev, ListNode next)
  {
    this.prev = prev;
    this.next = next;
    this.key = kye;
  }
}

class LRU {
  // probably cannot get memory refs if we use Generic LinkedList class
  Dictionary<int, ListNode> dict;
  ListNode head, tail;

  public LRU() {
    Count = 0;
    head = tail = null;
    dict = new Dictionary<int, ListNode>();
  }

  public int Count { get; private set; }

  public ListNode find(int item) {
    return dict.ContainsKey(item) == false ? null : dict[item];
  }

  public void Enqueue(int key) {
    ListNode newHead = new ListNode(key, null, head == null ? null : head);
    if (head != null)
      head.prev = newHead;
    head = newHead;
      
    if (tail == null)
      tail = newHead;
    // Add to dictionary
    dict.Add(key, newHead);
    Count++;
  }

  // Remove the least recently used item
  public void Dequeue() {
    // Remove it from dictionary
    dict.Remove(tail.key);

    // drop the node at tail, if it's head it does not have a previous node
    if (tail.prev != null)
      tail.prev.next = null;
    // Update tail
    tail = tail.prev;

    if (--Count == 0)
      head = tail = null;
  }

  /// <summary>
  /// Update as most recently accessed item
  /// references move in the linked list but is not changed
  /// Hence, dictionary entry is not udpated
  /// Consider, this node can be head, tail or in the middle
  /// </summary>
  /// <param name="node"> perform mentioned actions above on current give node </param>
  public void UpdateAsMRU(ListNode node)
  {
    if (node == head)
      return;
    if (node == tail)
      tail = tail.prev;
    // update previous's next, previous's prev is untouched
    node.prev.next = node.next;
    // update next's prev, next's next is untouched
    //  next is null for tail
    if (node.next != null)
      node.next.prev = node.prev;
    // node becomes current head
    // previous is null, next is previous head
    node.prev = null;
    node.next = head;
    // previous head's previous is this node
    head.prev = node;
    // current node becomes head
    head = node;
  }

  public string GetAllItems() {
    // Using array probably for faster IO
    int[] res = new int[Count];
    ListNode current = head;
    int i = 0;
    while (current != null) { 
      res[i++] = current.key;
      current = current.next;
    }
    return string.Join(" ", res);
  }
}

class Solution {
  static void Main(String[] args) {
    string[] tokens = Console.ReadLine().Split();
    int N = int.Parse(tokens[0]);
    int S = int.Parse(tokens[1]);
    int pfCount = 0;    // page fault count

    LRU lruObj = new LRU();

    for (int T=N; T > 0; ) {
      tokens = Console.ReadLine().Split();
      T -= tokens.Length;

      for (int i=0; i<tokens.Length; i++) {
        int item = int.Parse(tokens[i]);
        ListNode pos = lruObj.find(item);

        if (pos == null) {
          if (lruObj.Count == S)
            lruObj.Dequeue();
          lruObj.Enqueue(item);
          pfCount++;
        }
        else
          lruObj.UpdateAsMRU(pos);
      }
    }
    Console.WriteLine(pfCount);
    Console.WriteLine(lruObj.GetAllItems());
  }
}

/*Debug Code:
Console.WriteLine("Step " + (i+1));
Console.WriteLine(lruObj.GetAllItems());

return "head: " + head.val + " tail: " + tail.val + "\r\n " + string.Join(" ", res);
*/

/* Priority Queue based implementation: 2017-08-18
 * Complexity  : O(n log n)
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
*   This version supercedes previous implementation of Priority Queue in
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
***************************************************************************/
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

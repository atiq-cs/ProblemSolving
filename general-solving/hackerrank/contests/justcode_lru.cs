/***************************************************************************
* Title       : LRU Cache
* URL         : https://www.hackerrank.com/contests/justcode/challenges/
*               lru-implementtion
* Occasion    : contests/justcode
* Date        : Aug 18, 2017
* Complexity  : O(n log n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Solved using 'Priority Queue' Data Structure. Lower number has
*   higher priority. We start assigning priority starting from int max value
*   while reading inputs and inserting them into the queue.
*   An item that appeared later has therefore higher priority as we decrease
*   priority value every time we insert an item.
*   In the contrary, we can start with min value and increment priority over
*   time. In that case, changing the conditional operator for comparing
*   priority will help.
* 
* Priority Queue Implementation for this problem:
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

* Modification: Due to the issue mentioned above I remove the last element
*               in the last line of 'ExtractMin' implementation          
*               
* meta        : tag-data-structure, tag-implementation, tag-priority-queue,
*   tag-heap, tag-LRU
***************************************************************************/
using System;
using System.Collections.Generic;

class LRUItem {
  public int Value;
  public int Priority;    // member used to resolve prirority
  public LRUItem(int key, int pr_val) { Value = key; Priority = pr_val; }
}

class PriorityQueue {
  private int heapSize;
  List<LRUItem> itemList;

  /* Use when necessary
  public List<LRUItem> GetItemList {
    get {
      return itemList;
    }
  }

  // not planning to use this one right now
  public PriorityQueue(List<LRUItem> nl) {
    heapSize = nl.Count;
    itemList = new List<LRUItem>();

    for (int i = 0; i < nl.Count; i++)
        itemList.Add(nl[i]);
  } */

  public PriorityQueue() {
    heapSize = 0;
    itemList = new List<LRUItem>();
  }

  public void Enqueue(LRUItem item) {  // requires public
    heapSize++;
    itemList.Add(item);
  }

  void exchange(int i, int j) {
    LRUItem temp = itemList[i];
    itemList[i] = itemList[j];
    itemList[j] = temp;
  }

  void heapify(int i) {
    int l = 2 * i + 1;
    int r = 2 * i + 2;
    int largest = -1;
    // '>' implies larger number will have higher priority
    if (l < heapSize && (itemList[l].Priority < itemList[i].Priority))
      largest = l;
    else
        largest = i;
    if (r < heapSize && (itemList[r].Priority < itemList[largest].Priority))
      largest = r;
    if (largest != i) {
      exchange(i, largest);
      heapify(largest);
    }
  }

  // called before extracting minimum
  public void buildHeap() {    // requires public
    for (int i = heapSize / 2; i >= 0; i--)
      heapify(i);
  }

  int heapSearch(LRUItem item) {
    for (int i = 0; i < heapSize; i++) {
        LRUItem aItem = itemList[i];
        if (item.Value == aItem.Value)
            return i;
    }
    return -1;
  }

  public int Count {
    get { return heapSize; }
  }

  public LRUItem elementAt(int i) {
    return itemList[i];
  }

  void heapSort() {
    int temp = heapSize;
    buildHeap();

    for (int i = heapSize - 1; i >= 1; i--) {
        exchange(0, i);
        heapSize--;
        heapify(0);
    }
    heapSize = temp;
  }

  public LRUItem extractMin() {
    if (heapSize < 1)
      return null;
    heapSort();
    exchange(0, heapSize - 1);
    heapSize--;
    LRUItem temp = itemList[heapSize];
    itemList.RemoveAt(heapSize);
    return temp;
  }

  public int find(LRUItem item) {
    return heapSearch(item);
  }
  public void updateKey(int index, LRUItem item) {
    if (itemList[index].Value == item.Value)
      itemList[index].Priority = item.Priority;
  }
}

  class Solution {
  static void Main(String[] args) {
    string[] tokens = Console.ReadLine().Split();
    int N = int.Parse(tokens[0]);
    int S = int.Parse(tokens[1]);

    PriorityQueue priority_queue = new PriorityQueue();
    int pr = int.MaxValue;
    int countPF = 0;

    for (int T=N; T > 0;) {
      tokens = Console.ReadLine().Split();
      T -= tokens.Length;
      for (int i=0; i<tokens.Length; i++) {
        int val = int.Parse(tokens[i]);
        LRUItem item = new LRUItem(val, pr--);
        int pos = priority_queue.find(item);
        if (pos == -1) {
          if (priority_queue.Count == S)
            priority_queue.extractMin();
          priority_queue.Enqueue(item);
          countPF++;
        }
        else
          priority_queue.updateKey(pos, item);
      }
    }

    // Not required
    // while (priority_queue.Count > S)
      // priority_queue.extractMin();

    int[] res = new int[priority_queue.Count];
    Console.WriteLine(countPF);
    for (int i=0; priority_queue.Count > 0; i++)
      res[i] = priority_queue.extractMin().Value;
    Array.Reverse(res);
    Console.WriteLine(string.Join(" ", res));
  }
}

/***************************************************************************************************
* Title : LRU Cache
* URL   : https://leetcode.com/problems/lru-cache/
* Date  : 2019-03-20
* Comp  : O(1), O(1) amortized
* Status: Accepted
* Notes : based on 'hackerrank/contests/justcode_lru.cs'
*   modifications:
*    prev implementation did not require storing key value pair but only keys
*    but for this problem we need that. Hence, we added another attribute named val and added that
*    required methods.
*    
*    ToDo: utilize OrderedDictionary (
*    https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.ordereddictionary)
*    like Mak
* meta  : tag-ds-linked-list, tag-ds-doubly-linked-list, tag-ds-hash-table, tag-ds-heap,
*   tag-ds-priority-queue, tag-algo-LRU-cache
***************************************************************************************************/
using System;

public class LRUCache {
  // probably cannot get memory refs if we use Generic LinkedList class
  Dictionary<int, ListNode> dict;
  ListNode head, tail;
  int capacity;

  public int Count { get; private set; }

  // represents a node in doubly linked list
  internal class ListNode {
    public int key { get; set; }
    public int val { get; set; }
    public ListNode prev { get; set; }
    public ListNode next { get; set; }

    public ListNode(int key, int val, ListNode prev, ListNode next) {
      this.prev = prev;
      this.next = next;
      this.key = key;
      this.val = val;
    }
  }

  public LRUCache(int capacity) {
    Count = 0;
    head = tail = null;
    dict = new Dictionary<int, ListNode>();
    this.capacity = capacity;
  }

  public int Get(int key) {
    if (dict.ContainsKey(key) == false)
      return -1;
    ListNode pos = dict[key];
    Console.WriteLine("Get calling MRU for " + key);
    Console.WriteLine("capacity " + capacity);
    UpdateAsMRU(pos);
    return pos.val;
  }

  public void Put(int key, int val) {
    ListNode pos = dict.ContainsKey(key) == false ? null : dict[key];

    if (pos == null) {
      if (Count == capacity)
        Dequeue();
      Enqueue(key, val);
    }
    else {
      pos.val = val;
      Console.WriteLine("calling MRU for " + key);
      UpdateAsMRU(pos);
    }
  }

  public void Enqueue(int key, int val) {
    ListNode newHead = new ListNode(key, val, null, head == null ? null : head);
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
  private void UpdateAsMRU(ListNode node) {
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
}

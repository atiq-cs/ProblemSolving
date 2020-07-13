/***************************************************************************************************
* Title : Copy List with Random Pointer
* URL   : https://leetcode.com/problems/copy-list-with-random-pointer/
* Date  : 2018-04-27
* Comp  : O(N)
* Status: Accepted
* Notes :
* meta  : tag-ds-linked-list, tag-recursion, tag-ds-hash-table, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  public RandomListNode CopyRandomList(RandomListNode head) {
    // linear copy list and build hashtable to provide mapping for old address to new address
    // pointer for old list
    RandomListNode oldCurrent = head;
    // pointers for new list
    RandomListNode newHead = null;
    RandomListNode current;
    RandomListNode previous = null;
    var refTable = new Dictionary<RandomListNode, RandomListNode>();    // reference Dictionary


    // Traverse the old list and create a copy (except random member)
    while (oldCurrent != null) {
      current = new RandomListNode(oldCurrent.label);
      if (newHead == null)
        newHead = current;
      else
        previous.next = current;
      refTable.Add(oldCurrent, current);
      oldCurrent = oldCurrent.next;
      previous = current;
    }

    // initialize again for traverse again through old and new List
    current = newHead;
    oldCurrent = head;
    while (current != null) {
      current.random = oldCurrent.random == null ? null : refTable[oldCurrent.random];
      current = current.next;
      oldCurrent = oldCurrent.next;
    }
    return newHead;
  }
}

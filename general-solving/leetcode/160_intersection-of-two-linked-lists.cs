/***************************************************************************
* Title : Intersection of Two Linked Lists
* URL   : https://leetcode.com/problems/intersection-of-two-linked-lists
* Date  : 2018-01
* Author: Atiq Rahman
* Comp  : O(n), O(1) for hashset lookup
* Status: Accepted
* Notes : Build hashset using one linked list, lookup for each node in the
*   other linked list. if found then that's the intersection
* meta  : tag-easy, tag-linked-list, tag-hash-table
***************************************************************************/
public class Solution {
  HashSet<ListNode> BuildHash(ListNode head) {
    HashSet<ListNode> hashListA = new HashSet<ListNode>();
    for (;  head != null; head = head.next)
      if (! hashListA.Contains(head))
        hashListA.Add(head);
    return hashListA;
  }
  
  public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
    HashSet<ListNode> hashListA = BuildHash(headA);
    
    for (ListNode current = headB; current != null; current = current.next)
      if (hashListA.Contains(current))
        return current;
    return null;
  }
}

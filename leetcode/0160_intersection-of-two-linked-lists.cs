/***************************************************************************
* Title : Intersection of Two Linked Lists
* URL   : https://leetcode.com/problems/intersection-of-two-linked-lists
* Date  : 2018-02-19
* Comp  : O(n+m), O(1)
* Status: Accepted
* Notes : Iterate through each of nodes in both linked lists
 *   if one of them becomes null advance the head of the other linked list so
 *   that it reaches the node from where remaning length in the list equal to
 *   length of the list for which iterator has become null.
 *   
 *   When both of them restarts iterating from equal length just check where
 *   they match.
 *   more desc, check comment in code block
 *   Ack: Aaron (JS meetup)
* meta  : tag-ds-linked-list, tag-ds-hash-table, tag-leetcode-easy
***************************************************************************/
public class Solution
{
  public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
    ListNode curA = headA;
    ListNode curB = headB;

    while (curA != curB) {
      // one of the iterators is null at this point, so keep advancing head of the other one till
      // the iterator becomes null so it offsets the hea properly from the point where both of the
      // heads are same distance from the intersection or the tail
      if (curA == null) {
        while ( curB != null ) {
          headB = headB.next;
          curB = curB.next;
        }
        curA = headA;
        curB = headB;
      }
      else if (curB == null) {
        while ( curA != null ) {
          headA = headA.next;
          curA = curA.next;
        }
        curA = headA;
        curB = headB;
      }
      // keep iterating
      else {
        if (curA != null)
          curA = curA.next;
        if (curB != null)
          curB = curB.next;
      }
    }
    return curA;
  }
}

/* My previous solution
 * 2018-01
 * Let,
 *  N = Length of List A
 *  M = Length of List B
 * Time Complexity O(N+M)
 * Space Complexity O(N); can be improved to O(Minimum(N,M))
 * Note: Build hashset using one linked list, lookup for each node in the
 *   other linked list. if found then that's the intersection
 */
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

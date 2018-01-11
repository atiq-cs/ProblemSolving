/***************************************************************************
* Title : Merge Two Sorted Lists
* URL   : https://leetcode.com/problems/merge-two-sorted-lists
* Date  : 2017-12
* Author: Atiq Rahman
* Comp  : O(n) n = number of digits
* Status: Accepted
* Notes : Doesn't use additional space; modifies original linked list
*   Carefully consider cases where a pointer to one of the lists might become
*   null. First one breaks down to,
*   
*   handling null cases
*   if l1 or l2 null then,
*   
*   if (l1 == null)
*     head = l2;
*   
*   if (l2 == null)
*     head = l1;
* meta  : tag-linked-list, tag-data-structure
***************************************************************************/
public class Solution {
  public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
    ListNode head = null;
    // if linked list 1's head is null or value greater than second one's
    if ((l1 == null && l2 != null) || (l1 != null && l2 != null && l1.val >
      l2.val)) {
      head = l2;
      l2 = l2.next;
    } else if ((l1 != null && l2 == null) || (l1 != null && l2 != null)) {
      head = l1;
      l1 = l1.next;
    }
    
    ListNode current = head;
    // iterate over both lists and keep adding
    while(l1 != null || l2 != null) {
      if ((l1 == null && l2 != null) || (l1 != null && l2 != null && l1.val >
        l2.val)) {
        current.next = l2;
        l2 = l2.next;
      } else if ((l1 != null && l2 == null) || (l1 != null && l2 != null)) {
        current.next = l1;
        l1 = l1.next;
      }
      current = current.next;
      /* can put a check here for early termination if one of the linked list
       * pointer goes null */
    }
    if (current != null)
      current.next = null;
    
    return head;
  }
}

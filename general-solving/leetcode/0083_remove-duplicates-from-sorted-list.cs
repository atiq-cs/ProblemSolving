/***************************************************************************
* Title : Remove Duplicates from Sorted List
* URL   : https://leetcode.com/problems/remove-duplicates-from-sorted-list
* Date  : 2018-01
* Author: Atiq Rahman
* Comp  : O(n) n = number of nodes in the list
* Status: Accepted
* Notes : Maintain a previous till which no duplication happened
* meta  : tag-easy, tag-linked-list
***************************************************************************/
public class Solution {
  public ListNode DeleteDuplicates(ListNode head) {
    ListNode current = head;
    ListNode previous = null;

    while (current != null) {
      if (previous != null && previous.val == current.val)
        previous.next = current.next;
      else
        previous = current;
      current = current.next;
    }
    return head;
  }
}

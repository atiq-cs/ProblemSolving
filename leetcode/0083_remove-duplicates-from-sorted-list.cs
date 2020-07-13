/***************************************************************************
* Title : Remove Duplicates from Sorted List
* URL   : https://leetcode.com/problems/remove-duplicates-from-sorted-list
* Date  : 2018-01
* Comp  : O(n) where n = number of nodes in the list, O(1)
* Status: Accepted
* Notes : Use a previous pointer to track till which no duplication happened
* meta  : tag-ds-linked-list, tag-leetcode-easy
***************************************************************************/
public class Solution {
  public ListNode DeleteDuplicates(ListNode head) {
    ListNode current = head;
    ListNode previous = null;

    do
      if (previous != null && previous.val == current.val)
        previous.next = current.next;
      else
        previous = current;
    while((current = current?.next) != null);

    return head;
  }
}

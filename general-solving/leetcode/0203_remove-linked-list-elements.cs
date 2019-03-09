/***************************************************************************************************
* Title : Remove Linked List Elements
* URL   : https://leetcode.com/problems/remove-linked-list-elements/
* Date  : 2015-01-05
* Comp  : O(N)
* Author: Atiq Rahman
* Status: Accepted
* Notes : has to remove all elements equal to the value
* meta  : tag-ds-linked-list, tag-company-staffing, tag-leetcode-easy
***************************************************************************************************/
public class Solution {
  public ListNode RemoveElements(ListNode head, int val) {
    ListNode current = head, previous = null;

    // find the node that has value as val
    while (current != null) {
      while (current != null) {
        if (current.val == val)
          break;
        previous = current;
        current = current.next;
      }
      // found the val in current node
      if (current != null) {
        // value found in first node, there is no previous
        if (previous != null)
          previous.next = current.next;
        else
          head = current.next;
        current = current.next;
      }
    }
    return head;
  }
}

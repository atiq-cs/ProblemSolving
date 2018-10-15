/***************************************************************************************************
* Title : Odd Even Linked List
* URL   : https://leetcode.com/problems/odd-even-linked-list/
* Date  : 2016-01-16
* Comp  : O(n) Time
* Author: Atiq Rahman
* Status: Accepted
* Notes : We use two pointers to keep track of the tail of odd nodes and
*   the the tail of even nodes
*    oddtail - points to first item initially
*    eventail - points to second item initially
*   when an odd node is encountered it is inserted between oddtail
*   and eventail
*   when an eventail is encountered
* ref   : leetcode discussion
* meta  : tag-linked-list
***************************************************************************************************/
public class Solution
{
  public ListNode OddEvenList(ListNode head) {
    if (head==null || head.next==null)
      return head;
    ListNode oddtail = head;
    ListNode eventail = oddtail.next;
    ListNode current = eventail.next;
    bool isOdd = true;
    while (current != null) {
      if (isOdd) {
        // put current right after oddtail
        eventail.next = current.next;
        current.next = oddtail.next;
        oddtail.next = oddtail = current;
        current = eventail.next;
        isOdd = false;
      }
      else {
        // put current right after eventail and update eventail
        //eventail.next = current;  // not required as odd case already fixes this
        eventail = current;
        current = current.next;
        isOdd = true;
      }
    }
    return head;
  }
}

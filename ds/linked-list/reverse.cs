/***************************************************************************
* Title : Reverse a Linked List
* URL   : https://leetcode.com/problems/two-sum-iv-input-is-a-bst
* Date  : 2018-06
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : These problem has easy testcases I guess.
*   This solution will hit null pointer exception: NullReferenceException
*   when an empty or null tree is passed, i.e, []
*   [1] will work because left, right both pointing at that node and value at
*   left node won't be less than value at right node.
* Rel   : 'leetcode/167_two-sum-ii-input-array-is-sorted.cs'
* meta  : tag-leetcode-easy, tag-two-pointers, tag-binary-tree, tag-successor,
*   tag-predecessor
***************************************************************************/
// recursive
public class Solution {
  ListNode gHead=null; 		// global head, class member
  public ListNode ReverseList(ListNode head)
  {
    RecReverse(head);
    if (head != null)
      head.next = null;
    return gHead;
  }

  public void RecReverse(ListNode head)
  {
    if (head == null) return ;
    if (head.next == null) { gHead = head; return ; }
    RecReverse(head.next);
    // Reverse link safely. We can perform such change on link here because at
    // this point, all of the nodes till this one is already in stack. We won't
    // lose our previous nodes we change next pointer, we will still retrieve
    // previous nodes when function returns to caller
    head.next.next = head;
  }

  // first version: iterative
  ListNode ReverseList(ListNode head) {
    ListNode current = head;
    ListNode prev = null;

    while (current != null) {
      // save current's next because we are gonna move this pointer/refreence forward
      ListNode temp = current.next;
      // reverse current's next pointer
      current.next = prev;
      // move forward previous pointer
      prev = current;
      // move forward current's next pointer
      current.next = prev;  
    }
	  return prev;
  }
}

/* Consider following example for this recursive solution,
 3 -> 4 -> 5

previous node variable = null;

During first iteration,
head = 3
 current = 3
 head = 4 (next of 3)
 3 's next set to null
 previous = 3

on second iteration,
 current = 4
 head = 5
 4's next set to 3
 previous = 4

3rd iteration gives,
 current = 5
 head = null
 current's next set to 4
 previous = 5
*/

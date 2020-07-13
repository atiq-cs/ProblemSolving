/***************************************************************************************************
* Title : Palindrome Linked List
* URL   : https://leetcode.com/problems/palindrome-linked-list
* Date  : 2018-02-19
* Author: Atiq Rahman
* Comp  : Time O(N)
*   Worst case space complexity on the recursion stack O(N) *
* Status: Accepted
* Notes : To simplify, how do we validate the palindrome if the parameter
*   was string instead of Linked List?
*   May be compare characters using two iteration variables one from beginning
*   and other one from the end of the string.
*
*   This is a recursive (uses stack) solution implements similar idea for an
*   input linked list without using additional space.
*   We can utilize the recursion stack as in
*   'leetcode/206_reverse-linked-list_recursive.cs'
*   That takes care of the iteration variable 'end'
*   We need another iteration variable start that point to the nodes starting
*   from the head of the list and advances one step each time.
*   
*   * The stack contains all nodes of the list during the last recursion call.
* meta  : tag-ds-linked-list, tag-recursion, tag-string-palindrome, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  private ListNode start;

  public bool IsPalindrome(ListNode head) {
    start = head;
    return IsPalindromeRec(head);
  }
  
  public bool IsPalindromeRec(ListNode end) {
    if (end == null)
      return true;
    if (! IsPalindromeRec(end.next))
      return false;
    // after the last recursion call end variable contains the last node
    // (to simplify explanation, ignoring the last call where end = null)
    if (start != null) {
      if (start.val != end.val)
        return false;
      start = start.next;
    }
    return true;
  }
}

/***************************************************************************************************
* Title : Add Two Numbers
* URL   : https://leetcode.com/problems/add-two-numbers
* Date  : 2015-01-11
* Comp  : O(n+m) Time and Space; constant space if we are provided with n+m space for result
* Status: Accepted
* Notes : A mistake was not to add following line,
*   r = r.next;
*   Inspirted by leetcode forum discussion
* meta  : tag-ds-linked-list
***************************************************************************************************/
public class Solution {
  public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
    ListNode rHead=null, r=null;
    int c = 0;
    
    while (l1 != null || l2 != null || c==1) {
      int d = (l1==null? 0 : l1.val) + (l2==null? 0 : l2.val) + c;

      if (d>9) {
        c = 1;
        d -= 10;
      }
      else
        c = 0;

      // first time iteration: r is null as initialized
      // during every other time of iteration r points to the last node of the
      // list
      if (r == null)
        rHead = r = new ListNode(d);
      else {
        r.next = new ListNode(d);
        r = r.next;
      }

      if (l1 != null)
        l1 = l1.next;

      if (l2 != null)
        l2 = l2.next;
    }
    return rHead;
  }
}

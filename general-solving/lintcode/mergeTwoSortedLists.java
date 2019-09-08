/***************************************************************************************************
* URL   : https://www.lintcode.com/problem/merge-two-sorted-lists
* Author: Tianshu Bao (tianshubao1), commit#0d208d5a0
* Date  : 2015-06-01
* Status: Accepted
***************************************************************************************************/
class Solution {
  /**
   * @param ListNode l1 is the head of the linked list
   * @param ListNode l2 is the head of the linked list
   * @return: ListNode head of linked list
   */
  public ListNode mergeTwoLists(ListNode l1, ListNode l2) {
    ListNode dummy = new ListNode(0);
    ListNode head = dummy;
    
    while(l1 != null && l2 != null){
      if(l1.val < l2.val){
        head.next = l1;
        l1 = l1.next;
      }
      else{
        head.next = l2;
        l2 = l2.next;
      }
      head = head.next;
    }
    
    if(l1 != null)
      head.next = l1;
    else
      head.next = l2;
      
    return dummy.next;
  }
}

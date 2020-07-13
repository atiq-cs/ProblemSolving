/***************************************************************************************************
* URL   : remove-duplicates-from-sorted-list
* Author: Tianshu Bao (tianshubao1), commit#f8f10a742
* Date  : 2015-06-01
***************************************************************************************************/
public class Solution {
  /**
   * @param ListNode head is the head of the linked list
   * @return: ListNode head of linked list
   */
  public static ListNode deleteDuplicates(ListNode head) {
    if(head == null)
      return null;
      
    ListNode node = head;
    
    while(node.next != null){
      if(node.val == node.next.val)
        node.next = node.next.next;
      else node = node.next;
    }
    return head;
  }  
}

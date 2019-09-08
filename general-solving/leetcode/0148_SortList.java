/***************************************************************************************************
*   Sort a linked list in O(n log n) time using constant space complexity.
***************************************************************************************************/
package linkedList;

import dataStructures.ListNode;
public class SortList {
  private ListNode findMiddle(ListNode head) {
    if(head == null) return head;
    
    ListNode slow = head, fast = head.next;
    while(fast != null && fast.next != null) {
      fast = fast.next.next;
      slow = slow.next;
    }
    return slow;
  }
  
  private ListNode merge(ListNode left, ListNode right) {
    ListNode dummy = new ListNode(0);
    ListNode end = dummy;
    
    while(left != null && right != null) {
      if(left.val < right.val) {
        end.next = left;
        left = left.next;
      } else {
        end.next = right;
        right = right.next;
      }
      end = end.next;
    }
    
    if(left == null) {
      end.next = right;
    } else {
      end.next = left;
    }

    return dummy.next;
  }

  public ListNode sortList(ListNode head) {
    if(head == null || head.next == null) {
      return head;
    }
    
    ListNode mid = findMiddle(head); // find the middle node
    
    ListNode right = sortList(mid.next); 
    mid.next = null;
    ListNode left = sortList(head);
    
    return merge(left, right);  
  }
}

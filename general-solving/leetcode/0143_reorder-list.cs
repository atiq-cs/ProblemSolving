/***************************************************************************************************
* Title : Reorder List
* URL   : https://leetcode.com/problems/reorder-list/
* Date  : 2015-10-11
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Look after source code for detail analysis of the solution
*   Runtime won't be good; purpose is recursion instead of improving execution time.
*   For better execution time replace recursion with stack
*   Innoworld, some guy going for fb int, did it by reversing the rest I think..
* meta  : tag-recursion, tag-ds-linked-list, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  ListNode currentNode;
  
  public void ReorderList(ListNode head) {
    currentNode = head;
    reorderListRec(head);
  }

  void reorderListRec(ListNode head) {
    if (head == null)
      return ;
    reorderListRec(head.next);
    if (currentNode == null)
      return ;

    head.next = currentNode.next;
    currentNode.next = head;
    
    if (head.next == head)
      head.next = null;
    currentNode = head.next;     // send the current node to next
  }
}

/*
After line 26, recursive calls return flow:
will return in following order
  nth node
  (n-1)-th node
  (n-2)-th node
....
  first node
  for null value of head code does not reach line 30

input: l_0, l_1, l_2, ..... l_n
output: l_0, l_n, l_1, l_{n-1}, l2, l_{n-2} .....

We insert the ln-i node between ith node and (i+1)th node
how do we get to ln-i ?

link like this
l0.next = ln
ln.next = l1

naive implementation and call analysis
reorderListRec (1)
  cur = 1

reorderListRec (2)
  cur 2
  3.next = 2.next = 
  2.next = 3

reorderListRec (3)
  cur = 1
  t = 1.next = 2
  1.next = 3
  3.next = t
  cur = t = 2

reorderListRec (3)
  cur =2
  ... 2->3->3
  head.next = currentNode.next;
  3.next = 3
  currentNode.next = head;
  2.next = 3
  currentNode = head.next;   // send the current node to next
  
reorderListRec (4)
  cur = 1
  1->4->2->3->4...

** comment on line 31
  How can we know we reached the last node?
  First time we insert the last node in between the first two
  for example, consider input 1->2->3->4
  4 is inserted in between 1 and 2
  1->4->2
  We know that 3 was the last node. But we do not have access to 3.
  Therefore, we keep the link as it is. So, it becomes,
  1->4->2->3->4..
  This looks messy..
  However, for the last node we try to insert we face interesting scenerio.
  For example, we are inserting 3 in between 2 -> 3
  2.next = 3
  3.next (3 we got from recursion call) is also 3
  In this case we set next of last node (3) to null.
       
  We do not need to know whether there are even number of items or odd whether we reached the middle.
  For example this is unnecessary,
    if (ReorderComplete || currentNode == null)
    return ;
    if (currentNode == head) {
    ReorderComplete = true;
    head.next = null;   // important
    return ;
    }
*/

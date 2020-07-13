/****************************************************************************
* Title : Swap Nodes in Pairs
* URL   : https://leetcode.com/problems/swap-nodes-in-pairs
* Date  : 2017-09-22
* Comp  : O(n)
* Status: Accepted
* Notes : Naive approach (using additional linked list) would be,
*   - Iterate through each node of original linked list
*   - save the first one of every pair in a temp variable
*   - push the current node into the linked list and the temp one as
*   well into linked list 2.
*   In the end, if temp variable contains a node, we push that to the end of the linked list.
*   
*   Approach 2 (constant space):
*   Manipulate/remove link/rejoin pointers since restriction of constant space.
*   Consider 3 nodes while iterating through the entire list: node0, node1, node2
*   Why node0 or 3 nodes?
*    Because, previous to node1's next pointer needs to be updated.
*    
*   while loop does the iteration from line 39 to line 60. nodeCount is used detect every pair of
*   nodes.
*
*   Order of nodes, node0 -> node1 -> node2 -> current
*   To make swap of two adjacent in effect, we update node2's next to node1, node1's next to current
*
*   In doing that maintain 3 pointers: node0, node1, node2. next pointer of node1 and node2 are
*   rewired node0 is the previous node of node1 and node2 where the swap happened.
* meta  : tag-ds-linked-list, tag-two-pointers, tag-leetcode-medium
***************************************************************************/
public class Solution
{
  public ListNode SwapPairs(ListNode head) {    // approach 2
    ListNode current = head;
    int nodeCount = 0;
    ListNode node0, node1, node2;
    node0 = node1 = node2 = null;

    do {
      if (nodeCount == 2) {
        if (node0 == null)
          head = node2;
        else
          node0.next = node2;
        node2.next = node1;
        node1.next = current;
        nodeCount = 0;
        node0 = node2;
      }
      else {
        node0 = node1;
        node1 = node2;
      }

      node2 = current;
      nodeCount++;
    } while ((current = current?.next) != null || nodeCount == 2);

    return head;
  }
}

/*
earlier version:
  while (true) {
    if (nodeCount == 2) {
      if (node0 == null)
        head = node2;
      else
        node0.next = node2;
      node2.next = node1;
      node1.next = current;
      nodeCount = 0;
      node0 = node2;
    }
    else {
      node0 = node1;
      node1 = node2;
    }

    if (current == null)
      break;
    node2 = current;
    current = current.next;
    nodeCount++;
  }

*/

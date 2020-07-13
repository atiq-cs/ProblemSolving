/***************************************************************************
* Title : Convert Sorted List to Binary Search Tree
* URL   : https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree
* Date  : 2018-01-01
* Author: Atiq Rahman
* Comp  : O(n * n)
* Status: Accepted
* Notes : Similar to mentioned related problem. However,
*   Setting the value of root which is retrived by accessing A[mid] is replaced
*   by a seek in the linked list
* rel  : https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree
* meta  : tag-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************/
public class Solution
{
  public TreeNode SortedListToBST(ListNode head) {
    if (head == null)
      return null;
    int n = GetLinkedListLength(head);
    return SortedListToBSTRec(head, 0, n-1);
  }
  
  private int GetLinkedListLength(ListNode head) {
    ListNode current = head;
    int i=0;
    for (; current != null; i++)
      current = current.next;
    return i;
  }
  
  // find the offset needs to be seeked from start (head) and perform the seek
  private ListNode GetMiddleItem(ListNode head, int start, int end) {
    int midOffset = (end - start) / 2;
    ListNode midNode = head;
    for (int i=0; i < midOffset; i++ )
      midNode = midNode.next;
    return midNode;
  }
  
  // head = original head + start
  // this head is in parameter to improve seek time
  private TreeNode SortedListToBSTRec(ListNode head, int start, int end) {
    if (start > end)
      return null;
    int mid = (start + end) / 2;
    ListNode midItem = GetMiddleItem(head, start, end);
    TreeNode root = new TreeNode(midItem.val);
    root.left = SortedListToBSTRec(head, start, mid-1);
    root.right = SortedListToBSTRec(midItem.next, mid+1, end);
    return root;
  }
}

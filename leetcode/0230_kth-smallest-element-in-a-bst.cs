/***************************************************************************
* Title : Kth Smallest Element in a BST
* URL   : https://leetcode.com/problems/kth-smallest-element-in-a-bst
* Date  : 2018-05-13
* Author: Atiq Rahman
* Comp  : O(n), O(n) stack space
* Status: Accepted
* Notes : Inorder traversal gives us sorter order for a BST. Because the items
*   are sorted we can check consecutive items and decrement k each time.
*   We need to check equality if there are duplicate values kinda similar to
*   the ref.
*   Why is it tagged medium?
*   Easy if you know BSt.
* rel   : 'general-solving/leetcode/501_find-mode-in-binary-search-tree.cs'
* meta  : tag-ds-BST, tag-leetcode-medium
***************************************************************************/
public class Solution {
  private int k, val;

  public int KthSmallest(TreeNode root, int k) {
    this.k = k;
    InOrder(root);
    return val;
  }
  
  private void InOrder(TreeNode root) {
    if (root == null)
      return;
    InOrder(root.left);    
    if (--k == 0)
      val = root.val;    
    InOrder(root.right);
  }
}

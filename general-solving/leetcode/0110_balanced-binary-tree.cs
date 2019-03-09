/***************************************************************************************************
* Title : Balanced Binary Tree
* URL   : https://leetcode.com/problems/balanced-binary-tree/
* Date  : 2015-08-15
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
* meta  : tag-ds-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public bool IsBalanced(TreeNode root) {
    if (root == null)
      return true;
    if (IsBalanced(root.left) == false || IsBalanced(root.right) == false)
      return false;
    if (Math.Abs(getMaxDepth(root.left) - getMaxDepth(root.right)) <= 1)
      return true;
    return false;
  }

  private int getMaxDepth(TreeNode root) {
    if (root == null)
      return 0;
    return Math.Max(getMaxDepth(root.left), getMaxDepth(root.right)) + 1;
  }
}

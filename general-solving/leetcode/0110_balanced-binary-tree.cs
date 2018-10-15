/***************************************************************************************************
* Title : Balanced Binary Tree
* URL   : https://leetcode.com/problems/balanced-binary-tree/
* Date  : 2015-08-15
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
* meta  : tag-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public bool IsBalanced(TreeNode root) {
    if (root == null)
      return true;
    if (IsBalanced(root.left) == false || IsBalanced(root.right) == false)
      return false;
    if (Math.Abs(get_maxdepth(root.left) - get_maxdepth(root.right)) <= 1)
      return true;
    return false;
  }

  private int get_maxdepth(TreeNode root) {
    if (root == null)
      return 0;
    return Math.Max(get_maxdepth(root.left), get_maxdepth(root.right)) + 1;
  }
}

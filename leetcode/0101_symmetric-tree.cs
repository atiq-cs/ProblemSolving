/***************************************************************************************************
* Title : Symmetric Tree
* URL   : https://leetcode.com/problems/symmetric-tree/
* Date  : 2015-08-05
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes :  First version,
*   If one of them is null and other one not then the tree is not symmetric - line 17-18
*   if the value at that point does not match then it is not symmetric - line 21-22
*   Now check the properties whether holds similarly for left's left and right's right
*   also for left's right and right's left
* rel   : https://leetcode.com/problems/same-tree/
* meta  : tag-ds-binary-tree
***************************************************************************************************/
public class Solution
{
  public bool IsSymmetric(TreeNode root) {
    return IsSymmetric_rec(root, root);
  }

  bool IsSymmetric_rec(TreeNode root_left, TreeNode root_right) {
    if (root_left == null || root_right == null)
      return root_left==root_right;
      
    if (root_left.val != root_right.val)
      return false;

    return IsSymmetric_rec(root_left.left, root_right.right) && IsSymmetric_rec(root_left.right,
      root_right.left);
  }

  /* First version is presented below */
  bool IsSymmetric_rec(TreeNode root_left, TreeNode root_right) {
    if (root_left == null && root_right == null)
      return true;

    if (root_left == null && root_right != null)
      return false;

    if (root_left != null && root_right == null)
      return false;

    if (root_left.val != root_right.val)
      return false;

    if (IsSymmetric_rec(root_left.left, root_right.right) == false)
      return false;
    if (IsSymmetric_rec(root_left.right, root_right.left) == false)
      return false;
    return true;
  }
}

/***************************************************************************************************
* Title : Invert children of Binary Tree
* URL   : https://leetcode.com/problems/invert-binary-tree/
* Date  : 2015-07-22
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Simple and beatiful recursion
*   No library Swap function, have put on in utils
* rel   : http://www.lintcode.com/en/problem/invert-binary-tree/
*         https://www.hackerrank.com/challenges/swap-nodes-algo
* meta  : tag-binary-tree, tag-recursion, tag-company-microsoft, tag-interview-onsite,
*   tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  // last version
  public TreeNode InvertTree(TreeNode root) {
    if (root == null)
      return null;
    InvertTree(root.left);
    InvertTree(root.right);
    Swap<TreeNode>(ref root.left, ref root.right);
    return root;
  }

  // first version
  public TreeNode InvertTree(TreeNode root) {
    if (root == null)
      return root;
    Swap<TreeNode>(ref root.left, ref root.right);
    InvertTree(root.left);
    InvertTree(root.right);
    return root;
  }
}

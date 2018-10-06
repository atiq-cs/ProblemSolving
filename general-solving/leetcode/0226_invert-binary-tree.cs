/***************************************************************************
*	Problem Name:	Invert children of Binary Tree
*	Problem URL :	https://leetcode.com/problems/invert-binary-tree/
*               http://www.lintcode.com/en/problem/invert-binary-tree/
*               https://www.hackerrank.com/challenges/swap-nodes-algo
*	Date        :	2015-07-22
*	Algo, DS    :	Binary Tree, Recursion
*	Desc        :	Simple and beatiful recursion
*
*	Complexity  : O(n)
* Author      :	Atiq Rahman
* Status      : Accepted
*	Notes       : No library Swap function, have put on in utils
*	meta        : tag-binary-tree, tag-recursion, tag-microsoft, tag-onsite
***************************************************************************/
/*
* Definition for a binary tree node.
* public class TreeNode {
*     public int val;
*     public TreeNode left;
*     public TreeNode right;
*     public TreeNode(int x) { val = x; }
* }
*/

public class Solution {
  // last version
  public TreeNode InvertTree(TreeNode root)
  {
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

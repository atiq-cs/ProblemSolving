/***************************************************************************************************
* Title : Determines if given string has some properties
* URL   : https://leetcode.com/problems/maximum-depth-of-binary-tree/
* rel   : https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree
*   http://www.lintcode.com/en/problem/maximum-depth-of-binary-tree/
*   
* Date  : 2015-08-07
* Notes : Recursion on Binary Tree
*   Maximum depth is the max of depth from the children
*   Domain- data-structures/trees
* Comp  : O(n), .008s
* Author: Atiq Rahman
* Status: Accepted
* meta  : tag-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public int MaxDepth(TreeNode root) {
    if (root == null)
      return 0;
    return Math.Max(MaxDepth(root.left)+1, MaxDepth(root.right)+1);
  }
}

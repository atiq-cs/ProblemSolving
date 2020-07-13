/***************************************************************************************************
* Title : Determines if given string has some properties
* URL   : https://leetcode.com/problems/maximum-depth-of-binary-tree/
* Date  : 2015-08-07
* Comp  : O(n), O(lg N) stack
*   
* Status: Accepted
* Notes : Recursion on Binary Tree
*   Maximum depth is the max of depth from the children
*   Domain- data-structures/trees
* rel   : https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree
*   http://www.lintcode.com/en/problem/maximum-depth-of-binary-tree/
* meta  : tag-ds-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public int MaxDepth(TreeNode root) {
    return root == null ? 0 : Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
  }
}

/***************************************************************************
* Title : Find the minimum depth of a binary tree
* URL   : https://leetcode.com/problems/minimum-depth-of-binary-tree/
* Date  : 2015-07-22
* Author: Atiq Rahman
* Comp  : O(lg N)
* Status: Accepted
* Notes : Consider the case when left or right child does not exist.
*   We cannot take 0 as minimum height for those left/right sides, to ignore
*   those we use Math.Max
*
* rel   : http://www.lintcode.com/en/problem/minimum-depth-of-binary-tree/
* meta  : tag-ds-binary-tree, tag-recursion, tag-graph-dfs, tag-graph-bfs, tag-leetcode-easy
***************************************************************************/
public class Solution {
  public int MinDepth(TreeNode root)
  {
    if (root == null)
      return 0;

    if (root.left == null || root.right == null)
      return Math.Max(MinDepth(root.left), MinDepth(root.right)) + 1;
    
    return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
  }
}

/***************************************************************************
* Title : Count Complete Tree Nodes
* URL   : https://leetcode.com/problems/count-complete-tree-nodes
* Date  : 2018-05-10
* Author: Atiq Rahman
* Comp  : O(lg n)
* Status: Accepted
* Notes : Count number of nodes in complete binary tree. Do better than O(N)
*   From C.L.R.S (possibly),
*   A complete binary tree is a binary tree which is filled except possibly the
*   last/bottom level, which is filled from left to right.
* 
*   From a node, check strictly left side and check strictly right side. If
*   heights match then we found a perfect binary tree for which the count is
*   2^(h+1) - 1. Otherwise, we apply similar approach to sum of the count for
*   left subtree and right subtree.
*   
* Ack   : Initial idea, Kevin Huang
* Ref   : https://atiqcs.wordpress.com/2017/11/21/binary-tree-jargon/
* meta  : tag-binary-tree, tag-leetcode-medium
***************************************************************************/
public class Solution {
  // final version
  public int CountNodes(TreeNode root) {
    if (root == null)
      return 0;
    int lh = GetHeight(root.left);
    int rh = GetHeight(root.right, false);
    if (lh == rh)
      return (int) Math.Pow(2, lh+1)-1;
    return CountNodes(root.left) + CountNodes(root.right) + 1;
  }
  
  private int GetHeight(TreeNode root, bool isLeft=true) {
    if (root == null)
      return 0;
    return GetHeight(isLeft?root.left:root.right, isLeft) + 1;
  }

  // first version: O(N) - TLE
  public int CountNodes_v1(TreeNode root) {
    if (root == null)
      return 0;
    return CountNodes(root.left) + CountNodes(root.right) + 1;
  }
}
/*
Example,
[1]
[1,2,3]
[1,2,3,4,5,6]
*/

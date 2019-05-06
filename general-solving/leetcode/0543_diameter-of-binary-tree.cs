/***************************************************************************
* Title : Diameter of Binary Tree
* URL   : https://leetcode.com/problems/diameter-of-binary-tree
* Date  : 2018-04
* Author: Atiq Rahman
* Comp  : O(N)
* Status: Accepted
* Notes : Consider 3 options we have in each node
*   1. Height of the left subtree
*   2. Height of the right subtree
*   3. Combined height to get the diameter (+2 because current node adds 1 on
*   each side)
* meta  : tag-ds-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************/
public class Solution {
  public int DiameterOfBinaryTree(TreeNode node) {
    if (node == null)
      return 0;
    return Math.Max(height(node.left) + height(node.right) + 2, Math.Max(
      DiameterOfBinaryTree(node.left), DiameterOfBinaryTree(node.right)));
  }

  // can be improved much by memoization
  private int height(TreeNode root) {
    if (root == null)
      return -1;
    return Math.Max(height(root.left), height(root.right)) + 1;
  }
}

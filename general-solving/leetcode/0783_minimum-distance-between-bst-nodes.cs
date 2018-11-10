/***************************************************************************************************
* Title : Minimum Distance Between BST Nodes
* URL   : https://leetcode.com/problems/minimum-distance-between-bst-nodes
* Date  : 2018-07 (first met in Inno World Meetup a few weeks back)
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : 
* rel   : 'leetcode/0098_validate-binary-search-tree.cs'
* meta  : tag-leetcode-easy, tag-binary-tree, tag-recursion, tag-inorder
***************************************************************************************************/
public class Solution
{
  private int minDiff = int.MaxValue;
  TreeNode prev = null;

  public int MinDiffInBST(TreeNode root) {
    if (root == null) return minDiff;
    MinDiffInBST(root.left);

    if (prev != null)
      minDiff = Math.Min(minDiff, root.val - prev.val);

    prev = root;
    MinDiffInBST(root.right);
    return minDiff;
  }
}

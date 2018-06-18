/***************************************************************************
* Title : Lowest Common Ancestor of a Binary Tree
* URL   : https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree
* Date  : 2015-08
* Author: Atiq Rahman
* Comp  : 
* Status: Accepted
* Notes : 
* Ref   : http://www.geeksforgeeks.org/lowest-common-ancestor-binary-tree-set-1/
* meta  : tag-leetcode-medium, tag-binary-tree, tag-lca
***************************************************************************/
public class Solution {
  public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
    if (root == null || root == p || root ==q)
      return root;

    TreeNode left_lca = LowestCommonAncestor(root.left, p, q);
    TreeNode right_lca = LowestCommonAncestor(root.right, p, q);

    return left_lca == null? right_lca: right_lca == null ? left_lca: root;
    // or we could, return (left_lca != null && right_lca != null) ? root :
    // left_lca == null? right_lca: right_lca;
  }
}

/***************************************************************************
* Title : Lowest Common Ancestor of a Binary Tree
* URL   : https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree
* Date  : 2015-08
* Author: Atiq Rahman
* Comp  : O(N), O(1), O(lg N) on Stack
* Status: Accepted
* Notes : 
* Ref   : http://www.geeksforgeeks.org/lowest-common-ancestor-binary-tree-set-1/
* meta  : tag-leetcode-medium, tag-binary-tree, tag-lca
***************************************************************************/
public class Solution {
  public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
    if (root == null || root == p || root == q)
      return root;

    var leftLCA = LowestCommonAncestor(root.left, p, q);
    var rightLCA = LowestCommonAncestor(root.right, p, q);
    return leftLCA == null ? rightLCA : rightLCA == null ? leftLCA : root;
    // or we could, return (left_lca != null && right_lca != null) ? root :
    // left_lca == null? right_lca: right_lca;
  }
}

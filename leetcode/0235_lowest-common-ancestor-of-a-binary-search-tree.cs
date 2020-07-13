/***************************************************************************************************
* Title : Lowest Common Ancestor of a Binary Search Tree
* URL   : leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree
* Date  : 2015-08-02
* Comp  : O(n) Time
* Author: Atiq Rahman
* Status: Accepted (20ms time improvement when reference is used)
* Notes : This is the first version developed. This problem specifies BST
*   as input. However, it does not matter for our solution.
*   Second version: 'leetcode/0236_lowest-common-ancestor-of-a-binary-tree.cs'
* meta  : tag-lca, tag-ds-binary-tree, tag-ds-bst, tag-recursion, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
    return LowestCommonAncestor_rec(root, ref p.val, ref q.val);
  }

  // first version
  public TreeNode LowestCommonAncestor_rec(TreeNode root, ref int n1, ref int n2)
  {
    if (root == null || root.val == n1 || root.val == n2)
      return root;

    TreeNode left_lca = LowestCommonAncestor_rec(root.left, ref n1, ref n2);
    TreeNode right_lca = LowestCommonAncestor_rec(root.right, ref n1, ref n2);

    if (left_lca != null && right_lca != null) return root;
    return (left_lca != null) ? left_lca : right_lca;
  }

  // second version at '0236_lowest-common-ancestor-of-a-binary-tree.cs' based
  // on geeksforgeeks cpp version
}

/***************************************************************************
* Problem Name: Lowest Common Ancestor of a Binary Search Tree
* Problem URL : https://leetcode.com/problems/largest-number/
* Date        : Aug 2 2015
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted (20ms time improvement when reference is used)
* Notes       : ref: http://www.geeksforgeeks.org/lowest-common-ancestor-binary-tree-set-1/
* meta        : tag-lca
***************************************************************************/

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        return LowestCommonAncestor_rec(root, ref p.val, ref q.val);
    }

    public TreeNode LowestCommonAncestor_rec(TreeNode root, ref int n1, ref int n2)
    {
        if (root == null)
            return root;
        if (root.val == n1 || root.val == n2)
            return root;

        TreeNode left_lca = LowestCommonAncestor_rec(root.left, ref n1, ref n2);
        TreeNode right_lca = LowestCommonAncestor_rec(root.right, ref n1, ref n2);

        if (left_lca != null && right_lca != null) return root;
        return (left_lca != null) ? left_lca : right_lca;
    }
}

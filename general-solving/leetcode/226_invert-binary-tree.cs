/***************************************************************************
*	Problem Name:	Invert children of Binary Tree
*	Problem URL :	https://leetcode.com/problems/invert-binary-tree/
                    http://www.lintcode.com/en/problem/invert-binary-tree/
*	Date        :	July 22, 2015
*
*	Algo, DS    :	Binary Tree, Recursion
*	Desc        :	Simple and beatiful recursion
*
*	Complexity  :   O(n)
*   Author      :	Atiq Rahman
*   Status      :   Accepted
*	Notes       :   No library Swap function, had to create one
***************************************************************************/

/*
* Definition for a binary tree node.
* public class TreeNode {
*     public int val;
*     public TreeNode left;
*     public TreeNode right;
*     public TreeNode(int x) { val = x; }
* }
*/

public class Solution {
    public TreeNode InvertTree(TreeNode root) {
        if (root == null)
            return root;
        Swap<TreeNode>(ref root.left, ref root.right);
        InvertTree(root.left);
        InvertTree(root.right);
        return root;
    }

    void Swap<T>(ref T lhs, ref T rhs) {
        T temp;
        temp = lhs;
        lhs = rhs;
        rhs = temp;
    }
}

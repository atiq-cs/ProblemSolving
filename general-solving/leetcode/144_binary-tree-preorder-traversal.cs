/***************************************************************************
*	Problem Name:	Invert children of Binary Tree
*	Problem URL :	https://leetcode.com/problems/invert-binary-tree/
                    http://www.lintcode.com/en/problem/invert-binary-tree/
*	Date        :	July 22, 2015
*
*	Algo, DS    :	Binary Tree, Recursion
*	Desc        :	Preorder Traversal
*
*	Complexity  :   O(n)
*   Author      :	Atiq Rahman
*   Status      :   Accepted
*	Notes       :   Cannot instantiate abstract class IList<int>
 *	                had to use List instead
***************************************************************************/

// using System.Collections.Generic;    IList is in this namespace

public class Solution
{
    private List<int> node_list = new List<int>();

    public IList<int> PreorderTraversal(TreeNode root)
    {
        PreTraversal_rec(root);
        return node_list;
    }

    private void PreTraversal_rec(TreeNode root)
    {
        if (root == null) return;
        node_list.Add(root.val);

        PreTraversal_rec(root.left);
        PreTraversal_rec(root.right);
    }
}

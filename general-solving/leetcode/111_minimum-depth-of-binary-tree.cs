/***************************************************************************
*	Problem Name:	Find the minimum depth of a binary tree
*	Problem URL :	https://leetcode.com/problems/minimum-depth-of-binary-tree/
                    http://www.lintcode.com/en/problem/minimum-depth-of-binary-tree/
*	Date        :	July 22, 2015
*
*	Algo, DS    :	Binary Tree, Recursion
*	Desc        :	if we don't consider the
*					  - case when left or right child is null solution is wrong
*
*	Complexity  :   O(n)
*   Author      :	Atiq Rahman
*   Status      :   Accepted
*	Notes       :   We just adapted C#,
*	                Learned to use Math.Min
*	                Moving to C# seems prospective, code is much more readable
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

public class Solution
{
    public int MinDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        if (root.left == null)
            return MinDepth(root.right) + 1;

        if (root.right == null)
            return MinDepth(root.left) + 1;

        return (Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1);
    }
}

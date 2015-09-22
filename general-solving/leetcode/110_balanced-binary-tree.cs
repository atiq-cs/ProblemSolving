/***************************************************************************
*   Problem Name:   Balanced Binary Tree
*   Problem URL :   https://leetcode.com/problems/balanced-binary-tree/
*   Date        :   Aug 15, 2015
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted (Runtime beats 88.24% C# submissions)
*   Notes       :   
***************************************************************************/

public class Solution
{
    public bool IsBalanced(TreeNode root)
    {
        if (root == null)
            return true;
        if (IsBalanced(root.left) == false || IsBalanced(root.right) == false)
            return false;
        if (Math.Abs(get_maxdepth(root.left) - get_maxdepth(root.right)) <= 1)
            return true;
        return false;
    }

    private int get_maxdepth(TreeNode root)
    {
        if (root == null)
            return 0;
        return Math.Max(get_maxdepth(root.left), get_maxdepth(root.right)) + 1;
    }
}

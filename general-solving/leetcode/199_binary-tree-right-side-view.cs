/***************************************************************************
*   Problem Name:   Binary Tree Right Side View
*   Problem URL :   https://leetcode.com/problems/binary-tree-right-side-view/
         related:   http://www.geeksforgeeks.org/print-right-view-binary-tree-2/
*   Date        :   Aug 5, 2015
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted (Runtime beats 86.54% C# submissions)
*   Notes       :   
***************************************************************************/

public class Solution
{
    List<int> nums;
    public IList<int> RightSideView(TreeNode root)
    {
        nums = new List<int>();
        int maxLevel = 0;
        RightSideView_rec(root, 1, ref maxLevel);
        return nums;
    }

    void RightSideView_rec(TreeNode root, int level, ref int maxLevel)
    {
        if (root == null)
            return;
        if (level > maxLevel)
        {
            nums.Add(root.val);
            maxLevel = level;
        }
        RightSideView_rec(root.right, level + 1, ref maxLevel);
        RightSideView_rec(root.left, level + 1, ref maxLevel);
    }
}

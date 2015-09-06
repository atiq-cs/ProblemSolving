/***************************************************************************
*   Problem Name:   Find the minimum depth of a binary tree
*   Problem URL :   https://leetcode.com/problems/minimum-depth-of-binary-tree/
*                   http://www.lintcode.com/en/problem/minimum-depth-of-binary-tree/
*   Date        :   July 22, 2015
*
*   Algo, DS    :   Binary Tree, Recursion
*   Desc        :   Consider the case when left or right child does not exist,
*                       we cannot take 0 height as minimum for those parts, to ignore those we use Math.Max
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Notes       :   We just adapted C#,
*                    Learned to use Math.Min
*                    Moving to C# seems prospective, code is much more readable
***************************************************************************/

public class Solution {
    public int MinDepth(TreeNode root) {
        if (root == null)
            return 0;
            
        if (root.left == null || root.right == null)
            return Math.Max(MinDepth(root.left), MinDepth(root.right)) + 1;
        
        return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
    }
}

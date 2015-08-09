/***************************************************************************
*   Problem Name:   Determines if given string has some properties
*   Problem URL :   https://leetcode.com/problems/maximum-depth-of-binary-tree/
                    related: https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree
*   Domain      :   data-structures/trees
*   DateTime    :   August 7, 2015
*   Desc        :   Recursion on Binary Tree
*                   Maximum depth is the max of depth from the children
*   Complexity  :   O(n), .008s
*   Author      :   Atiq Rahman
*   Status      :   Accepted
***************************************************************************/

public class Solution {
    public int MaxDepth(TreeNode root) {
        if (root == null)
            return 0;
        return Math.Max(MaxDepth(root.left)+1, MaxDepth(root.right)+1);
    }
}

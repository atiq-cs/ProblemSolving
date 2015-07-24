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
***************************************************************************/

class Solution {
public:
    /**
    * @param root: The root of binary tree.
    * @return: An integer
    */
    int minDepth(TreeNode *root) {
        // write your code here
        if (root == NULL)
            return 0;

        if (root->left == NULL)
            return minDepth(root->right) + 1;

        if (root->right == NULL)
            return minDepth(root->left) + 1;

        return (std::min(minDepth(root->left), minDepth(root->right)) + 1);
    }
};

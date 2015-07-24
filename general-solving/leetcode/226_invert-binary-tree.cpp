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
*	Notes       :   For leet code add returning node
***************************************************************************/

class Solution {
public:
    /**
    * @param root: a TreeNode, the root of the binary tree
    * @return: nothing
    */
    void invertBinaryTree(TreeNode *root) {
        // write your code here
        // null node does not be done anything
        if (root == NULL)
            return;

        // has one or both children
        std::swap(root->left, root->right);
        invertBinaryTree(root->left);
        invertBinaryTree(root->right);
    }
};

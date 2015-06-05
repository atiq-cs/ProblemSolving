/*
	Problem: http://www.lintcode.com/en/problem/maximum-depth-of-binary-tree/
	Description:
			Recursive solution.

			Complexity: theta(n), I have to verify using master theorem cases

    Status  :   Accepted
*/

/*
* Definition of TreeNode:
* class TreeNode {
* public:
*     int val;
*     TreeNode *left, *right;
*     TreeNode(int val) {
*         this->val = val;
*         this->left = this->right = NULL;
*     }
* }
*/
#include <algorithm>

class Solution {
public:
    /**
    * @param root: The root of binary tree.
    * @return: An integer
    */
    int maxDepth(TreeNode *root) {
        // write your code here
        // if it is a NULL pointer
        if (root == NULL)
            return 0;
        // if has no children
        if (root->left == NULL && root->right == NULL)
            return 1;

        // if has both children
        if (root->left != NULL && root->right != NULL)
            return (std::max(maxDepth(root->left), maxDepth(root->right)) + 1);

        // if it has only left child
        if (root->right == NULL)
            return (maxDepth(root->left) + 1);

        // if it has only right child
        if (root->left == NULL)
            return (maxDepth(root->right) + 1);
    }
};

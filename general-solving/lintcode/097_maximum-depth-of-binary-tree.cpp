/*
	Problem: http://www.lintcode.com/en/problem/maximum-depth-of-binary-tree/
	Description:
			Recursive solution.
            This is no good. For better concise solution look at: 
			Complexity: theta(n), I have to verify using master theorem cases

    Status  :   Accepted
*/

#include <algorithm>

class Solution {
public:
    int maxDepth(TreeNode *root) {
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

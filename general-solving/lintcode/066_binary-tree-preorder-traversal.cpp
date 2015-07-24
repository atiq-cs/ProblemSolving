/*
    Problem: http://www.lintcode.com/en/problem/minimum-depth-of-binary-tree/
            also solves https://leetcode.com/problems/binary-tree-preorder-traversal/
            have a look at leetcode/144_binary-tree-preorder-traversal.cs

    Description:
            Recursive solution.

    Complexity: theta(n)

    Status  :   Accepted
*/

/**
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

class Solution {
private:
    vector<int> result;
public:
    /**
    * @param root: The root of binary tree.
    * @return: Preorder in vector which contains node values.
    */
    vector<int> preorderTraversal(TreeNode *root) {
        // write your code here
        result.clear();

        preorderTraversal_rec(root);

        return result;
    }

    void preorderTraversal_rec(TreeNode *node) {
        if (node == NULL)
            return;
        result.push_back(node->val);
        preorderTraversal_rec(node->left);
        preorderTraversal_rec(node->right);
    }
};

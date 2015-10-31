/*
    Problem     : http://www.lintcode.com/en/problem/validate-binary-search-tree/
    Description :
                Recursive solution
                My initial approach failed for testcase 18
                Because I was only checking with root
                
                geeksforgeeks idea on method 4 is pretty elegant
                look at: leetcode/098_validate-binary-search-tree.cs

    Complexity  : O(n) 

    Status      :   Accepted
    Reference   :   http://www.geeksforgeeks.org/a-program-to-check-if-a-binary-tree-is-bst-or-not/
*/


class Solution {
public:
    /**
    * @param root: The root of binary tree.
    * @return: True if the binary tree is BST, or false
    */

    bool isValidBST(TreeNode *root) {
        // write your code here
        if (root == NULL)
            return true;

        static TreeNode *prev = NULL;

        if (isValidBST(root->left) == false)
            return false;

        if (prev != NULL && root->val <= prev->val)
            return false;

        prev = root;

        if (isValidBST(root->right) == false)
            return false;
        return true;
    }
};

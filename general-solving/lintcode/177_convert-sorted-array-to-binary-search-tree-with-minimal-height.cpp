/*
    Problem: http://www.lintcode.com/en/problem/convert-sorted-array-to-binary-search-tree-with-minimal-height/
    Description:
            Recursive solution.

            Complexity: theta(log n), verify
            Had to look at a reference: http://articles.leetcode.com/2010/11/convert-sorted-array-into-balanced.html

    Remark  :   Some problems are easier to solve following original algorithm structure
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
class Solution {
public:
    /**
    * @param A: A sorted (increasing order) array
    * @return: A tree node
    */
    TreeNode *sortedArrayToBST(vector<int> &A) {
        // write your code here
        return sortedArrayToBST_rec(A, 0, A.size() - 1);
    }
    TreeNode *sortedArrayToBST_rec(vector<int> &A, int low, int high) {
        // write your code here
        if (low>high)
            return NULL;

        int mid = (low + high) / 2;
        TreeNode* root = new TreeNode(A[mid]);
        root->left = sortedArrayToBST_rec(A, low, mid - 1);
        root->right = sortedArrayToBST_rec(A, mid + 1, high);
        return root;
    }
};

/***************************************************************************************************
* URL   : convert-sorted-array-to-binary-search-tree-with-minimal-height
* Date  : 2015-06-04
* Author: Atiq Rahman
* Status: Accepted
* Comp  : O(n)
* Notes : Some problems are easier to solve following original algorithm structure
*   Comp analysis: theta(log n) or theta(n)?
*   We have to read at least once each item from the array. Hence, it cannot be less than theta(N)
* ref   : http://articles.leetcode.com/2010/11/convert-sorted-array-into-balanced.html
* meta  : tag-ds-BST, tag-recursion
***************************************************************************************************/
class Solution {
public:
  TreeNode *sortedArrayToBST(vector<int> &A) {
    return sortedArrayToBST(A, 0, A.size() - 1);
  }

  TreeNode *sortedArrayToBST(vector<int> &A, int low, int high) {
    if (low>high)
      return NULL;

    int mid = (low + high) / 2;
    TreeNode* root = new TreeNode(A[mid]);
    root->left = sortedArrayToBST(A, low, mid - 1);
    root->right = sortedArrayToBST(A, mid + 1, high);
    return root;
  }
};

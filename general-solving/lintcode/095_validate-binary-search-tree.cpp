/***************************************************************************************************
* Title : http://www.lintcode.com/en/problem/validate-binary-search-tree/
* Date  : 2015-06-21
* Author: Atiq Rahman
* Status: Accepted
* Comp  : O(n)
* Notes : My initial approach failed for testcase 18; because I was only checking with root
*
*   geeksforgeeks idea( method 4) is elegant
* rel   : leetcode/0098_validate-binary-search-tree.cs
* ref   : http://www.geeksforgeeks.org/a-program-to-check-if-a-binary-tree-is-bst-or-not/
* meta  : tag-ds-binary-tree, tag-recursion
***************************************************************************************************/
class Solution {
public:
  bool isValidBST(TreeNode *root) {
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

/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/minimum-depth-of-binary-tree/
* Date  : 2015-06-04
* Author: Atiq Rahman
* Comp  : theta(n)
* Status: Accepted
* Notes:  Can be done in single func
* ref   : leetcode/0144_binary-tree-preorder-traversal.cs
* rel   : https://leetcode.com/problems/binary-tree-preorder-traversal/
* meta  : tag-traversal, tag-ds-binary-tree, tag-recursion
***************************************************************************************************/
class Solution {
private:
  vector<int> result;
public:
  vector<int> preorderTraversal(TreeNode *root) {
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

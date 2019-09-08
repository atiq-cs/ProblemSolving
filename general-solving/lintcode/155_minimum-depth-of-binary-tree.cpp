/***************************************************************************************************
* Title : http://www.lintcode.com/en/problem/minimum-depth-of-binary-tree/
* Date  : 2015-06-04
* Author: Atiq Rahman
* Comp  : theta(n)
* Status: Accepted
* meta  : tag-ds-binary-tree, tag-recursion
***************************************************************************************************/
#include <algorithm>

class Solution {
public:
  int minDepth(TreeNode *root) {
    // if it is a NULL pointer
    if (root == NULL)
      return 0;
    // if has no children
    if (root->left == NULL && root->right == NULL)
      return 1;

    // if has both children
    if (root->left != NULL && root->right != NULL)
      return (std::min(minDepth(root->left), minDepth(root->right)) + 1);

    // if it has only left child
    if (root->right == NULL)
      return (minDepth(root->left) + 1);

    // if it has only right child
    if (root->left == NULL)
      return (minDepth(root->right) + 1);
  }
};

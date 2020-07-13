/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/maximum-depth-of-binary-tree/
* Date  : 2015-06-04
* Author: Atiq Rahman
* Comp  : theta(n), I have to verify using master theorem cases
* Notes : This is no good. For better concise solution look at ...
*   Hence, it is a ToDo
* Status: Accepted
* meta  : tag-ds-binary-tree, tag-recursion
***************************************************************************************************/
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

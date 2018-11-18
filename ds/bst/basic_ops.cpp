/***************************************************************************
* Title : Operations in a BST
* URL   : C.L.R.S Ch 12
* Date  : 2018-11-14
* Author: Atiq Rahman
* Comp  : O(lg n), O(n) if unbalanced
* Notes : for detailed notes refer 'basic_ops.cs'
* meta  : tag-ds-BST, tag-ds-core
***************************************************************************/
class Solution {
public:
  // insert method
  TreeNode* insertNode(TreeNode* root, TreeNode* z) {
    TreeNode *y = NULL;
    TreeNode *x = root;

    // find leaf node where the search ends, search continues down the path in BST
    while (x != NULL) {
      y = x;
      if (z->val < x->val)
        x = x->left;
      else
        x = x->right;
    }

    // insert z into the leaf node
    if (y == NULL)
      root = z;
    else if (z->val < y->val)
      y->left = z;
    else
      y->right = z;
    return root;
  }
};

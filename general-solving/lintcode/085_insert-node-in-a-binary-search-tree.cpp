/***************************************************************************
* Title : Insert Node in a Binary Search Tree
* URL   : http://lintcode.com/problem/insert-node-in-a-binary-search-tree/
* Date  : 2015-06-04
* Author: Atiq Rahman
* Comp  : O(lg n), O(n)
* Status: Accepted
* Notes : Build hashset using one linked list, lookup for each node in the
*   other linked list. if found then that's the intersection
*
*  O(n) space, when in worst case, BST is unbalanced. Use Red-Black or AVL for
*  better performance in such cases.
* meta  : tag-ds-BST
***************************************************************************/
class Solution {
public:
  TreeNode* insertNode(TreeNode* root, TreeNode* z) {
    TreeNode *y = NULL;
    TreeNode *x = root;

    while (x != NULL) {
      y = x;
      if (z->val < x->val)
        x = x->left;
      else
        x = x->right;
    }

    if (y == NULL)
      root = z;
    else if (z->val < y->val)
      y->left = z;
    else
      y->right = z;
    return root;
  }
};

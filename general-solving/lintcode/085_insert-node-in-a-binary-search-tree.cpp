/***************************************************************************
* Title : Insert Node in a Binary Search Tree
* URL   : http://lintcode.com/problem/insert-node-in-a-binary-search-tree/
* Date  : 2018-01
* Author: Atiq Rahman
* Comp  : O(lg n), O(n) when in worst case, BST is unbalanced, use Red-Black
    or AVL for better
* Status: Accepted
* Notes : Build hashset using one linked list, lookup for each node in the
*   other linked list. if found then that's the intersection
* meta  : tag-easy, tag-linked-list, tag-hash-table
***************************************************************************/
class Solution {
public:
  /*
  * @param root: The root of the binary search tree.
  * @param node: insert this node into the binary search tree
  * @return: The root of the new binary search tree.
  */
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

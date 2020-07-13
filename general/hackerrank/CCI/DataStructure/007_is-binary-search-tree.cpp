/***************************************************************************************************
* Title : Trees: Is This a Binary Search Tree?
* URL   : https://www.hackerrank.com/challenges/ctci-is-binary-search-tree
* Date  : 2017-09-07
* Comp  : O(n), O(lg n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Inorder traversal
*   assign values & compare in that order
*
*   Language specicfic direction,
*   global variable instead of static would also work
* rel   : general-solving/lintcode/095_validate-binary-search-tree.cpp
* meta  : tag-binary-tree, tag-easy
***************************************************************************************************/

bool checkBST(Node* root) {
  if (root == NULL)
    return true;
  static int pre_inorder_node_val = -1;
  if (checkBST(root->left) == false) return false;
  if (pre_inorder_node_val >= root->data)
    return false;
  pre_inorder_node_val = root->data;
  if (checkBST(root->right) == false) return false;
  return true;
}

/***************************************************************************
* Title : Operations in a BST
* URL   : C.L.R.S Ch 12
* Date  : 2015-06-04
* Author: Atiq Rahman
* Comp  : O(lg n), O(n) if unbalanced
* Notes : Only implements insert into BST, tested using leetcode#701
* meta  : tag-ds-BST, tag-ds-core
***************************************************************************/
class Solution {
  public TreeNode InsertIntoBST(TreeNode root, int val) {
    TreeNode y = null;
    TreeNode x = root;

    // find leaf node where the search ends, search continues down the path in BST
    while (x != null) {
      y = x;
      if (x.val > val)
        x = x.left;
      else
        x = x.right;
    }

    // insert z into the leaf node
    TreeNode z = new TreeNode(val);
    if (y == null)
      root = z;
    else if (y.val > val)
      y.left = z;
    else
      y.right = z;
    return root;
  }
}

/***************************************************************************
* Title : Operations in a BST
* URL   : C.L.R.S Ch 12
* Date  : 2015-06-04
* Comp  : O(lg n), O(n) if unbalanced
* Notes : Only implements insert into BST, tested using leetcode#701
* rel   : lt#701, https://leetcode.com/problems/insert-into-a-binary-search-tree
* meta  : tag-ds-BST, tag-ds-binary-tree, tag-ds-core
***************************************************************************/
class Solution {
  public TreeNode InsertIntoBST(TreeNode root, int val) {
    TreeNode y = null;
    TreeNode x = root;

    // find leaf node where the search ends, search continues down the path in BST
    // because, x ends being into null at leaf nodes we have y to track the last node/parent
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

  public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
    if (root == null || p == null)
      return null;

    if (p.right != null)
      return TreeMinimum(p.right);

  }


  /// <summary>
  /// If null return so
  /// Otherwise keep going down left wise..
  /// </summary>
  /// <param name="current"> node of subtree for which to find the min </param>
  /// <returns></returns>
  private TreeNode TreeMinimum(TreeNode current) {
    if (current == null) return null;

    for (; current.left != null; current = current.left) ;

    return current;
  }

}

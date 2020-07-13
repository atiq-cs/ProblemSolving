/***************************************************************************************************
* Title : Validate Binary Search Tree
* URL   : https://leetcode.com/problems/validate-binary-search-tree/
* Date  : 2015-10-31
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : A clever inorder traversal and updating the previous root each time solves the problem
*   
*   Why the solution is like this?
*   http://blogs.msdn.com/b/csharpfaq/archive/2004/05/11/
*    why-doesn-t-c-support-static-method-variables.aspx
* rel   : 'leetcode/0095_validate-binary-search-tree.cpp'
* meta  : tag-ds-binary-tree, tag-recursion
***************************************************************************************************/
public class Solution {
  // Moving this as tatic declaration inside a method is not supported.
  private TreeNode prev = null;

  public bool IsValidBST(TreeNode root) {
    if (root == null)
      return true;

    if (IsValidBST(root.left) == false)
      return false;
    if (prev != null && root.val <= prev.val)
      return false;

    prev = root;
    if (IsValidBST(root.right) == false)
      return false;
    return true;
  }
}

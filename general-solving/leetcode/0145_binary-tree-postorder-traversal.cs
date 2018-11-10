/***************************************************************************************************
* Title : Binary Tree Postorder Traversal
* URL   : https://leetcode.com/problems/binary-tree-postorder-traversal/
* Date  : 2015-09-24
* Comp  : O(n)
* Status: Accepted
* Notes : 
* meta  : tag-binary-tree, tag-leetcode-easy
***************************************************************************************************/

public class Solution
{
  IList<int> nodeList;
  public IList<int> PostorderTraversal(TreeNode root)
  {
    nodeList = new List<int>();
    PostorderTraversalRec(root);
    return nodeList;
  }

  void PostorderTraversalRec(TreeNode root)
  {
    if (root == null)
      return;
    PostorderTraversalRec(root.left);
    PostorderTraversalRec(root.right);
    nodeList.Add(root.val);
  }
}

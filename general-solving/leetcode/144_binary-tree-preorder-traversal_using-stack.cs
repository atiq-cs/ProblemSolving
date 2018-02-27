/***************************************************************************
* Problem Name: Binary Tree Inorder Traversal
* Problem URL : https://leetcode.com/problems/binary-tree-inorder-traversal/
* Date        : Oct 30 2017
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted (beats 84%)
* Notes       : Based on '094_Binary-tree-inorder-traversal_using-stack.cs'
* meta        : tag-binary-tree
***************************************************************************/
public class Solution {
  List<int> NodeList;

  private void PreorderTraversalUsingStackv1(TreeNode root) {
    if (root == null)
      return ;
    Stack<TreeNode> stack = new Stack<TreeNode>();

    do { // cur stands for current node - a temporary node to point to each
      // node while visiting each node of the tree
      TreeNode cur = root;
      while (cur != null) {
        stack.Push(cur);
        NodeList.Add(cur.val);
        cur = cur.left;
      }
      // At least one node is in the stack
      do {
        cur = stack.Pop();
      } while (cur.right == null && stack.Count > 0);
      root = cur.right;
    } while (root != null);
  }

  // Acknowledgement: Huy Zing
  private void PreorderTraversalUsingStack(TreeNode root) {
    Stack<TreeNode> stack = new Stack<TreeNode>();
    TreeNode current = root;

    while (current != null || stack.Count > 0) {
      if (current.right != null)
        stack.Push(current.right);
      nodeList.Add(current.val);
      if (current.left == null && stack.Count > 0)
        current = stack.Pop();
      else
        current = current.left;
    }
    return nodeList;
  }

  public IList<int> PreorderTraversal(TreeNode root) {
    NodeList = new List<int>();
    PreorderTraversalUsingStack(root);
    return NodeList;
  }
}

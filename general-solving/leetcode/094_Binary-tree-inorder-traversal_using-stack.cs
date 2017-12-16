/***************************************************************************
* Problem Name: Binary Tree Inorder Traversal
* Problem URL : https://leetcode.com/problems/binary-tree-inorder-traversal/
* Date        : Oct 30 2017
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted (beats 84%)
* Notes       : Using Stack CLR p289, Ex-12.1-3
*                Easy one (using stack)
* meta        : tag-lca
***************************************************************************/

public class Solution {
  List<int> NodeList;

  private void InorderTraversalUsingStack(TreeNode root) {
    if (root == null)
      return ;

    Stack<TreeNode> stack = new Stack<TreeNode>();

    do { // cur stands for current node - a temporary node to point to each
      // node while visiting each node of the tree
      TreeNode cur = root;
      while (cur != null) {
        stack.Push(cur);
        cur = cur.left;
      }
      // At least one node is in the stack
      do {
        cur = stack.Pop();
        NodeList.Add(cur.val);
      } while (cur.right == null && stack.Count > 0);
      root = cur.right;
    } while (root != null);
  }

  public IList<int> InorderTraversal(TreeNode root) {
    NodeList = new List<int>();
    InorderTraversalUsingStack(root);
    return NodeList;
  }
}

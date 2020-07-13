/***************************************************************************
* Title : Preorder Traversal of Binary Tree
* URL   : https://leetcode.com/problems/binary-tree-preorder-traversal
* Date  : 2016-06-03 (update)
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : similar to Inorder morris traversal which is at,
*   'ds/binary-tree/traversal.cs'
* meta  : tag-ds-stack, tag-ds-binary-tree, tag-recursion, tag-leetcode-medium
***************************************************************************/
public class Solution {
  // Uses Morris Traversal for Preorder, O(1) space
  //  'ds/binary-tree/traversal.cs'
  public IList<int> PreorderTraversal(TreeNode root) {
    return Traversal(root, false);
  }

  private List<int> nodeList = new List<int>();
  public IList<int> PreorderTraversal(TreeNode root) {
    if (root == null)
      return nodeList;

    nodeList.Add(root.val);
    PreorderTraversal(root.left);
    PreorderTraversal(root.right);
    return nodeList;
  }

  // Iterative Traverse using Stack: Push the left nodes onto the stack
  //  based on '0094_Binary-tree-inorder-traversal.cs'
  public IList<int> PreorderTraversal(TreeNode root) {
    var nodeList = new List<int>();
    if (root == null)
      return ;
    var stack = new Stack<TreeNode>();

    do { // cur stands for current node - a temporary node to point to each
      // node while visiting each node of the tree
      TreeNode cur = root;
      while (cur != null) {
        stack.Push(cur);
        nodeList.Add(cur.val);
        cur = cur.left;
      }
      // At least one node is in the stack
      do {
        cur = stack.Pop();
      } while (cur.right == null && stack.Count > 0);
      root = cur.right;
    } while (root != null);
    return nodeList;
  }

  // Iterative Traverse using Stack 2: Push the right nodes onto the stack along
  // the way down while process the left nodes on the way down, get those nodes
  // back from stack when we come back; Acknowledgement: Huy Zing
  public IList<int> PreorderTraversal(TreeNode current) {
    var nodeList = new List<int>();
    var stack = new Stack<TreeNode>();
    // 1 line more if we check root here and do less condition checking..
    while (current != null || stack.Count > 0) {
      if (current.right != null)
        stack.Push(current.right);
      nodeList.Add(current.val);
      current = (current.left == null && stack.Count > 0) ? stack.Pop() :
        current.left;
    }
    return nodeList;
  }

  private List<int> nodeList = new List<int>();
  // Recursive Traverse
  public IList<int> PreorderTraversal(TreeNode root) {
    if (root == null) return nodeList;
    nodeList.Add(root.val);
    PreorderTraversal(root.left);
    PreorderTraversal(root.right);
    return nodeList;
  }
}

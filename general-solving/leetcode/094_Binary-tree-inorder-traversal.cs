/***************************************************************************
* Title : Binary Tree Inorder Traversal
* URL   : https://leetcode.com/problems/binary-tree-inorder-traversal/
* Date  : 2017-10-30 (update)
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : Using Stack CLR p289, Ex-12.1-3
*   Easy one (using stack)
* meta  : tag-binary-tree, tag-leetcode-easy, tag-recursion, tag-stack
***************************************************************************/
public class Solution {
  // using stack for storing left node
  public IList<int> InorderTraversal(TreeNode root) {
    var nodeList = new List<int>();
    if (root == null) return nodeList;
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
        nodeList.Add(cur.val);
      } while (cur.right == null && stack.Count > 0);
      root = cur.right;
    } while (root != null);
    return nodeList;
  }

  // recursive InorderTraversal: drops returned object from function calls inside
  IList<int> nodeList = new List<int>();
  public IList<int> InorderTraversal(TreeNode root) {
    if (root == null)
      return nodeList;
    InorderTraversal(root.left);
    nodeList.Add(root.val);
    InorderTraversal(root.right);
    return nodeList;
  }
}

/*
OJ's Binary Tree Serialization:
 The serialization of a binary tree follows a level order traversal, where '#'
 signifies a path terminator where no node exists below.

 [37,-34,-48,null,-100,-100,48,null,null,null,null,-54,null,-71,-22,null,null,
 null,8]
*/

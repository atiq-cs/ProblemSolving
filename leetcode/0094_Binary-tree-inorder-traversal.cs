/***************************************************************************
* Title : Binary Tree Inorder Traversal
* URL   : https://leetcode.com/problems/binary-tree-inorder-traversal/
* Date  : 2017-10-30 (update)
* Author: Atiq Rahman
* Comp  : O(n), O(1) if Morris
* Status: Accepted
* Notes : Using Stack CLR p#289, Ex-12.1-3
*   Easy one (using stack)
* meta  : tag-ds-binary-tree, tag-recursion, tag-ds-stack, tag-leetcode-easy
***************************************************************************/
public class Solution {
  // Uses Morris Traversal for Inorder, O(1) space
  //  'ds/binary-tree/traversal.cs'
  public IList<int> InorderTraversal(TreeNode root) {
    return Traversal(root, true);
  }

  // Using stack for storing left node, O(h) space
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
      // At least stack contains a node
      do {
        cur = stack.Pop();
        nodeList.Add(cur.val);
      } while (cur.right == null && stack.Count > 0);
      root = cur.right;
    } while (root != null);
    return nodeList;
  }

  // Recursive Inorder Traversal: drops returned object from function calls
  // inside, O(h) stack space
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

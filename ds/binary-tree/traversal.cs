/***************************************************************************
* Title : Binary Tree Traversals
* URL   : https://www.geeksforgeeks.org/morris-traversal-for-preorder/
* Date  : 2018-06-04
* Author: Atiq Rahman
* Comp  : O(n), O(1)
* Ref   : Tushar Roy - Morris Inorder Tree Traversal
*   https://www.youtube.com/watch?v=wGXB9OWhPTg
*   geeksforgeeks.org/inorder-tree-traversal-without-recursion-and-without-stack/
* Notes : Implements Morris Traversals for Binary Trees
***************************************************************************/
public class TraversalUtil {
  // Implements Morris Traversal for Inorder/Preorder, O(1) space
  public IList<int> Traversal(TreeNode current, bool isInOrder) {
    var nodeList = new List<int>();
    while (current != null) {
      if (current.left == null) {
        // Visit current node
        nodeList.Add(current.val);
        current = current.right;
      }
      else {
        TreeNode pred = FindInOrderPredecessor(current);
        // create predecessor to current link
        if (pred.right == null) {
          pred.right = current;
          // Visit current node for PreOrder
          if (isInOrder == false)
            nodeList.Add(current.val);
          current = current.left;
        }
        // Undo link and Visit
        // why does this work?
        // Because, a predecessor does not have a right node,
        // this one has because we created it and its right node is current as
        // we linked
        else {
          pred.right = null;
          // Visit current node for InOrder
          if (isInOrder)
            nodeList.Add(current.val);
          current = current.right;
        }
      }
    }
    return nodeList;
  }

  // Iterative implementation of inorder predecessor find, O(h)
  private TreeNode FindInOrderPredecessor(TreeNode root) {
    TreeNode current = root.left;
    while (current.right != null && current.right != root)
      current = current.right;
    return current;
  }
}

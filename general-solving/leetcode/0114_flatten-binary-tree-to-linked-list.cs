/***************************************************************************
* Title : Flatten Binary Tree to Linked List
* URL   : https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
* Date  : 2015-09-26 (update InnoWorld 2018-08-19)
* Author: Atiq Rahman
* Comp  : O(n), O(1) O(lg N) stack space
* Status: Accepted
* Notes : Key here is that the flattened tree, each node's right child
*   points to the next node of a pre-order traversal
*   ToDo: Iterative version
* meta  : tag-binary-tree, tag-recursion, tag-leetcode-medium
***************************************************************************/
public class Solution {
  TreeNode previousNode = null;
  public void Flatten(TreeNode root)
  {
    if (root == null)
      return ;
    if (previousNode != null) {
      previousNode.right = root;
      previousNode.left = null;
    }
    previousNode = root;
    TreeNode temp = root.right;
    Flatten(root.left);
    Flatten(temp);
  }
}

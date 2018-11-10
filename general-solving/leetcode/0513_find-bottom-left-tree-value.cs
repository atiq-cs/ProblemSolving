/***************************************************************************
* Title : Maximum Binary Tree
* URL   : https://leetcode.com/problems/find-bottom-left-tree-value/
* Date  : 2017-10-24
* Author: Atiq Rahman
* Comp  : O(n), O(lg n) space for recursion stack
* Status: Accepted
* Notes : Naive approach
*   Traverse all nodes. while doing so find the one with highest depth. This
*   can be tracked doing an inorder traversal. Inorder works because it visits
*   the left node before other nodes.
*
* meta  : tag-ds-binary-tree, tag-leetcode-easy
***************************************************************************/
public class Solution {
  int maxDepth;
  TreeNode deepLeftNodeNode;
  
  public int FindBottomLeftValue(TreeNode root) {
    deepLeftNode = 0;
    maxDepth = 0;
    FindBottomLeftValueRec(root, 1);
    return deepLeftNode.val;
  }
  
  private void FindBottomLeftValueRec(TreeNode root, int depth) {
    if (root == null)
      return ;
    if (maxDepth < depth) {
      maxDepth = depth;
      deepLeftNode = root;
    }
    FindBottomLeftValueRec(root.left, depth+1);
    FindBottomLeftValueRec(root.right, depth+1);
  }
}

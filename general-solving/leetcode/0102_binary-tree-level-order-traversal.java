/***************************************************************************************************
* Title : Binary Tree Level Order Traversal
* URL   : https://leetcode.com/problems/binary-tree-level-order-traversal/
* Date  : 2019-03
* Comp  : O(n), O(lg N)
* Author: Atiq Rahman
* Status: Accepted
* Notes : O(lg N) Stack Space if balanced binary tree
*   Based on previous cpp solution
*   Please note that this is problem is solved in cpp and java
* rel   : 'leetcode 107 Binary Tree Level Order Traversal II'
* meta  : tag-ds-binary-tree, tag-recursion, tag-graph-bfs, tag-leetcode-medium
***************************************************************************************************/
class Solution {
  List<List<Integer>> levels;
  
  public List<List<Integer>> levelOrder(TreeNode root) {
    levels = new ArrayList<List<Integer>>();
    levelOrder(root, 0);
    return levels;
  }
                      
  private void levelOrder(TreeNode root, int depth) {
    if (root == null)
      return ;
    
    if (levels.size() == depth)
      levels.add(new LinkedList<Integer>());

    levels.get(depth).add(root.val);
    levelOrder(root.left, depth + 1);
    levelOrder(root.right, depth + 1);
  }
}

/******************************************************************************
* Title : Binary Tree Level Order Traversal II
* URL   : https://leetcode.com/problems/binary-tree-level-order-traversal-ii
* Date  : 2017-12-17
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : BFS Traversal
* meta  : tag-binary-tree, tag-bfs
******************************************************************************/
public class Solution {
  public IList<IList<int>> LevelOrderBottom(TreeNode root) {
    List<IList<int>> TraversalResult = new List<IList<int>>();;
    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    
    while (queue.Count > 0) {
      List<TreeNode> levelChildren = new List<TreeNode>();
      while (queue.Count != 0)
        levelChildren.Add(queue.Dequeue());
      
      List<int> levelChildrenVal = new List<int>();
      foreach(TreeNode node in levelChildren) {
        if (node != null) {
          queue.Enqueue(node.left);
          queue.Enqueue(node.right);
          levelChildrenVal.Add(node.val);
        }
      }
      if (levelChildrenVal.Count > 0)
        TraversalResult.Add(levelChildrenVal);
    }
    TraversalResult.Reverse();
    return TraversalResult;
  } 
}

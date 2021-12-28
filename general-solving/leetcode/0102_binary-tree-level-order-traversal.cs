/***************************************************************************
* Problem Name: Binary Tree Level Order Traversal
* Problem URL : https://leetcode.com/problems/binary-tree-level-order-traversal/
* Date        : 2015-01-05
* Complexity  : O(n), O(lg N) Stack
* Author      : Atiq Rahman
* Status      : Accepted (405ms)
* Notes       : O(lg N) Stack Space if balanced binary tree
*   Based on previous cpp solution
* meta        : tag-binary-tree, tag-bfs
***************************************************************************/
public class Solution {
  IList<IList<int>> levelList = new List<IList<int>>();

  // Using recursion/stack
  public IList<IList<int>> LevelOrder(TreeNode root, int index=0) {
    if (root == null)
      return levelList;
    if (levelList.Count <= index)
      levelList.Add(new List<int>());
    levelList[index].Add(root.val);
    LevelOrder(root.left, index + 1);
    LevelOrder(root.right, index + 1);
    return levelList;
  }

  // Using Queue
  public IList<IList<int>> LevelOrder(TreeNode root) {
    var queue = new Queue<TreeNode>( new[] { root, null });

    while (queue.Count > 0) {
      var node = queue.Dequeue();
      if (node == null) {
        if (queue.Count == 0) continue;
        levelList.Add(new List<int>());
        queue.Enqueue(null);
      }
      else {
        levelList[levelList.Count-1].Add(node.val);
        queue.Enqueue(node.left);
        queue.Enqueue(node.right);
      }
    }
    return levelList;
  }
}

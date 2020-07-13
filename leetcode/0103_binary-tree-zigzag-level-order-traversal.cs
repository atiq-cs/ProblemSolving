/***************************************************************************
* Title : Binary Tree Zigzag Level Order Traversal
* URL   : https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal
* Occasn: meetup at DEN
* Date  : 2018-06-23
* Author: Atiq Rahman
* Comp  : O(V+E) includes reverse in every 2 levels, Space O(V) worst case
* Status: Accepted
* Notes : Solved using BFS at DEN meetup added
*   TODO, solve using recursion
* meta  : tag-graph-bfs, tag-ds-binary-tree, tag-recursion, tag-csharp-lang-initializer-syntax,
*   tag-leetcode-medium
***************************************************************************/
public class Solution {
  public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
    IList<IList<int>> result = new List<IList<int>>();
    bool isLeftToRight = true;
    IList<int> levelNodes = new List<int>();
    var queue = new Queue<TreeNode>( new[] {root, null});

    while(queue.Count > 0) {
      TreeNode item = queue.Dequeue();
      if (item == null) {
        if (isLeftToRight)
          isLeftToRight = false;
        else {
          ((List<int>)levelNodes).Reverse();
          isLeftToRight = true;
        }
        if (levelNodes.Count == 0)  // handles root = null
          break;
        result.Add(levelNodes);
        if (queue.Count == 0)
          break;
        levelNodes = new List<int>();
        queue.Enqueue(null);
      }
      else {
        levelNodes.Add(item.val);
        if (item.left != null)
          queue.Enqueue(item.left);
        if (item.right != null)
        queue.Enqueue(item.right);
      }
    }
    return result;
  }
}

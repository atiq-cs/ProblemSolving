/******************************************************************************
* Title : Find Largest Value in Each Tree Row
* URL   : https://leetcode.com/problems/find-largest-value-in-each-tree-row
* Date  : 2017-12-17
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : Solvable using DFS, BFS
*   This technique is a dfs technique, uses recursion to implement
*   depth definition:
*     https://fftsys.azurewebsites.net/atiq/tech/binary-tree-jargon
* meta  : tag-ds-binary-tree, tag-graph-dfs, tag-graph-bfs, tag-recursion
******************************************************************************/
public class Solution {
  List<int> largestValueInRows;
  
  public IList<int> LargestValues(TreeNode root) {
    largestValueInRows = new List<int>();
    GetLargestValuesLevelWise(root, 0);
    return largestValueInRows;
  }

  // These two methods can be combined
  private void GetLargestValuesLevelWise(TreeNode root, int depth) {
    if (root == null)
      return ;
    if (largestValueInRows.Count < depth + 1)
      largestValueInRows.Add(root.val);
    else
      largestValueInRows[depth] = Math.Max(largestValueInRows[depth],root.val);
    GetLargestValuesLevelWise(root.left, depth + 1);
    GetLargestValuesLevelWise(root.right, depth + 1);
  }
}

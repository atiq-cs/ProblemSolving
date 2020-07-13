/***************************************************************************************************
* Title : Binary Tree Paths
* URL   : https://leetcode.com/problems/binary-tree-paths/
* Date  : 2015-09-24
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Improved a few times - code shortened
*   Initially tried with some list concat,
*   leftList.Concat(rightList) returns an IEnumberable which is difficult to cast to IList
*   also return leftList.AddRange(rightList) is not corrent since AddRange does not return anything
* meta  : tag-binary-tree, tag-dfs, tag-recursion, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  List<string> pathList = new List<string>();

  public IList<string> BinaryTreePaths(TreeNode root, string pathToLeaf="") {
    if (root != null) {
      if (root.left == null && root.right == null)
        pathList.Add(pathToLeaf + root.val.ToString());

      pathToLeaf = pathToLeaf + root.val.ToString() + "->";
      BinaryTreePaths(root.left, pathToLeaf);
      BinaryTreePaths(root.right, pathToLeaf);
    }
    return pathList;
  }
}

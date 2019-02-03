/***************************************************************************************************
* Title : Binary Tree Right Side View
* URL   : https://leetcode.com/problems/binary-tree-right-side-view/
* Date  : 2019-01-29
* Occasn: leetcode meetup 229 Polaris Ave, Mtn View
* Comp  : O(n), O(lg n)
* Status: Accepted
* Notes : Just visiting right nodes won't work since we have to print the right most one from left
*   nodes when a right subtree does not exist!
* rel   : http://www.geeksforgeeks.org/print-right-view-binary-tree-2/
* meta  : tag-ds-binary-tree, tag-recursion, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  IList<int> nodeList = null;

  public IList<int> RightSideView(TreeNode root) {
    nodeList = new List<int>();
    FindRight(root);
    return nodeList;
  }

  private void FindRight(TreeNode root, int depth = 0) {
    if (root == null)
      return;

    if (nodeList.Count == depth)
      nodeList.Add(root.val);

    FindRight(root.right, depth + 1);
    FindRight(root.left, depth + 1);
  }
}
/* Pruning is not as simple as this,

  if (nodeList.Count == depth)
    FindRight(root.left, depth + 1);

And following idea, did not work as well, iterative seems hard

  while (current != null) {
    nodeList.Add(current.val);
    current = current.right ?? current.left ?? prev?.right ?? prev?.left;
    prev = current;
  }

*/


// v1 2015-08-05
public class Solution
{
  List<int> nums;
  public IList<int> RightSideView(TreeNode root) {
    nums = new List<int>();
    int maxLevel = 0;
    RightSideView_rec(root, 1, ref maxLevel);
    return nums;
  }

  void RightSideView_rec(TreeNode root, int level, ref int maxLevel) {
    if (root == null)
      return;
    if (level > maxLevel)
    {
      nums.Add(root.val);
      maxLevel = level;
    }
    RightSideView_rec(root.right, level + 1, ref maxLevel);
    RightSideView_rec(root.left, level + 1, ref maxLevel);
  }
}

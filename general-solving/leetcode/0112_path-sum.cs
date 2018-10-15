/***************************************************************************************************
* Title : Path Sum
* URL   : https://leetcode.com/problems/path-sum/
* Date  : 2015-11-01
* Comp  : O(n) Time (164ms)
* Author: Atiq Rahman
* Status: Accepted (180ms)
* Notes : Visits every node, adds to sum, roll back
*   when going back and keep checking values
*   
*   Time is O(n) because it's gonna traverse all nodes
*
* meta  : tag-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public bool HasPathSum(TreeNode root, int sum, int curSum = 0) {
    if (root != null) {
      curSum += root.val;
      if (root.left == null && root.right == null && curSum == sum)
        return true;
      if (HasPathSum(root.left, sum, curSum) || HasPathSum(root.right, sum, curSum))
        return true;
    }
    return false;   
  }
}

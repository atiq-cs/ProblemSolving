/***************************************************************************
* Title       : Second Minimum Node In a Binary Tree
* URL         : https://leetcode.com/problems/second-minimum-node-in-a-binary-
*               tree/
* Date        : Sep 7 2017
* Complexity  : O(n), Space O(n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : For understanding 2 things to consider,
*               1. first min value is already on *root* node
*               2. left node necessarily does not have a smaller value than
*               right node
*
* meta        : tag-recursion, tag-tree
***************************************************************************/

public class Solution {
  private int second;
  private int first;

  public int FindSecondMinimumValue(TreeNode root) {
    first = root.val;
    second = int.MaxValue;
    FindSecondMinimumValueRec(root);
    return second==int.MaxValue?-1:second;
  }

  private void FindSecondMinimumValueRec(TreeNode root) {
    if (root == null) return ;
    if (first < root.val && second > root.val)
      second = root.val;

    FindSecondMinimumValueRec(root.left);
    FindSecondMinimumValueRec(root.right);
  }
}

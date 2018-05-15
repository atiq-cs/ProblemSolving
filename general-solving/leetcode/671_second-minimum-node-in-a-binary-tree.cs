/***************************************************************************
* Title       : Second Minimum Node In a Binary Tree
* URL         : https://leetcode.com/problems/second-minimum-node-in-a-binary-
*               tree
* Date        : 2017-09-07
* Complexity  : O(n), Space O(n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : For understanding 2 things to consider,
*               1. first min value is already on *root* node
*               2. left node necessarily does not have a smaller value than
*               right node
*
* meta        : tag-recursion, tag-binary-tree
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

/* Examples that help,
[2,2,2]
[2,2,5,null,null,5,7]
[5,5,6]
[1,1,3,1,1,3,4,3,1,1,1,3,8,4,8,3,3,1,6,2,1]
*/

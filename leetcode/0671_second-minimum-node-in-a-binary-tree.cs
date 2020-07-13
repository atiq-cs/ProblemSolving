/***************************************************************************************************
* Title : Second Minimum Node In a Binary Tree
* URL   : https://leetcode.com/problems/second-minimum-node-in-a-binary-tree
* Date  : 2017-09-07
* Comp  : O(n), O(n)
* Status: Accepted
* Notes : As the problem desc states,
*    If the node has two sub-nodes, then this node's value is the smaller value among its two
*    sub-nodes.
*
* Hence, 2 things to consider,
*   1. first min value is already on *root* node
*   2. left node necessarily does not have a smaller value than
*   right node
*
* meta  : tag-ds-binary-tree, ds-full-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************************************/
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
    if (root == null)
      return ;

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

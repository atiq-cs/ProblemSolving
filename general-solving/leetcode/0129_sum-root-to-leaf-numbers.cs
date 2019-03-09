/***************************************************************************
* Title : Sum Root to Leaf Numbers
* URL   : https://leetcode.com/problems/sum-root-to-leaf-numbers
* Date  : 2017-12
* Author: Atiq Rahman
* Comp  : O(N)
* Status: Accepted
* Notes : Handle passing the number from leaf node is the essence of it
* meta  : tag-ds-binary-tree, tag-leetcode-medium
***************************************************************************/
public class Solution {
  public int SumNumbers(TreeNode root, int num = 0) {
    if (root == null)
      return 0;
    num = num * 10 + root.val;
    // leaf node, to avoid duplication for double null
    if (root.left == null && root.right == null)
      return num;
    return SumNumbers(root.left, num) + SumNumbers(root.right, num);
  }
}

// Previous version: using class Member and less functional
public class Solution {
  int Sum = 0;
  public int SumNumbers(TreeNode root) {
    SumNumbersRec(root, 0);
    return Sum;
  }

  private void SumNumbersRec(TreeNode root, int sum) {
    if (root == null)
      return;
    int val = sum * 10 + root.val;
    // leat node
    if (root.left == null && root.right == null) {
      Sum += val;
      return;
    }
    SumNumbersRec(root.left, val);
    SumNumbersRec(root.right, val);
  }
}

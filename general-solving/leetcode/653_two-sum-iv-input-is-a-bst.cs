/***************************************************************************
* Title : Two Sum IV - Input is a BST
* URL   : https://leetcode.com/problems/two-sum-iv-input-is-a-bst
* Date  : 2018-06
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : Easy testcases I guess, can hit null pointer for hard cases?
* Rel   : 'leetcode/167_two-sum-ii-input-array-is-sorted.cs'
* meta  : tag-leetcode-easy, tag-two-pointers, tag-binary-tree, tag-successor,
*   tag-predecessor
***************************************************************************/
public class Solution {
  // this method needs to return node instead of value for this problem
  public TreeNode Next() {
    return currentNode;
  }

  public bool FindTarget(TreeNode root, int k) {
    BSTIterator nextIterator = new BSTIterator(root),
      preIterator = new BSTIterator(root, true);
    
    for (TreeNode left = nextIterator.HasNext() ? nextIterator.Next() : null,
      right = preIterator.HasNext()? preIterator.Next() : null; left.val <
      right.val; ) {
      int sum = left.val + right.val;
      if (sum == k)
        return true;
      if (sum < k)
        left = nextIterator.HasNext()? nextIterator.Next() : null;
      else
        right = preIterator.HasNext()? preIterator.Next() : null;
    }
    return false;
  }
}

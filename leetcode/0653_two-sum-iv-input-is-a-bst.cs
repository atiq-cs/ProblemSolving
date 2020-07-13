/***************************************************************************************************
* Title : Two Sum IV - Input is a BST
* URL   : https://leetcode.com/problems/two-sum-iv-input-is-a-bst
* Date  : 2018-06
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : These problem has easy testcases I guess.
*   This solution will hit null pointer exception: NullReferenceException
*   when an empty or null tree is passed, i.e, []
*   [1] will work because left, right both pointing at that node and value at
*   left node won't be less than value at right node.
* rel   : 'leetcode/167_two-sum-ii-input-array-is-sorted.cs'
* meta  : tag-leetcode-easy, tag-two-pointers, tag-binary-tree, tag-successor,
*   tag-predecessor
***************************************************************************************************/
public class Solution {
  // BST Iterator is at 'demos/ds/binary-tree/Iterator.cs'
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

/***************************************************************************
* Title : Maximum Binary Tree
* URL   : https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
* Date  : 2017-10-24
* Author: Atiq Rahman
* Comp  : O(n), O(lg n) space for recursion stack
* Status: Accepted
* Notes : Naive approach
*   Traverse all nodes. while doing so find the one with highest depth. This
*   can be tracked doing an inorder traversal. Inorder works because it visits
*   the left node before other nodes.
*
*   Same, 'lintcode/177_convert-sorted-array-to-binary-search-tree-with-minimal-height.cpp'
* meta  : tag-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************/
public class Solution {
  int[] A;
  
  private TreeNode SortedArrayToBSTRec(int p, int r) {
    if (p > r)
      return null;
    int mid = (p+r)/2;
    TreeNode root = new TreeNode(A[mid]);
    root.left = SortedArrayToBSTRec(p, mid-1);
    root.right = SortedArrayToBSTRec(mid+1, r);
    return root;
  }
  
  public TreeNode SortedArrayToBST(int[] nums) {
    A = nums;
    return SortedArrayToBSTRec(0, A.Length-1);
  }
}

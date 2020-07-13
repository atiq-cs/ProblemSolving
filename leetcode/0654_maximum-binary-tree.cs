/***************************************************************************
* Title : Maximum Binary Tree
* URL   : https://leetcode.com/problems/maximum-binary-tree/
* Date  : 2017-10-24
* Author: Atiq Rahman
* Comp  : O(n^2), n for traversing the tree and n for finding max for visit of
*   each node. O(n) for storing the sorted list and O(lg n) space complexity
*   for recursion stack
*
* Status: Accepted
* Notes : Similar to building binary tree from sorted array or converting
*   sorted array to BST: '108_convert-sorted-array-to-binary-search-tree.cs'
*   mid calculation/selection part is modified to solve this problem.
*
* meta  : tag-ds-binary-tree, tag-leetcode-easy
***************************************************************************/
public class Solution {
  int[] A;

  private int FindMax(int p, int r) {
    int max = p;
    for (int i=p+1; i<=r; i++) {
      if (A[max] < A[i])
        max = i;
    }
    return max;
  }

  private TreeNode ConstructMaximumBinaryTreeRec(int p, int r) {
    if (p>r)
      return null;
    int maxIndex = FindMax(p, r);
    TreeNode root  = new TreeNode(A[maxIndex]);
    root.left = ConstructMaximumBinaryTreeRec(p, maxIndex-1);
    root.right = ConstructMaximumBinaryTreeRec(maxIndex+1, r);
    return root;    
  }
  
  public TreeNode ConstructMaximumBinaryTree(int[] nums) {
    A = nums;
    return ConstructMaximumBinaryTreeRec(0, A.Length-1);
  }
}

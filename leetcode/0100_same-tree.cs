/***************************************************************************************************
* Title : Same Tree
* URL   : https://leetcode.com/problems/same-tree/
* Date  : 2015-11
* Comp  : O(n) Time
* Author: Atiq Rahman
* Status: Accepted (180ms)
* Notes : Based on the idea that in a binary tree if any of the left or
*   right sub-tree returns false they are not same tree
*   
*   Then, all we need is just to take care of the null cases
*   Time is O(n) because it's gonna traverse all nodes of the tree
*   
* meta  : tag-ds-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************************************/

public class Solution {
  public bool IsSameTree(TreeNode p, TreeNode q) {
    if (p==null || q==null)
      return p==q;
    if (p.val != q.val)
      return false;
    return (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));
  }
}

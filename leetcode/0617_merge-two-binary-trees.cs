/***************************************************************************************************
* Title : Merge Two Binary Trees
* URL   : https://leetcode.com/problems/merge-two-binary-trees
* Occasn: Innoworld (offtime)
* Date  : 2019-01-27
* Comp  : O(M+N), O(N+N)
* Status: Accepted
* Notes : Using null coalescing operator for pointers
* meta  : tag-recursion, tag-csharp-null-coalescing, tag-ds-binary-tree, tag-leetcode-easy
***************************************************************************************************/
public class Solution {
  public TreeNode MergeTrees(TreeNode t1, TreeNode t2) {
    if (t1 == null && t2 == null)
      return null;

    // additional parentheses are required here
    TreeNode t = new TreeNode((t1?.val ?? 0) + (t2?.val ?? 0));
    t.left = MergeTrees(t1?.left, t2?.left);
    t.right = MergeTrees(t1?.right, t2?.right);
    return t;
  }
}

/*
Readability,

  int val = (t1?.val ?? 0) + (t2?.val ?? 0);
  TreeNode t = new TreeNode(val);
*/

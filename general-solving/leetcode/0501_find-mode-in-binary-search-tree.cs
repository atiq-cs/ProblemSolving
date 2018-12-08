/***************************************************************************
* Title : Find Mode in Binary Search Tree
* URL   : https://leetcode.com/problems/find-mode-in-binary-search-tree
* Date  : 2018-05-13
* Author: Atiq Rahman
* Comp  : O(n), O(lg n) Stack Space if balanced
* Status: Accepted
* Notes : Inorder traversal gives us sorter order for a BST. Because the items
*   are sorted we can check consecutive items for frequency and update max.
*   max (maxFreq) contains the most frequency.
*   
*   During inorder traversal we maintain previous node using a class member.
*   We appropriately handle cases when it is null.
*   
*   Only does inorder traversal of a binary tree. It does not utilize anything other than that the
*   fact that input binary tree is sorted.
* meta  : tag-ds-BST, tag-leetcode-easy
***************************************************************************/
public class Solution
{
  private List<int> modes;

  public int[] FindMode(TreeNode root) {
    modes = new List<int>();
    InOrder(root);
    if (pre == null) ; else if (maxFreq == freq)
      modes.Add(pre.val);
    else if (maxFreq < freq)
    {
      maxFreq = freq;
      modes = new List<int>(new int[] { pre.val });
    }
   return modes.ToArray();
  }
  
  private TreeNode pre = null;
  private int freq = 1, maxFreq=0;
  
  public void InOrder(TreeNode root) {
    if (root == null)
      return;
    InOrder(root.left);
    if (pre == null) ; else if (pre.val == root.val) {
      freq++;
    }
    else {
      if (maxFreq == freq)
        modes.Add(pre.val);
      else if (maxFreq < freq) {
        maxFreq = freq;
        modes = new List<int>(new int[] { pre.val });
      }
      freq = 1;
    }
    pre = root;
    InOrder(root.right);
  }
}

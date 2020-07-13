/***************************************************************************************************
* Title : Construct String from Binary Tree
* URL   : https://leetcode.com/problems/construct-string-from-binary-tree/
* Date  : 2018-01-21
* Comp  : O(n lg n)
* Status: Accepted
* Notes : For string operations, we are approximately using O(N) time on each node level. Hence,
*   O(n lg n)
* meta  : tag-ds-binary-tree, tag-leetcode-easy
***************************************************************************************************/
public class Solution {
  public string Tree2str(TreeNode root) {
    if (root == null)
      return "";

    string res = (root.val + "(" + Tree2str(root.left) + ")" + "(" +
      Tree2str(root.right) + ")").Replace("())", ")").Replace(")()", ")").
      Replace("()()", "");

    return res.EndsWith("()")? res.Substring(0, res.Length - 2): res;
  }
}

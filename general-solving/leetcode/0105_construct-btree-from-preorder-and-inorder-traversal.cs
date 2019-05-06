/***************************************************************************************************
* Title : Construct Binary Tree from Preorder and Inorder Traversal
* URL   : https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal
* Date  : 2018-12-09
* Comp  : O(N^2), O(N) if unbalanced; O( N lg N), O(lg N)
* Status: Accepted
* Notes : Readable and elaborate solution
*  Soution 2 is for reference
* ref   : 
* Ack   : Mak (for comp analysis)
* rel   : leetcode#106
* meta  : tag-ds-binary-tree, tag-graph-dfs, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  int index = 0;

  public TreeNode BuildTree(int[] preorder, int[] inorder) {
    return BuildTree(preorder, inorder, 0, preorder.Length - 1);
  }

  public TreeNode BuildTree(int[] preorder, int[] inorder, int start, int end) {
    if (start > end)
      return null;

    TreeNode node = new TreeNode(preorder[index]);
    int inIndex = findInorderPosition(inorder, preorder[index++], start, end);
    node.left = BuildTree(preorder, inorder, start, inIndex - 1);
    node.right = BuildTree(preorder, inorder, inIndex + 1, end);
    return node;
  }

  // limit search scope to [start, end]
  int findInorderPosition(int[] inorder, int value, int start, int end) {
    for (int i = start; i <= end; i++)
      if (inorder[i] == value)
        return i;
    return -1;
  }
}

// Added later, for reference
public class SolutionV2 {
  private int preIndex = 0;
  private int inIndex = 0;

  // the elegant solution from https://leetcode.com/problems/construct-binary-tree-from-preorder-
  // and-inorder-traversal/discuss/193239/Java-solution.-Super-elegant!
  // Comp: ToDo
  public TreeNode BuildTree(int[] preorder, int[] inorder, TreeNode end = null) {
    if (inIndex > inorder.Length - 1 || (end != null && end.val == inorder[inIndex]))
      return null;

    TreeNode root = new TreeNode(preorder[preIndex++]);
    root.left = BuildTree(preorder, inorder, root);

    inIndex++;
    root.right = BuildTree(preorder, inorder, end);

    return root;
  }
}

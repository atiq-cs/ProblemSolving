/***************************************************************************
* Title : Count Complete Tree Nodes
* URL   : https://leetcode.com/problems/count-complete-tree-nodes
* Date  : 2018-05-10
* Comp  : O((lg n) ^ 2) Time, O(lg n) Space comp of GetHeight
*   Worst case will be: lg N + lg (N/2) + lg (N/4) + .... + 1
*   if h = lg N this becomes, T = h + (h-1) + (h-2) + (h-3) + .... + 1
*   => T = h * (h+1) / 2
*   Therefore, T = O((lg N)^2)
* Status: Accepted
* Notes : Count number of nodes in complete binary tree. Do better than O(N)
*   From C.L.R.S (possibly),
*   A complete binary tree is a binary tree which is filled except possibly the
*   last/bottom level, which is filled from left to right.
* 
*   From a node, check strictly left side and check strictly right side. If
*   heights match then we found a perfect binary tree for which the count is
*   2^(h+1) - 1. Otherwise, we apply similar approach to sum of the count for
*   left subtree and right subtree.
*   
* Ack   : Initial idea, Kevin Huang
* Ref   : https://atiqcs.wordpress.com/2017/11/21/binary-tree-jargon/
* meta  : tag-ds-binary-tree, tag-leetcode-medium
***************************************************************************/
public class Solution {
  // final version
  public int CountNodes(TreeNode root) {
    if (root == null)
      return 0;
    int lh = GetHeight(root.left);
    int rh = GetHeight(root.right, false);
    if (lh == rh)
      return (int) Math.Pow(2, lh+1)-1;
    return CountNodes(root.left) + CountNodes(root.right) + 1;
  }
  // O(lg n) Time/Space
  private int GetHeight(TreeNode root, bool isLeft=true) {
    if (root == null)
      return 0;
    return GetHeight(isLeft?root.left:root.right, isLeft) + 1;
  }

  // first version: O(N) - TLE
  public int CountNodes_v1(TreeNode root) {
    if (root == null)
      return 0;
    return CountNodes(root.left) + CountNodes(root.right) + 1;
  }
}
/*
Example,
[1]
[1,2,3]
[1,2,3,4,5,6]

Initial thoughts - TLE,
level 2
no right child
 return 2

level 3

check left height
check right height
equal? return result

not equal
check 

do dfs
whenever in a node it is encountered that it has left but no right stop

dfs(v) {
  if (last_left_leaf_discovered)
    return ;
  if (v == null)
    return;
  if (v.left == null && v.right == null) {
    // this is the node
    leaf_count ++;
  }
  dfs(v.left);
  dfs(v.right);
}


input example,
[1]
[1,2]
[1,2,3]
[1,2,3,4]
[1,2,3,4,5]
[1,2,3,4,5,6]
[1,2,3,4,5,6,7]
*/

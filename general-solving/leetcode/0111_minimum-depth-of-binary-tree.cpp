/***************************************************************************************************
* Title : Find the minimum depth of a binary tree
* URL   : https://leetcode.com/problems/minimum-depth-of-binary-tree/
*   http://www.lintcode.com/en/problem/minimum-depth-of-binary-tree/
* Date  : 2015-07-22
*
*   
* Notes : if we don't consider the
*   - case when left or right child is null solution is wrong
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* meta  : tag-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************************************/

class Solution {
public:
  /**
  * @param root: The root of binary tree.
  * @return: An integer
  */
  int minDepth(TreeNode *root) {
    // write your code here
    if (root == NULL)
      return 0;

    if (root->left == NULL)
      return minDepth(root->right) + 1;

    if (root->right == NULL)
      return minDepth(root->left) + 1;

    return (std::min(minDepth(root->left), minDepth(root->right)) + 1);
  }
};

/***************************************************************************************************
* Title : Determines if given string has some properties
* URL   : https://leetcode.com/problems/maximum-depth-of-binary-tree/
* Date  : 2015-08-07
* Comp  : O(n) .008s
* rel   : https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree
* Status: Accepted
* meta  : tag-binary-tree, tag-recursion, tag-leetcode-easy
***************************************************************************************************/
class Solution {
public:
  int height(node * root) {
    if (root == NULL)
      return 0;
    return std::max(height(root->left) + 1, height(root->right) + 1);
  }
}

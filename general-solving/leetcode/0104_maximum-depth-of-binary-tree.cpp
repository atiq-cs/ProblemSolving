/***************************************************************************
*   Problem Name:   Determines if given string has some properties
*   Problem URL :   https://leetcode.com/problems/maximum-depth-of-binary-tree/
                    related: https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree
*   Domain      :   data-structures/trees
*   DateTime    :   August 7, 2015
*   Desc        :   Recursion on Binary Tree
*                   
*
*   Complexity  :   O(n), .008s
*   Author      :   Atiq Rahman
*   Status      :   Accepted
***************************************************************************/

int height(node * root)
{
  if (root == NULL)
      return 0;
  return std::max(height(root->left)+1, height(root->right)+1);
}

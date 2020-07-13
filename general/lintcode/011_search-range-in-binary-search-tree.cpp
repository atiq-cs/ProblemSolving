/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/search-range-in-binary-search-tree/
* Date  : 2015-06-22
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : 
*   In-order traversal of binary tree, wiki
*   https://en.wikipedia.org/wiki/Tree_traversal#In-order_.28symmetric.29
*   geeksforgeeks
*   http://www.geeksforgeeks.org/618/
*
*   From wiki,
*   1. Traverse the left subtree by recursively calling the in-order function.
*   2. Display the data part of root element (or current element).
*   3. Traverse the right subtree by recursively calling the in-order function.
* meta  : tag-ds-BST, tag-recursion
***************************************************************************************************/
class Solution {
  vector<int> result;
public:
  /**
  * @param root: The root of the binary search tree.
  * @param k1 and k2: range k1 to k2.
  * @return: Return all keys that k1<=key<=k2 in ascending order.
  */
  vector<int> searchRange(TreeNode* root, int k1, int k2) {
    // write your code here
    // if we instantiate an object of vector without specifying size on constructor
    // we do not need to clear it in lintcode but
    // for other online judge we might need to clear it
    // as it will add up the nodes for each input
    // and will become a large in the end
    result.clear();
    InOrderSearchRange(root, k1, k2);
    return result;
  }

  void InOrderSearchRange(TreeNode* root, int k1, int k2) {
    if (root == NULL)
      return;
    InOrderSearchRange(root->left, k1, k2);
    if (k1 <= root->val && root->val <= k2)
      result.push_back(root->val);
    InOrderSearchRange(root->right, k1, k2);
  }
};

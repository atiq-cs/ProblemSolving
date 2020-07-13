/***************************************************************************************************
* Title : Binary Tree Level Order Traversal
* URL   : https://leetcode.com/problems/binary-tree-level-order-traversal/
* Date  : 2015-01-05
* Comp  : O(n) Time
* Author: Atiq Rahman
* Status: Accepted
* Notes : consider that nodes of each level stays on specific index on the vector of vectors
* meta  : tag-ds-binary-tree, tag-graph-bfs, tag-leetcode-medium
***************************************************************************************************/
class Solution {
private:
  vector<vector<int>> tr_node_list;
  
public:
  vector<vector<int>> levelOrder(TreeNode* root) {
    levelOrderRec(root, 0);
    return tr_node_list;
  }
  void levelOrderRec(TreeNode* root, int index) {
    if (root == NULL)
      return;
    if (tr_node_list.size() <= index) {
      vector<int> temp;
      tr_node_list.push_back(temp);
    }
    tr_node_list[index].push_back(root->val);
    levelOrderRec(root->left, index+1);
    levelOrderRec(root->right, index+1);
  }
};

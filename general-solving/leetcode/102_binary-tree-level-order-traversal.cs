/***************************************************************************
* Problem Name: Binary Tree Level Order Traversal
* Problem URL : https://leetcode.com/problems/binary-tree-level-order-traversal/
* Date        : Jan 5 2015
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted (405ms)
* Notes       : consider that nodes of each level stays on specific index on
*               the vector of vectors
*               this is the C# version from the cpp solution accepted first
* meta        : tag-binary-tree
***************************************************************************/

public class Solution {
    IList<IList<int>> Node_list_list;
    public IList<IList<int>> LevelOrder(TreeNode root) {
        Node_list_list = new List<IList<int>>();
        LevelOrderRec(root, 0);
        return Node_list_list;
    }
    
    void LevelOrderRec(TreeNode root, int index) {
        if (root == null)
            return ;
        if (Node_list_list.Count <= index) {
            IList<int> temp = new List<int>();
            Node_list_list.Add(temp);
        }
        Node_list_list[index].Add(root.val);
        LevelOrderRec(root.left, index + 1);
        LevelOrderRec(root.right, index + 1);
    }
}

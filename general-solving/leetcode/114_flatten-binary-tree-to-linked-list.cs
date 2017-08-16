/***************************************************************************
* Problem Name: Flatten Binary Tree to Linked List
* Problem URL : https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
* Date        : Sept 26 2015
* Complexity  : 
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Key here is that the flattened tree, each node's right child
*               points to the next node of a pre-order traversal
* meta        : tag-binary-tree; tag-recursion
***************************************************************************/
public class Solution
{
    TreeNode previousNode;
    public void Flatten(TreeNode root) {
        previousNode = null;
        FlattenRec(root);
    }

    void FlattenRec(TreeNode root) {
        if (root == null)
            return;
        if (previousNode != null) {
            previousNode.right = root;
            previousNode.left = null;
        }
        previousNode = root;
        TreeNode temp = root.right;
        FlattenRec(root.left);
        FlattenRec(temp);
    }
}

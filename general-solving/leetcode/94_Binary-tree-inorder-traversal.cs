/***************************************************************************
* Problem Name: Binary Tree Inorder Traversal
* Problem URL : https://leetcode.com/problems/binary-tree-inorder-traversal/
* Date        : Aug 2 2015
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted (beats 84%)
* Notes       : 
* meta        : tag-lca
***************************************************************************/

public class Solution
{
    List<int> node_list;
    public IList<int> InorderTraversal(TreeNode root)
    {
        node_list = new List<int>();
        InorderTraversal_rec(root);
        return node_list;
    }

    public void InorderTraversal_rec(TreeNode root)
    {
        if (root == null)
            return;
        InorderTraversal_rec(root.left);
        node_list.Add(root.val);
        InorderTraversal_rec(root.right);
    }
}

/*
OJ's Binary Tree Serialization:
The serialization of a binary tree follows a level order traversal, where '#' signifies a path terminator where no node exists below.

[37,-34,-48,null,-100,-100,48,null,null,null,null,-54,null,-71,-22,null,null,null,8]
*/

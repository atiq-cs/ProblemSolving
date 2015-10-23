/***************************************************************************
* Problem Name: Binary Tree Postorder Traversal
* Problem URL : https://leetcode.com/problems/binary-tree-postorder-traversal/
* Date        : Sept 24 2015
* Complexity  : O(n)
* Author      : Atiq Rahman
* Status      : Accepted (beat 78.57%)
* Notes       : 
* meta        : tag-easy, tag-binary-tree
***************************************************************************/

public class Solution
{
    IList<int> nodeList;
    public IList<int> PostorderTraversal(TreeNode root)
    {
        nodeList = new List<int>();
        PostorderTraversalRec(root);
        return nodeList;
    }

    void PostorderTraversalRec(TreeNode root)
    {
        if (root == null)
            return;
        PostorderTraversalRec(root.left);
        PostorderTraversalRec(root.right);
        nodeList.Add(root.val);
    }
}

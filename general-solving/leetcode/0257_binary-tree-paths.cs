/***************************************************************************
* Problem Name: Binary Tree Paths
* Problem URL : https://leetcode.com/problems/binary-tree-paths/
* Date        : Sept 24 2015
* Complexity  : O(n)
* Author      : Atiq Rahman
* Status      : Accepted (beat 99.49%)
* Notes       : 
* meta        : tag-easy, tag-binary-tree
***************************************************************************/
public class Solution
{
    List<string> pathList;
    public IList<string> BinaryTreePaths(TreeNode root) {
        pathList = new List<string>();
        BinaryTreePathsRec(root, "");
        return pathList;
    }

    void BinaryTreePathsRec(TreeNode root, string pathToLeaf) {
        if (root == null)
            return;
        if (root.left == null && root.right == null)
            pathList.Add(pathToLeaf + root.val.ToString());

        pathToLeaf = pathToLeaf + root.val.ToString() + "->";
        BinaryTreePathsRec(root.left, pathToLeaf);
        BinaryTreePathsRec(root.right, pathToLeaf);
    }
}

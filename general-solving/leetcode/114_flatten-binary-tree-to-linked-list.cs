/***************************************************************************
* Problem Name: Permutation Sequence
* Problem URL : https://leetcode.com/problems/permutation-sequence/submissions/
* Date        : Sept 27 2015
* Complexity  : 
* Author      : Atiq Rahman
* Status      : Accepted (beat 78% Time)
* Notes       : 
* meta        : tag-easy
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


/*
    Idea: Basically pre-order traversal to get the linked list order. A global reference is used to retrieve preivious node whose next (right) pointer will be changed
    However, while traversing left FlattenRec(root.left); it might change a right value that would 
    be used by FlattenRec(root.right); this might cause an infinite loop
 */

/***************************************************************************
* Problem Name: Symmetric Tree
* Problem URL : https://leetcode.com/problems/symmetric-tree/
* Date        : Aug 5 2015
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted (beats 68%)
* Notes       : 
* meta        : tag-binary-tree
***************************************************************************/

public class Solution {
    public bool IsSymmetric(TreeNode root) {
        return IsSymmetric_rec(root, root);
    }

    bool IsSymmetric_rec(TreeNode root_left, TreeNode root_right) {
        if (root_left == null || root_right == null)
            return root_left==root_right;
            
        if (root_left.val != root_right.val)
            return false;

        return IsSymmetric_rec(root_left.left, root_right.right) && IsSymmetric_rec(root_left.right, root_right.left);
    }
}

/*
* If one of them is null and other one not then the tree is not symmetric - line 17-18
* if the value at that point does not match then it is not symmetric - line 21-22
* Now check the properties whether holds similarly for left's left and right's right
*  also for left's right and right's left
*/

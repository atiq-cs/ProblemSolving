/***************************************************************************
* Problem Name: Path Sum
* Problem URL : https://leetcode.com/problems/path-sum/
* Date        : Nov 2015
* Complexity  : O(n) Time (164ms)
* Author      : Atiq Rahman
* Status      : Accepted (180ms)
* Notes       : Visits every node, adds to sum, roll back
*               when going back and keep checking values
*               
*               Time is O(n) because it's gonna traverse all nodes
*
* meta        : tag-binary-tree; tag-recursion; tag-easy
***************************************************************************/

public class Solution {
    public bool HasPathSum(TreeNode root, int sum) {
        return HasPathSumRec(root, 0, sum);
    }
    
    bool HasPathSumRec(TreeNode root, int curSum, int sum) {
        if (root != null) {
            curSum += root.val;
            if (root.left == null && root.right == null && curSum == sum)
                return true;
            if (HasPathSumRec(root.left, curSum, sum) || HasPathSumRec(root.right, curSum, sum))
                return true;
        }
        return false;
    }
}

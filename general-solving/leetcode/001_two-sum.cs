/***************************************************************************
* Problem Name: Two Sum
* Problem URL : https://leetcode.com/problems/two-sum/
* Date        : Jan 11 2015
* Complexity  : O(N) Time and Space
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : hashset is a better data structure for set operations
*               As we don't require set operations we use dictionary
*               beats 44.74%
* meta        : tag-hashtable
***************************************************************************/

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> numDict = new Dictionary<int, int>();
        
        for (int i=0; i<nums.Length; i++) {
            try {
                numDict.Add(nums[i], i+1);
            }
            catch (ArgumentException) { }
        }
        
        for (int i=0; i<nums.Length; i++) {
            try {
                int j = numDict[target-nums[i]];
                if (i+1 == j)
                    continue;
                if (i+1 > j)
                    return new int[] {j, i+1};
                return new int[] {i+1, j};
            }
            catch (KeyNotFoundException) { }
        }

        return new int[] {0, 0};
    }
}

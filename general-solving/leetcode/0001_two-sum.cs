/***************************************************************************
* Problem Name: Two Sum
* Problem URL : https://leetcode.com/problems/two-sum/
* Date        : Jan 11 2015
* Complexity  : O(N) Time and Space
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : hashset is a better data structure for set operations as we
*   don't require set operations we use dictionary
*   ref: https://leetcode.com/articles/two-sum/
*   Probably input number are distinct in that case we can use a hashMap
*   instead of Dictionary
* meta        : tag-hashtable
***************************************************************************/
public class Solution {
  // second version after Microsoft Interview 2018-05-21, similar to last one
  // in above article; utilizes single loop
  public int[] TwoSum(int[] nums, int sum)
  {
    var numDict = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++) {
      if (numDict.ContainsKey(sum - nums[i]))
        return new int[] { i, numDict[sum - nums[i]] };
      // numbers in nums can be duplicate
      if (numDict.ContainsKey(nums[i]) == false)
        numDict.Add(nums[i], i);
    }
    return null;
  }

  // first version
  public int[] TwoSumv1(int[] nums, int target) {
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

    return null;
  }
}

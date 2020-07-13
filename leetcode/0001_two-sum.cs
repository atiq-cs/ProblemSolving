/***************************************************************************************************
* Title : Two Sum
* URL   : https://leetcode.com/problems/two-sum/
* Date  : 2015-01-11
* Comp  : O(N), O(N)
* Status: Accepted
* Notes : HashSet is a better data structure for set operations. If we don't require set operations
*   we use dictionary for mapping.
*  Probably input numbers are distinct. In that case, we could use a HashSet instead of Dictionary
*  if it didn't require us to return pair of indices.
* ref   : https://leetcode.com/articles/two-sum/
* meta  : tag-ds-hashtable, tag-company-microsoft, tag-leetcode-easy
***************************************************************************************************/
public class Solution {
  /// <summary>
  /// Second version after Microsoft Interview 2018-05-21, similar to last one in above article;
  /// does it in single loop; we can use TryGetValue to reduce number of lookups
  /// </summary>
  public int[] TwoSum(int[] nums, int sum)
  {
    var numDict = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++) {
      if (numDict.ContainsKey(sum - nums[i]))
        return new int[] { i, numDict[sum - nums[i]] };
      // numbers in input array can be duplicate
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

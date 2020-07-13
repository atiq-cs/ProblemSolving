/***************************************************************************************************
* Title : Longest Consecutive Sequence
* URL   : https://leetcode.com/problems/longest-consecutive-sequence/
* Date  : 2018-01-10
* Comp  : O(n), O(N) for v1
* Author: Atiq Rahman
* Status: Accepted
* Notes : Takes care of the case that when adding t[i], they do not become duplicate in the mapping...
* meta  : tag-ds-hash-table, tag-leetcode-easy
***************************************************************************************************/
public class Solution {
  /// <summary>
  /// DP Algorithm to find LCS Length: check finding sequence length starting with each smallest
  /// number in the sequence.
  /// 
  /// We push all numbers into the hashset in the beginning; hence, we can ignore the number which
  /// are not in input set and check if next number does exist as well.
  /// <remarks>
  /// Readability, we could write the inner loop like this,
  ///   int j = num;
  ///   while (numSet.Contains(j))
  ///     j++;
  /// </remarks>
  /// </summary>
  /// <param name="nums">input array </param>
  public int LongestConsecutive(int[] nums) {
    var numSet = new HashSet<int>(nums);
    int LCSLength = 0;

    foreach (var num in nums) {
      if (numSet.Contains(num - 1) == false) {
        int j;
        for (j = num; numSet.Contains(j); j++) ;

        LCSLength = Math.Max(LCSLength, j - num);
      }
    }
    return LCSLength;
  }
  /// <summary>
  /// Comp: O(N lg N), O(N)
  /// <remarks>
  /// Readability, we could write the inner loop like this,
  ///   int j = num;
  ///   while (numSet.Contains(j))
  ///     j++;
  /// </remarks>
  /// </summary>
  /// <param name="nums">input array </param>
  public int LongestConsecutive_v2(int[] nums) {
    Array.Sort(nums);

    var numSet = new HashSet<int>(nums);
    int length = 1; int ans = (nums.Length == 0) ? 0 : length;

    for (int i = 1; i < nums.Length; i++) {
      if (nums[i] == nums[i - 1] + 1)
        length++;
      else if (nums[i] != nums[i - 1])
        length = 1;
      ans = Math.Max(ans, length);
    }
    return ans;
  }
}

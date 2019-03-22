/***************************************************************************************************
* Title : Target Sum
* URL   : https://leetcode.com/problems/target-sum
* Date  : 2017-12
* Author: Atiq Rahman
* Comp  : 
* Status: Accepted
* Notes : Given data is unsorted.
*   C.L.R.S Intro to Cormen - Ch#35, 35.5, The subset-sum problem, p#1128
*   Approx-Subset-Sum is at p#1131
*   Yet to understand how this algo works
*
* meta  : tag-algo-dp, tag-leetcode-medium
***************************************************************************************************/
// Follows the solution from the board
public class Solution
{
  public int FindTargetSumWays(int[] nums, int s) {
    int sum = 0;
    foreach (int n in nums)
      sum += n;
    return sum < s || (s + sum) % 2 > 0 ? 0 : subsetSum(nums, (int) (((uint) (s +
      sum)) >> 1));
  }

  private int subsetSum(int[] nums, int s) {
    int[] dp = new int[s + 1];
    dp[0] = 1;
    foreach (int n in nums)
      for (int i = s; i >= n; i--)
        dp[i] += dp[i - n];
    return dp[s];
  }
}

// This solution timed out; first version
public class NaiveSolution {
  int[] Nums;
  int Sum;
  int NumWays;

  /* taking combination of '+' and/or '-'*/
  private void comb(int k) {
    if (k == Nums.Length) {
      int sum = 0;
      for (int i = 0; i < Nums.Length; i++)
        sum += Nums[i];
      if (sum == Sum)
        NumWays++;
      return;
    }

    /* This apparently can be replaced with a loop */
    Nums[k] = -Nums[k];
    comb(k + 1);
    Nums[k] = -Nums[k];
    comb(k + 1);
  }

  public int FindTargetSumWays(int[] nums, int S) {
    this.Nums = nums;
    this.Sum = S;
    NumWays = 0;
    comb(0);
    return NumWays;
  }
}

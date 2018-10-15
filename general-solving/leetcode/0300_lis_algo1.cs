/***************************************************************************************************
* Title : Longest Increasing Subsequence
* URL   : https://leetcode.com/problems/longest-increasing-subsequence/
* Date  : 2017-09-18
* Comp  : O(n^2)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Based on 'uva-online-judge/231_TestingTheCatcher_lis_algo1.cpp'
* ref   : https://wcipeg.com/wiki/Longest_increasing_subsequence
* meta  : tag-lis, tag-dp
***************************************************************************************************/
public class Solution
{
  /* n^2 version - simple LIS algo */
  public int LengthOfLIS(int[] A) {
    int n = A.Length;
    int[] dp = new int[n];   // contains LIS length or count
    for (int i = 0; i<n; i++) // initialize
      dp[i] = 1;

    for (int i = 0; i<n-1; i++)
      for (int j = i + 1; j<n; j++)
        // m[i] < m[j] means an increasing subsequence
        if ((A[i] < A[j]) && (dp[j]<dp[i] + 1))
          dp[j] = dp[i] + 1;
    return n==0?0:dp.Max();   // linq
  }
}

/*
Sample input
[-2,-1]
[10,9,2,5,3,7,101,18]
*/

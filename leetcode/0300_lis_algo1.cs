/***************************************************************************************************
* Title : Longest Increasing Subsequence
* URL   : https://leetcode.com/problems/longest-increasing-subsequence/
* Date  : 2017-09-18
* Comp  : O(n^2)
* Status: Accepted
* Notes : ToDo, how do we have the intuition that something better is possible
* ref   : 1. 'uva-online-judge/231_TestingTheCatcher_lis_algo1.cpp'
*   2. C.L.R.S 3rd ed p#397: Ex-15.4-5
*   Give an O(n^2) time algorithm to find the longest monotonically increasing subsequence of a
*   sequence of n numbers.
*   3. http://web.archive.org/web/20180810125723/http://wcipeg.com/wiki/Longest_increasing_subsequence
* meta  : tag-dp-lis, tag-algo-dp, tag-leetcode-medium
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
        if (A[i] < A[j] && dp[j] < dp[i] + 1)
          dp[j] = dp[i] + 1;
    return n==0?0:dp.Max();   // linq
  }
}

/*
Sample input
[-2,-1]
[10,9,2,5,3,7,101,18]
*/

/***************************************************************************
* Title       : Longest Increasing Subsequence
* URL         : https://leetcode.com/problems/longest-increasing-subsequence/
* Date        : Sept 18, 2017
* Complexity  : O(n^2)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Based on 'uva-online-judge/231_TestingTheCatcher_lis_algo1.cpp'
* Ref         : https://wcipeg.com/wiki/Longest_increasing_subsequence
* meta        : tag-lis, tag-dyanmic-programming
***************************************************************************/

public class Solution {
  /* n^2 version - simple LIS algo */
  public int LengthOfLIS(int[] A) {
    int n = A.Length;
    int[] lis = new int[n];   // contains LIS length or count
    for (int i = 0; i<n; i++) // initialize
      lis[i] = 1;

    for (int i = 0; i<n-1; i++)
      for (int j = i + 1; j<n; j++)
        // m[i] < m[j] means an increasing subsequence
        if ((A[i] < A[j]) && (lis[j]<lis[i] + 1))
          lis[j] = lis[i] + 1;
    return n==0?0:lis.Max();
  }
}

/*
Sample input
[-2,-1]
[10,9,2,5,3,7,101,18]
*/

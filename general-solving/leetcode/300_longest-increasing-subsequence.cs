/***************************************************************************
* Title       : Longest Increasing Subsequence
* URL         : https://leetcode.com/problems/longest-increasing-subsequence/
* Date        : Sept 18, 2017
* Complexity  : O(n^2)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : LIS
* Ref         : https://wcipeg.com/wiki/Longest_increasing_subsequence
* meta        : tag-lis, tag-dyanmic-programming
***************************************************************************/

public class Solution {
  /* n^2 version - simple LIS algo */
  public int LengthOfLIS(int[] m) {
    int n = m.Length;
    int[] a = new int[n];   // contains LIS length or count
    for (int i = 0; i<n; i++) // initialize
      a[i] = 1;

    for (int i = 0; i<n-1; i++)
      for (int j = i + 1; j<n; j++)
        // m[i] < m[j] means an increasing subsequence
        if ((m[i] < m[j]) && (a[j]<a[i] + 1))
          a[j] = a[i] + 1;
    return n==0?0:a.Max();
  }
}

/*
Sample input
[-2,-1]
[10,9,2,5,3,7,101,18]
*/

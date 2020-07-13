/***************************************************************************
* Title : Number of Longest Increasing Subsequence
* URL   : https://leetcode.com/problems/number-of-longest-increasing-subsequence
* Date  : 2018-09-02
* Author: Atiq Rahman
* Comp  : O(n^2)
* Status: Accepted
* Notes : This problems asks to count number of sequences possible for maximum
*   LIS length.
*   
*   Feels like DP of DP (on top of regular LIS DP)
*   See comments inline code
* meta  : tag-dp-lis, tag-algo-dp
***************************************************************************/
public class Solution {
  public int FindNumberOfLIS(int[] a) {   //v2, v1 is below
    int n = a.Length;
    int[] dp = new int[n];   // contains LIS length
    int[] ways = new int[n];
    for (int i = 0; i<n; i++) { // initialize LIS Length Array
      dp[i] = 1;
      // How many ways can we make LIS Length dp[i] for the sequence ending
      // this element as last item?
      ways[i] = 1;
    }

    for (int i = 0; i<n-1; i++)
      for (int j = i + 1; j<n; j++)
        if (a[i] < a[j]) {
          if (dp[j] < dp[i] + 1) {
            dp[j] = dp[i] + 1;
            ways[j] = ways[i];
          }
          else if (dp[j]==dp[i] + 1)
            ways[j] += ways[i];
        }
    // It's hard to do in single loop above. For maxLISLength, we need to
    // iterate through all of them and sum
    // But, we don't know the count for the max until iteration is complete for
    // last LIS length. It's just easier to do it on a separate loop.
    // Without following counting, it would a count of 1 for following input,
    //  [1, 3, 2] or [1,3, 5, 4]
    int count = 0, maxIndex = 0;
    for (int i = 1; i < n; i++)
      if (dp[maxIndex] < dp[i]) {
        maxIndex = i;
        count = ways[i];
      }
      else if (dp[maxIndex] == dp[i])
        count += ways[i];
    return n == 0? 0 : dp[maxIndex] == 1? n : count;
  }

  // Initial idea, reset count every time we are able to bump up LIS Length
  // but recurrence relation is wrong.. we have to include counts for number of
  // ways previous lengths were made
  public int FindNumberOfLIS(int[] a) {
    int n = a.Length;
    int[] dp = new int[n];
    for (int i = 0; i<n; i++)
      dp[i] = 1; 

    int count = 0;
    int maxLISLength = 0;
    for (int i = 0; i<n-1; i++)
      for (int j = i + 1; j<n; j++)
        if (a[i] < a[j]) {
          if (dp[j] < dp[i] + 1) {
            dp[j] = dp[i] + 1;
            if (dp[j] > maxLISLength) {
              maxLISLength = dp[j];
              count = 0;
            }
            count++;
          }
          else if ((dp[j]==dp[i] + 1))
              count++;
        }
    return maxLISLength==0? n : count;
  }
}

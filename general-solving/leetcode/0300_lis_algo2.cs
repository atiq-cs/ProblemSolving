/***************************************************************************************************
* Title : Longest Increasing Subsequence
* URL   : https://leetcode.com/problems/longest-increasing-subsequence/
* Date  : 2017-10-09
* Comp  : O(n lg n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : For this problem result subsequence is in increasing order.
*   Equal numbers are not considered part of the subsequence.
*   
*   When sorting order of numbers in subsequence is different, in two places
*   we need to update comparison operator:
*   - line 50 (compare lis[j] with current item from Array A)
*   - line 83 (Binary Search compares with item on index mid)
*   
* ref   : 1. C.L.R.S 3rd ed p#397: Ex-15.4-6
*   Maintain candidate subsequence by linking them through the input sequence
*   2. https://wcipeg.com/wiki/Longest_increasing_subsequence
*   3. https://gist.github.com/atiq-cs/4b7910712c87e51dc2357f3450ab037d
*
* rel   : uva / 231_TestingTheCatcher_lis_algo2_v*
* Ack   : Jane Alam Jan, MAK
* meta  : tag-dp-lis, tag-algo-dp, 
***************************************************************************************************/
public class Solution
{
  List<int> lis;
  int n;

  /*
   * The heart of this Solution is this function that implements dynamic
   * programming and uses Binary Search to update candidate sequence
   */
  public int LengthOfLIS(int[] A) {
    // Initialization
    n = A.Length;
    lis = new List<int>();
    int limit = -1;

    for (int i = 0; i<n; i++) {
      // get lower bound
      int j = BSearch(A[i], 0, limit) + 1;
      // returned index does not exist
      // that means it's time to create that index
      if (j == lis.Count) {
        lis.Add(A[i]);
        limit++;
      }
      // update lis if item is greater
      else if (lis[j] > A[i])
        lis[j] = A[i];
        /* to allow equal items in subsequence
         * equal number found in sequence
         * add this number in appropriate position
         * first number that is not equal to A[i]
         * replaces that number
         * 
         * need to check Index Out of bound
         * and update lis accordingly
         */
        /* else if (lis[j] == A[i])
          for (int k = j+1;; k++)
            if (A[i] != lis[k]) {
              lis[k] = A[i];
              if (limit < k)
              limit = k;
              break;
            }*/
    }
    return limit+1;
  }

  /*
   * Modified Binary Search to return immediate smaller one if item looked up is
   * not found.
   */
  private int BSearch(int item, int start, int end) {
    int mid = (start + end) / 2;
    // lower_bound: return lower index
    if (start > end)
      return end;
    // to allow equal items in the subsequence use <=
    else if (lis[mid] < item)
      return BSearch(item, mid + 1, end);
    else
      return BSearch(item, start, mid - 1);
  }
}

/*
Good Input,
[2,2]
[10,9,2,5,3,7,101,18]
[]
[0]
*/

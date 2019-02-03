/***************************************************************************
* Title : Kth Largest Element in an Array
* URL   : https://leetcode.com/problems/kth-largest-element-in-an-array
* Date  : 2018-06
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : tested with both values of 'shouldGetIndex'
*   dremio asks a variation of this: return k largest elements
*   Find the smallest number in window of first k items and replace with a
*   number from the number outside of this window.
*   ref: https://stackoverflow.com/q/14450024
* meta  : tag-order-stats, tag-heap, tag-divide-conquer, tag-company-dremio
***************************************************************************/
public class Solution {
  // RandomizedSelet is at 'algo/OrderStat.cs'
  public int FindKthLargest(int[] nums, int k) {
    A = nums;
    shouldGetIndex = false;
    return AreIndicesValid(0, A.Length - 1) ? RandomizedSelet(0, A.Length - 1,
      A.Length - k + 1) : -1;
  }

  public static int[] kLargest_Dremio(int[] A, int k) {
    int[] result = new int[k];
    shouldGetIndex = true;
    int q = AreIndicesValid(0, A.Length - 1) ? RandomizedSelet(0, A.Length - 1,
      A.Length - k + 1) : -1;
    Array.Copy(A, q, result, 0, k);
    return result;
  }

  // see note above, ref: https://codereview.stackexchange.com/q/98010
  public static int[] kLargest_Dremio(int[] A, int k) {
    int minIndex = 0, i;              //Find Min
    for (i = k; i < A.Length; i++) {
      minIndex = 0;
      // O(k)
      for (int j = 0; j < k; j++)
        if (A[j] < A[minIndex])
          minIndex = j;
      if (A[minIndex] < A[i])
        Swap(A, minIndex, i);
    }
    // result is q..k, copy example is in method above
  }
}

/*
Experiment: do we get first k largest with RandomizedSelet?
[3,2,3,1,2,4,5,5,6]
4
returns
1 2 2 3 3
*/

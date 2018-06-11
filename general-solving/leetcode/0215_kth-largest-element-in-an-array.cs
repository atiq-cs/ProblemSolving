/***************************************************************************
* Title : Kth Largest Element in an Array
* URL   : https://leetcode.com/problems/kth-largest-element-in-an-array
* Date  : 2018-06
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : tested with both values of 'shouldGetIndex'
* meta  : tag-order-stats
***************************************************************************/
public class Solution {
  // RandomizedSelet is at 'demos/algo/OrderStat.cs'
  public int FindKthLargest(int[] nums, int k)
  {
    A = nums;
    shouldGetIndex = false;
    return RandomizedSelet(0, A.Length-1, A.Length-k+1);
  }
}

/***************************************************************************************************
* Title : Maximum Product Subarray
* URL   : https://leetcode.com/problems/maximum-product-subarray/
* Date  : 2019-02-01
* Occasn: leetcode meetup remote 229 Polaris Ave, Mtn View
* Comp  : O(n), O(1)
* Status: Accepted
* Notes : Modified Kadane algorithm, utilized currentMin to handle product for negative numbers
* ref   : leetcode.com/problems/maximum-product-subarray/discuss/225026/C%2B%2B-O(n)-time-99.16
* meta  : tag-algo-dp, tag-dp-kadane, tag-leetcode-medium
***************************************************************************************************/
public class Solution
{
  public int MaxProduct(int[] nums) {
    // current max product
    int currentMax = 1;
    // current min product
    int currentMin = 1;
    // for input array with single item initialization 'max = 0' won't work
    int max = nums[0];

    foreach (var num in nums) {
      // need to save this as we are modifying current maximum var
      int temp = currentMax;
      currentMax = Math.Max(num, Math.Max(num * currentMax, num * currentMin));
      currentMin = Math.Min(num, Math.Min(num * currentMin, num * temp));
      max = Math.Max(max, currentMax);
    }

    return max;
  }
}

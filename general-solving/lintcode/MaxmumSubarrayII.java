/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/maximum-subarray-ii
* Author: Tianshu Bao (tianshubao1), commit#47b65e92b
* Date  : 2015-06-05
***************************************************************************************************/
public class Solution {
  /**
   * @param nums: A list of integers
   * @return: An integer denotes the sum of max two non-overlapping subarrays
   */
  public int maxTwoSubArrays(ArrayList<Integer> nums) {
    // write your code
    if(nums.size() == 0)
      return 0;
    
    int len = nums.size();
    int[] left = new int[len];
    int[] right = new int[len];
    int max = Integer.MIN_VALUE;
    int sum = 0;
    // int min = Integer.MAX_VALUE;
    // int min = prices[0], max = prices[len - 1];
    int result = Integer.MIN_VALUE;
    
    for(int i = 0; i < len; i++){//consider max profit from left to right
      sum += nums.get(i);      
      max = Math.max(sum, max);
      sum = Math.max(0, sum);
      left[i] = max;
    }
    
    sum = 0;
    max = Integer.MIN_VALUE;
    for(int i = len - 1; i >= 0; i--){//consider max profit from left to right
      sum += nums.get(i);      
      max = Math.max(sum, max);
      sum = Math.max(0, sum);
      right[i] = max;
    }
    
    for(int i = 0; i < len - 1; i++){
      result = Math.max(left[i] + right[i + 1], result);
    }
    
    return result;    
    
  }
}



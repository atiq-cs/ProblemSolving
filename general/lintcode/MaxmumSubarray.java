/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/maximum-subarray
* Author: Tianshu Bao (tianshubao1), commit#47b65e92b
* Date  : 2015-06-05
***************************************************************************************************/
public class Solution {
  /**
   * @param nums: A list of integers
   * @return: A integer indicate the sum of max subarray
   */
  public int maxSubArray(ArrayList<Integer> nums) {
    // write your code
    int max = Integer.MIN_VALUE, sum = 0;//must include one number
    
    for(int i = 0; i < nums.size(); i++){
      sum += nums.get(i);
      max = Math.max(sum, max);
      if(sum < 0)
        sum = 0;
    }
    return max;
  }
}

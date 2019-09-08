/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/maximum-subarray-difference/
* Author: Tianshu Bao (tianshubao1), commit#47b65e92b
* Date  : 2015-06-05
***************************************************************************************************/
public class Solution {
  /**
   * @param nums: A list of integers
   * @return: An integer indicate the value of maximum difference between two
   *      Subarrays
   */
  public int maxDiffSubArrays(ArrayList<Integer> nums) {//did myself
    // write your code
    int len = nums.size();
    int max = Integer.MIN_VALUE;
    int min = Integer.MAX_VALUE;
    int sum = 0;
    int[] leftMax = new int[len];
    int[] rightMin = new int[len];
    
    for(int i = 0; i < len; i++){
      sum += nums.get(i);
      max = Math.max(sum, max);
      sum = Math.max(0, sum);
      leftMax[i] = max;
    }
    
    sum = 0;
    for(int i = len - 1; i >= 0; i--){
      sum += nums.get(i);
      min = Math.min(sum, min);
      sum = Math.min(0, sum);
      rightMin[i] = min;
    }
    
    int result = 0;
    for(int i = 0; i < len - 1; i++){
      result = Math.max(leftMax[i] - rightMin[i + 1], result);
    }
    int result1 = result;
    
    //right large, left small    
    max = Integer.MIN_VALUE;
    min = Integer.MAX_VALUE;
    sum = 0;
    int[] leftMin = new int[len];
    int[] rightMax = new int[len];
    
    for(int i = len - 1; i >= 0; i--){
      sum += nums.get(i);
      max = Math.max(sum, max);
      sum = Math.max(0, sum);
      rightMax[i] = max;
    }
    
    sum = 0;
    for(int i = 0; i < len; i++){
      sum += nums.get(i);
      min = Math.min(sum, min);
      sum = Math.min(0, sum);
      leftMin[i] = min;
    }
        
    result = 0;
    for(int i = 0; i < len - 1; i++){
      result = Math.max(rightMax[i + 1] - leftMin[i], result);
    }
    int result2 = result;
    
    return Math.max(result1, result2);
  }
}
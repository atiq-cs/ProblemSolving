/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/3-sum-closest
* Author: Tianshu Bao (tianshubao1)
* Date  : 2015-06-05
***************************************************************************************************/
class Solution
{
  public int threeSumClosest(int[] numbers ,int target) {
    // write your code here
    int result = Integer.MAX_VALUE;
    int closet = Integer.MAX_VALUE;
    int left = -1, right = -1;
    Arrays.sort(numbers);
    
    for(int i = 0; i < numbers.length; i++){
      left = i + 1;
      right = numbers.length - 1;
      
      while(left < right){
        int sum = numbers[left] + numbers[right] + numbers[i];
        if(Math.abs(target - sum) < result){
          result = Math.abs(target - sum);
          closet = sum;
        }
        if(sum > target)
          right--;
        else{
          left++;  
        }
      }
    }
    
    return closet;
  }
}


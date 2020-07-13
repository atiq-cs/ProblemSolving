/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/majority-number
* Author: Tianshu Bao (tianshubao1), commit#47b65e92b
* Date  : 2015-06-05
***************************************************************************************************/
public class Solution {
  /**
   * @param nums: a list of integers
   * @return: find a  majority number
   */
  public int majorityNumber(ArrayList<Integer> nums) {
    // write your code
    int candidate = 0, count = 0;
    for(int i = 0; i < nums.size(); i++){
      if(count == 0){
        candidate = nums.get(i);
        count++;
      }
      else{
        if(nums.get(i) != candidate)
          count--;
        else count++;
      }
    }
    
    return candidate;
  }
}


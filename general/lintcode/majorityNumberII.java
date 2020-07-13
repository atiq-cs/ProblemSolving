/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/majority-number-ii
* Author: Tianshu Bao (tianshubao1), commit#47b65e92b
* Date  : 2015-06-05
***************************************************************************************************/
public class Solution {
  /**
   * @param nums: A list of integers
   * @return: The majority number that occurs more than 1/3
   */
  public int majorityNumber(ArrayList<Integer> nums) {
    // write your code
    int candidate1 = 0, count1 = 0;
    int candidate2 = 0, count2 = 0;
    
    for(int i = 0; i < nums.size(); i++){
      if(candidate1 == nums.get(i))
        count1++;
      else if(candidate2 == nums.get(i))
        count2++;
      else if(count1 == 0){
        candidate1 = nums.get(i);
        count1++;
      }
      else if(count2 == 0){
        candidate2 = nums.get(i);
        count2++;
      }
      else{
        count1--;
        count2--;
      }
    }
    
    int result;
    count1 = 0;
    count2 = 0;
    for(int i = 0; i < nums.size(); i++){
      if(nums.get(i) == candidate1)
        count1++;
      else if(nums.get(i) == candidate2)
        count2++;
    }
    if(count1 > count2)
      result = candidate1;
    else
      result = candidate2;
    
    return result;    
  }
}


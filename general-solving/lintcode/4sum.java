/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/4-sum
* Author: Tianshu Bao (tianshubao1)
* Date  : 2015-06-05
***************************************************************************************************/
public class Solution {
  public ArrayList<ArrayList<Integer>> fourSum(int[] numbers, int target) {   
    //write your code here
    ArrayList<ArrayList<Integer>> result = new ArrayList<ArrayList<Integer>>();
    int len = numbers.length;
    if(len < 4)
      return result;
    int left = 0;
    int right = len - 1;
    int sum = 0;
    
    for(int i = 0; i < len; i++){
      if(i != 0 && numbers[i] == numbers[i - 1])
        continue;
      for(int j = i + 1; j < len; j++){
        if(j != i + 1 && numbers[j] == numbers[j - 1])
          continue;
        left = j + 1;
        right = len - 1;
        
        while(left < right){
          sum = numbers[i] + numbers[j] + numbers[left] + numbers[right];
          if(sum < target)
            left++;
          else if(sum > target)
            right--;
          else{
            ArrayList<Integer> res = new ArrayList<Integer>();
            res.add(numbers[i]);
            res.add(numbers[left]);
            res.add(numbers[right]);
            result.add(res);
            left++;
            right--;
            
            while(left < right && numbers[left] == numbers[left - 1])
              left++;
            while(left < right && numbers[right] == numbers[right + 1])
              right--;            
          }          
        }
      }
    }
  }
}


/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/3-sum
* Author: Tianshu Bao (tianshubao1)
* Date  : 2015-06-05
***************************************************************************************************/
class Solution
{
  //pay attention to duplicates
  public ArrayList<ArrayList<Integer>> threeSum(int[] numbers) {
    ArrayList<ArrayList<Integer>> result = new ArrayList<ArrayList<Integer>>();
    int len = numbers.length;
    if(len < 3)
      return result;
      
    Arrays.sort(numbers);  
    for(int i = 0; i < len; i++){
      if(i > 0 && numbers[i] == numbers[i - 1])
        continue;
      int left = i + 1;
      int right = len - 1;
      while(left < right){
        int sum = numbers[left] + numbers[right] + numbers[i];
        if(sum < 0)
          left++;
        else if(sum > 0)
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
    
    return result;
  }
}

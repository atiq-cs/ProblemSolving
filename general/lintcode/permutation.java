/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/permutations/
* Author: Tianshu Bao (tianshubao1), commit#3d45fab4c
* Date  : 2015-06-10
***************************************************************************************************/
class Solution {
  /**
   * @param nums: A list of integers.
   * @return: A list of permutations.
   */
  public ArrayList<ArrayList<Integer>> permute(ArrayList<Integer> nums) {
    // write your code here
    ArrayList<ArrayList<Integer>> result = new ArrayList<ArrayList<Integer>>();
    if(nums == null || nums.size() == 0)
      return result;
      
    ArrayList<Integer> list = new ArrayList<Integer>();
    helper(result, list, nums);
    return result;
  }
  
  private void helper(ArrayList<ArrayList<Integer>> result, ArrayList<Integer> list, ArrayList<Integer> nums){
    if(list.size() == nums.size()){
      result.add(new ArrayList<Integer>(list));
      return;
    }
    for(int i = 0; i < nums.size(); i++){
      if(list.contains(nums.get(i)))
        continue;
      list.add(nums.get(i));
      helper(result, list, nums);
      list.remove(list.size() - 1);//remove the last element
    }
  }
  
}

/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/permutations-ii
* Author: Tianshu Bao (tianshubao1), commit#3d45fab4c
* Date  : 2015-06-10
***************************************************************************************************/
class Solution {
  /**
   * @param nums: A list of integers.
   * @return: A list of unique permutations.
   */
  public ArrayList<ArrayList<Integer>> permuteUnique(ArrayList<Integer> nums){
    // write your code here
    ArrayList<ArrayList<Integer>> result = 
      new ArrayList<ArrayList<Integer>>();
    ArrayList<Integer> list = new ArrayList<Integer>();
    Collections.sort(nums);
    boolean visited[] = new boolean[nums.size()];
    helper(result, list, visited, nums);
    
    return result;
  }
  
  private void helper(ArrayList<ArrayList<Integer>> result,
            ArrayList<Integer> list, boolean visited[], 
            ArrayList<Integer> nums){
              
    if(list.size() == nums.size()){
      result.add(new ArrayList<Integer>(list));
      return;
    }
    
    for(int i = 0; i < nums.size(); i++){
      if(visited[i] == true || //pay attention, diff from subset II
        (i != 0 && nums.get(i) == nums.get(i - 1) 
          && visited[i - 1] == false))
          continue;
          
      visited[i] = true;    
      list.add(nums.get(i));
      helper(result, list, visited, nums);
      list.remove(list.size() - 1);
      visited[i] = false;//not very clear
    }
  }
}

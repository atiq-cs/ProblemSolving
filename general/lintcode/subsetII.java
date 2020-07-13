/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/subsets-ii
* Author: Tianshu Bao (tianshubao1)
* Date  : 2015-06-10
***************************************************************************************************/
class Solution {
  /**
   * @param S: A set of numbers.
   * @return: A list of lists. All valid subsets.
   */
  public ArrayList<ArrayList<Integer>> subsetsWithDup(ArrayList<Integer> S) {
    // write your code here
    ArrayList<ArrayList<Integer>> result = new ArrayList<ArrayList<Integer>>();
    if(S == null || S.size() == 0)
      return null;
    Collections.sort(S);
    ArrayList<Integer> lists = new ArrayList<Integer>();
    subsetsHelper(result, lists, S, 0);
    return result;
  }
  private void subsetsHelper(ArrayList<ArrayList<Integer>> result,ArrayList<Integer> list,
    ArrayList<Integer> S,int pos){
      result.add(new ArrayList<Integer>(list));
      
      for(int i = pos; i < S.size(); i++){
        if(i != pos && S.get(i) == S.get(i-1))
          continue;
        list.add(S.get(i));
        subsetsHelper(result, list, S, i + 1);
        list.remove(list.size() - 1);
      }
    }
}

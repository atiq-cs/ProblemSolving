/***************************************************************************************************
* URL   : https://www.jiuzhang.com/solutions/single-number-iii
* Author: Tianshu Bao (tianshubao1)
* Date  : 2015-06-03
***************************************************************************************************/
public class Solution {
  /**
   * @param A : An integer array
   * @return : Two integers
   */
  public List<Integer> singleNumberIII(int[] A) {//did myself
    // write your code here
    int sum = 0;
    for(int i = 0; i < A.length; i++)
      sum ^= A[i];
    
    int digit = -1;
    for(int i = 0; i < 32; i++){
      if((sum >> i & 1) == 1){
        digit = i;
        break;
      }
    }
    
    ArrayList<Integer> l1 = new ArrayList<Integer>();
    ArrayList<Integer> l2 = new ArrayList<Integer>();
    
    for(int i = 0; i < A.length; i++){
      if((A[i] >> digit & 1) == 0)
        l1.add(A[i]);
      else
        l2.add(A[i]);
    }
    int s1 = 0;
    for(int i = 0; i < l1.size(); i++)
      s1 ^= l1.get(i);
      
    int s2 = 0;
    for(int i = 0; i < l2.size(); i++)
      s2 ^= l2.get(i);
    
    ArrayList<Integer> result =  new ArrayList<Integer>();
    result.add(s1);
    result.add(s2);
    return result;   
  }
}

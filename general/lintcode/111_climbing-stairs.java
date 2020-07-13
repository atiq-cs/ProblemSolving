/***************************************************************************************************
* URL   : https://leetcode.com/problems/climbing-stairs/
* Author: Tianshu Bao (tianshubao1), commit#f8f10a742
* Date  : 2015-06-01
***************************************************************************************************/
public class Solution {
  /**
   * @param n: An integer
   * @return: An integer
   */
  public int climbStairs(int n) {
    // write your code here
    if(n <= 1)
      return 1;
    
    int last = 1, lastlast = 1;
    int now;
    
    for(int i = 2; i <= n; i++){
      now = last;
      last = last + lastlast;
      lastlast = now;
    }
    
    return last;
  }
}

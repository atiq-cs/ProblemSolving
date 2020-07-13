/***************************************************************************************************
* URL   : https://www.lintcode.com/problem/single-number
* Author: Tianshu Bao (tianshubao1)
* Date  : 2015-06-03
***************************************************************************************************/
public class Solution {
  /**
   *@param A : an integer array
   *return : a integer 
   */
  public int singleNumber(int[] A) {
    if (A.length == 0) {
      return 0;
    }

    int n = A[0];
    for(int i = 1; i < A.length; i++) {
      n = n ^ A[i];
    }

    return n;
  }
}

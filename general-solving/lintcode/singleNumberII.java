/***************************************************************************************************
* URL   : https://www.jiuzhang.com/solutions/single-number-ii
* Author: Tianshu Bao (tianshubao1)
* Date  : 2015-06-03
***************************************************************************************************/
public class Solution {
  /**
   * @param A : An integer array
   * @return : An integer 
   */
    public int singleNumberII(int[] A) {
        // write your code here
        int bits[] = new int[32];
        int result = 0;
        
        for(int i = 0; i < 32; i++){
            for(int j = 0; j < A.length; j++){
                bits[i] += (A[j] >> i & 1);        
            }
            bits[i] %= 3;
            result |= bits[i] << i;
        }
        
        return result;
    }
}

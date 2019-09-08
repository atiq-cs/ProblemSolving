/***************************************************************************************************
* URL   : https://www.lintcode.com/problem/unique-paths/
* Author: Tianshu Bao (tianshubao1)
* Date  : 2015-06-01
***************************************************************************************************/
class Solution {
  /**
   * @param n, m: positive integer (1 <= n ,m <= 100)
   * @return an integer
   */
  public int uniquePaths(int m, int n) {
    // write your code here 
    if(m == 0 || n == 0)
      return 0;
    
    int sum[][] = new int[m][n];
    
    for(int i = 0; i < m; i++){
      sum[i][0] = 1;
    }
    
    for(int j = 0; j < n; j++){
      sum[0][j] = 1;
    }    
    
    for(int i = 1; i < m; i++){
      for(int j = 1; j < n; j++){
        sum[i][j] = sum[i - 1][j] + sum[i][j - 1];
      }
    }
    
    return sum[m-1][n-1];
  }
}

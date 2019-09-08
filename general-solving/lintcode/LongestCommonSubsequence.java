/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/longest-common-subsequence
* Author: Tianshu Bao (tianshubao1), commit#3d45fab4c
* Date  : 2015-06-10
***************************************************************************************************/
public class Solution {
  /**
   * @param A, B: Two strings.
   * @return: The length of longest common subsequence of A and B.
   */
  public int longestCommonSubsequence(String A, String B) {// write myself, try to understand answer later
    // write your code here
    int n = A.length();
    int m = B.length();
    
    int f[][] = new int[n + 1][m + 1];
    
    for(int i = 0; i < n; i++){
      for(int j = 0; j < m; j++){
        
        f[i + 1][j + 1] = Math.max(f[i + 1][j], f[i][j + 1]);
        
        if(A.charAt(i) == B.charAt(j))
            f[i + 1][j + 1] = f[i][j] + 1;
      }
    }
    
    return f[n][m];
  }
}

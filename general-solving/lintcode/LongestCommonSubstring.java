//http://www.lintcode.com/en/problem/longest-common-substring/#
public class Solution {
    /**
     * @param A, B: Two string.
     * @return: the length of the longest common substring.
     */
    public int longestCommonSubstring(String A, String B) {//myself
        // write your code here
        int n = A.length();
        int m = B.length();
        
        int max = 0;    
        int f[][] = new int[n + 1][m + 1];
        
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                
                // f[i + 1][j + 1] = Math.max(f[i + 1][j], f[i][j + 1]);
                
                if(A.charAt(i) == B.charAt(j))
                        f[i + 1][j + 1] = f[i][j] + 1;
                if(f[i + 1][j + 1] > max)
                    max = f[i + 1][j + 1];
            }
        }
        
        return max;    
    }
}

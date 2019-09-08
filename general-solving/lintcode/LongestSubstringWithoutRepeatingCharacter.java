/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/longest-substring-without-repeating-characters
* Author: Tianshu Bao (tianshubao1), commit#3d45fab4c
* Date  : 2015-06-10
***************************************************************************************************/
public class Solution {
  /**
   * @param s: a string
   * @return: an integer 
   */
  public int lengthOfLongestSubstring(String s) {
    // write your code here
    boolean[] exist = new boolean[256];
    int i = 0, maxlen = 0;
    
    for(int j = 0; j < s.length(); j++){
      while(exist[s.charAt(j)]){//update from the beginning to last charAt(j)
        exist[s.charAt(i)] = false;
        i++;
      }
      exist[s.charAt(j)] = true;
      maxlen = Math.max(maxlen, j - i + 1);
    }
    
    return maxlen;
  }
}

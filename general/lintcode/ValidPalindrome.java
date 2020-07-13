/***************************************************************************************************
* URL   : https://leetcode.com/problems/valid-palindrome
* Author: Tianshu Bao (tianshubao1)
* Date  : 2015-06-01
***************************************************************************************************/
public class Solution {
  /**
   * @param s A string
   * @return Whether the string is a valid palindrome
   */
  public boolean isPalindrome(String s) {//solution from leetcode book, many details problems
    // Write your code here
    if(s.length() == 0 || s == null)
      return true;
    
    int start = 0, end = s.length() - 1;
    
    while(start < end){
      while(start < end && !Character.isLetterOrDigit(s.charAt(start)))//number is included
        start++;
      while(start < end && !Character.isLetterOrDigit(s.charAt(end)))
        end--;
      if(Character.toLowerCase(s.charAt(start)) !=
        Character.toLowerCase(s.charAt(end)))
        return false;
      start++;
      end--;
    }
    
    return true;
  }
}

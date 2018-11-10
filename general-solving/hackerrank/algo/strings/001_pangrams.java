/***************************************************************************************************
* Title : A Very Big Sum
* URL   : https://www.hackerrank.com/challenges/pangrams
* Date  : 2015-08-26
* Notes : Panagrams are strings containing every letter of the alphabet
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Shows how solution can be implemented in java to compare
* meta  : tag-string-anagram
***************************************************************************************************/
import java.io.*;
import java.util.*;

public class HKSolution {
  public static Boolean isAnagram(String line_str) {
    char[] line = line_str.toCharArray();
    
    int[] letters = new int[26];
    for (int i=0; i<26; i++)
      letters[i] = 0;
    
    for (int i=0; i<line.length; i++) {
      if (Character.isUpperCase(line[i]))
        letters[line[i]-65] = 1;
      else if (Character.isLowerCase(line[i]))
        letters[line[i]-97] = 1;
    }

    for (int i=0; i<26; i++)
      if (letters[i] == 0)
        return false;
    return true;
  }

  public static void main(String[] args) throws Exception {
    BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
    String line_str = br.readLine();
    
    if (isAnagram(line_str))
      System.out.println("pangram");
    else
      System.out.println("not pangram");    
  }
}

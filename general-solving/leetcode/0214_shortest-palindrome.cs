/***************************************************************************
* Title : Shortest Palindrome
* URL   : https://leetcode.com/problems/shortest-palindrome
* Date  : 2018-07-07 (Den Meetup with Charlie)
* Author: Atiq Rahman
* Comp  : O(n), O(n)
* Status: Accepted
* Notes : Uses prefix computor method from 'algo/string/KMP-String-Matcher.cs'
*   Regarding Sort function on char Array (IEnumberable) please note that Sort
*   call does not work; see comment in code. Instead use Array.Reverse()
*   
*   I was gonna find max index in prefix table and return it from ComputePrefix
*   From reference below I learnt that max can be found at last index of the
*   prefix table. Because as long as mismatch keep happening the roll back
*   index does not change and propagates till end of the array (prefix table).
*   
*   The problem is tagged hard. However, if we know KMP it gets easier.
*   
*   For palindrome problems, trying reversing is a good idea during string
*   manipulation/computation.
*   
*   Initial draft while discussing with Charlie added below.
*   
*   TODO: solve this problem using Manacher's Algorithm
* Ref   : https://github.com/awangdev/LintCode/blob/master/Java
*   /Shortest%20Palindrome.java
* meta  : tag-leetcode-hard, tag-string, tag-kmp
***************************************************************************/
public class Solution {
  public string ShortestPalindrome(string str) {
    char[] result = str.ToArray(); Array.Reverse(result);
    // result.Reverse(); does not work
    string revStr = new string(result);
    int longestPalindromeLength = ComputePrefix(str + "#" + revStr);
    return revStr.Substring(0, revStr.Length - longestPalindromeLength) + str;
  }

  // Component Prefix Table Computation from KMP
  private int ComputePrefix(string needle) {
    int max = 0;
    int[] pf = new int[needle.Length];

    pf[0] = -1; // first index is initialized
    for (int i = 1, k=-1; i < needle.Length; i++) {
      while (k >= 0 && needle[k + 1] != needle[i])
        k = pf[k];
      if (needle[k + 1] == needle[i])
        k++;
      pf[i] = k;
      max = Math.Max(max, k);
    }
    return pf[needle.Length - 1]+1;
  }

  /*
  foreach(var len in pf)
    Console.Write(" "+len);
  Console.WriteLine();
  */
}

/*
aacecaaa

abcd

trying to generate case where conflict would rise between choice
ac
- caac
- cac

abc
cabc
cbabc

1. Check if it's palindrome
if it's already palindrome just return it

if it's not palindrome start with last character and add in front and check

A naive approach would be to add one char at a time in the front

string shortestPalindrome(string s) {
  string pal;
  for (int i=s.Length-1; i>=0; i--) {
    pal = AddCharToString(s, s.Length-1-i, s[i]);
    if (IsPalindrome(pal))
      return pal;
  }
  return "";
}

right = "abcd"
left = ""

left = "d"
right = "abcd"


O(N)
string AddCharToString(string s, int pos, char ch) {
  return s.substring(0, pos-1) + ch + s.substring(pos, s.Length-pos);
}

// O(N)
bool IsPalindrome(string s) {
  for (int i=0, j=s.Length-1; i<j; i++,j--)
    if (s[i] != s[j])
      return false;
  return true;
}

abcd
dabcd

AddCharToString(s, 1, c);

'd', 'c', 'abcd'

AddCharToString(s, 2, b);


aacecaaa
aacecaaaaaacecaa

last executed input might not mean that it got TLE for that test-case but total time taken by test-cases so far upto that one.


prefix table for "aba"
-1 -1 0 -1 0 1 2

prefix table for "aaacecaaa"
-1 0 -1 -1 -1 0 1 1 -1 0 1 1 2 3 4 5 6

aaacecaaa
length 9
*/

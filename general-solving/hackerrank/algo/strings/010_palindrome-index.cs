/***************************************************************************************************
* Title : Palindrome Index
* URL   : https://www.hackerrank.com/challenges/palindrome-index
* Date  : 2016-01-03
* Comp  : O(N)
* Author: Atiq Rahman
* Status: Accepted
* Notes : A simple palindrome problem
*   palindrome (reads same from forward or backword)
*   Find the index where a char does not match on the other side
*   Check excluding that character whether rest is palindrome
* meta  : tag-string-palindrome
***************************************************************************************************/
using System;

class Solution {
  static void Main(String[] args) {
    int T = int.Parse(Console.ReadLine());

    while (T-- > 0) {
      string str = Console.ReadLine();
      /* i starts from beginning,
         j starts from end
      */
      int i = 0, j = str.Length - 1;
      for (; i < j; i++, j--) {
        if (str[i] != str[j]) {
          // remove i-th char and check if rest is palindrome
          if (isPalindrome(str, i + 1, j)) {
            Console.WriteLine(i);
            break;
          }
          // remove j-th char and check if rest is palindrome
          if (isPalindrome(str, i, j - 1)) {
            Console.WriteLine(j);
            break;
          }
        }
      }
      if (i >= j)
        Console.WriteLine("-1");
    }
  }

  /*
    This function tests if sub-string of the string is palindrome
     starting from index i to index j
  */
  static bool isPalindrome(string str, int i, int j) {
    for (; i < j; i++, j--)
      if (str[i] != str[j])
        return false;
    return true;
  }
}
/*
abcdcba
abccba

let's say we have an extra char in the beginning,
pabcdcba

so we say first char does not match with last char
one of the two must be removed
say indices are i and j

check 
s[i] == s[j]

not matching so check
s[i+1] == s[j]

bool foundMistmatch = false;

for (int i=0, j=length-1; )
if (s[i] != s[j]) {
  if (foundMistmatch) 
  if (s[i+1] == s[j]) {
    // answer is i if palindrome check is successful
    // otherwise -1
  }
  if (s[i+1] == s[j]) {
    // answer is i if palindrome check is successful
    // otherwise -1
  }
  foundMistmatch = true;
}

consider ab works
consider baa

5
baa
ada
aaab
baa
aaa
 */

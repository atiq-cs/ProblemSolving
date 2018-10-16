/***************************************************************************
* Title : Longest Common Subsequence
* Contst: Binghamton ACM April 2015
* URL   : https://www.hackerrank.com/contests/bingacm-apr15/challenges
* Date  : 2018-06-05
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : method call arguments are in reverse order
*
*    Input is two strings
* meta  : tag-dp-lcs, tag-algo-dp
***************************************************************************/
using System;

// class 'SubseqAlgoDemo' is declared and defined in 'demos/algo/dp/lcs.cs'

class HK_Solution {
  // Too simple to consider use of IO template
  static int[] Run(int[] a, int[] b) {
    var demo = new SubseqAlgoDemo<char>();
    var a = Console.ReadLine().ToCharArray();
    var b = Console.ReadLine().ToCharArray();
    Console.WriteLine(new string(demo.LongestCommonSubsequence(b, a)));
  }
}

/*
Considered input,
backtrack
algorithm
requires ar to be answer instead of at
*/

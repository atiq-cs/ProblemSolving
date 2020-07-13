/***************************************************************************
* Title : The Longest Common Subsequence
* URL   : https://www.hackerrank.com/challenges/dynamic-programming-classics-
*   the-longest-common-subsequence
* Date  : 2018-06-05
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : This also solves,
*   https://www.hackerrank.com/contests/cse-830-homework-3/challenges/dynamic-
*    programming-classics-the-longest-common-subsequence
*    
*    Input is two integer subsequences
* meta  : tag-dp-lcs, tag-algo-dp, tag-company-expedia, tag-coding-test
***************************************************************************/
using System;

// class 'SubseqAlgoDemo' is declared and defined in 'demos/algo/dp/lcs.cs'

class HKSolution {
  // IO method's in 'general-solving/hackerrank/IOTemplate.cs'
  static int[] Run(int[] a, int[] b) {
    var demo = new SubseqAlgoDemo<int>();
    return demo.LongestCommonSubsequence(a, b);  
  }
}

/*
Considered input,
5 6
1 2 3 4 1
3 4 1 2 1 3
*/

/*
Q2: Expedia: Missing Words
I am using HackerRank to improve programming
am HackerRank to improve

missing words:
I
am
using

string to num dict
num to string dict

assign each string a number

0 1 2 3 4 5 6 7
1 2 3 4

after finding lcs mark off the lcs words with an index value -1
*/

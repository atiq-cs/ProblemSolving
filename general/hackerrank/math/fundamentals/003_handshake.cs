/***************************************************************************
* Title : Handshake
* URL   : https://www.hackerrank.com/challenges/handshake
* Date  : 2017-09
* Author: Atiq Rahman
* Comp  : O(1)
* Status: Accepted
* Notes : See draft at bottom
*   Mathematics/Fundamentals
* meta  : tag-math, tag-easy
***************************************************************************/
using System;

class Solution {
  static void Main(String[] args)
  {
    int T = Convert.ToInt32(Console.ReadLine());
    for(int i = 0; i < T; i++) {
      int n = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine(n * (n-1) / 2);
    }
  }
}

/* can do little search for finding a related problem
if not found write test cases for this program, that's it..

1 3 5 7 9 2 4 6 8 10

6 1 3 7 8 4

i = 0
 odd
 j = 0
 swap

i = 1
 odd
 j = 2
 swap(3,5)
*/

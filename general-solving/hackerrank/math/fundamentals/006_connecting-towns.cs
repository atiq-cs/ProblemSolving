/***************************************************************************
* Title : Connecting Towns
* URL   : https://www.hackerrank.com/challenges/connecting-towns
* Date  : 2015-10
* Author: Atiq Rahman
* Comp  : O(1)
* Status: Accepted
* Notes : Mathematics/Fundamentals
* meta  : tag-math, tag-easy
***************************************************************************/
using System;

class Solution {
  static void Main(String[] args) {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      int N = int.Parse(Console.ReadLine())-1;
      string[] tokens = Console.ReadLine().Split();
      int p = 1;
      for (int i=0; i<N; i++) {
        int num = int.Parse(tokens[i]);
        p = p*(num%1234567)%1234567;
      }
      Console.WriteLine(p);
    }
  }
}

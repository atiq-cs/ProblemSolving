/***************************************************************************************************
* Title : Sherlock and The Beast
* URL   : https://www.hackerrank.com/challenges/sherlock-and-the-beast
* Date  : 2015-09-21
* Comp  : O(n^2)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Required faster IO with C# to pass testcases in required time limit
*   If this gave me TLE I would have used StringBuilder
* meta  : tag-easy, tag-cslang-io
***************************************************************************************************/
using System;
using System.Collections.Generic;

class HKSolution
{
  static void Main(String[] args) {
    int T = int.Parse(Console.ReadLine());

    while (T-- > 0) {
      int n = int.Parse(Console.ReadLine());
      // nx is number of fives
      int nx = GetMaximizedFive(n);
      if (nx == -1) {
        Console.WriteLine(nx);
        continue;
      }
      for (int i = 0; i < (n - 5 * nx) / 3; i++)
        Console.Write(555);
      for (int i = 0; i < nx; i++)
        Console.Write(33333);
      Console.WriteLine();
    }
  }
  /*
    Considering equation, 5x + 3y = 11
    where we need to maximize y because y represents digit 5
    
    when x = 0 y is equal to n
  */
  static int GetMaximizedFive(int n) {
    int x = 0;
    for (; n >= 5 * x; x++) {
      if ((n - 5 * x) % 3 == 0)
        return x;
    }
    return -1;
  }
}

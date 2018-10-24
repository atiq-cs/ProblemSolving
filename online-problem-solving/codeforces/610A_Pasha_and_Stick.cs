/***************************************************************************************************
* Title : Pasha and Stick
* URL   : http://codeforces.com/contest/610/problem/A
* Occasn: Codeforces Round #337 (Div. 2
* Date  : 2015-12-27
* Comp  : O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
* Notes : Count number of ways stick can be cut
*   consider dividing the problem into half see examples below
*
* meta  : tag-combinatorics, tag-math
***************************************************************************************************/

using System;

public class CFSolution {
  public static void Main() {
    int N = int.Parse(Console.ReadLine());
    Console.WriteLine(GetCountWays(N));
  }

  static int GetCountWays(int n) {
    if (n % 2 != 0)
      return 0;
    int m = n / 2;
    if (m % 2 == 0)
      return m / 2 - 1;
    return (m - 1) / 2;
  }
}

/* Example, consider 6
half:
3 = 1 + 2
1 2 4

Similarly for, 20
20/2 = 10

1+9
2+8
3+7
4+6

What about odd, 7?
not possible

10
5 =
1+4
2+3*/

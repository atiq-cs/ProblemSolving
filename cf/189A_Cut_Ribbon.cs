/***************************************************************************************************
* Title : Cut Ribbon
* URL   : http://codeforces.com/problemset/problem/189/A
* Occasn: Codeforces Round #119 (Div. 2)
* Date  : 2017-08-23
* Comp  : O(n^2) 46ms
* Author: Atiq Rahman
* Status: Accepted
* Notes : Try simple enough approach for this problem
* meta  : tag-algo-dp, tag-brute-force
***************************************************************************************************/

using System;

public class CFSolution {
  private static void Main() {
    string[] tokens = Console.ReadLine().Split();
    int n = int.Parse(tokens[0]);
    int a = int.Parse(tokens[1]);
    int b = int.Parse(tokens[2]);
    int c = int.Parse(tokens[3]);

    // sort a, b, c
    if (a > b) { int t = a; a = b; b = t; }
    if (a > c) { int t = a; a = c; c = t; }
    if (b > c) { int t = b; b = c; c = t; }
    Console.WriteLine(GetMaxNumPieces(n, a, b, c));
  }

  /*
   Optimization is possible. However, for the constraints and purpose of this
   problem current solution is ok/enough.
  */
  static int GetMaxNumPieces(int n, int a, int b, int c) {
    if (n % a == 0) // a small optimization
      return n / a;
    int max_pieces_count = 0;
    for (int x = 0; a*x <= n; x++)
      for (int y = 0; a*x + b*y <= n; y++) {
        if ((n - a * x - b * y) % c == 0)
          max_pieces_count = Math.Max(max_pieces_count, (x + y + (n - a * x - b * y) / c));
      }
    
    return max_pieces_count;
  }
}

/***************************************************************************************************
* Title : Two Buttons
* URL   : http://codeforces.com/problemset/problem/520/B
* Occasn: Codeforces Round #295 (Div. 2)
* Date  : 2017-10-09
* Comp  : O(lg n)
* Author: Atiq Rahman
* Status: Accepted (62ms)
* Notes : 
*   It looks like a distance problem: comparing distance from numbers and choosing minimal one
*   should work. It's not a DP problem as per the tags.
*   
*   - Simple case, when n >= m
*   count = n-m
*   
*   - Other case, n < m
*   Choosing distance 1:
*   keep dividing m by 2 and do count++ till n >= m
*   Choosing distance 2:
*   keep multiplying n by 2 and do count++ till n >= m
*   For both of these distances at the end do,
*   count += n-m
*   
*   Considered inputs while developing the solution,
*   7 20
*   7 21
*   4 6
*   10 1
*   1 3
* meta  : tag-algo-greedy, tag-graph-sssp, tag-graph-dfs tag-math
***************************************************************************************************/
using System;

public class CFSolution {
  // n < m
  static int GetCountByMovingDown(int n, int m) {
    int count = 0;
    while ( n < m ) {
      /* Idea 1: we are diving by 2, there can be reminders which should be
       * accounted. This idea is wrong which is caught by trying input 1 3
       * 
       * Idea 2: bump up the number n by 1 when the number is odd and increment
       * count by 1 to account for that.
       */
      if ((m & 0x1) == 1) {
        m++;
        count++;
      }
      m = m >> 1;
      count++;
    }
    // n >= m
    count += n - m;
    return count;
  }
  // n < m
  static int GetCountByMovingUp(int n, int m) {
    int count = 0;
    while ( n < m ) {
      n = n << 1;
      count++;
    }
    // n >= m
    count += n - m;
    return count;
  }

  static int GetMinMoves(int n, int m) {
    if (n >= m)
      return n - m;
    return Math.Min(GetCountByMovingDown(n, m), GetCountByMovingUp(n, m));
  }

  public static void Main() {
    string[] tokens = Console.ReadLine().Split();
    Console.WriteLine(GetMinMoves(int.Parse(tokens[0]), int.Parse(tokens[1])));
  }
}

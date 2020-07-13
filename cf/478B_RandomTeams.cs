/***************************************************************************************************
* Title : Random Teams
* URL   : http://codeforces.com/problemset/problem/478/B
* Occasn: Codeforces Round #273 (Div. 2)
* Date  : 2017-09-13
* Comp  : O(n), O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : input limit 10^9 requires larger data type than int
* meta  : tag-combinatorics, tag-math, tag-easy
***************************************************************************************************/
using System;

public class CFSolution {
  public static void Main() {
    string[] tokens = Console.ReadLine().Split();
    ulong n = ulong.Parse(tokens[0]);
    ulong m = ulong.Parse(tokens[1]);
    Console.WriteLine(GetMaxPairs(n, m));
  }

  static string GetMaxPairs(ulong n, ulong m) {
    // given that m <= n
    ulong x = n / m;
    ulong r = n % m;
    // * Finding minimum *
    // (m-r) groups will have n/m number of participants
    // r groups will have n/m+1 number of participants
    // What if m = 1,
    //  same formula still applies
    ulong min = (m - r) * x * (x - 1) / 2 + r*x *(x+1)/2;
    // max computation
    // put as many as possible into 1 team
    // (m-1) goes into all other teams as single participant
    // (n-m+1) goes into 1 team
    // that makes it m-1+1 = m teams each with at least one participant
    // What if m = 1,
    //  the formula translates to n * (n-1)/2 which is correct
    ulong max = (n - m) * (n - m + 1) / 2;
    return min.ToString() + " " + max.ToString();
  }
}

/*
 Considering example, 6 3
 First impression,
  max,
   6 people into 1 team,
   5 + 4 + 3 + 2 + 1
   = 15
 However, this is wrong, there should be at least 1 person in each team. Hence,
 max 4 people can go into 1 team,
  max (corrected),
   4 people into 1 team,
   3 + 2 + 1 = 6
 I developed the formula observing example test cases. Then, I proof checked
 whether the invariant holds for general case.

Checked for,
  8/3
  5/3
  3/2

1 remaining group

m * x * (x-1) / 2
3 * 2 * 1 / 2 = 3
*/

/***************************************************************************
* Title : Vanya and Lanterns
* URL   : http://codeforces.com/problemset/problem/492/B
* Contst: Codeforces Round #280 (Div. 2)
* Date  : 2017-12-01
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : 2 things to consider to develop the solution,
*   1. find interval/gaps between lights
*   2. consider that for first light co-ordinate 0 has to be considered &
*   for last light co-ordinate which is l has to be considered
*   see implementation notes in code inline
*
*   This problem is simpler than
*   https://www.hackerrank.com/challenges/hackerland-radio-transmitters
* meta  : tag-easy, tag-algo-sort, tag-math
***************************************************************************/
using System;
using System.Globalization;

public class CFSolution {
  private static double GetMinLightRadius(int[] a, int n, int l) {
    // sort, input in not sorted
    Array.Sort(a);
    // get max distance between (first co-ord and first light) and (last light
    // and last co-ord), need to multiply by 2 because we divide by 2 later
    int max = 2 * Math.Max(a[0], l-a[n-1]);
    // get max distance from sorted lights
    for (int i = 1; i < n; i++)
      if (max < a[i] - a[i - 1])
        max = a[i] - a[i - 1];
    // divide by 2 because 2 lights contribute together
    return (double)max / 2.0;
  }

  public static void Main() {
    string[] tokens = Console.ReadLine().Split();
    int n = int.Parse(tokens[0]);
    int l = int.Parse(tokens[1]);
    int[] a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    Console.WriteLine();
    Console.WriteLine(GetMinLightRadius(a, n, l).ToString("F10", CultureInfo.
      CreateSpecificCulture("en-US")));
  }
}

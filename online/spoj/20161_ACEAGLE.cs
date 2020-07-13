/***************************************************************************
* Title       : Eagle and Assassin’s Creed
* URL         : http://www.spoj.com/problems/ACEAGLE/
* Occasion    : tutorial
* Date        : Sept 20 2017
* Complexity  : O(1)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Based on codechef/CRZ04_CLOCK.cs
*   Cases:
*   1. hour hand moves every 30 degree
*   2. minute hand moves every 30 degree
*   So I performed floor to get expected angle after dividing by 30
*               
*   Probably result does not appear in floating point representation
*   However, I did not have to change to int because of that
*   a variation of 'online-problem-solving/codechef/CRZ04_CLOCK.cs'
*   rel: http://codeforces.com/problemset/problem/80/B
* meta        : tag-geometry, tag-math
***************************************************************************/
using System;

public class Demo {
  static double EPS = 1e-9;
  // get angle between hour and minute hands
  static double HMAngle(int h, int m) {
    // compute angle for hour hand
    double hA = 30 * h + (double)m / 2;
    hA = Math.Floor(hA / 30) * 30;
    if (hA > 360.0 - EPS)
      hA -= 360.0;
    // compute angle for minute hand
    double mA = 6 * m;
    mA = Math.Floor(mA / 30) * 30;
    double angle_diff = Math.Abs(hA-mA);
    if (angle_diff > 180.0 - EPS)
      angle_diff = 360.0 - angle_diff;
    return angle_diff;
  }

  public static void Main() {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      int h = int.Parse(tokens[0]);
      int m = int.Parse(tokens[1]);
      Console.WriteLine(HMAngle(h, m));
    }
  }
}

/*
2
10 10
6 15
*/

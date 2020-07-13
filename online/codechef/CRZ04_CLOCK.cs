/***************************************************************************
* Title       : CLOCK
* URL         : https://www.codechef.com/problems/CRZ04
* Occasion    : Practice(Extcontest)
* Date        : Sept 20 2017
* Complexity  : O(1)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : A simple geometry/math problem
*   Cases:
*   1. Angle between hands can be more than 180
*   2. Difference can come as negative
*   3. "CultureInfo.CreateSpecificCulture" not required for codechef
*   codeforces problem is simpler (doesn't even ask for difference)
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
    if (hA > 360.0 - EPS)
      hA -= 360.0;
    // compute angle for minute hand
    double mA = 6 * m;
    double angle_diff = Math.Abs(hA-mA);
    if (angle_diff > 180.0 - EPS)
      angle_diff = 360.0 - angle_diff;
    return angle_diff;
  }

  static bool IsInvalidTime(int hh, int mm) {
    // check hour input
    if (hh < 0 || hh > 23)
      return true;
    // check minute input
    if (mm < 0 || mm > 59)
      return true;
    return false;
  }

  public static void Main() {
    // feel free to modify
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      int h = int.Parse(tokens[0]);
      int m = int.Parse(tokens[1]);
      if (IsInvalidTime(h,m))
        Console.WriteLine("Invalid Time");
      else
        Console.WriteLine("{0:F1}", HMAngle(h, m));
      // Console.WriteLine(HMAngle(h, m).ToString("F2", CultureInfo.
      // CreateSpecificCulture("en-US")));
    }
  }
}

/*
Input,
3
12 00 
20 00 
24 00 
*/

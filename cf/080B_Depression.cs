/***************************************************************************************************
* Title : Depression
* URL   : http://codeforces.com/problemset/problem/80/B
* Occasn: Codeforces Beta Round #69 (Div. 2 Only)
* Date  : 2017-09-20
* Comp  : O(1) 46ms
* Author: Atiq Rahman
* Status: Accepted
* Notes : Simple angle calculation for hour and minute hands
*   This one doesn't ask for difference between angles
*   hour can be more than 12 (upto 23); this is handled by subtracting 2*pi
* rel   : 'online-problem-solving/codechef/CRZ04_CLOCK.cs'
* meta  : tag-geometry, tag-math
***************************************************************************************************/
using System;
using System.Globalization;

public class CFSolution {
  static double EPS = 1e-9;
  public static void Main() {
    // feel free to modify
    string[] tokens = Console.ReadLine().Split(':');
    int h = int.Parse(tokens[0]);
    int m = int.Parse(tokens[1]);
    // compute angle for hour hand
    double hA = 30 * h + (double)m / 2;
    if (hA > 360.0 - EPS)
      hA -= 360.0;
    // compute angle for minute hand
    double mA = 6 * m;
    Console.WriteLine(hA.ToString("F1", CultureInfo.CreateSpecificCulture("en-US")) + " " + mA);
  }  
}

/*
 Inputs:
 23:59
 20:15
*/

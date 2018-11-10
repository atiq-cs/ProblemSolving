/***************************************************************************************************
* Title : Minimum Height Triangle
* URL   : https://www.hackerrank.com/challenges/lowest-triangle
* Date  : 2017-12
* Author: Atiq Rahman
* Comp  : O(1)
* Status: Accepted
* Notes : Area of rectangle
* meta  : tag-math, tag-easy
***************************************************************************************************/
using System;

class HKSolution {
  static int lowestTriangle(int t_base, int area) {
    return (int) Math.Ceiling(2.0 * (double)area / t_base);
  }  

  static void Main(String[] args) {
    string[] tokens = Console.ReadLine().Split();
    int t_base = Convert.ToInt32(tokens[0]);    // base is C# keyword
    int area = Convert.ToInt32(tokens[1]);
    int height = lowestTriangle(t_base, area);
    Console.WriteLine(height);
  }
}

/***************************************************************************************************
* Title : Find Point
* URL   : https://www.hackerrank.com/challenges/find-point
* Date  : 2015-09-15
* Comp  : O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Look at detailed notes below
* meta  : tag-math, tag-easy
***************************************************************************************************/
using System;

class HKSolution
{
  static void Main(String[] args) {
    int T = int.Parse(Console.ReadLine());
    for (int i=0; i<T; i++) {
      string[] tokens = Console.ReadLine().Split();
      int[] x = new int[3];
      int[] y = new int[3];
      x[0] = int.Parse(tokens[0]); y[0] = int.Parse(tokens[1]);
      x[1] = int.Parse(tokens[2]); y[1] = int.Parse(tokens[3]);      

      x[2] = 2*x[1]-x[0];      
      y[2] = 2*y[1]-y[0];
      Console.WriteLine("{0} {1}", x[2], y[2]);
    }
  }
}

/*
How to define symmetric points?
Say the resultant point is R. Then, Q will be midpoint of P and R.

Considering this a solution,
x[2] = 2*x[1]-x[0];
  applies to (0, 0) and (1,1)
  what about (1,1) and (0,0) ? That give (-1, -1)

Now say, one point in q1 and other in q2
(1,1) and (-1,1)
  result = (-3, 1)

what about (-2, 2) and (2, -2)
result (6, -6)

if both points have same x, result symmetric point should have same X too,
however, judge does not seem to have test-cases for that, I have asked on the forum
  https://www.hackerrank.com/challenges/find-point/forum
if (x[0] == x[1])
  x[2] = x[1];
else
  x[2] = 2* x[1]-x[0];
      
if (y[0] == y[1])
  y[2] = y[1];
else
  y[2] = 2* y[1]-y[0];
*/

/***************************************************************************************************
* Title : Extra long factorials
* URL   : https://www.hackerrank.com/challenges/extra-long-factorials
* Date  : 2015-09-07
* Author: Atiq Rahman
* Status: Accepted
* Notes : Use BigInteger to calculate factorial, complexity is probably exponential
* meta  : tag-big-integer, tag-easy
***************************************************************************************************/
using System;
using System.Numerics;

class HKSolution
{
  static void Main(String[] args) {
    int N = int.Parse(Console.ReadLine());
    Console.WriteLine(GetFactorial(N));
  }

  static BigInteger GetFactorial(int n) {
    BigInteger fact = 1;
    for (int i = 2; i <= n; i++)
      fact *= i;
    return fact;
  }
}

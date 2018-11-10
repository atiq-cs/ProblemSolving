/***************************************************************************************************
* Title : Divisible Sum Pairs
* URL   : https://www.hackerrank.com/challenges/divisible-sum-pairs
* Date  : 2017-09-17
* Comp  : O(n+m)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Be aware that
*   (A[i] + A[j]) % k and A[i] + A[j] % k are different
*   expressions
* meta  : tag-easy, tag-math, tag-combinatorics, tag-implementation
***************************************************************************************************/
using System;

class HKSolution
{
  static int divisibleSumPairs(int n, int k, int[] A) {
    int count = 0;
    for (int i=0; i<n-1; i++)
      for (int j=i+1; j<n; j++)
        if ((A[i] + A[j]) % k == 0)
          count++;
    return count;
  }

  static void Main(String[] args) {
    string[] tokens_n = Console.ReadLine().Split(' ');
    int n = Convert.ToInt32(tokens_n[0]);
    int k = Convert.ToInt32(tokens_n[1]);
    string[] ar_temp = Console.ReadLine().Split(' ');
    int[] ar = Array.ConvertAll(ar_temp,Int32.Parse);
    int result = divisibleSumPairs(n, k, ar);
    Console.WriteLine(result);
  }
}

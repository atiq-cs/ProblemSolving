/***************************************************************************************************
* Title : Compare the Triplets
* URL   : https://www.hackerrank.com/challenges/compare-the-triplets
* Date  : 2016-12-20
* Comp  : O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Comparison only
* meta  : tag-easy
***************************************************************************************************/
using System;

class HKSolution {
  static void Main(String[] args) {
    string[] tokens_a0 = Console.ReadLine().Split(' ');
    int[] a = Array.ConvertAll(tokens_a0, Int32.Parse);
    string[] tokens_b0 = Console.ReadLine().Split(' ');
    int[] b = Array.ConvertAll(tokens_b0, Int32.Parse);
    
    int score_a = 0, score_b = 0;
    for (int i=0; i<3; i++)
      if (a[i] > b[i])
        score_a++;
      else if (a[i] < b[i])
        score_b++;
    Console.WriteLine("{0} {1}", score_a, score_b);
  }
}

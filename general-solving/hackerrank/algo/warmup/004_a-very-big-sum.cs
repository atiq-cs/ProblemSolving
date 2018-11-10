/***************************************************************************************************
* Title : A Very Big Sum
* URL   : https://www.hackerrank.com/challenges/a-very-big-sum
* Date  : 2015-09-07
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Find sum of given integers, only consider required data type for sum of 10
*   large integers
* rel   : https://www.hackerrank.com/domains/algorithms/warmup
* meta  : tag-easy
***************************************************************************************************/
using System;

class HKSolution
{
  static void Main() {
    int N = int.Parse(Console.ReadLine());
    string[] tokens = Console.ReadLine().Split();
    long sum = 0;
    for (int i = 0; i < N; i++)
      sum += int.Parse(tokens[i]);
    Console.WriteLine(sum);
  }
}

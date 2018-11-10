/***************************************************************************************************
* Title : Find the Median
* URL   : https://www.hackerrank.com/challenges/find-the-median
* Date  : 2018-01-01
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : This is a good problem to test order statistics algorithms.
*   My first implementation of Randomized Select has been used with
*   'hourrank-24/D_kth-minimum.cs'
*   This is the first problem that gave acceptance with that algorithm
*   Finds median in N operations. With the 'RandomizedSelet' function that
*   returns the item instead it requires 2 * N Operations to find the median
*   when n is an even number.
* meta  : tag-median, tag-order-stats
***************************************************************************************************/
using System;

class MedianSolution
{
  public void TakeInput() {
    int n = int.Parse(Console.ReadLine());
    A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    if (n != A.Length)
      throw new ArgumentException();
  }

  // RandomizedSelet is at 'demos/algo/OrderStat.cs'

  // returns median: single call
  public int GetMedian() {
    shouldGetIndex = true;
    int m = RandomizedSelet(0, A.Length - 1, A.Length/2 + 1);
    if (A.Length % 2 == 1)
      return A[m];
    return (A[m-1] + A[m]) / 2;
  }

  // first version: two calls
  public int GetMedian() {
    shouldGetIndex = false;
    int m1 = RandomizedSelet(0, n - 1, n/2 + 1);
    if (n % 2 == 1)
      return m1;
    int m2 = RandomizedSelet(0, n - 1, n/2);
    return (m1 + m2) / 2;
  }
}

public class HK_Solution {
  private static void Main() {
    MedianSolution medianDemo = new MedianSolution();
    medianDemo.TakeInput();
    Console.WriteLine(medianDemo.GetMedian());
  }
}

/*
Sample input/output,
2
5 3

7
0 1 2 4 6 5 3

8
0 1 2 6 8 5 7 3
*/

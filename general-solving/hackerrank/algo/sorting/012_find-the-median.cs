/***************************************************************************
* Title : Find the Median
* URL   : https://www.hackerrank.com/challenges/find-the-median
* Contst: Codeforces Alpha Round #20 
* Date  : 2017-01-01
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : This is a good problem to test order statistics algorithms. 
*   My first implementation of Randomized Select has been used with
*     'hourrank-24/D_kth-minimum.cs'
*   This is the first problem that gave acceptance with that algorithm
*   Finds median in N operations. With the 'RandomizedSelet' function that
*   returns the item instead it requires 2 * N Operations to find the median
*   when n is an even number.
* meta  : tag-median, tag-order-stats
***************************************************************************/
using System;
using System.Collections.Generic;

class MedianSolution {  // Reverse segment Solution Class
  private int n;
  private int[] A;

  public void TakeInput() {
    n = int.Parse(Console.ReadLine());
    A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
  }

  // return index instead of the item
  private int RandomizedSelet(int p, int r, int i) {
    if (p == r)
      return p;
    int q = RandomizedPartition(p, r);
    int k_i = q - p + 1;
    if (i == k_i)
      return q;
    else if (i < k_i)
      return RandomizedSelet(p, q-1, i);
    else
      return RandomizedSelet(q + 1, r, i - k_i);
  }

  /* this algorithm also gives Accept
   * Return the item
  private int RandomizedSelet(int p, int r, int i) {
    if (p == r)
      return A[p];
    int q = RandomizedPartition(p, r);
    int k_i = q - p + 1;
    if (i == k_i)
      return A[q];
    else if (i < k_i)
      return RandomizedSelet(p, q-1, i);
    else
      return RandomizedSelet(q + 1, r, i - k_i);
  }
  public int GetMedian() {
    if (n != A.Length)
      return -1;
    int m1 = RandomizedSelet(0, n - 1, n/2 + 1);
    if (n % 2 == 1)
      return m1;
    int m2 = RandomizedSelet(0, n - 1, n/2);
    return (m1 + m2) / 2;
  }
  */

  // returns index of median
  public int GetMedian() {
    if (n != A.Length)
      return -1;
    int m = RandomizedSelet(0, n - 1, n/2 + 1);
    if (n % 2 == 1)
      return A[m];
    return (A[m-1] + A[m]) / 2;
  }

  private int RandomizedPartition(int p, int r) {
    Random rnd = new Random();
    int i = rnd.Next(p, r+1);
    Swap(i, r);
    return Partition(p, r);
  }

  // simple quick sort partition - C.L.R page 171
  private int Partition(int p, int r) {
    int i = p-1;
    long x = A[r];
    for (int j=p; j<r; j++) {
      /*
       * maintains invariant that all items are less than pivot are in the
       * block of i (or smaller elements till where i ends)
       */
      if (A[j] <= x) {
        i++;
        Swap(i, j);
      }
    }
    Swap(i+1, r);
    return i + 1;
  }

  private void Swap(int i, int j) {
    if (i != j) {
      int temp = A[i];
      A[i] = A[j];
      A[j] = temp;
    }
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

/***************************************************************************
* Title       : Number of Ways
* URL         : http://codeforces.com/problemset/problem/466/C
* Occasion    : Good Bye 2014
* Date        : Sep 12 2017
* Complexity  : O(n) 46ms, Space O(n)
* Author      : Atiq Rahman
* Status      : TLE -> needs performance improvement
* Notes       : Trying DP and Prefix Sum
* ref         : http://codeforces.com/blog/entry/13758
* meta        : tag-tree, tag-easy, tag-judge-ToDo
***************************************************************************/
using System;

public class LinearSplit {
  private long[] A;
  public void TakeInput() {
    int N = int.Parse(Console.ReadLine());
    string[] tokens = Console.ReadLine().Split();
    A = new long[N];

    for (int i=0; i<N; i++)
      A[i] = int.Parse(tokens[i]);
  }

  // this brute-force implementation was probably correct however inefficient
  // need to use DP or memoization
  public int GetNumWays() {
    int n = A.Length;
    int count = 0;
    long sum1 = 0, orig_sum3=0;
    //int orig_sum2 = n == 0 ? 0 : A[0];
    // pre-calculate original sum3
    for (int i = 0; i < n; i++)
      orig_sum3 += A[i];

    for (int i = 1; i < n - 1; i++) {
      sum1 += A[i - 1];
      long sum2 = 0;
      orig_sum3 -= A[i-1];
      long sum3 = orig_sum3;
      for (int j = i + 1; j < n; j++) {
        sum2 += A[j - 1];
        sum3 -= A[j - 1];
        if (sum1 == sum2 && sum2 == sum3)
          count++;
        //Console.WriteLine("[{0},{1}]: {2},{3},{4}", i, j, sum1, sum2, sum3);
      }
    }
    return count;
  }
}

public class CFSolution {
  private static void Main() {
    LinearSplit LS = new LinearSplit();
    LS.TakeInput();
    Console.WriteLine(LS.GetNumWays());
  }
}

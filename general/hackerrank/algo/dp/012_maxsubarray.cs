/***************************************************************************************************
* Title : The Maximum Subarray
* URL   : https://www.hackerrank.com/challenges/maxsubarray
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : First part is solved by kadane algorithm
*   second part is non-contiguous sum problem
*   However, the problem is simplified that sum needs not be strictly
*   contiguous therefore applying my trivial approach to sum up all positive
*   and ignore if negative parts are there works just fine
* meta  : tag-algo-dp, tag-kadane
***************************************************************************************************/
using System;

class HKSolution
{
  static void Main(String[] args) {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      int N = int.Parse(Console.ReadLine());
      string[] tokens = Console.ReadLine().Split();
      int[] A = new int[N];
      for (int i = 0; i < N; i++)
        A[i] = int.Parse(tokens[i]);
      int pos_sum = A[0];

      // initialize max sum with first element
      int current_sum = A[0];
      int max_sum = current_sum;

      // run simple kadane's algorithm to get max sum
      for (int i = 1; i < A.Length; i++) {
        if (pos_sum < 0 && pos_sum < A[i])
          pos_sum = A[i];
        else
          pos_sum = Math.Max(pos_sum, pos_sum + A[i]);
        current_sum = Math.Max(A[i], current_sum + A[i]);
        max_sum = Math.Max(max_sum, current_sum);
      }
      Console.WriteLine("{0} {1}", max_sum, pos_sum);
    }
  }
}

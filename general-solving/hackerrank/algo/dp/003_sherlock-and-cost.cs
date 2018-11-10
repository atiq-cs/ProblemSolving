/***************************************************************************************************
* Title : Sherlock and Cost
* URL   : https://www.hackerrank.com/challenges/sherlock-and-cost
* Date  : 2017-09-22
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Traditional Sum = Sum(A[i]) for i=0..N
*   To maximize we have to consider two values for each A[i],
*   1 and B[i]. I consider 1 as the low value and B[i] as the
*   high value. However, B[i] can be 1 as well.
*   
*   To build this DP it helps to consider outcome for each item
*   with both high and low value (1 and B[i].
*   
*   There is no outcome with 1 item. So,
*   s[0][LOW] and s[0][HIGH] are both 0;
*   
*   Considering current value of A[i] to be low (1): then we have 2
*   cases,
*   1. Previous one: A[i-1] is low. In that case,
*   s[i][low] = s[i-1][low] + 1 -1 = s[i-1][low]
*   2. Previous one: A[i-1] is high. So,
*   s[i][low] = s[i-1][high] + b[i-1] -1
*
*   Finally, we take the value that maximizes,
*   s[i][low] = Max( sum1, sum2 );
*   
*   However, there is no gain in choosing s[i-1][low]
*   We get more when we do, s[i-1][high] + b[i-1] -1
*   This works given that B[i] >= 0
*   Therefore, more we can accumulate the more it maximizes the
*   result.
*   
*   it is the sum of A[i-1] to be
*   s[i][LOW] = s[i - 1][HIGH] + b[i-1] - 1;
*   
*   This could also be solved using three variable that keep track
*   of previous 2 values for s[i-1]
*   The use of array in the solution looks okay for recurrence.
* meta  : tag-algo-dp
***************************************************************************************************/
using System;

class HK_Solution {
  const int LOW = 0;
  const int HIGH = 1;

  // As per input desc, the function does not expect N < 1
  static int GetMaxSum(int[] b) {
    int N = b.Length;
    // allocate array sum for DP
    int[][] s = new int[N][];
    // look for one-liner later
    for (int i = 0; i < N; i++)
      s[i] = new int[2];

    s[0][LOW] = s[0][HIGH] = 0;
    for (int i = 1; i < N; i++) {
      s[i][LOW] = s[i - 1][HIGH] + b[i-1] - 1;
      s[i][HIGH] = Math.Max(s[i - 1][HIGH]+ Math.Abs(b[i]-b[i-1]), s[i - 1]
        [LOW] + b[i] - 1);
    }
    return Math.Max(s[N - 1][LOW], s[N-1][HIGH]);
  }

  static void Main(String[] args) {
    // Take input
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      Console.ReadLine();   // discard N for now
      string[] tokens = Console.ReadLine().Split();
      int[] b = Array.ConvertAll(tokens, int.Parse);
      Console.WriteLine(GetMaxSum(b));
    }
  }
}

/*
Sample Inputs,
1
4
1 20 39 1

1
4
1 20 38 1

12
3
1 20 38
3
1 20 39
3
1 20 40
3
1 20 20
3
1 19 20
3
11 10 9
3
12 10 8
3
5 10 20
3
10 10 5
3
5 10 10
2
10 10
5
10 1 10 1 10   
*/

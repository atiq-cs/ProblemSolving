/***************************************************************************************************
* Title : Diagonal Difference
* URL   : https://www.hackerrank.com/challenges/diagonal-difference
* Date  : 2015-09-07
* Notes : Find diff between sum of integers on two diagonals
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : jagged arrays vs multi-dimensional array
*   why, http://stackoverflow.com/questions/12567329/multidimensional-array-vs
* ref   : https://msdn.microsoft.com/en-us/library/2yd9wwz4.aspx
* meta  : tag-easy
***************************************************************************************************/
using System;

class HKSolution {
  // Only traverse required elements - complexity O(N)
  static void Main(String[] args) {
    int N = int.Parse(Console.ReadLine());
    int[][] matrix = new int[N][];
    for (int i = 0; i < N; i++) {
      string[] tokens = Console.ReadLine().Split(' ');
      matrix[i] = Array.ConvertAll(tokens,Int32.Parse);
    }

    int d_sum1 = 0;
    for (int i = 0; i < N; i++) {
      d_sum1 += matrix[i][i];
      d_sum2 += matrix[i][N-i-1];
    }

    Console.WriteLine(Math.Abs(d_sum1 - d_sum2));
  }

  // complexity O(N^2)
  static void Main_v0(String[] args) {
    int N = int.Parse(Console.ReadLine());
    int[,] matrix = new int[N, N];   // square matrix

    int d_sum1 = 0;
    int d_sum2 = 0;

    for (int i = 0; i < N; i++) {
      string[] tokens = Console.ReadLine().Split();
      for (int j = 0; j < N; j++) {
        matrix[i, j] = int.Parse(tokens[j]);
        if (i == j)
          d_sum1 += matrix[i, j];
        if (i + j == N - 1)
          d_sum2 += matrix[i, j];
      }
    }
    Console.WriteLine(Math.Abs(d_sum1 - d_sum2));
  }
}

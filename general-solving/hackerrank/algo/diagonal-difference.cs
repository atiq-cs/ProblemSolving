/***************************************************************************
*   Problem Name:   Diagonal Difference
*   Problem URL :   https://www.hackerrank.com/challenges/diagonal-difference
*   Date        :   Sept 07, 2015
*
*   Domain      :   algorithms/warmup
*                   https://www.hackerrank.com/domains/algorithms/warmup

*   Desc        :   Find diff between sum of integers on two diagonals
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Notes       :   Had to use multi-dimensional array to represent 2d arrays
                  ref: https://msdn.microsoft.com/en-us/library/2yd9wwz4.aspx
                  why, http://stackoverflow.com/questions/12567329/multidimensional-array-vs
***************************************************************************/

using System;
using System.Collections.Generic;

class Solution
{
    static void Main(String[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[,] matrix = new int[N, N];     // square matrix

        int d_sum1 = 0;
        int d_sum2 = 0;

        for (int i = 0; i < N; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            for (int j = 0; j < N; j++)
            {
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

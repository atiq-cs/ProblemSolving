/***************************************************************************************************
* Title : Forming a Magic Square
* URL   : https://www.hackerrank.com/challenges/magic-square-forming
* Date  : 2017-09-17
* Comp  : O(n^2) or O(9) or O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Find one magic square and derive all others by row-wise,
*   column-wise swap and by tranpose (see bottom for more info/draft)
*   I generated 8 of them
* ref   : http://mathforum.org/alejandre/magic.square/adler/adler.whatsquare.html
* meta  : tag-math, tag-combinatorics, tag-implementation, tag-easy
***************************************************************************************************/
using System;

class HKSolution
{
  static int GetSumCost(int[][] A) {
    int[][][] MS = new int[8][][] {
                  new int[3][] { new int[] {4, 9, 2}, new int[] {3, 5, 7}, new int[] {8, 1, 6}},
                  new int[3][] { new int[] {8, 1, 6}, new int[] {3, 5, 7}, new int[] {4, 9, 2}},
                  new int[3][] { new int[] {2, 9, 4}, new int[] {7, 5, 3}, new int[] {6, 1, 8}},
                  new int[3][] { new int[] {2, 7, 6}, new int[] {9, 5, 1}, new int[] {4, 3, 8}},
                  new int[3][] { new int[] {6, 1, 8}, new int[] {7, 5, 3}, new int[] {2, 9, 4}},
                  new int[3][] { new int[] {4, 3, 8}, new int[] {9, 5, 1}, new int[] {2, 7, 6}},
                  new int[3][] { new int[] {6, 7, 2}, new int[] {1, 5, 9}, new int[] {8, 3, 4}},
                  new int[3][] { new int[] {8, 3, 4}, new int[] {1, 5, 9}, new int[] {6, 7, 2}}};
    int min_sum = int.MaxValue;
    for (int k=0; k<8; k++) {
      int sum = 0;
      for (int i=0; i<3; i++)
        for (int j=0; j<3; j++)
          sum += Math.Abs(A[i][j]-MS[k][i][j]);
      if (min_sum > sum) min_sum = sum;
    }
    return min_sum;
  }

  static void Main(String[] args) {
    int[][] s = new int[3][];
    for(int s_i = 0; s_i < 3; s_i++){
       string[] s_temp = Console.ReadLine().Split(' ');
       s[s_i] = Array.ConvertAll(s_temp,Int32.Parse);
    }
    //  Print the minimum cost of converting 's' into a magic square
    Console.WriteLine(GetSumCost(s));
  }
}

/*
All combinations,
C1,

{4, 9, 2}
{3, 5, 7}
{8, 1, 6}

C1->C2 (row-wise),

{8, 1, 6}
{3, 5, 7}
{4, 9, 2}

C1->C3 (column-wise),
{2, 9, 4}
{7, 5, 3}
{6, 1, 8}

C1->C4 (transpose)
{2, 7, 6}
{9, 5, 1}
{4, 3, 8}

C2-> (row wise is done already)
C2->C5 (column-wise)

{6, 1, 8}
{7, 5, 3}
{2, 9, 4}

C3-> (column wise is done already)
C3-> (row wise gives same as C4)

C5-> (row wise done already)
C5-> (column-wise done as well)

C4->C6 (row wise)
{4, 3, 8}
{9, 5, 1}
{2, 7, 6}

C4->C7 (column-wise)
{6, 7, 2}
{1, 5, 9}
{8, 3, 4}

C5->C8 (transpose)
{8, 3, 4}
{1, 5, 9}
{6, 7, 2}

C6-> (row wise done)
C6-> (column-wise done)
C6-> (transpose done)

C7-> (row wise done)
C7-> (column-wise done)
C7-> (transpose done)

C8-> (row wise done)
C8-> (transpose done)
*/

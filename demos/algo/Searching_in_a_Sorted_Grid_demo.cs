/***************************************************************************
* Title   : Searching in a Sorted Grid
* Date    : July 29, 2015
* Algo    : Algorithm 4 on Dr. Rezaul's Lecture
* Desc    :   
*
* Complexity: O(m+n) for input mxn matrix
* Author  : Atiq Rahman
* Notes   : Algo ref
*           http://www3.cs.stonybrook.edu/~rezaul/Spring-2015/CSE548/
*           CSE548-lecture-1.pdf
*           Property of the bottom left corner:
*            The item in this corner is smallest in the row and largest
*            in the column
*            Because we start from this corner by going up and right we
*            are able to search the item in all possible position where
*            the item can be found.
*
*           Therefore, approach:
*            Start from bottom left corner
*            1. 2if y == x item is found
*            2. if y < x go right
*            3. if y > x go up
*
* Language  we use multidimensional arrays
*           https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/
*           arrays/multidimensional-arrays
*           be aware of following
*            - Rank is the property that returns the number of dimensions
*            - number of rows: matrix.GetLength(0);
*            - number of columns:  matrix.GetLength(1);
*           initialilzation examples,
*            https://msdn.microsoft.com/en-us/library/aa287601.aspx
* Related : leetcode/240_search-a-2d-matrix-ii.cs
***************************************************************************/
using System;

public class Solution {
  public static bool SearchMatrix(int[][] matrix, int target) {
    // first navigate to right and go toward bottom to find the target
    int row = matrix.Length-1;    // bottom of matrix
    int col = 0;              // left of matrix

    while (true) {
      if (matrix[row][col] == target)
        return true;
      if (matrix[row][col] < target) {
        col++;
        if (col == matrix.Length)
          break;
      }
      if (matrix[row][col] > target) {
        row--;
        if (row < 0)
          break;
      }
    }
    return false;
  }

  public static void Main(string[] args) {
    int[][] mat = new int[][] { new int[] { 1, 4, 7, 11, 15 },
                  new int[] { 2, 5, 8, 12, 19 },
                  new int[] { 3,  6,  9, 16, 22 },
                  new int[] { 10, 13, 14, 17, 24 },
                  new int[] { 18, 21, 23, 26, 30 } };
    Console.Write("Enter input number to find: ");
    int n=1;
    int.TryParse(Console.ReadLine(), out n);
    do {
      if (SearchMatrix(mat, n))
        Console.WriteLine("{0} is found", n);
      else
        Console.WriteLine("{0} is not found", n);

      int.TryParse(Console.ReadLine(), out n);
    } while (n > 0);
  }
  public static bool old_SearchMatrix(int[,] matrix, int target) {
    // first navigate to right and go toward bottom to find the target
    int row = matrix.GetLength(0)-1;    // bottom of matrix
    int col = 0;              // left of matrix

    while (true) {
      if (matrix[row, col] == target)
        return true;
      if (matrix[row, col] < target) {
        col++;
        if (col == matrix.GetLength(1))
          break;
      }
      if (matrix[row, col] > target) {
        row--;
        if (row < 0)
          break;
      }
    }
    return false;
  }

  public static void old_Main(string[] args) {
    int[,] mat = new int[,] { {1, 4,  7, 11, 15},
                { 2,  5,  8, 12, 19},
                { 3,  6,  9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}};
    Console.Write("Enter input number to find: ");
    int n = 1;
    int.TryParse(Console.ReadLine(), out n);
    do {
      if (old_SearchMatrix(mat, n))
        Console.WriteLine("{0} is found", n);
      else
        Console.WriteLine("{0} is not found", n);

      int.TryParse(Console.ReadLine(), out n);
    } while (n > 0);
  }
}

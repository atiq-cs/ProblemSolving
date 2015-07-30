/***************************************************************************
*   Problem Name:   Searching in a Sorted Grid
*   Related Problem:   general-solving/leetcode/240_search-a-2d-matrix-ii.cs
*   Date        :   July 29, 2015
*   Algo, DS    :   Algorithm 4, ref: http://www3.cs.stonybrook.edu/~rezaul/Spring-2015/CSE548/CSE548-lecture-1.pdf
*   Desc        :   Powerful simple algorithm that solves the problem - 
*                   Start from bottom left corner
*                    if y == x item is found
*                    if y < x go right
*                    if y > x go up
*
*   Complexity  :   O(m+n) for input mxn matrix
*   Author      :   Atiq Rahman
*   Notes       :   Technical Notes - we use multidimensional arrays https://msdn.microsoft.com/en-us/library/2yd9wwz4.aspx
 *                   be aware of following
*                    - Rank is the property that returns the number of dimensions
*                    - number of rows: matrix.GetLength(0);
*                    - number of columns:  matrix.GetLength(1);
***************************************************************************/
using System;

public class Solution
{
    public static bool SearchMatrix(int[,] matrix, int target)
    {
        // first navigate to right and go toward bottom to find the target
        int row = matrix.GetLength(0)-1;        // bottom of matrix
        int col = 0;                            // left of matrix

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

    public static void Main(string[] args) { 
        int[,] mat = new int[,] { {1, 4,  7, 11, 15},
                                { 2,  5,  8, 12, 19},
                                { 3,  6,  9, 16, 22},
                                {10, 13, 14, 17, 24},
                                {18, 21, 23, 26, 30}};
        Console.Write("Enter input number to find: ");
        int n=1;
        int.TryParse(Console.ReadLine(), out n);
        do
        {
            if (SearchMatrix(mat, n))
                Console.WriteLine("{0} is found", n);
            else
                Console.WriteLine("{0} is not found", n);

            int.TryParse(Console.ReadLine(), out n);
        } while (n > 0);

    }
}

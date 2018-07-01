/***************************************************************************
*   Problem Name:   Search a 2D Matrix II
*   Problem URL :   https://leetcode.com/problems/search-a-2d-matrix-ii/
*                   Derived from: Algorithms/Searching_in_a_Sorted_Grid_demo.cs

*   Date        :   July 29, 2015
*   Desc        :   Look at Algorithms/Searching_in_a_Sorted_Grid_demo.cs
*
*   Complexity  :   O(m+n) for input mxn matrix
*   Author      :   Atiq Rahman
*   Status      :   Accepted
***************************************************************************/
public class Solution
{
    public bool SearchMatrix(int[,] matrix, int target)
    {
        int row = matrix.GetLength(0) - 1;        // bottom of matrix
        int col = 0;                            // left of matrix

        while (true)
        {
            if (matrix[row, col] == target)
                return true;
            if (matrix[row, col] < target)
            {
                col++;
                if (col == matrix.GetLength(1))
                    break;
            }
            if (matrix[row, col] > target)
            {
                row--;
                if (row < 0)
                    break;
            }
        }
        return false;
    }
}

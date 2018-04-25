/***************************************************************************
* Title : Island Perimeter
* URL   : https://leetcode.com/problems/island-perimeter
* Date  : 2018-02
* Author: Atiq Rahman
* Comp  : O(N*M)
* Status: Accepted
* Notes : Based on Vasili's version which essentially boils down to,
*   if element on starting index is less than item on middle index then left
*   (w.r.t middle element) side is sorted
*   Otherwise, right side is sorted
*   
*   Because one of the two sides must be sorted in a rotated sorted array
*   
*   This is more comprehensive than what I was developing initially,
*   My first idea was to consider all cases where the rotation index can be (
*   starting from 1 to N-1). This means rotation point can be in between
*   first and middle or middle and last
* meta  : tag-binary-search, tag-recursion
***************************************************************************/
public class Solution {
  int n, m;
  public int IslandPerimeter(int[,] jgrid) {
    int[][] grid = ConvertMultiDimensionalToJagged(jgrid);
    int cellCount = 0, excludeCellCount = 0;

    for (int i=0; i<n; i++)
      for (int j=0; j<m; j++)
        if (grid[i][j] == 1) {
          cellCount++;
          if (i != 0 && (grid[i-1][j] == 1))
            excludeCellCount++;
          if (j != 0 && (grid[i][j-1] == 1))
            excludeCellCount++;
        }
    return (cellCount<<2) - (excludeCellCount<<1);
  }
}

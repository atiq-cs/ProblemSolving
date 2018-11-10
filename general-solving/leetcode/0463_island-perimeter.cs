/***************************************************************************
* Title : Island Perimeter
* URL   : https://leetcode.com/problems/island-perimeter
* Date  : 2018-02
* Author: Atiq Rahman
* Comp  : O(N*M)
* Status: Accepted
* Notes : Determine the perimeter of the island.
*   To calculate the perimeter we can sum up the sides of the island. To get
*   that sum we have to multiply total number of cells with 4. While doing that
*   we have included the sides that are in between two cells twice. Therefore,
*   we need to subtract that. Here's an example,
*    __
*   |  |
*    --
*   |  |
*    --
*    
*   Perimeter here is = 2 * 4 - 1 * 2 = 6
*   
*   Kinda like dp, linear progression to compute final result.
* meta  : tag-algo-dp, tag-leetcode-easy
***************************************************************************/
public class Solution {
  int n, m;
  public int IslandPerimeter(int[,] mdGrid) {
    int[][] grid = ConvertMultiDimensionalToJagged<int>(mdGrid);
    int cellCount = 0, excludeCellCount = 0;

    for (int i = 0; i < n; i++)
      for (int j = 0; j < m; j++)
        if (grid[i][j] == 1) {
          cellCount++;
          if (i != 0 && (grid[i - 1][j] == 1))
            excludeCellCount++;
          if (j != 0 && (grid[i][j - 1] == 1))
            excludeCellCount++;
        }
    return (cellCount << 2) - (excludeCellCount << 1);
  }
}

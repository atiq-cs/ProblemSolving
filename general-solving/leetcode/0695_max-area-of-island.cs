/***************************************************************************
* Title : Max Area of Island
* URL   : https://leetcode.com/problems/max-area-of-island
* Date  : 2018-02
* Author: Atiq Rahman
* Comp  : O(n * m), O(n * m)
* Status: Accepted
* Notes : The problem maps to finding size of largest DFS forest
*   this solution does not modify original array
*   If we are allowed to modify the original array then we don't need to use
*   additional visit array which requires O(n*m) space
* meta  : tag-graph-dfs
***************************************************************************/
public class Solution {
  private int[][] grid;
  private int numRows;
  private int numCols;
  private int forestSize;
  private int maxForestSize;
  private bool[][] visited;

  public int MaxAreaOfIsland(int[,] mdGrid) {
    // ref: 'utils.cs'
    grid = ConvertMultiDimensionalToJagged<int>(mdGrid);
    visited = new bool[numRows][];
    for (int i = 0; i < numRows; i++)
      visited[i] = new bool[numCols];
    maxForestSize = 0;
    for (int i = 0; i < numRows; i++)
      for (int j = 0; j < numCols; j++) {
        forestSize = 0;
        DFS(i, j);
        if (maxForestSize < forestSize)
          maxForestSize = forestSize;
      }
    return maxForestSize;
  }

  private void DFS(int r, int c) {
    if (r < 0 || c < 0 || r >= numRows || c >= numCols || visited[r][c] || grid[r][c] == 0)
      return;
    visited[r][c] = true;
    forestSize++;
    DFS(r - 1, c);
    DFS(r, c - 1);
    DFS(r + 1, c);
    DFS(r, c + 1);
  }
}

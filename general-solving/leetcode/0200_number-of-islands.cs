/***************************************************************************
* Title : Number of Islands
* URL   : https://leetcode.com/problems/number-of-islands
* Date  : 2018-07 (Den Meetup)
* Author: Atiq Rahman
* Comp  : O(nm), O(1)
* Status: Accepted
* Notes :
* Rel   : 'leetcode/0695_max-area-of-island.cs'
* meta  : tag-leetcode-medium, tag-dfs, tag-graph
***************************************************************************/
public class Solution {
  private int numRows, numCols;
  private bool[][] grid;

  public int NumIslands(char[,] mdGrid) {
    grid = ConvertMultiDimensionalToJagged(mdGrid, '0');    // ref: 'utils.cs'
    int count = 0;
    for (int i=0; i<numRows; i++)
      for (int j=0; j<numCols; j++) {
        if (grid[i][j]) {
          DFS(i, j);
          count++;
        }
      }
    return count;
  }
  
  private void DFS(int r, int c) {
    if (r < 0 || c<0 || r>=numRows || c>=numCols || grid[r][c] == false)
      return ;
    grid[r][c] = false;
    DFS(r-1, c);
    DFS(r, c-1);
    DFS(r+1, c);
    DFS(r, c+1);
  }

  // Previous version that uses O(nm) space
  public int NumIslands_v0(char[,] mdGrid) {
    grid = ConvertMultiDimensionalToJagged<int>(mdGrid);
    // declare this as class member as well
    visited = new bool[numRows][];
    for (int i=0; i<numRows; i++)
      visited[i] = new bool[numCols];
    int count = 0;
    for (int i=0; i<numRows; i++)
      for (int j=0; j<numCols; j++) {
        if (grid[i][j] && visited[i][j] == false) {
          DFS(i, j);
          count++;
        }
      }
    return count;
  }
  
  private void DFS_v0(int r, int c) {
    if (r < 0 || c<0 || r>=numRows || c>=numCols || visited[r][c] ||
        grid[r][c] == false)
      return ;
    visited[r][c] = true;
    DFS(r-1, c);
    DFS(r, c-1);
    DFS(r+1, c);
    DFS(r, c+1);
  }
}

/***************************************************************************************************
* Title : Making A Large Island
* URL   : https://leetcode.com/problems/making-a-large-island
* Date  : 2018-07-08 (InnoWorld)
* Author: Atiq Rahman
* Comp  : O(nm), O(n)
* Status: Accepted
* Notes : O(n) worst case space to store size of forests
*   not really hard once figured out how we can mark using forest number
*   
*   TODO, now solve using Union Find and Path compression
* rel   : 'leetcode/0695_max-area-of-island.cs'
* meta  : tag-leetcode-hard, tag-dfs, tag-graph
***************************************************************************************************/
public class Solution {
  private int numRows, numCols;
  private int[][] grid;
  // Number of DFS Forests Found, offset by 2 since 0 and 1 are already used
  private int forestCount = 2;
  private List<int> forestSizes;  // Size of each forest

  public int LargestIsland(int[][] mGrid) {
    grid = mGrid;
    numRows = mGrid.Length;
    numCols = mGrid[0].Length;
    forestSizes = new List<int>();
    for (int i=0; i<numRows; i++)
      for (int j=0; j<numCols; j++) {
        if (grid[i][j] == 1) {
          forestSizes.Add(0);
          DFS(i, j);
          forestCount++;
        }
      }
    // Using information regarding DFS forests let's find largest island
    // possible using a single flip of a 0
    return tryMakingLargeIsland();
  }
  
  private void DFS(int r, int c) {
    if (r < 0 || c<0 || r>=numRows || c>=numCols || grid[r][c] == 0 ||
        grid[r][c] != 1)
      return ;
    grid[r][c] = forestCount;
    forestSizes[forestCount-2]++;
    DFS(r-1, c);
    DFS(r, c-1);
    DFS(r+1, c);
    DFS(r, c+1);
  }
  
  private int tryMakingLargeIsland() {
    int maxArea = 0;
    // if no cell can be flipped max is the largest forest we already have
    // without flipping
    foreach(var fArea in forestSizes)
      maxArea = Math.Max(maxArea, fArea);
    for (int i=0; i<numRows; i++)
      for (int j=0; j<numCols; j++)
        if (grid[i][j] == 0) {    // try flipping cell (i,j)
          var adjSet = new HashSet<int>();
          int area = 1;
          area += GetForestSize(i-1, j, adjSet);
          area += GetForestSize(i, j-1, adjSet);
          area += GetForestSize(i+1, j, adjSet);
          area += GetForestSize(i, j+1, adjSet);
          maxArea = Math.Max(maxArea, area);
        }
    return maxArea;
  }
  
  private int GetForestSize(int r, int c, HashSet<int> adjSet) {
    if (r < 0 || c<0 || r>=numRows || c>=numCols || grid[r][c] == 0 ||
        adjSet.Contains(grid[r][c]))
      return 0;
    adjSet.Add(grid[r][c]);
    return forestSizes[grid[r][c]-2];
  }
}

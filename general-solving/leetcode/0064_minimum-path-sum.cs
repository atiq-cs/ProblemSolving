/***************************************************************************
* Title : Minimum Path Sum
* URL   : https://leetcode.com/problems/minimum-path-sum
* Date  : 2018-07-20
* Author: Atiq Rahman
* Comp  : O(mn), O(n)
* Occasn: JS meetup 2018-07-20 Q1; have seen variation of this in Fortress IQ
*   coding test
* Status: Accepted
* Notes : final version, would be hard to understand as this code has
*   shortened over a few iterations. Therefore, code history is included. Points,
*   Need to take care of base case that, dp[0][0] = grid[0][0]
*   Row and col cannot be negative.
*   Overflow for addition with Max Int (INF) is taken care of in `Add()`
*   
* meta  : tag-algo-dp, tag-graph-bfs, tag-leetcode-medium
***************************************************************************/
public class Solution {
  int numRows, numCols;
  const int INF = int.MaxValue;
  int[] previousRow;

  // final version for O(N) space
  public int MinPathSum(int[,] mdGrid) {
    var grid = ConvertMultiDimensionalToJagged<int>(mdGrid);    // ref: 'utils.cs'
    previousRow = new int[numCols];

    // allocation, init and dp logic all in same loop
    for (int row=0; row<numRows; row++) {
      for (int col=0; col<numCols; col++)
        if (row==0 && col==0)
          previousRow[col] = grid[row][col];
        else // in this version this line is simplified
          previousRow[col] = Math.Min(Add(row, col, grid[row][col], true),
            Add(row, col, grid[row][col], false));
    }
    return previousRow[numCols-1];
  }

  // simplified
  private int Add(int row, int col, int val, bool checkRow) {
    if (checkRow) {
      if (row == 0) return INF;
    }
    else {
      if (col == 0) return INF;
      col--;
    }
    return previousRow[col] == INF? INF : previousRow[col] + val;
  }

  // second iteration: removes variable preColDpVal
  private int Add(int row, int col, int val, bool checkRow) {
    if (checkRow) {
      if (row == 0 || previousRow[col] == INF)
        return INF;
      return previousRow[col] + val;
    }
    else {
      if (col == 0 || previousRow[col-1] == INF)
        return INF;
      return previousRow[col-1] + val;
    }
  }

  public int MinPathSum(int[,] mdGrid) {
    var grid = ConvertMultiDimensionalToJagged<int>(mdGrid);
    previousRow = new int[numCols];
    int preColDpVal=INF;

    // allocation, init and dp logic all in same loop
    for (int row=0; row<numRows; row++) {
      for (int col=0; col<numCols; col++)
        if (row==0 && col==0)
          previousRow[col] = preColDpVal = grid[row][col];
        else // in this version this line is simplified
          previousRow[col] = preColDpVal = Math.Min(Add(row, col, grid[row][col], true), Add(row, col, grid[row][col], false, preColDpVal));
    }
    return preColDpVal;
  }

  private int Add(int row, int col, int val, bool checkRow, int preColDpVal = 0) {
    if (checkRow) {
      if (row == 0 || previousRow[col] == INF)
        return INF;
      return previousRow[col] + val;
    }
    else {
      if (col == 0 || preColDpVal == INF)
        return INF;
      return preColDpVal + val;
    }
  }

  // third version, O(MN) space, Add simplified/overriden
  int[][] dp;
  public int MinPathSum(int[,] mdGrid) {
    var grid = ConvertMultiDimensionalToJagged<int>(mdGrid);
    dp = new int[numRows][];

    // allocation, init and dp logic all in same loop
    for (int row=0; row<numRows; row++) {
      dp[row] = new int[numCols];
      for (int col=0; col<numCols; col++)
        if (row==0 && col==0)
          dp[row][col] = grid[row][col];
        else // in this version, this line is simplified coz of *readability*
          dp[row][col] = Math.Min(Add(row-1, col, grid[row][col]),
            Add(row, col-1, grid[row][col]));
    }
    return dp[numRows-1][numCols-1];
  }
  
  private int Add(int row, int col, int val) {
    if (row == -1 || col == -1 || dp[row][col] == INF)
      return INF;
    return dp[row][col] + val;
  }

  // second version, O(MN) space, alloc, init, dp all in same loop
  public int MinPathSum(int[,] mdGrid) {
    for (int row=0; row<numRows; row++) {
      dp[row] = new int[numCols];
      for (int col=0; col<numCols; col++)
        if (row==0 && col==0)
          dp[row][col] = grid[row][col];
        else
          dp[row][col] = Math.Min(row==0? INF : (dp[row-1][col]==INF? INF: (
            dp[row-1][col] + grid[row][col])), col==0? INF : (dp[row][col-1]==
            INF?INF : (dp[row][col-1] + grid[row][col])));
    }
  }

  // first version, O(MN) space
  public int MinPathSum(int[,] mdGrid) {
    var grid = ConvertMultiDimensionalToJagged<int>(mdGrid);
    var dp = new int[numRows][];
    const int INF = int.MaxValue;
    // aloc & init
    for (int row=0; row<numRows; row++) {
      dp[row] = new int[numCols];
      for (int col=0; col<numCols; col++)
        dp[row][col] = INF;
    }
    dp[0][0] = grid[0][0];

    // conditional like this prevents addition with Max Int value which causes
    // an overflow
    // dp[row-1][col]==INF? INF: (dp[row-1][col] + grid[row][col])
    // in next version this is simplified and implemented in a separate method
    for (int row=0; row<numRows; row++)
      for (int col=0; col<numCols; col++)
        dp[row][col] = Math.Min(dp[row][col], Math.Min(row==0? INF :
          (dp[row-1][col]==INF? INF: (dp[row-1][col] + grid[row][col])),
          col==0? INF : (dp[row][col-1]==INF?INF : (dp[row][col-1] +
          grid[row][col]))));
    return dp[numRows-1][numCols-1];
  }
}

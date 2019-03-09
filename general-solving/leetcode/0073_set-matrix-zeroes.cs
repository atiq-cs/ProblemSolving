/***************************************************************************
* Title : Set Matrix Zeroes
* URL   : https://leetcode.com/problems/set-matrix-zeroes
* Occasn: Meetup at DEN, remote
* Date  : 2018-05-12
* Author: Atiq Rahman
* Comp  : O(n*m), O(n+m)
* Status: Accepted
* Notes : Kind of optimizing an array solution
*   Sets rows and columns in single loop
* meta  : tag-leetcode-medium
***************************************************************************/
public class Solution {
  private int numRows;
  private int numCols;
  
  public void SetZeroes(int[,] mdMat) {
    int[][] matrix = ConvertMultiDimensionalToJagged<int>(mdMat);
    bool[] rows = new bool[numRows];  // indicates marked rows for being zeroed out
    bool[] cols = new bool[numCols];  // marked columns for being zeroed out    
    
    for (int i=0; i<numRows; i++)   // pointer to row
      for (int j=0; j<numCols; j++) { // pointer to column
        if (matrix[i][j] == 0) {
          if (rows[i] == false) {
            rows[i] = true;
            for (int k=0; k<j;k++)  // reset row upto column j
              matrix[i][k] = 0;
          }
          if (cols[j] == false) {
            cols[j] = true;
            for (int k=0; k<i;k++)  // reset column upto row i
              matrix[k][j] = 0;
          }
        }
        // This is required
        else if (cols[j] || rows[i])
          matrix[i][j] = 0;
      }
    ConvertJaggedToMultiDimensional<int>(matrix, mdMat);
  }

  // first version, a better solution if input was only 1 and 0 in matrix
  // however, unfortunately, input example, [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
  public void SetZeroes(int[,] mdMat) {
    bool[][] matrix = ConvertMultiDimensionalToJagged(mdMat);
    int col = n, row = m;
    bool[] rows = new bool[row];  // indicates marked rows for being zeroed out
    bool[] cols = new bool[col];  // marked columns for being zeroed out    
    
    for (int i=0; i<col; i++)
      for (int j=0; j<row; j++) {
        if (cols[i] || rows[j])
          matrix[i][j] = false;
        else if (matrix[i][j] == false) {
          cols[i] = true;
          rows[j] = true;
          for (int k=0; k<i;k++)  // reset column
            matrix[k][j] = false;
          for (int k=0; k<j;k++)  // reset row
            matrix[i][k] = false;
        }
      }
    ConvertJaggedToMultiDimensional(matrix, mdMat);
  }
}
/*
Some inputs,
[[-4,-2147483648,6,-7,0],[-8,6,-8,-6,0],[2147483647,2,-9,-6,-10]]
[[0,1,2,0],[3,4,5,2],[1,3,1,5]]
[[1,1,1],[1,0,1],[1,1,1]]
*/

/***************************************************************************
* Title : Spiral Matrix
* URL   : https://leetcode.com/problems/spiral-matrix
* Date  : 2018-08-15
* Author: Atiq Rahman
* Occasn: InnoWorld 2018-08-12, Indy, Charan
* Comp  : O(n*m)
* Status: Accepted
* Notes : Corner cases:
*    when numRows != numColumns
*    if starting row and ending row are same don't traverse left to print..
*    if starting column and ending column are same don't traverse up to print..
*
*    for matrices like 2x3 matrix, this condition is not correct,
*      r<=m/2 && c<=n/2
* meta  : tag-implementation, tag-leetcode-medium
***************************************************************************/
public class Solution {
  int[][] matrix;
  IList<int> result = new List<int>();
  int numRows, numCols;
  
  public IList<int> SpiralOrder(int[,] md) {
    matrix = ConvertMultiDimensionalToJagged<int>(md);
    for (int r=0, c=0; r<=(numRows-1)/2 && c<=(numCols-1)/2; r++, c++)
      CreateSpiral(r, c);
    return result;
  }

  // sr: starting row
  // sc: starting column
  private void CreateSpiral(int sr, int sc) {
    // add in left to right order, same row
    for (int c=sc; c<numCols-sc; c++)
      result.Add(matrix[sr][c]);

    // add in top to down order, same column
    for (int r=sr+1; r<numRows-sr; r++)
      result.Add(matrix[r][numCols - sc - 1]);

    // add in right to left order, same row
    if (sr != (numRows-sr-1))
      for (int c=numCols-sc-2; c>=sc; c--)
        result.Add(matrix[numRows-sr-1][c]);

    // add in bottom to top order, same column
    if (sc != (numCols-sc-1))
      for (int r=numRows-sr-2; r>sr; r--)
        result.Add(matrix[r][sc]);
  }
}

/* Draft
Inputs,
[[1,2,3],[4,5,6],[7,8,9]]
[[1,2,3,4],[5,6,7,8],[9,10,11,12]]

[[7],[9],[6]]

[[2,5,8],[4,0,-1]]

[
[2,5,8],
[4,0,-1]
]

Debug code can be found at,
 https://leetcode.com/submissions/detail/169710797/
*/

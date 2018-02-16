/***************************************************************************
* Title : Utilities for leetcode
* URL   : 
* Date  : 2018-02-12
* Author: Atiq Rahman
* Notes : 
***************************************************************************/
// Utility functions where the leetcode problem provides jagged array in parameters
private int[][] ConvertMultiDimensionalToJagged(int[,] md) {
  n = md.GetLength(0);
  m = md.GetLength(1);
  int[][] A = new int[md.GetLength(0)][];
  for (int i=0; i<n; i++) {
    A[i] = new int[m];
    for (int j=0; j<m; j++)
      A[i][j] = md[i,j];
  }
  return A;
}

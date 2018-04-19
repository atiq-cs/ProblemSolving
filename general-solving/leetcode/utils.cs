/***************************************************************************
* Title : Utilities for leetcode
* URL   : 
* Date  : 2018-02-12
* Author: Atiq Rahman
* Notes : Utility function for leetcode problems with jagged array in parameters
***************************************************************************/
public class LeetcodeUtils {
  private int[][] ConvertMultiDimensionalToJagged(int[,] md)
  {
    n = md.GetLength(0);  // class member
    m = md.GetLength(1);  // class member

    int[][] jaggedArray = new int[n][];
    for (int i=0; i<n; i++) {
      jaggedArray[i] = new int[m];
      for (int j=0; j<m; j++)
        jaggedArray[i][j] = md[i,j];
    }
    return jaggedArray;
  }

  private int[,] ConvertJaggedToMultiDimensional(int[][] jaggedArray)
  {
    n = jaggedArray.Length;  // class member
    if (n == 0)
      throw new ArgumentException();
    m = jaggedArray[0].Length;  // class member
    if (m == 0)
      throw new ArgumentException();

    int[,] md = new int[n,m];
    for (int i = 0; i < n; i++)
      for (int j = 0; j < m; j++)
        md[i, j] = jaggedArray[i][j];
    return md;
  }
}

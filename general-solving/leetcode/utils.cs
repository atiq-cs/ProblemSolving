/***************************************************************************
* Title : Utilities for leetcode
* URL   : 
* Date  : 2018-05-13 (updated)
* Author: Atiq Rahman
* Notes : Utility function for leetcode problems with jagged array in
*   parameters. A few overrides added
***************************************************************************/
public class LeetcodeUtils {
  private int[][] ConvertMultiDimensionalToJagged(int[,] md)
  {
    numRows = md.GetLength(0);  // renamed from n
    numCols = md.GetLength(1);  // renamed from m

    int[][] jaggedArray = new int[numRows][];
    for (int i = 0; i < numRows; i++)
    {
      jaggedArray[i] = new int[numCols];
      for (int j = 0; j < numCols; j++)
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

  // equivalent to previous ConvertJaggedToMultiDimensional
  // provide override when original function does not provide way to return
  // result array
  void ConvertJaggedToMultiDimensional(int[][] jaggedArray, int[,] md)
  {
    numRows = jaggedArray.Length;  // class member
    if (numRows == 0)
      throw new ArgumentException();
    numCols = jaggedArray[0].Length;  // class member
    if (numCols == 0)
      throw new ArgumentException();

    for (int i = 0; i < numRows; i++)
      for (int j = 0; j < numCols; j++)
        md[i, j] = jaggedArray[i][j];
  }


  // Provide boolean overrides to optimize space
  private bool[][] ConvertMultiDimensionalToJagged(int[,] md)
  {
    numRows = md.GetLength(0);  // class member
    numCols = md.GetLength(1);  // class member

    bool[][] jaggedArray = new bool[numRows][];
    for (int i=0; i< numRows; i++) {
      jaggedArray[i] = new bool[numCols];
      for (int j=0; j<numCols; j++)
        jaggedArray[i][j] = md[i,j] == 0? false : true;
    }
    return jaggedArray;
  }

  void ConvertJaggedToMultiDimensional(bool[][] jaggedArray, int[,] md) {
    numRows = jaggedArray.Length;  // class member
    if (numRows == 0)
      throw new ArgumentException();
    numCols = jaggedArray[0].Length;  // class member
    if (numCols == 0)
      throw new ArgumentException();

    for (int i = 0; i < numRows; i++)
      for (int j = 0; j < numCols; j++)
        md[i, j] = jaggedArray[i][j]? 1: 0;
  }
}

/***************************************************************************************************
* Title : Utilities for leetcode
* URL   : 
* Date  : 2018-05-13 (updated)
* Author: Atiq Rahman
* Notes : Utility function for leetcode problems with jagged array in
*   parameters. A few overrides added
*   I find Comparison to be complicated in Generics!
***************************************************************************************************/
public class LeetcodeUtils {
  void Swap<T>(ref T lhs, ref T rhs) {
    T tmp = lhs;
    lhs = rhs;
    rhs = tmp;
  }

  // here's a version might seem readable some times
  private void Swap<T>(T[] A, int i, int j) {
    T tmp = A[i];
    A[i] = A[j];
    A[j] = tmp;
  }

  private T[][] ConvertMultiDimensionalToJagged<T>(T[,] md) {
    numRows = md.GetLength(0);  // renamed from n
    numCols = md.GetLength(1);  // renamed from m

    T[][] jaggedArray = new T[numRows][];
    for (int i = 0; i < numRows; i++) {
      jaggedArray[i] = new T[numCols];
      for (int j = 0; j < numCols; j++)
        jaggedArray[i][j] = md[i, j];
    }
    return jaggedArray;
  }

  private T[,] ConvertJaggedToMultiDimensional<T>(T[][] jaggedArray) {
    numRows = jaggedArray.Length;  // class member
    if (numRows == 0)
      throw new ArgumentException();
    numCols = jaggedArray[0].Length;  // class member
    if (numCols == 0)
      throw new ArgumentException();

    T[,] md = new T[numRows, numCols];
    for (int i = 0; i < numRows; i++)
      for (int j = 0; j < numCols; j++)
        md[i, j] = jaggedArray[i][j];
    return md;
  }

  // Provide boolean overrides to optimize space
  // Checking type parameter of a generic method in C# ref:
  //  https://stackoverflow.com/q/2004508
  // ref, for IEquatable if required http://blog.andreaskahler.com/2009/04
  //  /how-to-test-equality-for-objects-of.html
  private bool[][] ConvertMultiDimensionalToJagged<T>(T[,] md, T zero) {
    numRows = md.GetLength(0);  // class member
    numCols = md.GetLength(1);  // class member

    bool[][] jaggedArray = new bool[numRows][];
    for (int i = 0; i < numRows; i++) {
      jaggedArray[i] = new bool[numCols];
      for (int j = 0; j < numCols; j++)
        jaggedArray[i][j] = md[i, j].Equals(zero) ? false : true;
    }
    return jaggedArray;
  }

  // equivalent to previous ConvertJaggedToMultiDimensional
  // provide override when original function does not provide way to return
  // result array, modify the provided array instead
  void ConvertJaggedToMultiDimensional<T>(T[][] jaggedArray, T[,] md) {
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

  void ConvertJaggedToMultiDimensional(bool[][] jaggedArray, int[,] md) {
    numRows = jaggedArray.Length;  // class member
    if (numRows == 0)
      throw new ArgumentException();
    numCols = jaggedArray[0].Length;  // class member
    if (numCols == 0)
      throw new ArgumentException();

    for (int i = 0; i < numRows; i++)
      for (int j = 0; j < numCols; j++)
        md[i, j] = jaggedArray[i][j] ? 1 : 0;
  }
}

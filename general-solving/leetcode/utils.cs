﻿/***************************************************************************
* Title : Utilities for leetcode
* URL   : 
* Date  : 2018-02-12
* Author: Atiq Rahman
* Notes : Utility function for leetcode problems with jagged array in parameters
***************************************************************************/
public class LeetcodeUtils {
  private int[][] ConvertMultiDimensionalToJagged(int[,] md) {
    n = md.GetLength(0);
    m = md.GetLength(1);
    int[][] jaggedArray = new int[md.GetLength(0)][];
    for (int i=0; i<n; i++) {
      jaggedArray[i] = new int[m];
      for (int j=0; j<m; j++)
        jaggedArray[i][j] = md[i,j];
    }
    return jaggedArray;
  }
}

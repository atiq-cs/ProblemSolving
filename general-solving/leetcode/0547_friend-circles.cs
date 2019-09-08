/***************************************************************************************************
* Title : Determines if given string has some properties
* URL   : https://leetcode.com/problems/friend-circles/
* Date  : 2019-03-19
* Comp  : m alpha n amortized for n makeSet and m Unions I am assuming
* Status: Accepted
* Notes :
* rel   : 'ds/dsf.cs'
* meta  : tag-ds-dsf, tag-algo-union-find, tag-ds-core
***************************************************************************************************/
public class Solution {
  int numRows;
  int numCols;

  public int FindCircleNum(int[,] md) {
    var mat = ConvertMultiDimensionalToJagged<int>(md); // utils.cs

    DSF dsu = new DSF(numRows);
    for (int r = 0; r < numRows; r++)
      for (int c = 0; c < numCols; c++)
        if (r != c && mat[r][c] == 1)
          dsu.Union(dsu.FindSet(r), dsu.FindSet(c));

    return dsu.Count;
  }
}

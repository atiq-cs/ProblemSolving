/***************************************************************************
* Title : Pascal's Triangle
* URL   : https://leetcode.com/problems/pascals-triangle
* Date  : 2018-01
* Author: Atiq Rahman
* Comp  : O(N^2)
* Status: Accepted
* Notes : Output List is easier to generate we have the formula for each cell
*   (row, column)
* meta  : tag-math, tag-leetcode-easy
***************************************************************************/
public class Solution {
  int GetCellValue(int n, int r) {
    int result = 1;
    for (int i = r, j = 1; i < n; i++, j++)
      result = (result * i) / j;
    return result;
  }

  public IList<IList<int>> Generate(int numRows) {
    IList<IList<int>> result = new List<IList<int>>();
    for (int row = 1; row <= numRows; row++) {
      IList<int> rowResult = new List<int>();
      for (int column = 1; column <= row; column++)
        rowResult.Add(GetCellValue(row, column));
      result.Add(rowResult);
    }
    return result;
  }
}

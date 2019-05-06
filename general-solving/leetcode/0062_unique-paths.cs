/***************************************************************************************************
* Title : Unique Paths
* URL   : https://leetcode.com/problems/unique-paths/
* Date  : 2019-01-20
* Comp  : O(mn), O(n)
* Status: Accepted
* Notes : Easier version of FortressIQ 2nd problem, hence found it too easy
* rel   : 'general-solving/coding-tests/FortressIQ_2.cs'
* meta  : tag-algo-dp, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  public int UniquePaths(int m, int n) {
    int[] prevRow = new int[n];   // just previous row
    for (int i = 0; i < n; i++)
      prevRow[i] = 1;
    int prevCol = 1;

    for (int row = 1; row < m; row++)
      for (int col = 1; col < n; col++) {
        prevRow[col] = prevRow[col] + prevCol;
        prevCol = col==n-1?1:prevRow[col];
      }

    return prevRow[n - 1];
  }

  // initial easy version, good for explaining th prob as well..
  // O(mn), O(mn)
  public int UniquePaths_v1(int m, int n) {
    // Allocation and initialization
    int[][] pathCount = new int[m][];
    for (int i = 0; i < m; i++) {
      pathCount[i] = new int[n];
      // first column can be reached in one way
      pathCount[i][0] = 1;
    }

    // first row can be reached in one way: going from left to right
    for (int i = 0; i < n; i++)
      pathCount[0][i] = 1;

    // DP
    for (int row = 1; row < m; row++)
      for (int col = 1; col < n; col++)
        // sum of how many we can go the upper cell and left side cell
        pathCount[row][col] = pathCount[row - 1][col] + pathCount[row][col - 1];

    return pathCount[m - 1][n - 1];
  }
}

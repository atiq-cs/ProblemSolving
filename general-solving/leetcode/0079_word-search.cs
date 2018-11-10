/***************************************************************************************************
* Title : Word Search
* URL   : word-search
* Date  : 2018-10-27
* Author: Atiq Rahman
* Comp  : O(N*M)
* Status: Accepted
* Notes : 
* ref   : 
* rel   : 
* meta  : tag-graph-dfs, tag-backtracking
***************************************************************************************************/
public class Solution
{
  char[][] board;
  string word;
  int numRows, numCols;
  bool[][] visited;

  public bool Exist(char[,] mdBoard, string word) {
    // at 'utils.cs'
    this.board = ConvertMultiDimensionalToJagged <char>( mdBoard );
    this.word = word;
    visited = new bool[numRows][];
    for (int i = 0; i < numRows; i++)
      visited[i] = new bool[numCols];

    for (int i = 0; i < numRows; i++)
      for (int j = 0; j < numCols; j++)
        if (DFS(i, j, 0))
          return true;
    return false;
  }

  // DFS without Visited list: what's this ?
  private bool DFS(int r, int c, int index) {
    if (r < 0 || c < 0 || r >= numRows || c >= numCols || visited[r][c] || board[r][c] !=
        word[index])
      return false;
    if (index == word.Length - 1)
      return true;
    visited[r][c] = true;
    if (DFS(r - 1, c, index + 1) || DFS(r, c - 1, index + 1) || DFS(r + 1, c, index + 1) ||
        DFS(r, c + 1, index + 1))
      return true;
    visited[r][c] = false;
    return false;
  }
}

/***************************************************************************************************
* Title : N-Queens
* URL   : https://leetcode.com/problems/n-queens/
* Date  : 2019-02-02
* Occasn: leetcode meetup remote 229 Polaris Ave, Mtn View
* Comp  : O(n^n * n^2), O(n^2) & space for result List
* Status: Accepted
* Notes : Time Comp Analysis,
*   n^n for recursive back tracking for n number of queens
*   n^2 is to check validity of a board each time before assigning a queen in a cell
*   
*   inspired a bit by the solution in link below. I thought this kind of naive implementation
*   without optimization would get TLE for the hard categorized problem.
*   
*   Attack from same row or column is easy to encounter. For diagonal attacks it obeys following
*   math assuming we have two queens (r1, c1) and (r2, c2)
*     |r1-r2| = |c1-c2|
*     
*   reference link takes care of diagonal attacks in following way,
*    r1 + c2 == c1 + r2 || r1 + c1 == r2 + c2
*
* ref   : https://leetcode.com/problems/n-queens/discuss/19805/My-easy-understanding-Java-Solution/231156
* Ack   : jasondai1991 for explaining those conditions
* meta  : tag-recursion, tag-backtracking, tag-leetcode-hard
***************************************************************************************************/
using System;
using System.Collections.Generic;

public class Solution {
  IList<IList<string>> boardList;
  char[][] board;
  int numRows, numCols;

  public IList<IList<string>> SolveNQueens(int n) {
    Init();
    NaiveNQueens();
    return boardList;
  }

  private void NaiveNQueens(int row = 0) {
    if (row == numRows) {
      // found a solution, hence, construct new board, add the board to result list
      boardList.Add(constructNewBoard());
      return;
    }

    for (int col = 0; col < numCols; col++)
      if (validateBoard(row, col)) {
        board[row][col] = 'Q';
        NaiveNQueens(row + 1);
        board[row][col] = '.';
      }
  }
  
  // can be improved to 4N by only checking row, col and two diagonals
  private bool validateBoard(int newRow, int newCol) {
    for (int row = 0; row < numRows; row++)
      for (int col = 0; col < numCols; col++)
        if (board[row][col] == 'Q' && (col == newCol || row + newCol == col + newRow || row + col == newRow + newCol))
          return false;

    return true;
  }

  private void Init() {
    boardList = new List<IList<string>>();
    numRows = numCols = n;

    // Initialize Board
    board = new char[numRows][];
    for (int r = 0; r < numRows; r++) {
      board[r] = new char[numCols];

      for (int c = 0; c < numCols; c++)
        board[r][c] = '.';
    }
  }

  private IList<string> constructNewBoard() {
    IList<string> newBoard = new List<string>(numRows);
    for (int r = 0; r < numRows; r++)
      newBoard.Add(new string(board[r]));
    return newBoard;
  }
}

// Test with a driver Main method
class Driver {
  private static void Main() {
    Solution demo = new Solution();
    demo.SolveNQueens(4);   // default example in the problem desc
  }
}

/*
See ack above, previously I did it this way.
Turns out row check is not necessary

  private bool validateBoard(int newRow, int newCol) {
    for (int row = 0; row < numRows; row++)
      for (int col = 0; col < numCols; col++)
        if (board[row][col] == 'Q' && (row == newRow || col == newCol || Math.Abs(row - newRow) ==
          Math.Abs(col - newCol)))
          return false;

    return true;
  }

*/
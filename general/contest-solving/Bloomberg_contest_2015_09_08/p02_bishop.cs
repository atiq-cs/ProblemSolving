/***************************************************************************************************
* Title : Bishop, Problem B
* URL   : http://codecon.bloomberg.com/problemDetails/CONTEST/84/Stony%20Brook%20CodeCon/1426/2015-
*   09-18T22:45:00.000Z
* Date  : 2015-09-18
* Comp  : O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Puzzle like math
*   8x8 Chessboard, determine number of moves required for the bishop to reach destination from
*   target, chessoboard number starts from 1 and ends at 64
*   How to solve: first map the number to row, column indices. Afterwards, apply conditions on
*   those row, column pairs
* meta  : tag-math
***************************************************************************************************/
using System;
using System.Collections.Generic;

namespace Bloomberg_contest_2015_09_08
{
  class ChessCell {
    public int row = 0;
    public int col = 0;
    public ChessCell(int a, int b) { row = a; col = b; }
  }

  class Program
  {
    static public void Main()
    {
      int source = int.Parse(Console.ReadLine());   // price of chocolate
      int dest = int.Parse(Console.ReadLine());   // number of wrapers per chocolate

      ChessCell source_cc = GetChessMapping(source);
      ChessCell dest_cc = GetChessMapping(dest);

      Console.WriteLine(GetMovesCount(source_cc, dest_cc));
    }
    static ChessCell GetChessMapping(int n) {
      return new ChessCell((n -1) / 8, (n-1)%8);
    }

    static int GetMovesCount(ChessCell s, ChessCell d) {
      if (s.row == d.row && s.col== d.col)
        return 0;
      // white can't reach black and black can't white
      if ((s.row + s.col) % 2 != (d.row + d.col) % 2)
        return -1;
      // d1
      if (d.row - s.row == d.col - s.col)
        return 1;
      // d2
      if (d.row - s.row == s.col-d.col)
        return 1;
      return 2;
    }
  }
}

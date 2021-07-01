/***************************************************************************************************
* Title : Bot saves princess
* URL   : https://www.hackerrank.com/challenges/saveprincess
* Date  : 2015-10-01
* Comp  : O()
* Author: Atiq Rahman
* Status: Accepted
* Notes : 2015 but not sure what date
* meta  : tag-ai
***************************************************************************************************/

using System;
using System.Collections.Generic;

struct Position2d {
  public int row;
  public int col;
  public Position2d(int a, int b) { row = a; col = b; }
}

class Solution {
  static Position2d GetAgentPosition(string[] grid, char target) {
    for (int i=0; i<grid.Length; i++)
      for (int j=0; j<grid.Length; j++)
        if (grid[i][j] == target)
          return new Position2d(i, j);
    return new Position2d(0, 0);
  }
  
  static void GenerateMoves(Position2d botPosition, Position2d pPosition) {
    string strMove = "UP";
    int numMoves = Math.Abs(pPosition.row - botPosition.row);
    if (botPosition.row < pPosition.row)
      strMove = "DOWN";
    for (int i=0;i<numMoves; i++)
      Console.WriteLine(strMove);
    
    strMove = "LEFT";
    numMoves = Math.Abs(pPosition.col - botPosition.col);
    if (botPosition.col < pPosition.col)
      strMove = "RIGHT";
    for (int i=0;i<numMoves; i++)
      Console.WriteLine(strMove);
  }
  
  static void displayPathToPrincess(int n, string [] grid){
    // find bot position
    Position2d botPosition = GetAgentPosition(grid, 'm');
    //Console.WriteLine("Found bot position: {0}{1}", botPosition.row, botPosition.col);
    // find princess position
    Position2d pPosition = GetAgentPosition(grid, 'p');
    
    GenerateMoves(botPosition, pPosition);
  }
  
  static void Main(String[] args) {
    int m;

    m = int.Parse(Console.ReadLine());

    String[] grid  = new String[m];
    for(int i=0; i < m; i++) {
      grid[i] = Console.ReadLine(); 
    }

    displayPathToPrincess(m, grid);
   }
}

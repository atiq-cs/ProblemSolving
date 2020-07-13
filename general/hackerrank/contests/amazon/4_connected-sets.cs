/***************************************************************************
* Title : Connected Sets
* URL   : https://www.hackerrank.com/contests/amazon/challenges/connected-sets
* Contst: amazon
* Date  : 2018-02-28
* Author: Atiq Rahman
* Comp  : O(n * n), space O(n*n) can be eliminated if we modify original array
* Status: Accepted
* Notes : Goal: Find number of Connected Sets
*   Two points are connected if they are adjacent
*   - horizontal
*   - vertical
*   - diagonally
*   Similar max area of island
* meta  : tag-easy, tag-graph-dfs
***************************************************************************/
using System;

public class Graph {
  private bool[][] grid;
  private int n;  // square: n = m
  private int forestSize;
  private int maxForestSize;
  private bool[][] visited;

  public int CountDFSForests() {
    visited = new bool[n][];
    for (int i=0; i<n; i++)
      visited[i] = new bool[m];

    int count = 0;
    for (int i=0; i<n; i++)
      for (int j=0; j<n; j++) {
        if (visited[i][j]==false) {
          DFS(i, j);
          count++;
        }
      }
    return count;
  }

  private void DFSVisit(int r, int c) {
    if (r < 0 || c<0 || r>=n || c>=n || visited[r][c] || grid[r][c])
      return ;
    visited[r][c] = true;
    DFS(r-1, c-1);
    DFS(r-1, c);
    DFS(r-1, c+1);
    DFS(r, c-1);
    DFS(r, c+1);
    DFS(r+1, c-1);
    DFS(r+1, c);
    DFS(r+1, c+1);
  }

  public void TakeInput() {
    n = int.Parse(Console.ReadLine());
    for (int i = 0; i < n; i++) {
      string[] tokens = Console.ReadLine().Split();
      for (int j = 0; j < n; j++)
        grid[i][j] = int.Parse(tokens[j]) == 0 ? true : false;
    }
  }
}

public class HKSolution {
  public static void Main() {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      Graph demo = new Graph();
      demo.TakeInput();
      Console.WriteLine(demo.CountDFSForests());
    }
  }
}

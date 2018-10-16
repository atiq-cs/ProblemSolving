/***************************************************************************
* Title : Minimum Knight moves
* URL   : https://www.spoj.com/problems/NAKANJ/
* Occasn: JS meetup 2018-06-25
* Date  : 2018-06-26
* Author: Atiq Rahman
* Comp  : O(V+E)
* Status: Accepted
* Notes : BoardLength is used to generalize and to support boards of different
*   sizes
* meta  : tag-graph-bfs, tag-sssp
***************************************************************************/
using System;
using System.Collections.Generic;

public class SSSPUtil {
  const int BoardLength = 8;
  const int BoardSize = BoardLength * BoardLength;

  // BFS defined at 'algo/Graph/01_BFS.cs'

  private List<int> GetAdjList(int u) {
    var adjList = new List<int>();
    int r = u / BoardLength, c = u % BoardLength;
    int x;
    if ((x = ComputeIndex(r - 2, c - 1)) != -1)
      adjList.Add(x);
    if ((x = ComputeIndex(r - 2, c + 1)) != -1)
      adjList.Add(x);
    if ((x = ComputeIndex(r - 1, c - 2)) != -1)
      adjList.Add(x);
    if ((x = ComputeIndex(r - 1, c + 2)) != -1)
      adjList.Add(x);
    if ((x = ComputeIndex(r + 1, c - 2)) != -1)
      adjList.Add(x);
    if ((x = ComputeIndex(r + 1, c + 2)) != -1)
      adjList.Add(x);
    if ((x = ComputeIndex(r + 2, c - 1)) != -1)
      adjList.Add(x);
    if ((x = ComputeIndex(r + 2, c + 1)) != -1)
      adjList.Add(x);
    return adjList;
  }

  /* GetAdjList v0
   * Wrong idea
  private List<int> GetAdjList(int u) {
    int[] offsets = new int[] { 6, 10, 15, 17 };
    foreach (int x in offsets) {
      if (u - x >= 0)
        adjList.Add(u-x);
      if (u + x < BoardSize)
        adjList.Add(u + x);
    }
  }*/

  private int ComputeIndex(int r, int c) {
    if (r < 0 || r >= BoardLength || c < 0 || c >= BoardLength)
      return -1;
    return BoardLength * r + c;
  }

  public void Run() {
    int T = int.Parse(Console.ReadLine());
    for (int i = 0; i < T; i++) {
      string[] tokens = Console.ReadLine().Split();
      int source = GetChessBoardMapping(tokens[0]);
      int dest = GetChessBoardMapping(tokens[1]);
      Console.WriteLine(BFS(source, dest));
    }
  }

  private int GetChessBoardMapping(string v) {
    int r = v[1] - '0' - 1;
    int c = v[0] - 'a';
    return r * BoardLength + c;
  }
}

public class SPOJSOlution {
  public static void Main() {
    SSSPUtil demo = new SSSPUtil();
    demo.Run();
  }
}

/*
5
a1 h8
a1 c2
h8 c3
a1 a1
a1 e1
*/

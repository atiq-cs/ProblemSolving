/***************************************************************************
* Title : Red Knight's Shortest Path
* URL   : hackerrank.com/contests/world-codesprint-12/challenges/
*   red-knights-shortest-path
* Occasn: JS meetup 2018-06-25
* Date  : 2018-06-27
* Author: Atiq Rahman
* Comp  : O(V+E)
* Status: Accepted
* Notes : Regarding GetDirection
*   for validating computation using offsets are okay. However, to generate
*   adjacency list using offsets (numbers: usual mapping: BoardLength * r + c)
*   it is not a good idea to use offsets rows andcolumns have to be checked
* meta  : tag-graph-bfs, tag-sssp
***************************************************************************/
using System;
using System.Collections.Generic;

public class SSSPUtil {
  int BoardLength;
  int BoardSize;
  int source;
  int[] pre;

  // BFS defined at 'algo/Graph/01_BFS.cs'

  // usually knight has 8 moves, this problem modifies that rule removes 4 and
  // adds two additional two moves
  // for traditional knight moves have a look at
  private List<int> GetAdjList(int u) {
    var adjList = new List<int>();
    int r = u / BoardLength, c = u % BoardLength;
    int x;
    if ((x = ComputeIndex(r - 2, c - 1)) != -1)
      adjList.Add(x);
    if ((x = ComputeIndex(r - 2, c + 1)) != -1)
      adjList.Add(x);
    if ((x = ComputeIndex(r, c - 2)) != -1)
      adjList.Add(x);
    if ((x = ComputeIndex(r, c + 2)) != -1)
      adjList.Add(x);
    // required reordering like this for this problem
    // i.e., input: 7
    // 0 3 4 3
    // so that LR is evaluated first before trying LL to find a shortest path
    if ((x = ComputeIndex(r + 2, c + 1)) != -1)
      adjList.Add(x);
    if ((x = ComputeIndex(r + 2, c - 1)) != -1)
      adjList.Add(x);
    return adjList;
  }

  // ComputeIndex() is defined at 'spoj/12323_NAKANJ.cs'

  private void GetPath(int v) {
    if (v == source || v==-1)
      return;
    GetPath(pre[v]);
    Console.Write(GetDirection(pre[v], v) + " ");
  }

  // v = current vertex, p is parent vertex
  private string GetDirection(int p, int v) {
    int r = p - v;
    if (r == 2)
      return "L";
    else if (-r == 2)
      return "R";
    else if (r == BoardLength * 2 - 1)
      return "UR";
    else if (-r == BoardLength * 2 - 1)
      return "LL";
    else if (r == BoardLength * 2 + 1)
      return "UL";
    else if (-r == BoardLength * 2 + 1)
      return "LR";
    else
      return "Invalid";
  }

  public void Run() {
    BoardLength = int.Parse(Console.ReadLine());
    BoardSize = BoardLength * BoardLength;
    string[] tokens = Console.ReadLine().Split();
    source = int.Parse(tokens[0]) * BoardLength + int.Parse(tokens[1]);
    int dest = int.Parse(tokens[2]) * BoardLength + int.Parse(tokens[3]);
    int numHops = BFS(dest);
    if (numHops == -1)
      Console.WriteLine("Impossible");
    else {
      Console.WriteLine(numHops);
      GetPath(dest);
      Console.WriteLine();
    }
  }
}

public class SPOJSOlution {
  public static void Main() {
    SSSPUtil demo = new SSSPUtil();
    demo.Run();
  }
}

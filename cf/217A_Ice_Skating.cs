/***************************************************************************
* Title : Ice Skating
* URL   : http://codeforces.com/problemset/problem/217/A
* Contst: Codeforces Round #134 (Div. 1)
* Date  : 2017-12-19
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : First time understanding the problem,
*   Given snow drifts (points) find minimum number of snow drifts need to be
*   created so all snow drifts are reachable. A snow drift is reachable from
*   other if their x-coordinate or y-coordinate values are equal.
*
*   Final impression,
*   Given graph count dfs forests.
*   
*   Why this matches to counting DFS forest problem?
*   Following Q&A might help answering that.
*   Is it possible that one point can join more than two points/snow drifts?
*   No. Proof is left for exercise.
*
*   A minimal DFS implementation
*
*   System.Drawing is allowed in codeforces
* meta  : tag-graph-dfs, tag-easy
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;

public class GraphDemo {
  bool[] IsVisited;
  // Array of List
  List<int>[] AdjList;
  int nV;

  public void Build(Point[] points) {
    nV = points.Length;
    AdjList = new List<int>[nV];
    IsVisited = new bool[nV];
    for (int i = 0; i < nV; i++)
      AdjList[i] = new List<int>();

    // Build adjacency list from given points
    for (int u = 0; u < nV; u++) {
      for (int v = 0; v < nV; v++)
        // if x-coordinate or y-coordinate is equal
        if (u != v && points[u].X == points[v].X || points[u].Y == points[v].Y)
        {
          AdjList[u].Add(v);
          // AdjList[v].Add(u);   // not required for this problem
        }
    }
  }

  public int CountDFSForests() {
    int count = 0;
    for (int v = 0; v < nV; v++)
      if (IsVisited[v] == false) {
        DFSVisit(v);
        count++;
      }
    return count;
  }

  private void DFSVisit(int u) {
    IsVisited[u] = true;
    foreach (int v in AdjList[u])
      if (IsVisited[v] == false)
        DFSVisit(v);
  }
}

public class CFSolution {
  private static Point[] TakeInput() {
    int numSnowDrift = int.Parse(Console.ReadLine());
    Point[] snowDrifts = new Point[numSnowDrift];
    for (int i = 0; i < numSnowDrift; i++) {
      string[] tokens = Console.ReadLine().Split();
      snowDrifts[i].X = int.Parse(tokens[0]);
      snowDrifts[i].Y = int.Parse(tokens[1]);
    }
    return snowDrifts;
  }

  public static void Main() {
    GraphDemo graph_demo = new GraphDemo();
    graph_demo.Build(TakeInput());
    Console.WriteLine(graph_demo.CountDFSForests()-1);
  }
}

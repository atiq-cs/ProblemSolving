/***************************************************************************************************
* Title : Longtail Hedgehog
* URL   : http://codeforces.com/contest/615/problem/B
* Date  : 2016-01-12
* Notes : Linear DP with DFS
* Comp  : O(V+E)
* Author: Atiq Rahman
* Status: Accepted
* Notes : This solution uses a variation of DP; can also be solved using DFS.
*   A simple solution such as this one has been possible because of the relaxation, mentioned in
*   C.L.R.S 3rd condition,
*   "The numbers of points from the beginning of the tail to the end should strictly increase."
*   
*   First time, when we have a look at that condition we might interpret as number(count) of points
*   from beginning to end. However, that is not the case. Numbers here means assigned integer to
*   each vertex.
*   
*   For example, tail of the mentioned hedgedog in example, is 1, 2 and 5.
*   
*   No visit list: there is no cycle, this is tree graph.
*   
*   In simple words, the problem boils down to following, find the maximum number that can be
*   produced by multiplying degree of the vertex in the graph with max length of shortest path from
*   this vertex to other vertices.
*   
* Ack   : Mak Kader
* meta  : tag-algo-dp, tag-graph-dfs
***************************************************************************************************/
using System;
using System.Collections.Generic;

public class Solution {
  private static void Main() {
    GraphDemo graph_demo = new GraphDemo();
    graph_demo.TakeInput();
    Console.WriteLine(graph_demo.fun_dp());
  }
}

public class GraphDemo {
  int[] degreeCount;
  long[] maxDist;
  // Array of List
  List<int>[] AdjList;
  int nV;

  public void TakeInput() {
    string[] tokens = Console.ReadLine().Split();
    nV = int.Parse(tokens[0]);
    int nE = int.Parse(tokens[1]);
    degreeCount = new int[nV];
    maxDist = new long[nV];
    AdjList = new List<int>[nV];
    for (int i = 0; i < nV; i++)
      AdjList[i] = new List<int>();

    // Build adjacency list and count degree
    for (int i = 0; i < nE; i++) {
      tokens = Console.ReadLine().Split();
      int u = int.Parse(tokens[0])-1;
      int v = int.Parse(tokens[1])-1;
      if (u == v)
        continue;
      degreeCount[u]++;
      degreeCount[v]++;
      if (u > v)
        AdjList[u].Add(v);
      else
        AdjList[v].Add(u);
    }
  }

  public long fun_dp() {
    // calculate max distance that can be travelled  a vertex 
    // assigned integer for the vertices are increasing for the tail
    // so works well
    //   maxDist[0] = 0
    for (int v = 1; v < nV; v++)
      foreach (int u in AdjList[v])
        if (maxDist[v] < maxDist[u] + 1)
          maxDist[v] = maxDist[u] + 1;

    long maxOutcome = 0;
    for (int v = 0; v < nV; v++)
      maxOutcome = Math.Max(maxOutcome, (maxDist[v] + 1) * degreeCount[v]);
    return maxOutcome;
  }
}

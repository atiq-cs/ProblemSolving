/***************************************************************************
* Title : Find shortest path from Source to Destination
* URL   :
* Date  : 2018-06-27 (update)
* Author: Atiq Rahman
* Comp  : O(V+E)
* Status: Demo
* Notes : BFS v1
*   Finds shortest path distance from source to dest, doesn't use additional
*   distance array.
*   Uses isVisited array (no distance array), level variable to maintain level
*   One item is never enqueued twice.
*   pre is the array used to keep track of ancestors.
*   source is a class member used by GetPath
*   
* meta  : tag-graph, tag-dfs, tag-recursion
***************************************************************************/
using System;
using System.Collections.Generic;

public class SSSP { // SSSP - Single Source Shortest Path
  // bfs v1, used in
  //  spoj/12323_NAKANJ.cs
  //  world-codesprint-12_red-knights-shortest-path.cs
  private int BFS(int dest) {
    if (source == dest) return 0;
    int level = 1;
    bool[] isVisited = new bool[BoardSize];
    var queue = new Queue<int>(new[] { source, -1 });
    isVisited[source] = true;
    pre = new int[BoardSize];
    for (int i = 0; i < BoardSize; i++)
      pre[i] = -1;

    while (queue.Count > 0) {
      int u = queue.Dequeue();
      if (u == -1) {
        level++;
        if (queue.Count == 0)
          break;
        queue.Enqueue(-1);
      }
      else {
        foreach (int v in GetAdjList(u))
          if (isVisited[v] == false) {
            pre[v] = u;
            if (v == dest) return level;
            queue.Enqueue(v);
            isVisited[v] = true;
          }
      }
    }
    return -1;
  }

  // This version developed for gatecoin coding test
  // 'algo/Graph/gatecoin_1_BFS_SP_demo.cs'
  // uses distance array
  private void BFS() {
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(Source);
    int[] d = new int[nV];
    d[0] = 0;
    for (int i = 1; i < nV; i++)
      d[i] = INF;

    while (queue.Count > 0) {
      int u = queue.Dequeue();
      foreach (int v in AdjList[u])
        if (d[v] > d[u] + 1) {
          pre[v] = u;
          d[v] = d[u] + 1;
          queue.Enqueue(v);
        }
      }
  }

  // 'algo/Graph/gatecoin_1_BFS_SP_demo.cs' also impelmentes one of this where
  // node list in the path is returned using a List
  private void GetPath(int v) {
    if (v == source || v==-1)
      return;
    GetPath(pre[v]);
    // GetDirection is at
    // 'hackerrank/contests/world-codesprint-12_red-knights-shortest-path.cs'
    Console.Write(GetDirection(pre[v], v) + " ");
  }
}

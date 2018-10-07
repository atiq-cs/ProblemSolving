/***************************************************************************
* Title : Dijkstra: Shortest Reach 2
* URL   : https://www.hackerrank.com/challenges/dijkstrashortreach
* Date  : 2017-12-30
* Author: Atiq Rahman
* Comp  : O(V^2 + E lg V) verify
* Status: TLE on Test Case #7
* Notes : Adj Matrix
*   at 'demos/ds/PriorityQueue_v1.cs'
* Rel   : http://spoj.com/problems/TRVCOST/
* meta  : tag-stack, tag-balance-expression
***************************************************************************/
using System;
using System.Collections.Generic;

public class Vertex : PriorityQueueElement {
  public int i;
  public uint d;
  // public int p; // parent member is not necessary for dijkstra

  public Vertex(int i, uint d) { this.i = i; this.d = d; }
  // public int GetIndex() { return i; }
  public uint GetValue() { return d; }
}

public class Dijkstra {
  // does not use color, uses distance to track visited vertices instead
  // enum COLOR { WHITE, GRAY, BLACK };
  // COLOR[] color;
  Vertex[] Vertices;
  // List<int>[] AdjList;
  uint[][] AdjMatrix;
  int nE;
  int nV;
  int Source;
  const uint INF = uint.MaxValue;

  public void TakeInput() {
    string[] tokens = Console.ReadLine().Split();
    nV = Convert.ToInt32(tokens[0]);
    nE = Convert.ToInt32(tokens[1]);
    Vertices = new Vertex[nV];
    AdjMatrix = new uint[nV][];
    for (int i = 0; i < nV; i++)
      AdjMatrix[i] = new uint[nV];

    for (int i = 0; i < nE; i++) {
      tokens = Console.ReadLine().Split();
      int u = int.Parse(tokens[0])-1;
      int v = int.Parse(tokens[1])-1;
      uint c = uint.Parse(tokens[2]);
      if (AdjMatrix[u][v] == 0 || AdjMatrix[u][v] > c)
        AdjMatrix[u][v] = AdjMatrix[v][u] = c;
    }

    Source = int.Parse(Console.ReadLine())-1;
  }

  public void Run() {
    // Initialize for Single Source Shortest Path Algorithm
    for (int i = 0; i < nV; i++)
      Vertices[i] = new Vertex(i, INF);
    Vertices[Source].d = 0;
    // end of init_sssp

    PriorityQueue<Vertex> queue = new PriorityQueue<Vertex>();
    queue.Enqueue(Vertices[Source]);

    while (queue.Count > 0) {
      Vertex u = queue.Dequeue();

      if (u.d != INF) {
        for (int i = 0; i < nV; i++) {
          Vertex v = Vertices[i];
          uint w = AdjMatrix[u.i][v.i];
          // adjacent means entry on adj mat != 0; 0 because of initialization
          if (u != v && w != 0) {
            // relax all v using u
            if (v.d > u.d + w) {
              v.d = u.d + w;
              // replace with decrease key
              queue.Enqueue(v);
            }
          }
        }
      }
    }
  }

  public void ShowResult() {
    for (int v=0; v<nV; v++)
      if (v != Source)
        Console.Write((Vertices[v].d == INF? -1: (int)Vertices[v].d) + " ");

    Console.WriteLine();
  }
}

class HK_Solution {
  public static void Main() {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      Dijkstra grahpDemo = new Dijkstra();
      grahpDemo.TakeInput();
      grahpDemo.Run();
      grahpDemo.ShowResult();
    }
  }
}

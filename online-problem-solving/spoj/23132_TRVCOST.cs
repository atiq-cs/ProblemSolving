/***************************************************************************
* Title : Travelling cost
* URL   : http://spoj.com/problems/TRVCOST/
* Date  : 2017-12-24 (C# Conversion from cpp)
* Author: Atiq Rahman
* Comp  : O(V+E)
* Status: Accepted (submission# 20890794)
* Notes : For previous implementation and documentation/remarks/explanation
*   please have a look at 'spoj/23132_TRVCOST.cpp'
*   
*   For more info, please have a look in this source file. More explanation is in
*   comments inline inside code blocks. This is rather simplified implementation.
*   
*   Input limits,
*    1<=N<=500
*    0<=A,B<=500
*    1<=W<=100
*    0<=U,V<=500
*    1<=Q<=500
*
*   Considering input constraints,
*   - Implemented using adjacency matrix and it worked great.
*   - Judge only has a single set of input
*   
*   Want DecreaseKey?
*   https://stackoverflow.com/questions/17009056
*   https://courses.csail.mit.edu/6.006/fall10/handouts/recitation10-8.pdf
* meta  : tag-graph-dijkstra, tag-sssp
***************************************************************************/
using System;
using System.Collections.Generic;

/*
 * Due to generic class implementation of 'PriorityQueue' it cannot access
 * members of the passed type. To reach an agreement with the class what
 * members must exist inside the type use following interface to inherit
 * specify should exist members inside the interface.
 * 
 * Access to index is not required to the 'PriorityQueue' class. so removed,
 *  int GetIndex();
 *  
 * GetValue() provides the priority for the priority queue items
 * enables access to distance member to 'PriorityQueue' class so that the
 * class can do comparison based on distance and keep the heap arranged
 * accordingly
 *
interface PriorityQueueElement {
  uint GetValue();
}*/

public class Edge {
  public int u;
  public int v;
  public uint c;
  public Edge(int u, int v, uint c) { this.u = u; this.v = v; this.c = c; }
}

public class Vertex {
  // don't use i for space efficiency
  // public int i;
  public uint d;
  // public int p; // parent member is not necessary for dijkstra

  public Vertex(/*int i,*/ uint d) { /*this.i = i;*/ this.d = d; }
  // public uint GetValue() { return d; }
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
  int[] DestinationVertices;
  const uint INF = uint.MaxValue;

  public Dijkstra() {
    nV = 0;
  }

  public void TakeInput() {
    nE = int.Parse(Console.ReadLine());
    Edge[] edges = new Edge[nE];

    // input edge list, temporary just because number of vertices is not given
    // we are finding this by looking at vertex index in all the edges
    for (int i = 0; i < nE; i++) {
      string[] tokens = Console.ReadLine().Split();
      edges[i] = new Edge(int.Parse(tokens[0]), int.Parse(tokens[1]), uint.
        Parse(tokens[2]));
      /* loop check not necessary
      if (edges[i].u == edges[i].v)
        continue; */
      // index starts from 0. Therefore, vertex count is 1 + last index
      nV = Math.Max(nV, Math.Max(edges[i].u, edges[i].v) + 1);
    }

    Vertices = new Vertex[nV];
    // AdjList = new List<int>[nV];
    AdjMatrix = new uint[nV][];
    Source = int.Parse(Console.ReadLine());

    // Initialize for Single Source Shortest Path algo
    for (int i = 0; i < nV; i++) {
      Vertices[i] = new Vertex(INF);
      // AdjList[i] = new List<int>();
      AdjMatrix[i] = new uint[nV];
      // initializing cost in adjacency matrix is not required
      /* for (int j = 0; j < nV; j++)
        AdjMatrix[i][j] = INF;*/
    }
    Vertices[Source].d = 0;
    // end of init_sssp

    int NumQueries = int.Parse(Console.ReadLine());
    DestinationVertices = new int[NumQueries];
    for (int i = 0; i < NumQueries; i++)
      DestinationVertices[i] = int.Parse(Console.ReadLine());

    // conversion from edge list to edges
    foreach (Edge edge in edges) {
      AdjMatrix[edge.u][edge.v] = AdjMatrix[edge.v][edge.u] = edge.c;
    }
  }

  public void Run() {
    PriorityQueue queue = new PriorityQueue(Vertices);
    queue.Enqueue(Source);

    while (queue.Count > 0) {
      int u = queue.Dequeue();

      if (Vertices[u].d != INF) {
        for (int v = 0; v < nV; v++) {
          uint w = AdjMatrix[u][v];
          // adjacent means entry on adj mat != 0; 0 because of initialization
          if (u != v && w != 0) {
            // relax all v using u
            if (Vertices[v].d > Vertices[u].d + w) {
              Vertices[v].d = Vertices[u].d + w;
              // replace with decrease key
              queue.Enqueue(v);
            }
          }
        }
      }
    }
  }

  private int GetPathCost(int v) {
    if (v >= nV || Vertices[v].d == INF)
      return -1;
    // takes care of u == v as well
    return  (int) Vertices[v].d;
  }

  public void ShowResult() {
    foreach(int v in DestinationVertices) {
      int cost = GetPathCost(v);
      Console.WriteLine(cost == -1 ? "NO PATH": cost.ToString());
    }
  }
}

public class SPOJSOlution {
  private static void Main() {
    Dijkstra grahpDemo = new Dijkstra();
    grahpDemo.TakeInput();
    grahpDemo.Run();
    grahpDemo.ShowResult();
  }
}

/*
Helpful input,
20
10 11 11
2 3 5
2 6 3
2 1 4
2 4 2
5 2 3
4 6 2
3 4 6
3 4 6
2 3 5
3 4 6
6 4 5
1 2 4
1 3 8
1 4 1
1 4 4
4 2 3
3 4 2
2 4 1
3 4 2
3
8
8
6
2
4
5
1
3
4
*/

/***************************************************************************
* Title : Find shortest path from Source to Destination
* URL   :
* Date  : 2018-02-23
* Author: Atiq Rahman
* Comp  : O(V+E)
* Status: Demo
* Notes : comments inline, input sample at bottom
* meta  : tag-graph-dfs, tag-recursion, tag-company-gatecoin, tag-coding-test
***************************************************************************/
using System;
using System.Collections.Generic;

public class GraphDemo {
  // We are using Adjacency List instead of adjacency matrix to save space
  // for sparse graphs (average case)
  List<int>[] AdjList;
  // keep track of nodes in the path being visited
  List<int> Path;
  int[] pre;
  int nV;   // number of Vertices
  int nE;   // number of Edges
  int Source;
  int Destination;
  int INF = int.MaxValue - 1;

  public void TakeInput() {
    Console.WriteLine("Please enter number of vertices in the graph:");
    nV = int.Parse(Console.ReadLine());
    if (nV < 1)
      throw new ArgumentException();

    // Initialization from this point as we know number of vertices
    Path = new List<int>();
    AdjList = new List<int>[nV];
    pre = new int[nV];    // track of ancestors
    for (int i = 0; i < nV; i++) {
      AdjList[i] = new List<int>();
      pre[i] = -1;
    }

    // Build adjacency list from given points
    Console.WriteLine("Please enter number of edges:");
    nE = int.Parse(Console.ReadLine());
    if (nV < 0)
      throw new ArgumentException();

    Console.WriteLine("Please enter {0} of edges, one edge per line \"u v\" " +
      "where 1 <= u <= {1} and 1 <= v <= {1}", nE, nV);

    string[] tokens = null;
    for (int i=0; i<nE; i++)  {
      tokens = Console.ReadLine().Split();
      int u = int.Parse(tokens[0]) - 1;
      int v = int.Parse(tokens[1]) - 1;
      if (u < 0 || u >= nV || v < 0 || v >= nV)
        throw new ArgumentException();
      AdjList[u].Add(v);
      AdjList[v].Add(u);
    }
    Console.WriteLine("Please provide source and destination:");
    tokens = Console.ReadLine().Split();
    Source = int.Parse(tokens[0]) - 1;
    Destination = int.Parse(tokens[1]) - 1;
    if (Source < 0 || Source >= nV || Destination < 0 || Destination >= nV)
      throw new ArgumentException();
  }

  private void PrintPath() {
    PrintPathRec(Destination);
    if (Path.Count == 0)
      Console.WriteLine("Shortest Path from {0} to {1} does not exist!", Source+1, Destination + 1);
    else
      Console.WriteLine("Shortest Path from {0} to {1}:", Source + 1, Destination + 1);

    for (int i = 0; i < Path.Count; i++)
      if (i==0)
        Console.Write(" {0}", Path[i] + 1);
      else
        Console.Write(" -> {0}", Path[i]+1);
    Console.WriteLine();
  }

  /* Recursively find each node in the path */
  private void PrintPathRec(int u) {
      if (u == -1)
        return;
      PrintPathRec(pre[u]);
      Path.Add(u);
  }

  public void ShowResult() {
    BFS();
    PrintPath();
  }
}

class Program {
  static void Main(string[] args) {
    GraphDemo graph_demo = new GraphDemo();
    graph_demo.TakeInput();
    graph_demo.ShowResult();
  }
}

/*
Input format,
------------------
number of vertices
number of edges
edge 1
edge 2
...
..
edge n
source destination
---------------------

For better understanding of the input specification please check below examples

The input for the example graph in the problem is below,
Example 1: A to H
8
11
1 2
1 3
1 4
2 3
2 5
2 6
3 6
4 7
5 7
6 7
7 8
Some source to destination examples can be,
1 8
1 7
1 6
*/

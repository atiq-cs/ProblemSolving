/***************************************************************************
* Title : Find all possible paths from Source to Destination
* URL   :
* Date  : 2018-02-23
* Author: Atiq Rahman
* Comp  : O(V+E)
* Status: Demo
* Notes : comments inline, input sample at '01_BFS_SP.cs'
* meta  : tag-graph-dfs, tag-recursion, tag-company-gatecoin, tag-coding-test, tag-algo-core
***************************************************************************/
using System;
using System.Collections.Generic;

public class GraphDemo {
  bool[] IsVisited;
  // We are using Adjacency List instead of adjacency matrix to save space,
  // for sparse graphs which is average case
  List<int>[] AdjList;
  // Nodes in the path being visited so far
  int[] Path;
  // Number of nodes so far encountered during the visit
  int PathHopCount;
  int PathCount = 0;
  // Number of Vertices in the graph
  int nV;
  // Number of Edges
  int nE;
  int Source;
  int Destination;

  /*
    * Takes input
    * Build adjacency list graph representation
    * Does input validation
    */
  public void TakeInput() {
    Console.WriteLine("Please enter number of vertices in the graph:");
    nV = int.Parse(Console.ReadLine());
    if (nV < 1)
      throw new ArgumentException();

    // As number of vertices is know at this point,
    // Initialize (another way to do is to move this block to constructor)
    Path = new int[nV];
    PathHopCount = 0;
    PathCount = 0;
    AdjList = new List<int>[nV];
    // by default C# compiler sets values in array to false
    IsVisited = new bool[nV];
    for (int i = 0; i < nV; i++)
      AdjList[i] = new List<int>();

    // Build adjacency list from given points
    Console.WriteLine("Please enter number of edges:");
    nE = int.Parse(Console.ReadLine());
    if (nE < 0)
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
    // reuse tokens variable, if it were reducing readability we would a new
    // variable
    tokens = Console.ReadLine().Split();
    Source = int.Parse(tokens[0]) - 1;
    Destination = int.Parse(tokens[1]) - 1;
    if (Source < 0 || Source >= nV || Destination < 0 || Destination >= nV)
      throw new ArgumentException();
  }

  /*
  * Depth first search algorithm to find path from source to destination
  * for the node of the graph passed as argument
  * 1. We check if it's destination node (we avoid cycle)
  * 2. If not then if the node is not visited in the same path then we visit
  *    its adjacent nodes
  * To allow visiting same node in a different path we set visited to false
  * for the node when we backtrack to a different path
  * 
  * We store the visited paths for the node in Path variable and keep count
  * of nodes in the path using variable PathHopCount. Path variable is
  * reused for finding other paths.
  * 
  * If we want to return list of all paths we can use a list of list to store
  * all of them from this variable
  */
  private void DFSVisit(int u) {
    IsVisited[u] = true;
    Path[PathHopCount++] = u;

    if (u == Destination)
      PrintPath();
    else
      foreach (int v in AdjList[u])
        if (IsVisited[v] == false)
          DFSVisit(v);

    PathHopCount--;
    IsVisited[u] = false;
  }

  /*
  * Simply print nodes from array Path
  * PathCount increments every time a new path is found.
  */
  private void PrintPath() {
    Console.WriteLine("Path {0}:", ++PathCount);
    for (int i = 0; i < PathHopCount; i++)
      if (i==0)
        Console.Write(" {0}", Path[i] + 1);
      else
        Console.Write(" -> {0}", Path[i]+1);
    Console.WriteLine();
  }

  public void ShowResult() {
    Console.WriteLine("Listing paths from {0} to {1}.", Source+1, Destination+1);
    DFSVisit(Source);
  }
}

class Program {
  static void Main(string[] args) {
    GraphDemo graph_demo = new GraphDemo();
    graph_demo.TakeInput();
    graph_demo.ShowResult();
  }
}

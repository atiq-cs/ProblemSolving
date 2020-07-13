/***************************************************************************************************
* Title : Breadth First Search: Shortest Reach
* URL   : https://www.hackerrank.com/challenges/bfsshortreach
* Date  : 2015-09-15
* Notes : use BFS to find distance of each node, then multiply by 6; a trivial problem
* Comp  : O(V+E)
* Author: Atiq Rahman
* Status: Accepted
* Notes : use BFS to find distance of each node, then multiply by 6; a trivial problem
*   Minimal Graph Representation
*   Another implementation of C.L.R.S style BFS
* ref   : Algorithms/Graph/01_BFS.cpp
* meta  : tag-graph-bfs
***************************************************************************************************/
using System;
using System.Collections.Generic;

enum Color { White, Gray, Black };

/* if we use struct we cannot modify records in the list as structures are immutable types */
class Vertex {
  public int distance;
  // int predecessor; // not necessary for now
  public Color color;
  public Vertex(int d, Color c) { distance = d; color = c; }  // constructor
}

class Graph {
  int nV;
  int nE;
  List<Vertex> vertex;    // List is not linked list, it is like vector
  List<List<int>> AdjList;

  // all initializations here
  public Graph(int n, int m) {
    nV = n; nE = m;
    vertex = new List<Vertex>(nV);
    AdjList = new List<List<int>>(nV);

    for (int i = 0; i < nV; i++) {
      // even though an argument has been passed to constructor with initial size,
      // unlike C++ container List is empty
      vertex.Add(new Vertex(-1, Color.White));
      AdjList.Add(new List<int>());
    }
  }

  public void AddEdge(int u, int v) {
    AdjList[u].Add(v);
    AdjList[v].Add(u);
  }

  public int GetDistance(int index) {
    if (vertex[index].distance == -1)
      return vertex[index].distance;
    else /* this is only for this problem */
      return vertex[index].distance * 6;
  }

  /*  This implementation follows Intro to Algorithms, C.L.R.S
   *  We can remove the color by checking if distance of just 
   *  discoved node is INF,
   *  We can even ignore setting the color to GRAY, it will give us same result
   *  In that case we only need 1 bit to store color 
   */
  public void bfs(int s) {
    vertex[s].distance = 0;

    Queue<int> queue = new Queue<int>();
    queue.Enqueue(s);

    while (queue.Count > 0) {
      int u = queue.Dequeue();
      foreach (int v in AdjList[u]){
        if (vertex[v].color == Color.White)
        {   // never visited before
          vertex[v].color = Color.Gray;
          vertex[v].distance = vertex[u].distance + 1;
          queue.Enqueue(v);
        }
      }
      vertex[u].color = Color.Black;          // visited the node and all of its adjacents
    }
  }
}

class Solution {
  static void Main(String[] args) {
    // Let's handle IO
    int T = int.Parse(Console.ReadLine());

    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      int nV = int.Parse(tokens[0]);    // number of vertices
      int nE = int.Parse(tokens[1]);    // number of edges
      Graph graph = new Graph(nV, nE);
      // input edges
      for (int i = 0; i < nE; i++) {
        tokens = Console.ReadLine().Split();
        int u = int.Parse(tokens[0]);    // number of vertices
        int v = int.Parse(tokens[1]);    // number of edges

        graph.AddEdge(u - 1, v - 1);       // 1 based index, adjust
      }
      int source = int.Parse(Console.ReadLine());
      source--;
      // run bfs
      graph.bfs(source);
      for (int i = 0; i < nV; i++) {
        if (i != source) {
          if (i == nV - 1)
            Console.WriteLine(graph.GetDistance(i));
          else
            Console.Write(graph.GetDistance(i) + " ");
        }
      }
    }
  }
}

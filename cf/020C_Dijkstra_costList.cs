/***************************************************************************
* Title : Dijkstra?
* URL   : http://codeforces.com/contest/20/problem/C
* Contst: Codeforces Alpha Round #20 
* Date  : 2017-12-30
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Memory Limit Exceeded
* Notes : This is the implementation after solving Hackerrank Dijkstra short
*   Reach 2 problem.
*   However, getting MLE on test 31, n = 100,000 m = 99,999
*   Adjacency matrix replaced with adjacency list of vertex class which also
*   keeps the cost
*   
*   This however cannot take cair of mutliple edges between a pair of vertices
*   and keeps duplicate
*   This has been improved in '020C_Dijkstra_DecreaseKey_CostTuple.cs'
* meta  : tag-graph-dijkstra
***************************************************************************/
using System;
using System.Collections.Generic;

/*
 * Due to generic class implementation of 'PriorityQueue' it cannot access
 * members of the passed type. To reach an agreement with the class what
 * members must exist inside the type use following interface to inherit
 * specify should exist members inside the interface
 */
interface PriorityQueueElement {
  // Access to index is not required to the 'PriorityQueue' class
  // int GetIndex();
  /* 
   * enables access to distance member to 'PriorityQueue' class so that the
   * class can do comparison based on distance and keep the heap arranged
   * accordingly
   */
  uint GetValue();
}

class PriorityQueue<T> where T : PriorityQueueElement {
  protected List<T> Arr;
  protected int Size;

  public PriorityQueue() {
    Arr = new List<T>();
    Size = 0;
  }

  protected int GetParent(int i) { return (i - 1) / 2; }
  protected int GetLeftChild(int i) { return 2 * i + 1; }
  protected int GetRightChild(int i) { return 2 * i + 2; }

  // getter only property
  public int Count { get { return Size; } }

  public T Peek() {
    if (Size == 0)
      throw new InvalidOperationException("MinHeap is empty!");
    return Arr[0];
  }

  protected void Swap(int i, int j) {
    T tmp = Arr[i];
    Arr[i] = Arr[j];
    Arr[j] = tmp;
  }

  public void Enqueue(T item) {
    if (Size < Arr.Count)
      Arr[Size] = item;
    else
      Arr.Add(item);
    int i = Size++;
    // Similar to Decrease Key
    while (i > 0 && Arr[GetParent(i)].GetValue() > Arr[i].GetValue()) {
      Swap(i, GetParent(i));
      i = GetParent(i);
    }
  }

  protected void Heapify(int i) {
    int l = GetLeftChild(i);
    int r = GetRightChild(i);
    int smallest = i;
    if (l < Size && Arr[l].GetValue() < Arr[smallest].GetValue())
      smallest = l;
    if (r < Size && Arr[r].GetValue() < Arr[smallest].GetValue())
      smallest = r;
    if (smallest != i) {
      Swap(smallest, i);
      Heapify(smallest);
    }
  }

  public T Dequeue() {
    if (Size == 0)
      throw new InvalidOperationException("MinHeap underflow!");
    T max = Arr[0];
    Arr[0] = Arr[--Size];
    Heapify(0);
    return max;
  }
}

public class Vertex:PriorityQueueElement {
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
  List<Vertex>[] AdjList;
  List<int> ShortestPath;
  // uint[][] AdjMatrix;
  int[] parent;
  int nE;
  int nV;
  int Source;
  const uint INF = uint.MaxValue;

  public void TakeInput() {
    string[] tokens = Console.ReadLine().Split();
    nV = Convert.ToInt32(tokens[0]);
    nE = Convert.ToInt32(tokens[1]);
    Vertices = new Vertex[nV];
    AdjList = new List<Vertex>[nV];
    // AdjMatrix = new uint[nV][];
    for (int i = 0; i < nV; i++) {
      // AdjMatrix[i] = new uint[nV];
      AdjList[i] = new List<Vertex>();
    }
    parent = new int[nV];

    for (int i = 0; i < nE; i++) {
      tokens = Console.ReadLine().Split();
      int u = int.Parse(tokens[0]) - 1;
      int v = int.Parse(tokens[1]) - 1;
      uint c = uint.Parse(tokens[2]);
      //if (AdjMatrix[u][v] == 0 || AdjMatrix[u][v] > c)
      // AdjMatrix[u][v] = AdjMatrix[v][u] = c;
      // AdjList[u].Add(v); AdjList[v].Add(u);
      // if (u > v) { int t = u; u = v; v = t; }
      // avoid self loops
      if (u != v) {
        AdjList[u].Add(new Vertex(v, c));
        AdjList[v].Add(new Vertex(u, c));
      }
    }

    Source = 0;
  }

  public void Run() {
    // Initialize for Single Source Shortest Path Algorithm
    for (int i = 0; i < nV; i++) {
      Vertices[i] = new Vertex(i, INF);
      parent[i] = -1;
    }
    Vertices[Source].d = 0;
    // end of init_sssp

    PriorityQueue<Vertex> queue = new PriorityQueue<Vertex>();
    queue.Enqueue(Vertices[Source]);

    while (queue.Count > 0) {
      Vertex u = queue.Dequeue();

      if (u.d != INF) {
        foreach (Vertex va in AdjList[u.i]) {
          Vertex v = Vertices[va.i];
          uint w = va.d;
          if (u != v) {
            // relax all v using u
            if (v.d > u.d + w) {
              v.d = u.d + w;
              parent[v.i] = u.i;
              // replace with decrease key
              queue.Enqueue(v);
            }
          }
        }
      }
    }
  }

  void PrintPath(int v) {
    if (v == -1)
      return;
    PrintPath(parent[v]);
    ShortestPath.Add(v + 1);
  }

  public void ShowResult() {
    // last vertex
    int v = nV - 1;
    if (v != Source && Vertices[v].d == INF) {
      Console.WriteLine("-1");
      return;
    }

    ShortestPath = new List<int>();
    PrintPath(v);
    Console.WriteLine(string.Join(" ", ShortestPath));
  }
}

class CFSolution {
  public static void Main() {
    Dijkstra grahpDemo = new Dijkstra();
    grahpDemo.TakeInput();
    grahpDemo.Run();
    grahpDemo.ShowResult();
  }
}

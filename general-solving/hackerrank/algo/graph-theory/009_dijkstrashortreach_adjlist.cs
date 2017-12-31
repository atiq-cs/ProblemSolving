/***************************************************************************
* Title : Dijkstra: Shortest Reach 2
* URL   : https://www.hackerrank.com/challenges/dijkstrashortreach
* Date  : 2017-12-30
* Author: Atiq Rahman
* Comp  : O(V + E lg V) verify
* Status: TLE on Test Case #7
* Notes : Adj List
* Rel   : http://spoj.com/problems/TRVCOST/
* meta  : tag-dijkstra, tag-graph-theory
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

class PriorityQueue <T> where T:PriorityQueueElement {
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
    if (r< Size && Arr[r].GetValue() < Arr[smallest].GetValue())
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
  List<int>[] AdjList;
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
    AdjList = new List<int>[nV];
    AdjMatrix = new uint[nV][];
    for (int i = 0; i < nV; i++) {
      AdjMatrix[i] = new uint[nV];
      AdjList[i] = new List<int>();
    }

    for (int i = 0; i < nE; i++) {
      tokens = Console.ReadLine().Split();
      int u = int.Parse(tokens[0])-1;
      int v = int.Parse(tokens[1])-1;
      uint c = uint.Parse(tokens[2]);
      if (AdjMatrix[u][v] == 0 || AdjMatrix[u][v] > c)
        AdjMatrix[u][v] = AdjMatrix[v][u] = c;
      AdjList[u].Add(v); AdjList[v].Add(u);
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
        foreach(int i in AdjList[u.i]) {
        //for (int i = 0; i < nV; i++) {
          Vertex v = Vertices[i];
          uint w = AdjMatrix[u.i][v.i];
          if (u != v) {
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

  /* Still not fast enough for I/O */ 
  public int[] GetResult() {
    int[] costs = new int[nV-1];
    for (int v=0, i=0; v<nV; v++)
      if (v != Source)
        costs[i++] = Vertices[v].d == INF? -1: (int)Vertices[v].d;
    return costs;
  }

  /* public void ShowResult() {
    for (int v=0; v<nV; v++)
      if (v != Source)
        Console.Write((Vertices[v].d == INF? -1: (int)Vertices[v].d) + " ");

    Console.WriteLine();
  }*/
}

class HK_Solution {
  public static void Main() {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      Dijkstra grahpDemo = new Dijkstra();
      grahpDemo.TakeInput();
      grahpDemo.Run();
      Console.WriteLine(string.Join(" ", grahpDemo.GetResult()));
    }
  }
}

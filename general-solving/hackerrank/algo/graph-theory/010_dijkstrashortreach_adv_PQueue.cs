﻿/***************************************************************************
* Title : Dijkstra: Shortest Reach 2
* URL   : https://www.hackerrank.com/challenges/dijkstrashortreach
* Date  : 2017-12-30
* Author: Atiq Rahman
* Comp  : O(V + E lg V) verify
* Status: TLE on Test Case #7
* Notes : Sophisticated Priority Queue
* Rel   : http://spoj.com/problems/TRVCOST/
* meta  : tag-dijkstra, tag-graph-theory
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

/*
 * Due to generic class implementation of 'PriorityQueue' it cannot access
 * members of the passed type. To reach an agreement with the class what
 * members must exist inside the type use following interface to inherit
 * specify should exist members inside the interface
 */
interface PriorityQueueElement {
  // Access to index is not required to the 'PriorityQueue' class
  int Index { get; }
  /* 
   * enables access to distance member to 'PriorityQueue' class so that the
   * class can do comparison based on distance and keep the heap arranged
   * accordingly
   */
  uint Value { get; set; }
}

class PriorityQueue <T> where T:PriorityQueueElement {
  protected List<T> Arr;
  protected int Size;
  Dictionary<int, int> map;

  public PriorityQueue() {
    Arr = new List<T>();
    Size = 0;
    map = new Dictionary<int, int>();
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
    // after swap fix indices
    map[Arr[i].Index] = i;
    map[Arr[j].Index] = j;
  }

  public void Enqueue(T item) {
    if (Size < Arr.Count)
      Arr[Size] = item;
    else
      Arr.Add(item);
    map.Add(item.Index, Size);
    BubbleUp(Size);  Size++;
  }

  protected void BubbleUp(int i) {
    while (i > 0 && Arr[GetParent(i)].Value > Arr[i].Value) {
      Swap(i, GetParent(i));
      i = GetParent(i);
    }
  }

  protected void Heapify(int i) {
    int l = GetLeftChild(i);
    int r = GetRightChild(i);
    int smallest = i;
    if (l < Size && Arr[l].Value < Arr[smallest].Value)
      smallest = l;
    if (r< Size && Arr[r].Value < Arr[smallest].Value)
      smallest = r;
    if (smallest != i) {
      Swap(smallest, i);
      Heapify(smallest);
    }
  }

  public T Dequeue() {    // ExtractMin
    if (Size == 0)
      throw new InvalidOperationException("MinHeap underflow!");
    T max = Arr[0];
    Arr[0] = Arr[--Size];
    map.Remove(max.Index);
    map[Arr[0].Index] = 0;
    Heapify(0);
    return max;
  }
  public void DecreaseKey(T item) {
    if (!map.ContainsKey(item.Index)) {
      Enqueue(item);
      return ;
    }
    int i = map[item.Index];
    if (Arr[i].Value > item.Value)
      Arr[i].Value = item.Value;
    BubbleUp(i);
  }
}

public class Vertex : PriorityQueueElement {
  public int i;
  public uint d;
  // public int p; // maintaining a seperate parent array instead

  public Vertex(int i, uint d) { this.i = i; this.d = d; }
  // getter only
  public int Index { get { return i; } }
  public uint Value { get { return d; } set { d = value; } }
}

public class Dijkstra {
  // does not use color, uses positive distance instead to relax and visit
  // enum COLOR { WHITE, GRAY, BLACK };
  // COLOR[] color;
  Vertex[] Vertices;
  List<int>[] AdjList;
  Dictionary<Tuple<int, int>, uint> CostMatrix;
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
    for (int i = 0; i < nV; i++)
      AdjList[i] = new List<int>();

    CostMatrix = new Dictionary<Tuple<int, int>, uint>();

    for (int i = 0; i < nE; i++) {
      tokens = Console.ReadLine().Split();
      int u = int.Parse(tokens[0])-1;
      int v = int.Parse(tokens[1])-1;
      uint c = uint.Parse(tokens[2]);
      // cost matrix only contains edges from smaller index to larger index
      if (u > v) { int t = u; u = v; v = t; }
      // avoid self loops
      if (u != v) {
        AdjList[u].Add(v);
        AdjList[v].Add(u);
      }
      Tuple<int, int> key = new Tuple<int, int>(u, v);
      if (CostMatrix.ContainsKey(key)) {
        if (CostMatrix[key] > c)
          CostMatrix[key] = c;
      }
      else
        CostMatrix.Add(key, c);
    }
    Source = int.Parse(Console.ReadLine()) - 1;
  }

  public void Run() {
    // Initialize for Single Source Shortest Path Algorithm
    for (int i = 0; i < nV; i++)
      Vertices[i] = new Vertex(i, INF);
    Vertices[Source].d = 0;
    // end of init_sssp

    PriorityQueue<Vertex> queue = new PriorityQueue<Vertex>();
    // Implementation from C.L.R pushes all vertices into the Queue
    //for (int i = 0; i < nV; i++)
      //queue.Enqueue(Vertices[i]);    
    queue.Enqueue(Vertices[Source]);    

    while (queue.Count > 0) {
      Vertex u = queue.Dequeue();

      if (u.d != INF) {
        foreach(int i in AdjList[u.i]) {
          Vertex v = Vertices[i];
          int ui = u.i;
          int vi = v.i;
          if (ui > vi) { int t = ui; ui = vi; vi = t; }
          uint w = CostMatrix[new Tuple<int, int>(ui, vi)];
          if (u != v) {
            // relax all v using u
            if (v.d > u.d + w) {
              v.d = u.d + w;
              // replace with decrease key
              // queue.Enqueue(v);
              queue.DecreaseKey(v);
            }
          }
        }
      }
    }
  }

  /* Still not fast enough for I/O */ 
  public void GetResult(StringBuilder sb) {
    for (int v=0; v<nV; v++)
      if (v != Source)
        sb.Append((Vertices[v].d == INF? "-1": Vertices[v].d.ToString()) + " ");
    sb.Append("\r\n");
  }
}

class CF_Solution {
  public static void Main() {
    StringBuilder Result = new StringBuilder();
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      Dijkstra grahpDemo = new Dijkstra();
      grahpDemo.TakeInput();
      grahpDemo.Run();
      grahpDemo.GetResult(Result);
      // Console.WriteLine(string.Join(" ", grahpDemo.GetResult()));
    }
    Console.Write(Result.ToString());
  }
}

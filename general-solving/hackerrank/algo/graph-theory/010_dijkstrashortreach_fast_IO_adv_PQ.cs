/***************************************************************************
* Title : Dijkstra: Shortest Reach 2
* URL   : https://www.hackerrank.com/challenges/dijkstrashortreach
* Date  : 2017-12-30
* Author: Atiq Rahman
* Comp  : O(V + E lg V) verify
* Status: Runtime Error (Wrong Answer)
* Notes : at 'demos/ds/PriorityQueue.cs', Fast IO
*   got past TLE now
* Rel   : http://spoj.com/problems/TRVCOST/
* meta  : tag-graph-dijkstra
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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

  public void TakeInput(string[] tokens) {
    nV = CFSolution.getNextNumber(tokens);
    nE = CFSolution.getNextNumber(tokens);
    Vertices = new Vertex[nV];
    AdjList = new List<int>[nV];
    for (int i = 0; i < nV; i++)
      AdjList[i] = new List<int>();

    CostMatrix = new Dictionary<Tuple<int, int>, uint>();

    for (int i = 0; i < nE; i++) {
      int u = CFSolution.getNextNumber(tokens) - 1;
      int v = CFSolution.getNextNumber(tokens) - 1;
      uint c = (uint) CFSolution.getNextNumber(tokens);
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
    Source = CFSolution.getNextNumber(tokens) - 1;
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

public class CFSolution {
  public static int tok_index;
  public static int getNextNumber(string[] tokens) {
    while (string.IsNullOrEmpty(tokens[++tok_index]));
    return int.Parse(tokens[tok_index]);
  }

  public static void Main() {
    StreamReader streamReader = new StreamReader(Console.OpenStandardInput());
    string[] tokens = streamReader.ReadToEnd().Split();
    tok_index = -1;

    StringBuilder Result = new StringBuilder();
    int T = getNextNumber(tokens);
    while (T-- > 0) {
      Dijkstra grahpDemo = new Dijkstra();
      grahpDemo.TakeInput(tokens);
      grahpDemo.Run();
      grahpDemo.GetResult(Result);
      // Console.WriteLine(string.Join(" ", grahpDemo.GetResult()));
    }
    Console.Write(Result.ToString());
  }
}

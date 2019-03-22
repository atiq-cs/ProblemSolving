/***************************************************************************
* Title : A Bug’s Life
* URL   : http://spoj.com/problems/BUGLIFE/
* Contst: 2007 PUJ - Circuito de Maratones ACIS / REDIS
* Date  : 2017-12-19
* Comp  : O(n)
* Status: Time Limit Exceeded
* Notes : This is same as '3377_BUGLIFE_dfs.cs' and,
*   Stack is replaced with Queue
* meta  : tag-graph-bfs, tag-easy
***************************************************************************/
using System;
using System.Collections.Generic;

public class DFSDemo {
  // Probably GRAY for Male and BLACK for Female
  internal enum COLOR { WHITE, GRAY, BLACK };

  internal class Vertex {
    public int Index { get; set; }
    public COLOR Color { get; set; }
    public Vertex(int v, COLOR c) { Index = v; Color = c; }
  }

  COLOR[] color;
  // Array of List
  List<int>[] AdjList;
  int nV;
  int[] p;

  public void TakeInput() {
    string[] tokens = Console.ReadLine().Split();
    nV = int.Parse(tokens[0]);
    int nE = int.Parse(tokens[1]);
    AdjList = new List<int>[nV];
    color = new COLOR[nV];
    p = new int[nV];

    for (int i = 0; i < nV; i++) {
      AdjList[i] = new List<int>();
      p[i] = -1;
    }

    // Build adjacency list
    for (int i = 0; i < nE; i++) {
      tokens = Console.ReadLine().Split();
      int u = int.Parse(tokens[0]) - 1;
      int v = int.Parse(tokens[1]) - 1;
      if (u == v)
        continue;
      AdjList[u].Add(v);
      AdjList[v].Add(u);
    }
  }

  private bool DFS() {
    Queue<Vertex> bugQueue = new Queue<Vertex>();

    for (int s = 0; s < nV; s++) {
      if (color[s] == COLOR.WHITE)
        bugQueue.Enqueue(new Vertex(s, COLOR.GRAY));

      while (bugQueue.Count > 0) {
        Vertex vertex = bugQueue.Dequeue();
        int u = vertex.Index;
        COLOR sex = vertex.Color;
        color[u] = sex;
        foreach (int v in AdjList[u])
          if (color[v] == COLOR.WHITE)
            bugQueue.Enqueue(new Vertex(v, sex == COLOR.GRAY ? COLOR.BLACK : COLOR.GRAY));
          // non-parent back edge
          else if (color[u] == color[v])
            return true;
      }
    }
    return false;
  }

  public void ShowResult(int t) {
    // DFS();
    Console.WriteLine("Scenario #{0}:\r\n{1}", t, DFS() ?
      "Suspicious bugs found!" : "No suspicious bugs found!");
  }
}

public class SPOJSOlution {
  private static void Main() {
    int T = int.Parse(Console.ReadLine());

    for (int i=1; i<=T; i++) {
      DFSDemo grahpDemo = new DFSDemo();
      grahpDemo.TakeInput();
      grahpDemo.ShowResult(i);
    }
  }
}

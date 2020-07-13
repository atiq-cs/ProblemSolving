/***************************************************************************
* Title : A Bug’s Life
* URL   : http://spoj.com/problems/BUGLIFE/
* Contst: 2007 PUJ - Circuito de Maratones ACIS / REDIS
* Date  : 2017-12-19
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Time Limit Exceeded
* Notes : Using stack instead of recursion to implement DFS
*   Uses Vertex class to store color
*   More details on '3377_BUGLIFE_recursion.cs'
* meta  : tag-graph-dfs, tag-easy
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
    Stack<Vertex> bugStack = new Stack<Vertex>();

    for (int s = 0; s < nV; s++) {
      if (color[s] == COLOR.WHITE)
        bugStack.Push(new Vertex(s, COLOR.GRAY));

      while (bugStack.Count > 0) {
        Vertex vertex = bugStack.Pop();
        int u = vertex.Index;
        COLOR sex = vertex.Color;
        color[u] = sex;
        foreach (int v in AdjList[u])
          if (color[v] == COLOR.WHITE)
            bugStack.Push(new Vertex(v, sex == COLOR.GRAY ? COLOR.BLACK : COLOR.GRAY));
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

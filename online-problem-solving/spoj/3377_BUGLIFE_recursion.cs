/***************************************************************************
* Title : A Bug’s Life
* URL   : http://spoj.com/problems/BUGLIFE/
* Contst: 2007 PUJ - Circuito de Maratones ACIS / REDIS
* Date  : 2017-12-19
* Author: Atiq Rahman
* Comp  : O(V+E)
* Status: Time Limit Exceeded
* Notes : What does the problem ask?
*   Homosexuality is the bug. Two bugs of opposite gender can mingle. However,
*   Two bugs of same gender cannot mingle! Input data does not specify the
*   gender of a bug. If X and Y mingle, Y and Z mingle then if X and Z are of
*   same gender. If an interaction is found between X and Z then we it's
*   suspicious.
*   
*   Use two colors to paint the vertices.
*   Colors have following meaning
*   White - Unexplored vertices
*   GRAY  - Male
*   BLACK - Female
*   
*   While doing DFS traversal during checking adjacent vertices check if the
*   vertex has same color with parent.
* meta  : tag-easy, tag-dfs, tag-recursion
***************************************************************************/
using System;
using System.Collections.Generic;

public class DFSDemo {
  enum COLOR { WHITE, GRAY, BLACK };

  COLOR[] color;
  // Array of List
  List<int>[] AdjList;
  int nV;
  int[] p;
  bool HasCycle = false;

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

  private void DFS() {
    for (int v = 0; v < nV; v++)
      if (color[v] == COLOR.WHITE) {
        DFSVisit(v, COLOR.GRAY);
      }
  }

  private void DFSVisit(int u, COLOR sex) {
    if (HasCycle)
      return;
    color[u] = sex;
    foreach (int v in AdjList[u])
      if (color[v] == COLOR.WHITE) {
        DFSVisit(v, sex == COLOR.GRAY? COLOR.BLACK : COLOR.GRAY);
      }
      // non-parent back edge
      else if (color[u] == color[v]) {
        HasCycle = true;
        return;
      }
  }

  public void ShowResult(int t) {
    DFS();
    Console.WriteLine("Scenario #{0}:\r\n{1}", t, HasCycle?
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

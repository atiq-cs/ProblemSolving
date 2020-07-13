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
*   Problem is mapped with bi-coloring. If bi-coloring is not possible then we
*   conclude as suspicious. Otherwise, not.
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

  public void TakeInput() {
    string[] tokens = Console.ReadLine().Split();
    nV = int.Parse(tokens[0]);
    int nE = int.Parse(tokens[1]);
    AdjList = new List<int>[nV];
    color = new COLOR[nV];

    for (int i = 0; i < nV; i++) {
      AdjList[i] = new List<int>();
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
    for (int v = 0; v < nV; v++)
      if (color[v] == COLOR.WHITE) {
        if (!DFSVisit(v, COLOR.GRAY))
          return false;
      }
    return true;
  }

  /* returns true if bi-coloring possible */
  private bool DFSVisit(int u, COLOR sex) {
    color[u] = sex;
    foreach (int v in AdjList[u])
      if (color[v] == COLOR.WHITE) {
        if (!DFSVisit(v, sex == COLOR.GRAY ? COLOR.BLACK : COLOR.GRAY))
          return false;
      }
      // colors matches - coloring not possible
      else if (color[u] == color[v])
        return false;
    return true;
  }

  public void ShowResult(int t) {
    Console.WriteLine("Scenario #{0}:\r\n{1}", t, DFS()?
      "No suspicious bugs found!" : "Suspicious bugs found!");
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

/*
 * mapp
 * 
Draft
bicoloring not possible: suspicious
1
3 3
1 2
2 3
1 3

bicoloring possible: not suspicious
1
4 2
1 2
3 4

possible
1
7 5
1 2
2 3
4 5
5 6
6 7

possible (group 1: 1,2,3 group 2: 4,5,6,7)
last edge connects the two groups
1
7 6
1 2
2 3
4 5
5 6
6 7
7 1

possible
1
7 6
1 2
2 3
4 5
5 6
6 7
7 4

not possible: suspicious
1
3 3
1 2
2 3
3 1

possible
1 2
2 3
3 4
4 1

however, following is not possible: suspicious
1
4 4
1 2
2 3
3 4
4 2

possible
1
7 6
1 2
2 3
4 5
5 6
6 7
7 4   
*/

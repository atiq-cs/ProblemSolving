/***************************************************************************************************
* Title : Kefa and Park
* URL   : http://codeforces.com/problemset/problem/580/C
* Occasn: Codeforces Round #321 (Div. 2)
* Date  : 2017-08-18
* Comp  : O(nlogn)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
* Notes : The graph is a tree. Assumption that this graph would work for unidirection (edge
*   addition: adding v to u's adj list when u < v) mapping is wrong. So we add u to v's adj list
*   and v to u's adj list. We maintain a visited list to avoild looping or duplicate visits to same
*   nodes.
*   This idea works because we have a fixed root node: vertex 1.
*   
* meta  : tag-graph-tree, tag-graph-dfs
***************************************************************************************************/
using System;
using System.Collections.Generic;

public class GraphDemo
{
  List<uint>[] AdjList;
  bool[] hasCat;
  bool[] visited;
  uint nV;
  uint m; // m for number of consecutive cats allowed

  public void TakeInput() {
    string[] tokens = Console.ReadLine().Split();
    nV = uint.Parse(tokens[0]);
    m = uint.Parse(tokens[1]);
    AdjList = new List<uint>[nV];
    hasCat = new bool[nV];
    visited = new bool[nV];
    tokens = Console.ReadLine().Split();
    for (int i = 0; i < nV; i++) {
      AdjList[i] = new List<uint>();
      hasCat[i] = (uint.Parse(tokens[i]) == 1) ? true : false;
    }

    for (int i = 0; i < nV-1; i++) {
      tokens = Console.ReadLine().Split();
      uint u = uint.Parse(tokens[0])-1;
      uint v = uint.Parse(tokens[1])-1;
      if (u != v) {
        AdjList[u].Add(v);
        AdjList[v].Add(u);
      }
    }
  }

  public ulong GetVisitableNodeCount(uint u=0, uint k=0) {
    visited[u] = true;

    if (hasCat[u])
      k++;
    else
      k = 0;

    if (k > m)
      return 0;

    ulong sum = 0;
    bool isLeafNode = true;

    foreach (uint v in AdjList[u])
      if (visited[v] == false) {
        if (isLeafNode)
          isLeafNode = false;
        sum += GetVisitableNodeCount(v, k);
      }

    return isLeafNode? 1:sum;
  }
}

public class CFSolution {
  private static void Main() {
    GraphDemo demo = new GraphDemo();
    demo.TakeInput();
    Console.WriteLine(demo.GetVisitableNodeCount());
  }
}

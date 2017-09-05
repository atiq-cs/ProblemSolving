/***************************************************************************
* Problem Name: Kefa and Park
* Problem URL : http://codeforces.com/problemset/problem/580/C
* Occasion    : Codeforces Round #321 (Div. 2)
* Date        : Aug 18 2017
* Complexity  : O(nlogn)
* Author      : Atiq Rahman
* Status      : Accepted
* Desc        :  
* Notes       : The graph is a tree. Assumption that this graph would work for
*               unidirection (edge addition: adding v to u's adj list when
*               u < v) mapping is wrong. So we add u to v's adj list and v
*               to u's adj list. We maintain a visited list to avoild looping
*               or duplicate visits to same nodes. This idea works because we
*               have a fixed root node: vertex 1.
*               
* meta        : tag-tree, tag-graph
***************************************************************************/
using System;
using System.Collections.Generic;

public class Solution {
  private static void Main() {
    GraphDemo graph_demo = new GraphDemo();
    graph_demo.TakeInput();
    Console.WriteLine(graph_demo.GetVisitableNodeCount());
  }
}

public class GraphDemo {
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
  public ulong GetVisitableNodeCount() {
    return GetVisitableNodeCountRec(0, 0);
  }
  private ulong GetVisitableNodeCountRec(uint u, uint k) {
    visited[u] = true;
    if (hasCat[u]) k++;
    else k = 0;
    if (k > m) return 0;
    ulong sum = 0;
    bool isLeafNode = true;
    foreach (uint v in AdjList[u])
      if (visited[v] == false) {
        if (isLeafNode) isLeafNode = false;
        sum += GetVisitableNodeCountRec(v, k);
      }
    if (isLeafNode) return 1;
    return sum;
  }
}

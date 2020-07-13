/***************************************************************************************************
* Title : Party
* URL   : http://codeforces.com/problemset/problem/115/A
* Occasn: Codeforces Beta Round #87 (Div. 1 Only)
* Date  : 2017-08-12
* Comp  : O(n) to traverse nodes
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
* Notes : Run time would increase asymptotically if there were cycles or
*   if it were hard to find the root nodes
*   Easy tree depth Problem
* meta  : tag-easy, tag-tree
***************************************************************************************************/
using System;
using System.Collections.Generic;

public class Solution {
  private static void Main() {
    GraphDemo graph_demo = new GraphDemo();
    graph_demo.TakeInput();
    Console.WriteLine(graph_demo.IterRootNodes());
  }
}

public class GraphDemo {
  List<uint>[] AdjList;
  List<uint> rootNodeList;
  int nV;

  public void TakeInput() {
    // input
    nV = int.Parse(Console.ReadLine());
    // Initialization based on number of nodes
    AdjList = new List<uint>[nV];
    for (int i = 0; i < nV; i++)
      AdjList[i] = new List<uint>();
    rootNodeList = new List<uint>();

    // rest of input
    for (uint v = 0; v < nV; v++) {
      int u = int.Parse(Console.ReadLine());
      if (u == -1)
        rootNodeList.Add(v);
      else
        AdjList[u-1].Add(v);
    }    
  }

  // iterate root nodes and find max depth
  public long IterRootNodes() {
    int max_depth = 0;
    foreach (uint v in rootNodeList)
      max_depth = Math.Max(max_depth, GetMaxDepth(v));
    return max_depth;
  }

  private int GetMaxDepth(uint u) {
    int max_depth = 1;
    foreach (uint v in AdjList[u])
      max_depth = Math.Max(max_depth, GetMaxDepth(v)+1);
    return max_depth;
  }
}

/*
 * Sample Input 1:
10
-1
-1
2
3
2
5
6
-1
8
9

* Sample Input 2:
2
2
-1

*/

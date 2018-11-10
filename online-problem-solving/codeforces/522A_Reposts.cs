/***************************************************************************************************
* Title : Reposts
* URL   : http://codeforces.com/problemset/problem/522/A
* Occasn: VK Cup 2015 - Qualification Round 1
* Date  : 2017-09-10
* Comp  : O(n) 42ms, O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : identical to the problem in 'rel'. However, it is not a binary tree. Instead it's a
*   general tree to construct and find max depth.
* rel   : 'leetcode/0104_maximum-depth-of-binary-tree.cs'
* meta  : tag-graph-tree, tag-graph-dfs, tag-algo-dp, tag-easy
***************************************************************************************************/
using System;
using System.Collections.Generic;

public class UniDTree
{
  List<List<int>> adjList;   // graph representation of choice
  int lastIndex;             // for values in name_table of keys
  HashSet<int> rootList;     // set of original posters/caandidate roots

  // Take the string pairs as input and construct a unidirectional tree
  // string info is not necessarily required to find max depth of the tree
  public void TakeInput() {
    int T = int.Parse(Console.ReadLine());
    // this table is not required once tree is constructed
    Dictionary<string, int> name_table = new Dictionary<string, int>();
    adjList = new List<List<int>>();
    rootList = new HashSet<int>();
    lastIndex = 0;

    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      int v = GetNameIndex(ref name_table, tokens[0].ToLower());
      int u = GetNameIndex(ref name_table, tokens[2].ToLower());
      adjList[u].Add(v);
      if (rootList.Contains(u) == false)
        rootList.Add(u);
    }
  }

  public int GetMaxDepth() {
    int maxDepth = 0;
    foreach (int v in rootList)
      maxDepth = Math.Max(maxDepth, GetMaxDepth(v));
    return maxDepth+1;
  }

  private int GetMaxDepth(int u) {
    if (adjList[u].Count == 0)
      return 0;
    int maxDepth = 0;
    foreach (int v in adjList[u])
      maxDepth = Math.Max(maxDepth, GetMaxDepth(v));
    return maxDepth + 1;
  }

  // For a new item,
  //  add it to the name table with index number
  //  Grow the adjacency list
  //  Update last index number
  private int GetNameIndex(ref Dictionary<string, int> nameTable, string key) {
    if (nameTable.ContainsKey(key))
      return nameTable[key];
    nameTable.Add(key, lastIndex++);
    adjList.Add(new List<int>());
    return lastIndex - 1;
  }
}

public class CFSolution {
  private static void Main() {
    UniDTree udt = new UniDTree();
    udt.TakeInput();
    Console.WriteLine(udt.GetMaxDepth());
  }
}

/* Sample Inputs
5
tourist reposted Polycarp
Petr reposted Tourist
WJMZBMR reposted Petr
sdya reposted wjmzbmr
vepifanov reposted sdya

3
tourist reposted Polycarp
Petr reposted Nova
Katy reposted Polycarp
*/

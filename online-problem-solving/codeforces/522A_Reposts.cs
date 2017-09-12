/***************************************************************************
* Title       : Reposts
* URL         : http://codeforces.com/problemset/problem/522/A
* Occasion    : VK Cup 2015 - Qualification Round 1
* Date        : Sep 10 2017
* Complexity  : O(n) 42ms, Space O(n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Goal,
*               Construct the tree
*               Find max depth
* Related     : leetcode/104_maximum-depth-of-binary-tree.cs
* meta        : tag-tree, tag-easy
***************************************************************************/
using System;
using System.Collections.Generic;

public class UniDTree {
  List<List<int>> adj_list;   // graph representation of choice
  int last_index;             // for values in name_table of keys
  HashSet<int> root_list;     // set of original posters/caandidate roots
  // Take the string pairs as input and construct a unidirectional tree
  // string info is not necessarily required to find max depth of the tree
  public void TakeInput() {
    int T = int.Parse(Console.ReadLine());
    // this table is not required once tree is constructed
    Dictionary<string, int> name_table = new Dictionary<string, int>();
    adj_list = new List<List<int>>();
    root_list = new HashSet<int>();
    last_index = 0;

    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      int v = GetNameIndex(ref name_table, tokens[0].ToLower());
      int u = GetNameIndex(ref name_table, tokens[2].ToLower());
      adj_list[u].Add(v);
      if (root_list.Contains(u) == false)
        root_list.Add(u);
    }
  }
  public int GetMaxDepth() {
    int maxDepth = 0;
    foreach (int v in root_list)
      maxDepth = Math.Max(maxDepth, GetMaxDepthRec(v));
    return maxDepth+1;
  }

  private int GetMaxDepthRec(int u) {
    if (adj_list[u].Count == 0)
      return 0;
    int maxDepth = 0;
    foreach (int v in adj_list[u])
      maxDepth = Math.Max(maxDepth, GetMaxDepthRec(v));
    return maxDepth + 1;
  }
  // For a new item,
  //  add it to the name table with index number
  //  Grow the adjacency list
  //  Update last index number
  private int GetNameIndex(ref Dictionary<string, int> name_table, string key) {
    if (name_table.ContainsKey(key))
      return name_table[key];
    name_table.Add(key, last_index++);
    adj_list.Add(new List<int>());
    return last_index - 1;
  }
}

public class CF_Solution {
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

/***************************************************************************************************
* Title : Disjoint Set Forests
* URL   : C.L.R.S
* Date  : 2019-03-19
* Author: Atiq Rahman
* Comp  : O(m α n) amortized for n makeSet and m Unions I am assuming
* Notes : Implements Union Find Algorithm using ranks heuristics and path compression
*   hence run time gets better
*
* ref   : C.L.R.S 3rd ed, Ch#21, p#571
* rel   : 'ds/dsf.cpp' & uva probs
*   leetcode#547
* meta  : tag-ds-dsf, tag-algo-union-find, tag-ds-core
***************************************************************************************************/
using System;

class DSF {
  int n;
  int[] sets;
  int[] ranks;
  // To keep track of total number of sets we have
  public int Count { get; private set; }
  int[] numChildren;

  public DSF(int n) {
    this.n = this.Count = n;
    sets = new int[n];
    ranks = new int[n];
    // this property is only necessary if we want to count members belonging to each group
    numChildren = new int[n];
    MakeSet();
  }

  void MakeSet() {
    for (int i = 0; i < n; i++) {
      sets[i] = i;
      numChildren[i] = 1;
      // ranks auto initialized
    }
  }

  public int FindSet(int i) {
    if (sets[i] == i)
      return i;
    else
      return FindSet(sets[i]);
  }

  public void Union(int x, int y) {
    if (x != y) {
      // merge happens..
      if (ranks[x] > ranks[y]) {
        sets[y] = x;
        numChildren[x] += numChildren[y];
      }
      else {
        sets[x] = y;
        numChildren[y] += numChildren[x];

        if (ranks[x] == ranks[y])
          ranks[y]++;
      }

      Count--;
    }
  }

  /// <summary>
  /// necessary only when count for largest group is necessary, use case: UVA problems
  /// </summary>
  /// <returns></returns>
  public int GetItemCountForLargestGroup() {
    // include linq
    return numChildren.Max();
  }
}

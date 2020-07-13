/***************************************************************************
* Title : Greg and Array
* URL   : https://codeforces.com/contest/296/problem/C
* Occasn: The Xth Urals Collegiate Programing Championship, March 24-25, 2006
* Date  : 2018-09-08
* Author: Atiq Rahman
* Comp  : O(m lg n) where m is number of operations
* Status: Accepted
* Notes : Utilizes two fenwick trees
*   1. one for queries (precomputes op count)
*   2. another to apply the queries on original result Fenwick Tree
*   
*   long int is required for storing results
* meta  : tag-tree, tag-fenwick-tree
***************************************************************************/
using System;
using System.Collections.Generic;

class Operation {
  public int l { get; set; }
  public int r { get; set; }
  public int d { get; set; }

  public Operation(int l, int r, int d)
  {
    this.l = l;
    this.r = r;
    this.d = d;
  }
}

// class FenwickTree is at 'ds/FenwickTree.cs'

public class FenwickTreeDemo {
  public void Run() {
    string[] tokens = Console.ReadLine().Split();
    int n = int.Parse(tokens[0]);
    int m = int.Parse(tokens[1]);
    int k = int.Parse(tokens[2]);

    tokens = Console.ReadLine().Split();

    FenwickTree result = new FenwickTree(n);
    // add initial values
    // nums = new int[n];
    for (int i = 0; i < n; i++) {
      // nums[i] = int.Parse(tokens[i]);
      int v = int.Parse(tokens[i]);
      result.Add(i + 1, v);   // BIT 1 based index
      result.Add(i + 2, -v);
    }
    // result.PrintArray();

    Operation[] ops = new Operation[m];
    for (int i = 0; i < m; i++) {
      tokens = Console.ReadLine().Split();
      if (tokens.Length != 3)
        throw new ArgumentException();
      ops[i] = new Operation(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]));
    }

    FenwickTree opCount = new FenwickTree(m);
    for (int i = 0; i < k; i++) {
      tokens = Console.ReadLine().Split();
      int l = int.Parse(tokens[0]);
      int r = int.Parse(tokens[1]);
      // do for whole tree
      opCount.Add(l, 1);
      // undo for r to n
      opCount.Add(r+1, -1);
    }

    // at this point, opCount contains info which operation should be applied
    // how many times

    // for each operation apply them opCount times
    for (int i = 0; i < m; i++) {
      long v = ops[i].d * opCount.Sum(i+1);
      result.Add(ops[i].l, v);
      result.Add(ops[i].r+1, -v);
    }
    // result.PrintArray();
    result.ShowResult();
  }
}

class CFSolution {
  static void Main(String[] args) {
    FenwickTreeDemo Demo = new FenwickTreeDemo();
    Demo.Run();
  }
}

/* Input that provided me clue on limits
Test case# 11
15968 30103 4266
...

Test case# 26
100000 100000 100000
*/

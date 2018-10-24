/***************************************************************************************************
* Title : New Year Transportation
* URL   : http://codeforces.com/problemset/problem/522/A
* Occasn: Good Bye 2014
* Date  : 2017-09-12
* Comp  : O(n), O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Do a linear loop and check if destination is reachable
* meta  : tag-graph-dfs, tag-algo-dp, tag-implementation, tag-easy
***************************************************************************************************/
using System;

// This could be represented easily with static functions inside Main class
public class LinearIteration {
  private int t;
  private int[] A;
  public void TakeInput() {
    string[] tokens = Console.ReadLine().Split();
    int N = int.Parse(tokens[0])-1;
    t = int.Parse(tokens[1])-1;
    A = new int[N];

    tokens = Console.ReadLine().Split();
    for (int i=0; i<N; i++)
      A[i] = int.Parse(tokens[i]);
  }

  // source = 0
  // destination = t
  public bool IsReachable() {
    int i = 0;    // source
    do i += A[i];
    while (i<t);
    if (i == t)
      return true;
    return false;
  }
}

public class CFSolution {
  private static void Main() {
    LinearIteration LG = new LinearIteration();
    LG.TakeInput();
    Console.WriteLine(LG.IsReachable()?"YES":"NO");
  }
}

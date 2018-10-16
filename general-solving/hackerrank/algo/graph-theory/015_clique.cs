/***************************************************************************
* Title : Clique
* URL   : https://www.hackerrank.com/challenges/clique/problem
* Date  : 2018-01
* Author: Atiq Rahman
* Comp  : O(.)
* Status: Accepted
* Notes : Find what is the minimum size of the largest clique in any graph with
*   N nodes and M edges.
*   C# version based on the second version
*   I have adapted the equation from,
*    https://en.wikipedia.org/wiki/Tur%C3%A1n_graph
*
* github solutions refs
* https://github.com/haotian-wu/Hackerrank_solutions/blob/master/
*  GraphTheory/clique.cpp
* https://github.com/zjsxzy/HackerRank/blob/master/Algorithms/Graph%20Theory/
*  Clique/main.cpp
* Dicussion has some good hints,
*   https://www.hackerrank.com/challenges/clique/forum
* meta  : tag-graph, tag-clique, tag-math, tag-company-cruise-automation, tag-coding-test
***************************************************************************/
using System;

class HK_Solution {
  private static int getCliqueSize(int n, int k) {
    int c_quotient = (int) Math.Ceiling((double) n / (double) k);
    int f_quotient = (int) Math.Floor((double) n / (double) k);
    int e = (n*n - (n%k) * c_quotient * c_quotient - (k - n % k) * f_quotient *
      f_quotient) / 2;
    return e;
  }

  public static void Main() {
    int T = int.Parse(Console.ReadLine());

    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      int N = int.Parse(tokens[0]);
      int M = int.Parse(tokens[1]);
      int lo = 1, hi = N + 1;
      while (lo + 1 < hi) {
        int mid = lo + (hi - lo) / 2;
        if (getCliqueSize(N, mid) < M)
          lo = mid+1;
        else
          hi = mid-1;
      }
      Console.WriteLine(hi);
    }
  }
}

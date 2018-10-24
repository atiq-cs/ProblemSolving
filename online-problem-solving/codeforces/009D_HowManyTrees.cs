/***************************************************************************************************
* Title : How many trees?
* URL   : http://codeforces.com/problemset/problem/9/D
* Occasn: Codeforces Beta Round #9 (Div. 2 Only)
* Date  : 2016-01-12
* Comp  : probably, N^2 * lg N
* Author: Atiq Rahman
* Status: Accepted
* Notes : Check note if we have draft, compare with other solutions if run
*   time can be improved or optimized
*   ToDo, analyze complexity
* meta  : tag-combinatorics, tag-algo-dp
***************************************************************************************************/
using System;

public class CFSolution
{
  public static void Main() {
    string[] tokens = Console.ReadLine().Split();
    int n = int.Parse(tokens[0]);
    int h = int.Parse(tokens[1]);
    Console.WriteLine(NumTrees(n)-NumTreesUptoHeight(n, h-1));
  }
  
  private static long NumTrees(int n) {
    long[] numWays = new long[n+1];
    // initialization; note on 0 nodes: above
    numWays[0] = 1;
    
    for (int target=1; target<=n; target++)
      for (int i=1; i<=target; i++)
        numWays[target] += numWays[i-1] * numWays[target-i];
    return numWays[n];
  }

  // minHN is minimum height in number of nodes from root to leaf
  private static long NumTreesUptoHeight(int n, int minHN) {
    long[][] numWays = new long[minHN+1][];
    for (int i = 0; i <= minHN; i++)
      numWays[i] = new long[n+1];  // to make the indexing mapped exactly to height, 0 is unused
    numWays[0][0] = 1;
    for (int i = 1; i <= n; i++)
      numWays[0][i] = 0;

    for (int h = 1; h <= minHN; h++) {
      numWays[h][0] = 1;
      for (int target = 1; target <= n; target++)
        for (int i = 1; i <= target; i++)
          numWays[h][target] += numWays[h - 1][i - 1] * numWays[h - 1][target - i];
    }
    return numWays[minHN][n];
  }
}

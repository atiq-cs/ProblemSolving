/***************************************************************************
* Title : Algorithm as utility for Longest Common Subsequence Problems
* URL   : C.L.R.S p394
* Date  : 2018-06-04
* Author: Atiq Rahman
* Comp  : O(m*n), O(m*n)
* Notes : tested with a few hackerrank problems
*   ToDo: space complexity can be reduced further, optimize further
*   2d array for directions can be eliminated. Also m*n states might not be
*   required. To compute only length we don't need that much space (array c).
* meta  : tag-lcs, tag-dp
***************************************************************************/
using System.Collections.Generic;

class SubseqAlgoDemo<T> {
  enum DIR { Up, Diag, Left };

  // variables/objects shared acrosss methods
  int[][] c;
  DIR[][] b;
  List<T> lcs;
  T[] seq1;

  public T[] LongestCommonSubsequence(T[] seq1, T[] seq2) {
    this.seq1 = seq1;
    int m = seq1.Length;
    int n = seq2.Length;

    // memory allocations
    c = new int[m+1][];
    b = new DIR[m+1][];
    lcs = new List<T>();

    // and initializations
    for (int i=0; i<=m; i++) {
      c[i] = new int[n+1];
      b[i] = new DIR[n+1];
      c[i][0] = 0;
    }
    for (int i=1; i<=n; i++)
      c[0][i] = 0;

    // LCS loops
    for (int i=0; i<m; i++)
      for (int j=0; j<n; j++)
        // couldn't figure out how to override '==' yet
        if (Comparer<T>.Default.Compare(seq1[i], seq2[j]) == 0) {
          c[i+1][j+1] = c[i][j] + 1;
          b[i+1][j+1] = DIR.Diag;
        }
        else if (c[i][j+1] >= c[i+1][j]) {
          c[i+1][j+1] = c[i][j+1];
          b[i+1][j+1] = DIR.Up;
        }
        else {
          c[i+1][j+1] = c[i+1][j];
          b[i+1][j+1] = DIR.Left;
        }

    // Get result subsequence
    PrintLCS(m, n);
    lcs.Reverse();
    return lcs.ToArray();
  }

  private void PrintLCS(int i, int j) {
    if (i==0 || j==0)
      return;
    if (b[i][j] == DIR.Diag) {
      lcs.Add(seq1[i-1]);
      PrintLCS(i-1, j-1);
    }
    else if (b[i][j] == DIR.Up)
      PrintLCS(i-1, j);
    else
      PrintLCS(i, j-1);
  }  
}

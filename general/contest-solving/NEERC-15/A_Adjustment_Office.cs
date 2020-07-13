/***************************************************************************************************
* Title : Adjustment Office
* URL   : http://codeforces.com/gym/100851/attachments/download/3961/\
*   20152016-acmicpc-northeastern-european-regional-contest-neerc-15-en.pdf
* Occasn: ACM ICPC 2015 NEERC
* Date  : 2016-01-22
* Comp  : O() Time
* Author: Atiq Rahman
* Status: Accepted (108ms)
* Occasn: 2015-2016 ACM-ICPC Northeastern European Regional Contest
* Notes : 
*   fill in ...
*   
*   Demonstrates use of StreamWriter for IO
*   
* meta  : tag-algo-dp
***************************************************************************************************/
using System;

public class MatQuerySolution {
  long n;
  bool[] row_set;
  bool[] col_set;
  long ColZeroSum;
  long RowZeroSum;
  long nColZero;
  long nRowZero;

  public MatQuerySolution(int nn) {
    n = nn;
    row_set = new bool[n];
    col_set = new bool[n];
  }

  public long RowQuery(long i) {
    if (row_set[i-1])
      return 0;
    long sum = GetPartialSeriesSum(i) - ColZeroSum - i * nColZero;
    RowZeroSum += i; nRowZero++; row_set[i-1] = true;
    return sum;
  }
  public long ColumnQuery(long i) {
    if (col_set[i-1])
      return 0;
    long sum = GetPartialSeriesSum(i) - RowZeroSum - i * nRowZero;
    ColZeroSum += i; nColZero++;  col_set[i-1] = true;
    return sum;
  }

  public long GetPartialSeriesSum(long t) {
    return n * (n + 2*t + 1) / 2;
  }
}

public class ICPCSolution {
  public static void Main() {
    System.IO.StreamReader inFile = new System.IO.StreamReader("adjustment.in");
    string[] tokens = inFile.ReadLine().Split();
    int n = int.Parse(tokens[0]);
    int q = int.Parse(tokens[1]);
    MatQuerySolution matSol = new MatQuerySolution(n);
    System.IO.StreamWriter outFile = new System.IO.StreamWriter("adjustment.out");

    for (int i = 0; i < q; i++) {
      tokens = inFile.ReadLine().Split();
      char p = char.Parse(tokens[0]);
      int t = int.Parse(tokens[1]);

      if (p == 'R')
        outFile.WriteLine(matSol.RowQuery(t));
      else if (p == 'C')
        outFile.WriteLine(matSol.ColumnQuery(t));
    }
    inFile.Close();
    outFile.Close();
  }
}

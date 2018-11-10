/***************************************************************************************************
* Title : Big Sorting
* URL   : https://www.hackerrank.com/challenges/big-sorting
* Date  : 2017-09-16
* Comp  : O(n lg n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : BigInteger Solution timed out
*   I noticed that the default sort: Array.Sort is quick sort
*   
*   Probably this problem expects a simple implementation being the
*   first problem in the list of sorting problems in hackerrank
*   For simplicity, we use Library's sort: Array.Sort
*   
*   Clever use of 'string.Join'
*   Learnt here how to specify a comparer function
*   Comparer ref, https://msdn.microsoft.com/en-us/library/cxt053xf.aspx
* rel   : Basic Sort.cs
* meta  : tag-algo-sort
***************************************************************************************************/
using System;

class HKSolution
{
  /* Case here: because there is no leading zero  */
  private static int CompareBigInteger(string x, string y) {
    if (x.Length == y.Length) {
      int i = 0;
      while ((i < x.Length - 1) && (x[i] == y[i])) i++;
      // this does same job as well
      //for (; (i<x.Length-1) && (x[i] == y[i]); i++);
      return x[i]-y[i];
    }
    return x.Length - y.Length;
  }

  static void Main(String[] args) {
    // take input
    int n = int.Parse(Console.ReadLine());
    string[] A = new string[n];
    for(int i=0; i<n; i++)
       A[i] = Console.ReadLine();
    // sort & print
    Array.Sort(A, CompareBigInteger);
    Console.WriteLine(string.Join("\r\n", A));
  }
}

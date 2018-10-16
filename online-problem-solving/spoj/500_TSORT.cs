/***************************************************************************
* Title       : Turbo Sort
* URL         : http://www.spoj.com/problems/TSORT/
* Date        : Sep 18, 2017
* Complexity  : O(n) here, n = 10^6
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Conclusion: Take care that I/O is fast then it gets easily
*               accepted
* meta        : tag-algo-sort
***************************************************************************/
using System;
using System.Text;    // for StringBuilder

// Second accepted version
public class Test {
  public static void Main() {
    // take input
    int n = int.Parse(Console.ReadLine());    
    const int LIMIT = 1000001;
    int[] C = new int[LIMIT];     // input int limit is 100

    // sort
    for (int i = 0; i < n; i++)
      C[int.Parse(Console.ReadLine())]++;

    // print
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < LIMIT; i++)
      if (C[i] > 0)
        for (int j = 0; j < C[i]; j++)
          sb.AppendLine(i.ToString());
    Console.Write(sb.ToString());
  }
}

// first accepted version
public class Test {
  public static void Main() {
    // take input
    int n = int.Parse(Console.ReadLine());
    int[] A = new int[n];
    for (int i=0; i<n; i++)
        A[i] = int.Parse(Console.ReadLine());    
    
    const int LIMIT = 1000001;
    int[] C = new int[LIMIT];     // input int limit is 100
    int[] B = new int[n];

    // sorting first part
    for (int i=0; i<n; i++)
      C[A[i]]++;
    for (int i=1; i<LIMIT; i++)
      C[i] +=  C[i-1];

    // stable sort: final step
    for (int i=n-1; i>=0; i--) {
        B[C[A[i]] - 1] = A[i];    // updated to support 0-based index
        C[A[i]]--;
    }
    Console.WriteLine(string.Join("\r\n", B));
  }
}

/* Sample input
2
1000000
2
*/

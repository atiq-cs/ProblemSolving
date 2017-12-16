/***************************************************************************
* Title       : The Full Counting Sort
* URL         : https://www.hackerrank.com/challenges/countingsort4
* Date        : Sep 17 2017
* Complexity  : O(n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Counting Sort page 194 CLR
* msdn ref    : https://docs.microsoft.com/en-us/dotnet/csharp/programming
*               -guide/classes-and-structs/using-structs
* meta        : tag-sort, tag-counting-sort
***************************************************************************/
using System;

/*
 * all public to save space and faster/simpler representation
 * not considering a requirement for encapsulation here
 * avoid this representation for next problem
 */
public struct Item {
  public int num;
  public string str;
  public Item(int n, string s) { num = n; str = s; }
}

class HK_Solution {
  static void Main(String[] args) {
    // take input
    int n = int.Parse(Console.ReadLine());
    Item[] A = new Item[n];

    for (int i=0; i<n; i++) {
      string[] tokens = Console.ReadLine().Split();
      A[i] = new Item(int.Parse(tokens[0]), (i<n/2)? "-" : tokens[1]);
    }
    
    const int LIMIT = 100;
    int[] C = new int[LIMIT];     // input int limit is 100
    Item[] B = new Item[n];

    // sorting first part
    for (int i=0; i<n; i++)
      C[A[i].num]++;
    for (int i=1; i<LIMIT; i++)
      C[i] +=  C[i-1];

    // stable sort: final step
    for (int i=n-1; i>=0; i--) {
      // The array C keeps continuous accumulation of the frequencies for each
      // element
      // For example, for the largest element in A[i], C[A[i]] will point to
      // the last index inside array B
      // if that largest element has multiple copies due to decrement of
      // C[A[i]] the index reduces by 1 to point to previous to last one
      B[C[A[i].num] - 1] = A[i];    // updated to support 0-based index
      C[A[i].num]--;
    }
    for (int i=0; i<n; i++)
      Console.Write(B[i].str + " ");
    Console.WriteLine();
  }
}

/* Thoughts draft
20
0 ab
6 cd
0 ef
6 gh
4 ij
0 ab
6 cd
0 ef
6 gh
0 ij
4 that
3 be
0 to
1 be
5 question
1 or
2 not
4 is
2 to
4 the

considered part for sorting
10
4 that
3 be
0 to
1 be
5 question
1 or
2 not
4 is
2 to
4 the

*/

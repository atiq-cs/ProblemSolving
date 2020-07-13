/***************************************************************************************************
* Title : The Full Counting Sort
* URL   : https://www.hackerrank.com/challenges/countingsort4
* Date  : 2017-09-17
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : C.L.R.S 3rd ed, p#194
* meta  : tag-algo-sort
***************************************************************************************************/
using System;
using System.Text;

class HKSolution
{
  static void Main(String[] args) {
    // take input
    int n = int.Parse(Console.ReadLine());
    Item[] A = new Item[n];

    for (int i=0; i<n; i++) {
      string[] tokens = Console.ReadLine().Split();
      A[i] = new Item(int.Parse(tokens[0]), (i<n/2)? "-" : tokens[1]);
    }

    var sortDemo = new Sorting();
    var B = sortDemo.CountingSort(A);
    StringBuilder sb = new StringBuilder();
    for (int i=0; i<n; i++)
      sb.Append(B[i].val + " ");
    Console.WriteLine(sb.ToString());
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

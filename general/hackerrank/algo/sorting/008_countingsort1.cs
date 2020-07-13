/***************************************************************************************************
* Title : Counting Sort 1
* URL   : https://www.hackerrank.com/challenges/countingsort1
* Date  : 2017-09-17
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : C.L.R.S 3rd ed, p#194
* meta  : tag-algo-sort
***************************************************************************************************/
using System;

class HKSolution {
  static void Main(String[] args) {
    // take input
    int n = int.Parse(Console.ReadLine());
    string[] tokens = Console.ReadLine().Split();
    int[] C = new int[100];     // input int limit is 100

    // sort & print
    for (int i=0; i<n; i++)
       C[int.Parse(tokens[i])]++;
    Console.WriteLine(string.Join(" ", C));
  }
}

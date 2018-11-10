/***************************************************************************************************
* Title : Counting Sort 2
* URL   : https://www.hackerrank.com/challenges/countingsort2
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
    const int LIMIT = 100;
    int[] C = new int[LIMIT];     // input int limit is 100

    // sort
    for (int i=0; i<n; i++)
       C[int.Parse(tokens[i])]++;

    // print
    for (int i=0; i<LIMIT; i++)
        if (C[i] > 0)
            for (int j=0; j<C[i]; j++)
                Console.Write(i+" ");      
    Console.WriteLine();
  }
}

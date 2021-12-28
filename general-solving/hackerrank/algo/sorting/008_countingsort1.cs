﻿/***************************************************************************
* Title       : Counting Sort 1
* URL         : https://www.hackerrank.com/challenges/countingsort1
* Date        : Sep 17 2017
* Complexity  : O(n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Counting Sort page
*               
*               Nicety - 'string.Join'
* meta        : tag-sort, tag-counting-sort
***************************************************************************/
using System;

class HK_Solution {
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

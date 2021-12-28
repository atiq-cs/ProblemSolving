﻿/***************************************************************************
*   Problem Name:   Arrays: Left Rotation
*   Problem URL :   https://www.hackerrank.com/challenges/ctci-array-left-rotation
*   Date        :   Jan 15, 2016
*   Domain      :   cracking-the-coding-interview/data-structure
*   Desc        :   Linear swap
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Notes       :   Direct solution based on,
*                   https://www.hackerrank.com/challenges/circular-array-rotation
*   meta        :   tag-easy
***************************************************************************/
using System;

class HK_Solution {
  // perform circular rotation
  static void c_rotate(int[] a, int[] b, int n, int k) {
    for (int i = 0; i < n; i++)
      b[(i+n - k) % n] = a[i];
  }

  static void Main(String[] args) {
    string[] tokens_n = Console.ReadLine().Split(' ');
    int n = Convert.ToInt32(tokens_n[0]);
    int k = Convert.ToInt32(tokens_n[1]);
    tokens_n = Console.ReadLine().Split(' ');
    int[] a = Array.ConvertAll(tokens_n, Int32.Parse);
    int[] b = new int[n];       // rotated array

    c_rotate(a, b, n, k);
      for (int i = 0; i < n; i++)
        Console.Write(b[i]+" ");
    Console.WriteLine("");
  }
}

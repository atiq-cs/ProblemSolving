/***************************************************************************************************
* Title : Next Round
* URL   : http://codeforces.com/problemset/problem/158/A
* Occasn: VK Cup 2012 Qualification Round 1
* Date  : 2017-08-10
* Comp  : O(n) to read items
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
* Notes : Easy implementation Problem
* meta  : tag-easy, tag-implementation
***************************************************************************************************/

using System;

public class CFSolution {
  private static void Main() {
    string[] tokens = Console.ReadLine().Split();
    uint n = uint.Parse(tokens[0]);
    uint k = uint.Parse(tokens[1]);
    uint[] score = new uint[n];

    tokens = Console.ReadLine().Split();
    for (uint i = 0; i < n; i++)
      score[i] = uint.Parse(tokens[i]);

    uint count=0;
    /* from the first item to k-th item since it's non-increasing squencce */
    for (uint i = 0; i < n; i++) {
      if (score[i] == 0)
        break;
      if (score[i] >= score[k - 1])
        count++;
      else
        break;
    }
    Console.WriteLine(count);
  }
}

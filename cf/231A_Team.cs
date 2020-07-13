/***************************************************************************************************
* Title : Team
* URL   : http://codeforces.com/problemset/problem/231/A
* Occasn: Codeforces Round #143 (Div. 2)
* Date  : 2017-09-28
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : a simple problem just for fun, utilized bitwise when I see that's possible
* meta  : tag-brute-force, tag-algo-greedy, tag-bit-manip, tag-easy
***************************************************************************************************/
using System;

public class CFSolution
{
  public static void Main() {
    int  n = int.Parse(Console.ReadLine());
    int numProbs = 0;
    for (int i = 0; i < n; i++) {
      int numThinksSolvable = 0;
      string[] tokens = Console.ReadLine().Split();
      for (int j = 0; j<tokens.Length; j++)
        numThinksSolvable += int.Parse(tokens[j]);
      numProbs += numThinksSolvable >> 1;
    }
    Console.WriteLine(numProbs);
  }  
}

/*
Or the last line could be written as,

  if ((numThinksSolvable & 0x2) != 0)
    numProbs++;
*/

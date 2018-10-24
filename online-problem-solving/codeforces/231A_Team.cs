/***************************************************************************
* Title       : Team
* URL         : http://codeforces.com/problemset/problem/231/A
* Occasion    : Codeforces Round #143 (Div. 2)
* Date        : Sep 28 2017
* Complexity  : O(n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : a simple problem just for fun
* meta        : tag-easy
***************************************************************************/
using System;

public class CFSolution {
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
 * Or the last line could be written as,
     if ((numThinksSolvable & 0x2) != 0)
       numProbs++;
*/

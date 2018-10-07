/***************************************************************************
* Title : Army Game
* URL   : https://www.hackerrank.com/challenges/game-with-cells
* Date  : 2017-12
* Author: Atiq Rahman
* Comp  : O(1)
* Status: Accepted
* Notes : Mathematics/Fundamentals
* meta  : tag-math, tag-easy
***************************************************************************/
using System;

class Solution {
  static int GetMinSupply(int r, int c) {
    int result = 0;
    if (r>=2 && c>=2) {
      result += (r/2) * (c/2);
      int t_r = r;
      r = r%2 * c;
      c = c%2 * t_r;
    }
    result += r/2 + r%2;
    result += c/2 + c%2;
    
    return (r>0 && c>0)?result-1 : result;
  }
  
  static void Main(String[] args) {
    string[] tokens_n = Console.ReadLine().Split(' ');
    int n = Convert.ToInt32(tokens_n[0]);
    int m = Convert.ToInt32(tokens_n[1]);

    Console.WriteLine(GetMinSupply(n, m));
  }
}

/*
some inputs,
3 3
4 4
5 5
9 9
7 7
1 7
5 1
2 4
1 6
5 1
*/

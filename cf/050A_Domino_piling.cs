/***************************************************************************************************
* Title : Domino piling
* URL   : http://codeforces.com/problemset/problem/50/A
* Occasn: Codeforces Beta Round #47
* Date  : 2017-08-20
* Comp  : O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
* Notes : very easy math
* meta  : tag-easy, tag-math
***************************************************************************************************/
using System;

public class CFSolution {
  private static void Main() {
    string[] tokens = Console.ReadLine().Split();
    uint M = uint.Parse(tokens[0]);
    uint N = uint.Parse(tokens[1]);
    Console.WriteLine(M*N/2);
  }
}

/*
2x1 1
2x2 

9 take mutliple of 2

say I have
5x3
I can still fill it up except 1 cell. 
*/

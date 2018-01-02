/***************************************************************************
* Problem Name: Domino piling
* Problem URL : http://codeforces.com/problemset/problem/50/A
* Occasion    : Codeforces Beta Round #47
* Date        : Aug 20 2017
* Complexity  : O(1) or time required for multiplication
* Author      : Atiq Rahman
* Status      : Accepted
* Desc        :  
* Notes       : very easy math
* meta        : tag-easy, tag-math
***************************************************************************/

using System;

public class CF_Solution {
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

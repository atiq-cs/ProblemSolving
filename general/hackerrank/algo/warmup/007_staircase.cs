/***************************************************************************************************
* Title : Staircase
* URL   : https://www.hackerrank.com/challenges/staircase
* Date  : 2015-12
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : Loop
* meta  : tag-easy
***************************************************************************************************/
using System;
using System.Collections.Generic;

class HKSolution
{
  static void Main(String[] args) {
    int n = int.Parse(Console.ReadLine());
    
    for (int i=1; i<=n; i++) {
      for (int j=n-i; j>0; j--)
        Console.Write(" ");
      for (int j=1; j<=i; j++)
        Console.Write("#");
      Console.WriteLine();
    }
  }
}

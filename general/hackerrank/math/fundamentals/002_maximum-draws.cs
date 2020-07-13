/***************************************************************************************************
* Title : Maximum Draws
* URL   : https://www.hackerrank.com/challenges/maximum-draws
* Date  : 2015-09-12
* Comp  : O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : If you take one more than half of the items
*   it is certain that 1 pair will be in the collection
*   input is given in number of pairs, n
*   output is n+1
* meta  : tag-math, tag-easy
***************************************************************************************************/
using System;

class HKSolution
{
  static void Main(String[] args) {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      int n = int.Parse(Console.ReadLine());
      Console.WriteLine(n+1);
    }
  }
}

/***************************************************************************************************
* Title : Watermelon
* URL   : http://codeforces.com/problemset/problem/4/A
* Date  : 2015-10-19
*
* Comp  : O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : simple math
* meta  : tag-easy
***************************************************************************************************/

using System;
public class CFSolution
{
  private static void Main() {
    int w = int.Parse(Console.ReadLine());
    if (w > 3 && w % 2 == 0)
      Console.WriteLine("YES");
    else
      Console.WriteLine("NO");
  }
}

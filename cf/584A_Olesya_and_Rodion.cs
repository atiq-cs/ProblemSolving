/***************************************************************************************************
* Title : Olesya and Rodion
* URL   : http://codeforces.com/problemset/problem/584/A
* Occasn: Codeforces Round #324 (Div. 2)
* Date  : 2015-12-31
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
* Notes : I knew a simple solution is possible
*   Looked up a solution online to understand
*
* meta  : tag-math
***************************************************************************************************/

using System;

public class Solution
{
  private static void Main() {
    string[] tokens = Console.ReadLine().Split();
    int n = int.Parse(tokens[0]);
    int t = int.Parse(tokens[1]);

    if (t == 10)
    {
      if (n == 1)
        Console.WriteLine("-1");
      else {
        Console.Write("1");
        for (int i = 1; i < n; i++)
          Console.Write("0");
        Console.WriteLine();
      }
      return;
    }
    for (int i = 0; i < n; i++)
      Console.Write(t);
    Console.WriteLine();

  }
}

/* number of digits 1
 1 to 9 result
 result is t
 if t == 10
  result -1
 
number of digits 2
 10 to 19
 result is 1 followed by t-1
 if t = 10 result is 10
 
number of digits 100
 .....0 to .....9
 result is 1 followed by ..........(t-1)
 if t = 10 consider
*/

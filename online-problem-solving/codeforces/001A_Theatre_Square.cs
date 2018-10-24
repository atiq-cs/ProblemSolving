/***************************************************************************************************
* Title : Theatre Square
* URL   : http://codeforces.com/problemset/problem/1/A
* Date  : 2015-10-19
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : simple math
* meta  : tag-easy
***************************************************************************************************/
using System;

public class CFSolution
{
  private static void Main() {
    string[] tokens = Console.ReadLine().Split();
    int n = int.Parse(tokens[0]);
    int m = int.Parse(tokens[1]);
    int a = int.Parse(tokens[2]);

    /* changed to ulong after an overflow for input:  1000000000 1000000000 192 */
    ulong res = (ulong)(Math.Ceiling(n * 1.0 / a) * Math.Ceiling(m * 1.0 / a));
    Console.WriteLine(res);
  }
}

/*
xxxxxx
xxxxxx
xxxxxx
xxxxxx
xxxxxx
xxxxxx

4 4 4
1
5 4 4
2
6 4 4
2
5 5
4
n/a * m/a

8 8 4
4
8 4 4
2

xxxxxxx
x
x
x
x


6x4 = 6
more 6 to cover those extra
*/

/***************************************************************************
* Title : Word Capitalization
* URL   : http://codeforces.com/problemset/problem/281/A
* Contst: Codeforces Round #172 (Div. 2)
* Date  : 2018-01-29
* Author: Atiq Rahman
* Comp  : O(n), if mutable string is used then O(1)
* Status: Accepted
* Notes : solves replacing the first character of a string
* meta  : tag-string, tag-easy
***************************************************************************/
using System;

class CFSolution {
  private static string Capitalize(string str) {
    if (Char.IsUpper(str[0]))
      return str;
    return Char.ToUpper(str[0]) + str.Substring(1);
  }

  public static void Main() {
    string str = Console.ReadLine();
    Console.WriteLine(Capitalize(str));
  }
}

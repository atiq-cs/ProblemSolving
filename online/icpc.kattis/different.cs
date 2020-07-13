/***************************************************************************
*   Problem Name: A Different Problem
*   Problem URL : https://icpc.kattis.com/problems/different
*   Date        : Oct 13, 2015
*
*   Complexity  : O(1)
*   Author      : Atiq Rahman
*   Status      : Accepted
*   Notes       : Console.ReadLine Method () returns null on EOF
          https://msdn.microsoft.com/en-us/library/system.console.readline.aspx
                  Beware following are not correct,
                  Math.Abs((Decimal)(a-b))
                  Math.Abs((double)a-b)
*   meta        : tag-easy
***************************************************************************/
using System;

public class Solution {
  private static void Main() {
    string line;
    while ((line = Console.ReadLine()) != null) {
      string[] tokens = line.Split();
      long a = long.Parse(tokens[0]);
      long b = long.Parse(tokens[1]);
      Console.WriteLine("{0}", Math.Abs(a - b));
    }
  }
}

/*
 test cases
 9223372036854775807 9223372036854775807
 623372036854775807 9223372036854775807
 0 5
*/

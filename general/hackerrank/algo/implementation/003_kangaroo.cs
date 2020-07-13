/***************************************************************************************************
* Title : Kangaroo
* URL   : https://www.hackerrank.com/challenges/kangaroo
* Date  : 2017-10-01
* Comp  : O()
* Author: Atiq Rahman
* Status: Accepted
* Notes : Consider 3 options we have in each node
* meta  : tag-math, tag-easy
***************************************************************************************************/
using System;

class Solution
{
  static string kangaroo(int x1, int v1, int x2, int v2) {
    int s1 = x1;
    int s2 = x2;
    int d1 = Math.Abs(s2 - s1);

    for (int t = 1; ; t++) {
      s1 += v1;
      s2 += v2;

      int d2 = Math.Abs(s2 - s1);
      if (d2 >= d1)
        return "NO";
      if (s2 == s1)
        return "YES";

      d1 = d2;
    }
  }

  static void Main(String[] args) {
    string[] tokens_x1 = Console.ReadLine().Split(' ');
    int x1 = Convert.ToInt32(tokens_x1[0]);
    int v1 = Convert.ToInt32(tokens_x1[1]);
    int x2 = Convert.ToInt32(tokens_x1[2]);
    int v2 = Convert.ToInt32(tokens_x1[3]);

    string result = kangaroo(x1, v1, x2, v2);
    Console.WriteLine(result);
  }
}

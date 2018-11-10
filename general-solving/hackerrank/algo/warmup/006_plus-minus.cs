/***************************************************************************************************
* Title : Plus Minus
* URL   : https://www.hackerrank.com/challenges/plus-minus
* Date  : 2015-09-12
* Comp  : 
* Status: Accepted
* Notes : It is a trivial problem but it demonstrates how to format floating numbers in C#
* ref   : Numeric standard format specifier for C#
*   https://msdn.microsoft.com/en-us/library/dwhawy9k.aspx
*   https://msdn.microsoft.com/en-us/library/s8s7t687.aspx
* meta  : tag-easy
***************************************************************************************************/
using System;

class HKSolution {
  static void Main() {
    int N = int.Parse(Console.ReadLine());
    string[] tokens = Console.ReadLine().Split();

    int p = 0, n = 0, z = 0;
    for (int i = 0; i < N; i++) {
      int num = int.Parse(tokens[i]);
      if (num == 0)
        z++;
      else if (num > 0)
        p++;
      else
        n++;
    }
    // 3 digits after decimal point, see refs
    Console.WriteLine("{0:F3}", p / (float)N);
    Console.WriteLine("{0:F3}", n / (float)N);
    Console.WriteLine("{0:F3}", z / (float)N);
  }
}

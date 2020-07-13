/***************************************************************************************************
* Title : Possible Path
* URL   : https://www.hackerrank.com/challenges/possible-path
* Date  : 2016-01-15
* Comp  : O(logb)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Lemma: A point (a, b) where g = gcd(a, b) is connected to one of
*   the following points: (g, 0), (0, g), (−g, 0), (0, −g). Ref:
* ref   : https://hr-filepicker.s3.amazonaws.com/infinitum-jun14/editorials/2372-possible-path.pdf
* meta  : tag-math
***************************************************************************************************/
using System;

class HKSolution
{
  static void Main(String[] args) {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      long a = long.Parse(tokens[0]);
      long b = long.Parse(tokens[1]);
      long x = long.Parse(tokens[2]);
      long y = long.Parse(tokens[3]);

      if (gcd(a,b) == gcd(x,y))
        Console.WriteLine("YES");
      else
        Console.WriteLine("NO");
    }
  }
  /*
    Euclidean algorithm for finding gcd
    Mod can't be negative but in C, C# it is
    Wiki: for (a,b)   the number of division steps is at most 2 log b + 1
    http://math.stackexchange.com/questions/27719/what-is-gcd0-a-where-a-is-a-positive-integer
    
  */
  static long gcd(long a, long b) {
    // critical cases when a = 0 or b=0 or less therefore just avoiding them for now
    if (a==0)
      return b;
    if (a<1 || b<1)
      return -1;
    return gcd(b%a, a);
  }
}

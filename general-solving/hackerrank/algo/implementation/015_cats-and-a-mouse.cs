/***************************************************************************
* Title       : Cats and a Mouse
* URL         : https://www.hackerrank.com/challenges/cats-and-a-mouse
* Date        : Sept 22, 2017
* Domain      : algorithms/implementation
* Complexity  : O(1)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Integral Point: A point in an nn-dimensional space R_n with
*               integer coordinates
* Ref         : https://www.encyclopediaofmath.org/index.php/Integral_point
* meta        : tag-easy, tag-math, tag-implementation
***************************************************************************/
using System;

class Solution {
  static void Main(String[] args) {
    int q = Convert.ToInt32(Console.ReadLine());
    for(int a0 = 0; a0 < q; a0++){
      string[] tokens_x = Console.ReadLine().Split(' ');
      int x = Convert.ToInt32(tokens_x[0]);
      int y = Convert.ToInt32(tokens_x[1]);
      int z = Convert.ToInt32(tokens_x[2]);

      int dA = Math.Abs(z-x);
      int dB = Math.Abs(z-y);
      
      if (dA > dB)
        Console.WriteLine("Cat B");
      else if (dA < dB)
        Console.WriteLine("Cat A");
      else
        Console.WriteLine("Mouse C");
    }
  }
}

/*
* Problem   : Generate Binary Numbers using Combination
* Author    : Atiq Rahman
* Date      : Nov 01, 2015
* Notes      : Generate binary numbers using recursive combination
*             This is the basic of generating combination
*             Apparently binary numbers can be efficiently generated using
*              bitwise operations
*             for bitwise implementation have a look at,
*             ref: http://www.cs.utexas.edu/users/djimenez/utsa/cs3343/lecture25.html
*              
*              ToDo, complexity analysis
* meta      : tag-combination, tag-recursion
*/
using System;

class CombinationBinary
{
  public void comb(int[] A, int k) {
    if (k == A.Length) {
      DisplayArray(A);
      return;
    }
    // This can be replaced with a loop
    A[k] = 0;
    comb(A, k + 1);
    A[k] = 1;
    comb(A, k + 1);
  }

  void DisplayArray(int[] A) {
    foreach (var item in A)
      Console.Write(item);
    Console.WriteLine();
  }
}

// Generate all binary numbers of n bits
class Demo {
  static void Main(string[] args) {
    CombinationBinary com = new CombinationBinary();
    int N = 3;
    int[] A = new int[N];
    com.comb(A, 0);
  }
}

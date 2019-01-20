/***************************************************************************************************
* Title : Generate Binary Number
* URL   : C.L.R.S defines combinations p#1185
* Occasn: 
* Date  : 2019-01
* Comp  : O(2^N), O(N) Stack
* Status: 
* Notes : This is a variation of combination. A combination doesn't repeat subsets. For example,
*   {0, 1, 0} and {1, 0, 0} can be two different binary numbers.
*   This does not map to permutation as well. Since, permutation doesn't allow repeating an element
*   from the Set. Example: {a, b, c}
*    abc
*    acb
*    bac
*    bca
*    ...
*   
*   This is here for example, not exactly combination.
* meta  : tag-combination
***************************************************************************************************/
using System;

public class NumberSystem {
  int[] A;
  int limit;

  public void TakeInput() {
    limit = int.Parse(Console.ReadLine());
    A = new int[limit];
  }

  private void PrintNumber() {
    for (int i = 0; i < limit; i++)
      Console.Write(A[i]);
    Console.WriteLine();
  }

  public void GenerateBinary(int i=0) {
    if (i == limit)
      PrintNumber();
    else {
      A[i] = 0;
      GenerateBinary(i + 1);
      A[i] = 1;
      GenerateBinary(i+1);
    }
  }
}

public class Solution {
  private static void Main() {
    NumberSystem demo = new NumberSystem();
    demo.TakeInput();
    demo.GenerateBinary();
  }
}

/*
Input: 3

Output:
000
001
010
011
100
101
110
111

2015-11 version passes an Array of spcified of length instead of passing limit,

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

*/

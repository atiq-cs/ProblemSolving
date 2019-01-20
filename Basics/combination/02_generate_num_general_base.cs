/***************************************************************************************************
* Title : Generate Numbers for provided base
* URL   : C.L.R.S defines combinations p#1185
* Occasn: 
* Date  : 2019-01
* Comp  : 
* Status: 
* Notes : See '01_generate_binary_num.cs' for more details
*   
*   This is here for example, not exactly combination.
*   However, recursion loop is very identical to combination's loop
*   
*   Example output at bottom
* meta  : tag-combination, tag-recursion
***************************************************************************************************/
using System;

public class NumberSystem {
  int[] A;
  int maxDigits;
  int baseNum;

  public void TakeInput() {
    maxDigits = int.Parse(Console.ReadLine());
    A = new int[maxDigits];
    baseNum = int.Parse(Console.ReadLine());
  }

  private void PrintNumber() {
    for (int i = 0; i < maxDigits; i++)
      Console.Write(A[i]);
    Console.WriteLine();
  }

  public void Generate(int i=0) {
    if (i == maxDigits)
      PrintNumber();
    else
      for (int k=0; k<baseNum; k++) {
        A[i] = k;
        Generate(i + 1);
      }
  }
}

public class Solution {
  private static void Main() {
    NumberSystem demo = new NumberSystem();
    demo.TakeInput();
    demo.Generate();
  }
}

/*
Input:
2 (max digits)
3 (base)
Output:
00
01
02
10
11
12
20
21
22
*/

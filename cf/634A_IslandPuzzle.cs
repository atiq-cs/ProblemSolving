/***************************************************************************************************
* Title : Island Puzzle
* URL   : https://codeforces.com/problemset/problem/634/A
* Occasn: Competitive programming, with Lewin Gan; 8VC Venture Cup 2016 - Final Round (Div. 1 Ed)
*   Contest#4 Group#ylgaGzHfaj
* Date  : 2018-11-13
* Comp  : O(n) 171ms, O(1) 31600KB
* Status: Accepted
* Notes : It's an easy problem as input numbers are distinct. Find the first number from rotation
*   output with original array and keep comparing to find if it matches till the end.
*
*   Demonstrates ConvertAll with ReadLine
* meta  : tag-binary-search, tag-two-pointers, tag-easy
***************************************************************************************************/
using System;

public class ArrayRotation {
  int[] A, eA;

  public void TakeInput() {
    int.Parse(Console.ReadLine());
    A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    eA = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
  }

  // Check if expected order is possible to get by rotation
  public bool CanGetOrder() {
    // find position of eA[0] in A
    int x = eA[0] == 0? eA[1]: eA[0];
    int firstIndex = 0;
    for (; firstIndex < A.Length; firstIndex++)
      if (x == A[firstIndex])
        break;

    // get possible output for rotation from there
    int i = (eA[0]==0)?2:1;
    int rIndex = (firstIndex + 1) % A.Length;

    for (; i < A.Length; i++) {
      if (eA[i] == 0)
        continue;

      if (A[rIndex] == 0)
        rIndex = (rIndex+1) % A.Length;
      if (eA[i] != A[rIndex])
        return false;

      rIndex = (rIndex + 1) % A.Length;
    }

    return true;
  }
}

public class CFSolution {
  private static void Main() {
    ArrayRotation arDemo = new ArrayRotation();
    arDemo.TakeInput();
    Console.WriteLine(arDemo.CanGetOrder() ? "YES" : "NO");
  }
}

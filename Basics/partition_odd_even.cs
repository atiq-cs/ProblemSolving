/***************************************************************************
* Title : Sort even/odd
* URL   : N/A
* Occsn : Interview OTS
* Date  : 2017-09-22
* Author: Atiq Rahman
* Comp  : O(n^2)
* Status: Manually Tested
* Notes : A beautiful tweak of quick sort's partition algorithm.
*   The algorithm ensures that the invariant that one item is placed a location
*   is finalized and so, it is not touched again.
*   
*   Complexity can be reduced to O(n lg n) by replacing linear search with
*   binary search
*   
*   Could not find a similar problem on online judges yet
* Rel   : http://www.crazyforcode.com/rearrange-array-even-numbers-odd-numbers/
* meta  : tag-algo-sort, tag-company-microsoft, tag-interview
***************************************************************************/
using System;

public class Demo
{
  /// <summary>
  /// We should be able to do it in much simpler way like Sort Color leetcode problem
  /// </summary>
  /// <param name="A"></param>
  static void OddEvenSort(int[] A) {
    int j = -2; // odd pointer
    int k = -1; // even pointer
    for (int i = 0; i < A.Length; i++) {
      // Maintain invariant:
      //  don't touch even items in even locations; last one pointed by k
      //  don't touch odd items in odd locations; last one pointed by j
      if (i % 2 == 0) {
        if (i <= j)
          continue;
      }
      else if (i <= k)
        continue;

      if (A[i] % 2 == 0 && k + 2 < A.Length) {
        k = k + 2;
        Swap<int>(A, i, k);   // utils.cs
      }
      else if (A[i] % 2 == 1 && j + 2 < A.Length) {
        j = j + 2;
        Swap<int>(A, i, j);
      }
    }
  }

  /// <summary>
  /// This is from meetup 2018-02-08 where I wrote this, not tested
  /// rel: http://collabedit.com/fk87m
  /// </summary>
  public void EvenOdd_v2(int[] A) {
    for (int i = 0, j = A.Length - 1; i < j; i++) {
      while (A[j] % 2 == 1 && i < j)
        j--;
      if (A[i] % 2 == 1)
        Swap<int>(A, i, j);
    }
  }

  public static void Main() {
    // TODO: implement tests
    if (ShouldRunTest)
      RunTest();
    int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    OddEvenSort(A);
    Console.WriteLine("After rearrangment: ");
    Console.WriteLine(string.Join(" ", A));
  }  
}

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
* meta  : tag-sort, tag-microsoft, tag-interviews
***************************************************************************/
using System;

public class Demo {
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
        Swap(A, i, k);
      }
      else if (A[i] % 2 == 1 && j + 2 < A.Length) {
        j = j + 2;
        Swap(A, i, j);
      }
    }
  }

  static void Swap(int[] A, int i, int j) {
    int tmp = A[i];
    A[i] = A[j];
    A[j] = tmp;
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

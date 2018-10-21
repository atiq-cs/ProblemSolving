/***************************************************************************************************
* Title : Sorting Algorithms
* Author: Atiq Rahman
* Date  : 2015-09-23
* Notes : Algos covered,
*   Selection sort
*   Bubble sort
*   Insertion sort
* meta  : tag-algo-sort, tag-algo-core
***************************************************************************************************/
using System;

class SortingAlgorithms {
  /*
  * Algo  : Selection sort (Select Minimum)
  * Notes : Finds the smallest number each time and put it in front of
  *   unsorted window. It's as if the selected window is reduced by
  *   one each time starting with length n
  * Comp  : Worst case, average case and best case - O(n^2)
  */
  public void SelectionSort(int[] A) {
    for (int i = 0; i < A.Length - 1; i++) {
      int iMin = i;
      for (int j = i + 1; j < A.Length; j++)
        if (A[iMin] > A[j])
          iMin = j;
      Swap<int>(ref A[iMin], ref A[i]);
    }
  }
  /*
  * Algo  : Bubble sort (Select Maximum with Continuous Swapping if we call it bubbling)
  * Notes : Finds the maximum each time and put it on appropriate index swapping all of them
  *   cocktail shaker sort evolves from this
  * Comp  : Worst case and average case - O (n^2); Best case O(n)
  * Versions:
  *   v2 - adds isSwap
  *   v3 - updates n based last swapped happened (instead of isSwapped)
  */
  public void BubbleSort_v1(int[] A) {
    int n = A.Length;
    do {
      int newn = 0;
      for (int i = 1; i < n; i++)
        if (A[i - 1] > A[i]) {
          Swap<int>(ref A[i-1], ref A[i]);
          newn = i;
        }
      n = newn;
    } while (n > 0);
  }

  public void BubbleSort_v2(int[] A) {
    int n = A.Length;
    bool isSwapped;
    do {
      isSwapped = false;
      for (int i = 1; i < n; i++)
        if (A[i - 1] > A[i]) {
          Swap<int>(ref A[i - 1], ref A[i]);
          isSwapped = true;
        }
      n--;
    } while (isSwapped);
  }
  /*
  * Algo  : Insertion sort (Reverse Bubble)
  * Notes : Takes an index (i) from beginning to end
  *   Start swapping from i to beginning of the array as long as swap is possible in reverse
  *   direction. As a result, after each iteration items of the array upto i is sorted
  *   For example, consider the array 5, 4, 3, 8, 7, 6
  *   in step 1, i=1, it will sort: 4, 5
  *   i=2, it will sort, 3, 4, 5
  *   version 2 does not do swap but only moves items
  *   As if items are being inserted in their proper position in the sorted list each time
  *   Ref: C.L.R.S p#18 (shows loop invariants and corrections), elaborate runtime analysis:
  *   p#26
  *
  * Comp  : Worst case and average case - O (n^2)
  *   Best case Ω(n)
  */
  public void InsertionSort_v1(int[] A) { // slightly improved version: swaps eliminated
    for (int i = 1; i < A.Length; i++) {
      // save i-th item because this will be replaced
      int x = A[i];
      int j = i;
      while (j > 0 && A[j - 1] > x) {
        A[j] = A[j - 1];
        j--;
      }
      A[j] = x;
    }
  }

  // easier, readable version
  public void InsertionSort_v2(int[] A) {
    for (int i = 1; i < A.Length; i++) {
      int j = i;
      while (j > 0 && A[j - 1] > A[j]) {
        Swap<int>(ref A[j - 1], ref A[j]); j--;
      }
    }
  }

  // Utility Functions, may be move to algo-core/utils.cs
  static void Swap<T>(ref T lhs, ref T rhs) {
    if (lhs.Equals(rhs))
      return ;
    T temp;
    temp = lhs;
    lhs = rhs;
    rhs = temp;
  }
}

class Demo {
  static void Main(string[] args) {
    int[] OriginalArray = { 5, 89, 43, 13, 67, 11, 45 };
    int[] A = new int[OriginalArray.Length];
    SortingAlgorithms sortAlgo = new SortingAlgorithms();

    // insertion sort demo
    Array.Copy(OriginalArray, A, A.Length);
    sortAlgo.InsertionSort_v1(A);
    Console.WriteLine("After insertion sort v1 list contains: ");
    Console.WriteLine(string.Join(" ", A));

    Array.Copy(OriginalArray, A, A.Length);
    sortAlgo.InsertionSort_v2(A);
    Console.WriteLine("After insertion sort v2 list contains: ");
    Console.WriteLine(string.Join(" ", A));

    // Selection sort demo
    Array.Copy(OriginalArray, A, A.Length);
    sortAlgo.SelectionSort(A);
    Console.WriteLine("After Selection sort list contains: ");
    Console.WriteLine(string.Join(" ", A));

    // Bubble sort demo
    Array.Copy(OriginalArray, A, A.Length);
    sortAlgo.BubbleSort_v1(A);
    Console.WriteLine("After Bubble sort v1 list contains: ");
    foreach (var item in A)
      Console.Write(" {0}", item);
    Console.WriteLine();
    Array.Copy(OriginalArray, A, A.Length);
    sortAlgo.BubbleSort_v2(A);
    Console.WriteLine("After Bubble sort v2 list contains: ");
    Console.WriteLine(string.Join(" ", A));
  }
}

/***************************************************************************
* Title : Quick Sort
* URL   : C.L.R Chapter 7
* Date  : Nov 1, 2017
* Author: Atiq Rahman
* Comp  : O(n), space O(1)
*
* Status: Accepted
* Notes : Contains,
*   QuickSort
*   Partition
*   Randomized-Partition
*
* Related: https://www.hackerrank.com/challenges/quicksort1
* meta  : tag-sorting
***************************************************************************/
using System;

class QuickSort {
  public void Sort(int[] A, int p, int r) {
    if (p<r) {
      int q = Partition(A, p, r);
      Sort(A, p, q - 1);
      Sort(A, q+1, r);
    }
  }

  // improvement 1 on worst case - Randomized-Partition simplified as per C.L.R
  // page 179
  private int RandomizedPartition(int[] A, int p, int r) {
    int i = Random();
    Swap(ref A[i], ref A[r]);
    return Partition(A, p, r);
  }

  // simple quick sort partition - C.L.R page 171
  private int Partition(int[] A, int p, int r) {
    int i = -1;
    int x = A[r];
    for (int j=0; j<r; j++) {
      /*
       * maintains invariant that all items are less than pivot are in the
       * block of i (or smaller elements till where i ends)
       */
      if (A[j] <= x) {
        i++;
        Swap(ref A[i], ref A[j]);
      }
    }
    Swap(ref A[i + 1], ref A[r]);
    return i + 1;
  }

  // Utility Functions
  void Swap<T>(ref T lhs, ref T rhs) {
    if (lhs.Equals(rhs) == false) {
      T temp;
      temp = lhs;
      lhs = rhs;
      rhs = temp;
    }
  }

  /* can be replaced with this if the Array is maintained as the member of the
  class
  void Swap(int i, int j) {
    if (i != j) {
      int temp = A[i];
      A[i] = A[j];
      A[j] = temp;
    }
  }*/
}

class Demo {
  static void Main(string[] args) {
    int[] OriginalArray = { 5, 89, 43, 13, 67, 11, 45 };
    int[] A = new int[OriginalArray.Length];
    QuickSort quickSortDemo = new QuickSort();

    Array.Copy(OriginalArray, A, A.Length);
    quickSortDemo.Sort(A, 0, A.Length - 1);
    Console.WriteLine("After Quick sort list contains: ");
    Console.WriteLine(string.Join(" ", A));
  }
}

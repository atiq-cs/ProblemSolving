/***************************************************************************
* Title : Counting sort utility
* URL   : C.L.R.S p194: Counting Sort
* Date  : 2018-06-07
* Author: Atiq Rahman
* Notes : Generic class implementation for class 'Sorting' is avoided for
*   simplicity
***************************************************************************/
/*
 * This was previously implemented using struct which provides pass by value
 * instead of references. msdn ref for this was,
 * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-
 *  and-structs/using-structs
 */
// Consider better encapsulation if required
class Item {
  public int priority { get; set; }   // or can be named 'key'
  public string val { get; set; }
  public Item(int n, string s) { priority = n; val = s; }
}

class Sorting {
  // To additional space for B can we modify and save result in original input
  // Array A?
  // Nope. There does not seem to be a one to one mapping.. overwriting makes
  // us lose information that we use later
  public Item[] CountingSort(Item[] A, bool isAscending) {
    const int LIMIT = 100;
    int n = A.Length;
    int[] C = new int[LIMIT];     // input int limit is 100
    Item[] B = new Item[n];

    // sorting first part
    for (int i=0; i<n; i++) {
      C[A[i].priority]++;
    }
    for (int i=1; i<LIMIT; i++)
      C[i] +=  C[i-1];

    // stable sort: final step
    for (int i=n-1; i>=0; i--) {
      // The array C keeps continuous accumulation of the frequencies for each
      // element
      // For example, for the largest element in A[i], C[A[i]] will point to
      // the last index inside array B
      // if that largest element has multiple copies due to decrement of
      // C[A[i]] the index reduces by 1 to point to previous to last one
      B[isAscending ? C[A[i].priority] - 1 : (B.Length - C[A[i].priority])] = A[i];    // updated to support 0-based index
      C[A[i].priority]--;
    }
    return B;
  }
}

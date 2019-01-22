/*
* Title   : Generate All Possible Combinations with k items from N items
* Date    : 2015-11-01
* Notes   : includes all repeatations
*           This is an incremental development
*           started from 'Basics/combination/01_generate_binary_num.cs'
* meta    : tag-combination, tag-recursion
*/
using System;

class CombinationBinary {
  // N = Length of inArray
  int[] inArray = { 1, 2, 3, 4 };

  public void comb(int[] A, int k) {
    if (k == A.Length)
      DisplayArray(A);
    else
      for (int i = 0; i < inArray.Length; i++) {
        A[k] = inArray[i];
        comb(A, k + 1);
      }
  }

  void DisplayArray(int[] A) {
    foreach (var item in A)
      Console.Write(item);
    Console.WriteLine();
  }
}

/* Demo: Generate all possible combination choosing k items out of N Numbers */
class Demo {
  static void Main(string[] args) {
    CombinationBinary com = new CombinationBinary();
    // k = Length of array, A
    // k must be <= N
    int k = 2;
    int[] A = new int[k];
    com.comb(A, 0);
  }
}


/* Draft 2019-01
find comb of k items from n

comb (n, k) {
  comb(n, k-1)
  
}


000
001
010
011
100
101
110
111

do that recursively,

00 -> 0
00 -> 1

GetBinary(0, 0)

GetBinary(int n, int k) {
  if (k == d) {
    PrintNumber()
  }
  
  GetBinary(n, k+1)
  
}
 
*/

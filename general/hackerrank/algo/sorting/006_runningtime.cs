/***************************************************************************************************
* Title : Running Time of Algorithms
* URL   : https://www.hackerrank.com/challenges/correctness-invariant
* Date  : 2015-09-17
* Comp  : O(n^2)
* Author: Atiq Rahman
* Status: Accepted
* Notes : C.L.R.S p#16
* meta  : tag-algo-sort
***************************************************************************************************/
using System;

class Solution { 
  static int insertionSortSwapCount(int[] A) { 
    int count = 0;
    for (int i = 1; i < A.Length; i++) { 
      int x = A[i]; 
      int j = i - 1; 
      while (j >= 0 && x < A[j]) { 
        A[j + 1] = A[j];
        j = j - 1; 
        count++;
      }
      if (j+1 != i)
        A[j + 1] = x; 
    }
    return count;
  }

  static void Main(string[] args) { 
    Console.ReadLine(); 
    int [] _ar = (from s in Console.ReadLine().Split() select Convert.ToInt32(s)).ToArray();
    Console.WriteLine(insertionSortSwapCount(_ar)); 
  }
} 

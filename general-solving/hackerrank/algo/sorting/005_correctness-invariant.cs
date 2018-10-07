/***************************************************************************
* Title       : Correctness and the Loop Invariant
* URL         : https://www.hackerrank.com/challenges/correctness-invariant
* Date        : Sep 17 2015
* Complexity  : O(n^2)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : page 16 CLR
* meta        : tag-sort, tag-insertion-sort
***************************************************************************/
using System;

class Solution { 
  public static void insertionSort (int[] A) { 
    int j = 0; 
    for (int i = 1; i < A.Length; i++) { 
      int value = A[i]; 
      j = i - 1; 
      while (j >= 0 && value < A[j]) { 
        A[j + 1] = A[j];
        j = j - 1; 
      } 
      A[j + 1] = value; 
    } 
    Console.WriteLine(string.Join(" ", A)); 
  }

  static void Main(string[] args) { 
    Console.ReadLine(); 
    int [] _ar = (from s in Console.ReadLine().Split() select Convert.ToInt32(s)).ToArray();
    insertionSort(_ar); 
  }
} 

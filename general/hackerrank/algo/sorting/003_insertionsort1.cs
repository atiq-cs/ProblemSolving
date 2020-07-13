/***************************************************************************************************
* Title : Insertion Sort - Part 1
* URL   : https://www.hackerrank.com/challenges/insertionsort1
* Date  : 2015-09-17
* Comp  : O(n^2)
* Author: Atiq Rahman
* Status: Accepted
* Notes : page 16 CLR
* meta  : tag-algo-sort
***************************************************************************************************/
using System;
using System.Collections.Generic;

class Solution {
  static void Swap<T>(ref T lhs, ref T rhs) {
    T temp = lhs;
    lhs = rhs;
    rhs = temp;
  }
  
  static void insertionSort(int[] A) {
    for (int i = 1; i < A.Length; i++) {
      int j = i;
      int x = A[j];
      while (j > 0 && A[j - 1] > x) {  // swap
        A[j] = A[j-1];
        j--;
        foreach ( var item in A)
          Console.Write("{0} ", item);
        Console.WriteLine();
      }
      if (j != i) {
        A[j] = x;
        foreach ( var item in A)
          Console.Write("{0} ", item);
        Console.WriteLine();
      }
    }
  }
  
  static void Main(String[] args) {       
    int _ar_size;
    _ar_size = Convert.ToInt32(Console.ReadLine());
    int [] _ar =new int [_ar_size];
    String elements = Console.ReadLine();
    String[] split_elements = elements.Split(' ');
    for(int _ar_i=0; _ar_i < _ar_size; _ar_i++) {
      _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]); 
    }

    insertionSort(_ar);
  }
}

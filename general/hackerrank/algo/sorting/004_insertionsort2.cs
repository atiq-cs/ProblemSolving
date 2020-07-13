/***************************************************************************************************
* Title : Insertion Sort - Part 2
* URL   : https://www.hackerrank.com/challenges/insertionsort2
* Date  : 2017-09-17
* Comp  : O(n^2)
* Author: Atiq Rahman
* Status: Accepted
* Notes : C.L.R.S p#16
* meta  : tag-algo-sort
***************************************************************************************************/
using System;

class HKSolution
{
  static void insertionSort(int[] A) {
    for (int i = 1; i < A.Length; i++) {
      int j = i;
      while (j > 0 && A[j - 1] > A[j]) {
        Swap(A, j-1, j);
        j--;
      }
      Console.WriteLine(string.Join(" ", A));
    }
  }
  
  static void Swap(int[] A, int i, int j) {
    int tmp = A[i];
    A[i] = A[j];
    A[j] = tmp;
  }
  
  static void Main(String[] args) {     
    int _ar_size;
    _ar_size = Convert.ToInt32(Console.ReadLine());
    int [] _ar =new int [_ar_size];
    String elements = Console.ReadLine();
    String[] split_elements = elements.Split(' ');
    for(int _ar_i=0; _ar_i < _ar_size; _ar_i++)
      _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]); 
    insertionSort(_ar);
  }
}

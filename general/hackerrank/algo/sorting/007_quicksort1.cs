/***************************************************************************************************
* Title : Quicksort 1 - Partition
* URL   : https://www.hackerrank.com/challenges/quicksort1
* Date  : 2015-09-01
* Comp  : Partition O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Quick Sort partition related, C.L.R.S p#16
* rel   : Basic Sort
* meta  : tag-algo-sort
***************************************************************************************************/
using System;

class HKSolution {
  static void partition(int[] ar) {
    // let's use an auxilary list
    int[] xa = new int[ar.Length];
    int pivot = ar[0], xi = 0;
    for (int i=1; i<ar.Length; i++)
      if (ar[i] <= pivot)
        xa[xi++] = ar[i];
    xa[xi++] = pivot;
    for (int i=1; i<ar.Length; i++)
      if (ar[i] > pivot)
        xa[xi++] = ar[i];
    for (int i=0; i<xi; i++)
      Console.Write("{0} ", xa[i]);
    Console.WriteLine();
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
    partition(_ar);
  }
}

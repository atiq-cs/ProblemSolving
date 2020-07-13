/***************************************************************************************************
* Title : Sorting: Bubble Sort
* URL   : https://www.hackerrank.com/challenges/ctci-bubble-sort
* Date  : 2017-09-07
* Comp  : O(n^2)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Bubble sort with tracking of swap operation
* rel   : Basics/basic_sort.cs
* meta  : tag-algo-sort, tag-easy
***************************************************************************************************/
using System;

class HKSolution
{
  static void Main(String[] args) {
    int n = Convert.ToInt32(Console.ReadLine());
    string[] a_temp = Console.ReadLine().Split(' ');
    int[] a = Array.ConvertAll(a_temp,Int32.Parse);
    Console.WriteLine("Array is sorted in {0} swaps.", BubbleSort(a, n));
    Console.WriteLine("First Element: {0}", a[0]);
    Console.WriteLine("Last Element: {0}", a[n-1]);
  }
  
  // Modified Bubble Sort to return number of Swaps
  public static int BubbleSort(int[] A, int n) {
    bool isSwapped;
    int numSwaps = 0;
    do {
      isSwapped = false;
      for (int i = 1; i < n; i++)
      if (A[i - 1] > A[i]) {
        int tmp = A[i-1]; A[i-1] = A[i]; A[i] = tmp; // swap
        isSwapped = true;
        numSwaps++;
      }
      n--;
    } while (isSwapped);
    return numSwaps;
  }
}

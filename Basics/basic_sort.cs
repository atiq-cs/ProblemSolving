/*
* Problem   : Basic Sorting Algorithms
* Author    : Atiqur Rahman
* Email     : mdarahman@cs.stonybrook.edu
* Date      : Sept 23, 2015
* Desc      : Sorting Algorithms covered,
*              Selection sort
*              Bubble sort
*              Insertion sort
* meta      : tag-sorting 
*/

using System;
using System.Collections.Generic;

class SortingAlgorithms
{
    /*
    * Sorting Algorithm: Selection sort
    * Desc             : Finds the minimum each time and put it on appropriate index swapping only once
    * Complexity        : Worst case, average case and best case - O (n^2)
    */
    public void SelectionSort(int[] A)
    {
        for (int j = 0; j < A.Length - 1; j++)
        {
            int iMin = j;
            for (int i = j + 1; i < A.Length; i++)
                if (A[iMin] > A[i])
                    iMin = i;
            if (iMin != j) { //swap
                int temp = A[iMin]; A[iMin] = A[j]; A[j] = temp;
            }
        }
    }

    /*
    * Sorting Algorithm : Bubble sort
    * Desc      : Finds the maximum each time and put it on appropriate index swapping all of them
    *                cocktail shaker sort evolves from this
    * Complexity: Worst case and average case - O (n^2)
    *              Best case O(n)
    * Versions  : v2 - addes isSwap
    *             v3 - updates n based last swapped happened (instead of isSwapped)
    */
    public void BubbleSort(int[] A) {
        int n = A.Length;
        do
        {
            newn = 0;
            for (int i = 1; i < n; i++)
                if (A[i - 1] > A[i]) {
                    int temp = A[i]; A[i] = A[i - 1]; A[i - 1] = temp;  // swap
                    newn = i;
                }
            n = newn;
        } while (n>0);
    }
    
    public void BubbleSort_v2(int[] A) {
        int n = A.Length;
        bool isSwapped;
        do
        {
            isSwapped = false;
            for (int i = 1; i < n; i++)
                if (A[i - 1] > A[i])
                {
                    int temp = A[i]; A[i] = A[i - 1]; A[i - 1] = temp;  // swap
                    isSwapped = true;
                }
            n--;
        } while (isSwapped);
    }

    /*
    * Sorting Algorithm: Insertion sort
    * Desc             : Takes an index (i) from beginning to end
                          Start swapping from i to beginning of the array as long as swap is possible in reverse
                          direction. As a result, after each iteration items of the array upto i is sorted
                          For example, consider the array 5, 4, 3, 8, 7, 6
                           in step 1, i=1, it will sort: 4, 5
                           i=2, it will sort, 3, 4, 5
                          version 2 does not do swap but only moves items 
                           As if items are being inserted in their proper position in the sorted list each time

    * Complexity        : Worst case and average case - O (n^2)
    *                      Best case Ω(n)
    */
    public void InsertionSort(int[] A) // slightly improved version: swaps eliminated
    {
        for (int i = 1; i < A.Length; i++)
        {
            // save i-th item because this will be replaced
            int x = A[i];
            int j = i;
            while (j > 0 && A[j - 1] > x)
            {
                A[j] = A[j - 1];
                j--;
            }
            A[j] = x;
        }
    }

    public void InsertionSort_v0(int[] A)
    {
        for (int i = 1; i < A.Length; i++)
        {
            int j = i;
            while (j > 0 && A[j - 1] > A[j])
            {    // swap
                int temp = A[j - 1]; A[j - 1] = A[j]; A[j] = temp;
                j--;
            }
        }
    }
}

class Demo
{
    static void Main(string[] args)
    {
        int[] OriginalArray = { 5, 89, 43, 13, 67, 11, 45 };
        int[] A = new int[OriginalArray.Length];
        SortingAlgorithms sortAlgo = new SortingAlgorithms();

        // insertion sort demo
        Array.Copy(OriginalArray, A, A.Length);
        sortAlgo.InsertionSort(A);
        Console.WriteLine("After insertion sort list contains: ");
        foreach (var item in A)
            Console.Write(" {0}", item);
        Console.WriteLine();

        // Selection sort demo
        Array.Copy(OriginalArray, A, A.Length);
        sortAlgo.SelectionSort(A);
        Console.WriteLine("After Selection sort list contains: ");
        foreach (var item in A)
            Console.Write(" {0}", item);
        Console.WriteLine();

        // Bubble sort demo
        Array.Copy(OriginalArray, A, A.Length);
        sortAlgo.BubbleSort(A);
        Console.WriteLine("After Bubble sort list contains: ");
        foreach (var item in A)
            Console.Write(" {0}", item);
        Console.WriteLine();
    }
}

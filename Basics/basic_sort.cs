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
    public void SelectionSort(List<int> A)
    {
        for (int j = 0; j < A.Count - 1; j++)
        {
            int iMin = j;
            for (int i = j + 1; i < A.Count; i++)
                if (A[iMin] > A[i])
                    iMin = i;
            if (iMin != j)
            { //swap
                int temp = A[iMin]; A[iMin] = A[j]; A[j] = temp;
            }
        }
    }

    /*
    * Sorting Algorithm: Bubble sort
    * Desc             : Finds the maximum each time and put it on appropriate index swapping all of them
    * Complexity        : Worst case and average case - O (n^2)
    *                      Best case O(n)
    */
    public void BubbleSort(List<int> A)
    {
        int n = A.Count;
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
                           As if items are being inserted in their proper position in the sorted list each time

    * Complexity        : Worst case and average case - O (n^2)
    *                      Best case Î©(n)
    */
    public void InsertionSort_v0(List<int> A)
    {
        for (int i = 1; i < A.Count; i++)
        {
            int j = i;
            while (j > 0 && A[j - 1] > A[j])
            {    // swap
                int temp = A[j - 1]; A[j - 1] = A[j]; A[j] = temp;
                j--;
            }
        }
    }

    // slightly improved version: instead of swaps move
    public void InsertionSort(List<int> A)
    {
        for (int i = 1; i < A.Count; i++)
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
}

class Demo
{
    static void Main(string[] args)
    {
        List<int> OriginalArray = new List<int> { 5, 89, 43, 13, 67, 11, 45 };
        List<int> A;
        SortingAlgorithms sortAlgo = new SortingAlgorithms();

        // insertion sort demo
        A = new List<int>(OriginalArray);
        sortAlgo.InsertionSort(A);
        Console.WriteLine("After insertion sort list contains: ");
        foreach (var item in A)
            Console.Write(" {0}", item);
        Console.WriteLine();

        // Selection sort demo
        A = new List<int>(OriginalArray);
        sortAlgo.SelectionSort(A);
        Console.WriteLine("After Selection sort list contains: ");
        foreach (var item in A)
            Console.Write(" {0}", item);
        Console.WriteLine();

        // Bubble sort demo
        A = new List<int>(OriginalArray);
        sortAlgo.BubbleSort(A);
        Console.WriteLine("After Bubble sort list contains: ");
        foreach (var item in A)
            Console.Write(" {0}", item);
        Console.WriteLine();
    }
}

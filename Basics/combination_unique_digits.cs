﻿/*
* Problem   : Generate All Possible Combinations with k items from N items but no repeatation of same item
* Author    : Atiqur Rahman
* Email     : mdarahman@cs.stonybrook.edu
* Date      : Nov 01, 2015
* Desc      : Ensures that number won't contain same digit twice
*             This is an incremental development based on
*              http://stackoverflow.com/questions/12991758/creating-all-possible-k-combinations-of-n-items-in-c
*              http://stackoverflow.com/questions/127704/algorithm-to-return-all-combinations-of-k-elements-from-n?lq=1
* meta      : tag-combination, tag-recursion
*/

using System;
class CombinationBinary
{
    // N = Length of inArray
    int[] inArray = { 1, 2, 3, 4 };
    bool[] isTaken = new bool[4];
    public void comb(int[] A, int k)
    {
        if (k == A.Length)
        {
            DisplayArray(A);
        }
        else
            for (int i = 0; i < inArray.Length; i++)
            {
                // find first item not taken
                while (i < inArray.Length && isTaken[i]) i++;
                if (i < inArray.Length)
                {
                    A[k] = inArray[i];
                    isTaken[i] = true;
                    comb(A, k + 1);
                    isTaken[i] = false;
                }
            }
    }

    void DisplayArray(int[] A)
    {
        foreach (var item in A)
            Console.Write(item);
        Console.WriteLine();
    }
}

/*  Demo: Generate all possible combination choosing k items out of N Numbers */
class Demo
{
    static void Main(string[] args)
    {
        CombinationBinary com = new CombinationBinary();
        // k = Length of array, A
        // k must be <= N
        int k = 2;
        int[] A = new int[k];
        com.comb(A, 0);
    }
}

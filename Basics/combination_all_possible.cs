/*
* Problem   : Generate All Possible Combinations with k items from N items
* Author    : Atiq Rahman
* Date      : Nov 01, 2015
* Desc      : includes all repeatations
*             This is an incremental development
*             started from Basics/combination_binary.cs
* meta      : tag-combination, tag-recursion
*/

using System;
class CombinationBinary
{
    // N = Length of inArray
    int[] inArray = { 1, 2, 3, 4 };
    public void comb(int[] A, int k)
    {
        if (k == A.Length)
            DisplayArray(A);
        else
            for (int i = 0; i < inArray.Length; i++)
            {
                A[k] = inArray[i];
                comb(A, k + 1);
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

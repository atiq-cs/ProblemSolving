/*
* Problem   : Generate All Possible Combinations with k items from N items but no repeatation of
*   same item
* Date      : 2015-11-01
* Desc      : Ensures that number won't contain same digit twice
*             This is an incremental development based on
*              Basics/combination_all_possible.cs
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

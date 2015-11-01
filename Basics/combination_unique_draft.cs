/*
* This is a draft before solving
* leetcode/077_combinations.cs
*  got rid of isTaken and reached the solution
* tag-combination
*/

using System;
class CombinationBinary
{
    // N = Length of inArray
    int[] inArray = { 1, 2, 3, 4 };
    bool[] isTaken = new bool[4];
    public void comb(int[] A, int offset, int k)
    {
        if (k == A.Length)
        {
            DisplayArray(A);
        }
        else
            for (int i = offset; i < inArray.Length; i++)
            {
                // find first item not taken
                // while (i < inArray.Length && isTaken[i]) i++;
                if (i < inArray.Length)
                {
                    A[k] = inArray[i];
                    isTaken[i] = true;
                    comb(i+1, k + 1);
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
        int k = 3;
        int[] A = new int[k];
        com.comb(A, 0, 0);
    }
}

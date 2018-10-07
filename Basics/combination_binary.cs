/*
* Problem   : Generate Binary Numbers using Combination
* Author    : Atiqur Rahman
* Email     : mdarahman@cs.stonybrook.edu
* Date      : Nov 01, 2015
* Desc      : Generate binary numbers using recursive combination
*             This is the basic of generating combination
*             Apparently binary numbers can be efficiently generated using
*              bitwise operations
*             for bitwise implementation have a look at,
*              http://www.cs.utexas.edu/users/djimenez/utsa/cs3343/lecture25.html
* meta      : tag-combination, tag-recursion
*/

using System;
class CombinationBinary
{
    public void comb(int[] A, int k) {
        if (k == A.Length)
        {
            DisplayArray(A);
            return;
        }
        /* This apparently can be replaced with a loop */
        A[k] = 0;
        comb(A, k + 1);
        A[k] = 1;
        comb(A, k + 1);
    }

    void DisplayArray(int[] A) {
        foreach (var item in A)
            Console.Write(item);
        Console.WriteLine();
    }
}

/*  Demo: Generate all of the binary numbers of n bits */
class Demo {
    static void Main(string[] args) {
        CombinationBinary com = new CombinationBinary();
        int N = 3;
        int[] A = new int[N];
        com.comb(A, 0);
    }
}

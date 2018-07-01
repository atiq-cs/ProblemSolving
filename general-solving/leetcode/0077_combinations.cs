/***************************************************************************
* Problem Name: Combinations
* Problem URL : https://leetcode.com/problems/combinations/
* Date        : Nov 01, 2015
* Complexity  : O(2^n) Time
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Unique combination
*               Judge is nice: as long as unique combinations are there order in the output does not matter
*               This is an incremental development based on
*                Basics/combination_all_possible.cs
*                Basics/combination_unique_digits.cs
*               Refs:
*               http://stackoverflow.com/questions/12991758/creating-all-possible-k-combinations-of-n-items-in-c
*               http://stackoverflow.com/questions/127704/algorithm-to-return-all-combinations-of-k-elements-from-n?lq=1
* meta        : tag-combination, tag-recursion
***************************************************************************/

public class Solution {
    IList<IList<int>> result;
    int[] A;
    int N;
    
    public IList<IList<int>> Combine(int n, int k) {
        result = new List<IList<int>>();
        A = new int[k]; N = n;
        UniqueComb(0, 0);
        return result;
    }
    
    /*
        k corresponds to index in output array A
        i corresponds to index in input array inArray
    */
    public void UniqueComb(int offset, int k) {
        if (k == A.Length)  // we got one of the comb.
            result.Add(new List<int>(A));
        else
            for (int i = offset; i < N - A.Length + k + 1; i++) {   // i<N replaced to make it more efficient
                A[k] = i+1; // i+1 would be taken from another array if provided i.e., inArray[i]
                UniqueComb(i + 1, k + 1);
            }
    }
}

/* A demo for this solution */
class Demo {
    static void Main(string[] args) {
        CombinationSolution comSol = new CombinationSolution();
        // k = Length of array, A
        // k must be <= N
        int N = 7, k = 3;
        IList<IList<int>> comRes = comSol.Combine(N, k);
        foreach (var list in comRes)
        {
            foreach (var item in list)
                Console.Write(item);
            Console.WriteLine();
        }
    }
}

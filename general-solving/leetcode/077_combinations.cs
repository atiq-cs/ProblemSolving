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
*               Basics/combination_unique_digits.cs
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
    
    public void UniqueComb(int offset, int k) {
        if (k == A.Length)  // we got one of the comb.
            result.Add(new List<int>(A));
        else
            for (int i = offset; i < N; i++) {
                A[k] = i+1; // i+1 would be taken from another array if provided
                UniqueComb(i + 1, k + 1);
            }
    }
}

/***************************************************************************************************
* Title : Combinations
* URL   : https://leetcode.com/problems/combinations/
* Date  : 2015-11-01
* Comp  : O(2^n) Time
* Author: Atiq Rahman
* Status: Accepted
* Notes : For an easy understanding of what this problem is asking look at the example in the URL
*   Unique combination
*   Judge is nice: as long as unique combinations are there order in the output does not matter
*   This is an incremental development based on
*    Basics/combination_all_possible.cs
*    Basics/combination_unique_digits.cs
*    
*    As per definition of combination this is indeed comb. I have some number generation examples
*    but I am not sure whether that should fall into the category of combination.
* ref   :
*   C.L.R.S defines combinations p#1185
*   http://stackoverflow.com/questions/12991758/creating-all-possible-k-combinations-of-n-items-in-c
*   http://stackoverflow.com/questions/127704/algorithm-to-return-all-combinations-of-k-elements-from-n?lq=1
* meta  : tag-combination, tag-recursion, tag-csharp-lang-initializer-syntax, tag-leetcode-medium
***************************************************************************************************/
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

  /// <summary>
  /// Recursively generate unique combinations
  /// Uae of offset simplifies recursion
  /// </summary>
  /// <param name="k"> index in output array A </param>
  /// <param name="offset"> starting point </param>
  public void UniqueComb(int offset, int k) {
    if (k == A.Length)  // we got one of the comb.
      result.Add(new List<int>(A));
    else
      // i<N replaced to make it more efficient
      for (int i = offset; i < N - A.Length + k + 1; i++) {
        // i+1 would be taken from another array if provided i.e., inArray[i]
        A[k] = i+1;
        UniqueComb(i + 1, k + 1);
      }
  }
}

/// <summary>
/// A demo for this solution, not required for leetcode
/// </summary>
class Demo {
  static void Main(string[] args) {
    CombinationSolution comSol = new CombinationSolution();
    // k = Length of array, A
    // k must be <= N
    int N = 7, k = 3;
    IList<IList<int>> comRes = comSol.Combine(N, k);

    foreach (var list in comRes) {
      foreach (var item in list)
        Console.Write(item);

      Console.WriteLine();
    }
  }
}

// A re-workout of the problem
// 2018-12
// Done slightly differently
public class Solution {
  int n;    // digit max
  int k;    // limit
  int[] A;
  IList<IList<int>> result;

  public IList<IList<int>> Combine(int n, int k) {
    this.n = n;
    this.k = k;
    A = new int[k];
    result = new List<IList<int>>();
    Comb();
    return result;
  }

  public void Comb(int j = 0) {
    if (j == k) {
      // did not use one line to provide example for IEnumberable constructor
      IList<int> singleComb = new List<int>(A);
      result.Add(singleComb);
    }
    else
      for (int i = ((j - 1) >= 0 ? A[j - 1] : 0) + 1; i <= n; i++) {
        A[j] = i;
        Comb(j + 1);
      }
  }
}

/*
with little changes my prev comb code adapts to the solution of the leetcode problem,
Specifically suiting this leetcode combination problem

Draft for previously arrived solution,
got rid of isTaken and reached the solution

class CombinationBinary {
  // N = Length of inArray
  int[] inArray = { 1, 2, 3, 4 };
  bool[] isTaken = new bool[4];

  public void comb(int[] A, int offset, int k) {
    if (k == A.Length)
      DisplayArray(A);
    else
      for (int i = offset; i < inArray.Length; i++) {
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

  void DisplayArray(int[] A) {
    foreach (var item in A)
      Console.Write(item);
    Console.WriteLine();
  }
}

and driver method for this looks like,
  static void Main(string[] args)
  {
      CombinationBinary com = new CombinationBinary();
      // k = Length of array, A
      // k must be <= N
      int k = 3;
      int[] A = new int[k];
      com.comb(A, 0, 0);
  }

*/

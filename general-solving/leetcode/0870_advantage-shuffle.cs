/***************************************************************************
* Title : Advantage Shuffle
* URL   : https://leetcode.com/problems/advantage-shuffle
* Date  : 2018-08-07
* Author: Atiq Rahman
* Occasn: InnoWorld 2018-08-05, Daniel Lee
* Comp  : O(n lg n), O(n)
* Status: Accepted
* Notes : Once inputs are sorted this problem is easy. However, mapping gets
*   tricky.
*   
*  Explanation of algorithm:
*   We sort A.
*   We don't sort B. But we sort indices array for B which is idxB.
*   idxB[i] gives us the index of i-th item in sorted B (the index of the item
*   in B if B was sorted)
*   
*   i is the iterator in A and j is iterator in sorted B.
*   if A[i], B[j] satisfies the property then A[i] is assigned in j-th index.
*   if it does not we assign A[i] to last index of sorted B (using a reverse
*   iterator)
*
*  What have I learnt from this implementation?
*   Instead of sorting an array, we can sort its respective indice array
*   overriding the comparison in such a way so that resulting indices sort will
*   contain positions of original numbers in sorted(as if) array.
* meta  : tag-algo-sort, tag-algo-greedy, tag-lambda-exp, tag-leetcode-medium
***************************************************************************/
public class Solution
{
  public int[] AdvantageCount(int[] A, int[] B) {
    Array.Sort(A);
    // indices sort for B
    var idxB = new int[B.Length];
    for (int i=0; i<B.Length; i++)
      idxB[i] = i;
    Array.Sort(idxB, (x, y) => {
        return B[x]-B[y];
      });

    var shuffledA = new int[A.Length];
    int iB = 0;           // forward iterator of B
    int rB = B.Length-1;  // reverse iterator of B
    for (int i=0; i<A.Length; i++) {
      // readability, these 4 lines can be combined into one
      int j = idxB[iB];
      if (A[i] > B[j]) {
        shuffledA[j] = A[i]; iB++;
      }
      else
        shuffledA[idxB[rB--]] = A[i];
    }
    return shuffledA;
  }
}

/* Helpful input,
[12,24,8,32]
[13,25,32,11]

Debugging code,
Array.ForEach(preB, x => { Console.Write(" " + x); });
Console.WriteLine();

And for the else part,
Console.WriteLine("Assigning " + A[i] + " to index " + idxB[rB]);
*/

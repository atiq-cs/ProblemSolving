/***************************************************************************
* Title : Permutations
* URL   : https://leetcode.com/problems/permutations
* Date  : 2015-10
* Author: Atiq Rahman
* Comp  : O(n! * n)
* Status: Accepted
* Notes : Basic Permutation, using recursion
* meta  : tag-permutation, tag-recursion, tag-leetcode-medium
***************************************************************************/
public class Solution {
  int[] numsToPerm;
  List<IList<int>> permList;
  int n;

  public IList<IList<int>> Permute(int[] A) {
    numsToPerm = A; n = numsToPerm.Length;
    permList = new List<IList<int>>();
    Permute();
    return permList;
  }

  void Permute(int index = 0) {
    if (index == n - 1) { // == n would also work
      permList.Add(new List<int>(numsToPerm));
      return;
    }

    for (int i = index; i < n; i++) {
      Swap<int>(A, i, index);     // util.cs
      Permute(index + 1);
      Swap<int>(A, index, i);
    }
  }
}

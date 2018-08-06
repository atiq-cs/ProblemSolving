/***************************************************************************
* Title : Permutations
* URL   : https://leetcode.com/problems/permutations
* Date  : 2015-10
* Author: Atiq Rahman
* Comp  : O(n! * n)
* Status: Accepted
* Notes : Basic Permutation, using recursion
* meta  : tag-leetcode-medium, tag-recursion
***************************************************************************/
public class Solution {
  int[] numsToPerm;
  List<IList<int>> permList;
  int n;

  public IList<IList<int>> Permute(int[] A) {
    numsToPerm = A; n = numsToPerm.Length;
    permList = new List<IList<int>>();
    PermuteRec();
    return permList;
  }

  void PermuteRec(int index=0) {
    if (index == n-1) { // == n would also work
      permList.Add(new List<int>(numsToPerm));
      return ;
    }
    
    for (int i=index; i<n; i++) {
      Swap(i, index);
      PermuteRec(index+1);
      Swap(index, i);
    }
  }
  
  void Swap(int i, int j) {
    // comparison is costly comparing overall time, so avoid
    int temp = numsToPerm[i];
    numsToPerm[i] = numsToPerm[j];
    numsToPerm[j] = temp;
  }
}

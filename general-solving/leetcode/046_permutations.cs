/***************************************************************************
* Problem Name: Permutations
* Problem URL : https://leetcode.com/problems/permutations/
* Date        : Oct 2015
* Complexity  : O(n! * n)
* Author      : Atiq Rahman
* Status      : Accepted (592ms)
* Notes       : Basic Permutation
*               using recursion
*               
* meta        : tag-recursion
***************************************************************************/

public class Solution {
  int[] numsPerm;
  List<IList<int>> permList;
  public IList<IList<int>> Permute(int[] nums) {
    numsPerm = nums;
    permList = new List<IList<int>>();

    PermuteRec(0);
    return permList;
  }
  
  void PermuteRec(int index) {
    if (index == numsPerm.Length -1) {
      permList.Add(new List<int>(numsPerm));
      return ;
    }
    
    for (int i=index; i<numsPerm.Length; i++) {
      Swap(i, index);
      PermuteRec(index+1);
      Swap(index, i);
    }
  }
  
  void Swap(int i, int j) {
    // comparison is costly comparing overall time, so avoid
    int temp = numsPerm[i];
    numsPerm[i] = numsPerm[j];
    numsPerm[j] = temp;
  }
}

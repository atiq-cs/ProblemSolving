/***************************************************************************
* Problem Name: Permutations
* Problem URL : https://leetcode.com/problems/permutations/
* Date        : Oct 2015
* Complexity  : O() Time
* Author      : Atiq Rahman
* Status      : Accepted (592ms)
* Notes       : Basic Permutation
*               using recursion
*               
* meta        : tag-recursion
***************************************************************************/

public class Solution {
    List<int> numsPerm;
    List<IList<int>> permList;
    public IList<IList<int>> Permute(int[] nums) {
        permList = new List<IList<int>>();
        numsPerm = new List<int>(nums.Length);
        foreach (var item in nums)
            numsPerm.Add(item);
        PermuteRec(0);
        return permList;
    }
    
    void PermuteRec(int index) {
        if (index == numsPerm.Count -1) {
            permList.Add(new List<int>(numsPerm));
            return ;
        }
        
        PermuteRec(index+1);
        for (int i=index+1; i<numsPerm.Count; i++) {
            int temp = numsPerm[i]; numsPerm[i] = numsPerm[index]; numsPerm[index] = temp;
            PermuteRec(index+1);
            temp = numsPerm[index]; numsPerm[index] = numsPerm[i]; numsPerm[i] = temp;
        }
    }
}

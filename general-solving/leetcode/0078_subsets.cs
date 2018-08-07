/***************************************************************************
* Title : Subsets
* URL   : https://leetcode.com/problems/subsets
* Date  : 2018-08-06
* Author: Atiq Rahman
* Occasn: InnoWorld 2018-07-22, Charan
* Comp  : O(2^n), O(2^n)
* Status: Accepted
* Notes : Following are tricky and solved,
* - DeepCopy of List of HashSet
* - Initializer list for List<HashSet<int>> is HashSet<int>[], goes inside ()
* - ForEach onliner with lambda syntax
*   
*  Explanation of algorithm:
* - Start with a list containing an empty list
* - Add a temp variable new subsets which contains the list adding just one
* - item from origin input array
* - Add this new list to original list
*   
*   While adding each item/number ensure that set already does not contain it
*   This problem is suitable for hashset solution since it inquires unique
*   items.
*
*   Complexity: output list grows double in each iteration. Therefore,
*   complexity is exponential to 2.
*   ToDo: check npp draft if found
*   This also can be implemented recursively
*   Shallow Copy ref: https://stackoverflow.com/q/9648327
* meta  : tag-leetcode-medium, tag-hash-table, tag-lambda
***************************************************************************/
public class Solution {
  public IList<IList<int>> Subsets(int[] nums) {
    var subsets = new List<HashSet<int>>(new HashSet<int>[] { new
      HashSet<int>() } ); // initialize with an empty HashSet
    foreach( var num in nums) {
      var newSubsets = new List<HashSet<int>>(DeepCopy(subsets));
      for (int i=0; i<newSubsets.Count; i++)
        if (newSubsets[i].Contains(num) == false)
          newSubsets[i].Add(num);
      subsets.AddRange(newSubsets);
    }
    // List of HashSet to List of List
    var result = new List<IList<int>>();
    subsets.ForEach(s => result.Add(s.ToList()));
    return result;
  }  
  
  private List<HashSet<int>> DeepCopy(List<HashSet<int>> subsets) {
    var result = new List<HashSet<int>>();
    subsets.ForEach(s => result.Add(new HashSet<int>(s)));
    return result;
  }
}

/* Debugging code,
PrintSubsets(subsets);

private void PrintSubsets(List<HashSet<int>> sets) {
  foreach( var s in sets) {
    s.ForEach(num => Console.Write(" " + num););
    Console.WriteLine();
  }
  Console.WriteLine();    
}
*/

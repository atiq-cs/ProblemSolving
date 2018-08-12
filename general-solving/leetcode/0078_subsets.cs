/***************************************************************************
* Title : Subsets
* URL   : https://leetcode.com/problems/subsets
* Date  : 2018-08-06
* Author: Atiq Rahman
* Occasn: InnoWorld 2018-07-22, Charan, update: Den 2018-09-11
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
   // fourth: ack: Adam, use less temporary space by insert list into original
   // result collection
  public IList<IList<int>> Subsets(int[] nums) {
    var subsets = new List<IList<int>>(new List<int>[] { new List<int>() } );
    foreach( var num in nums) {
      int len = subsets.Count; for (int i=0; i<len; i++) {
        subsets.Add(new List<int>(subsets[i]));
        subsets[subsets.Count-1].Add(num);
      }
    }
    return subsets;
  }

  // third: uses List, no deep copy
  public IList<IList<int>> Subsets(int[] nums) {
    var subsets = new List<IList<int>>(new List<int>[] { new List<int>() } );
    foreach( var num in nums) {
      var newSubsets = new List<IList<int>>();
      subsets.ForEach(s => {
          newSubsets.Add(new List<int>(s));
          newSubsets[newSubsets.Count-1].Add(num);
        });
    }    
    return subsets;
  }

  // second: no hashset, converted the HashSet version to List

  // first version
  public IList<IList<int>> Subsets(int[] nums) {
    var subsets = new List<HashSet<int>>(new HashSet<int>[] { new
      HashSet<int>() } ); // initialize with an empty HashSet
    foreach( var num in nums) {
      var newSubsets = new List<HashSet<int>>(DeepCopy(subsets));
      for (int i=0; i<newSubsets.Count; i++)
        // checking uniqueness not required; given inputs are distinct integers
        // if (newSubsets[i].Contains(num) == false)
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

/* Draft
nums = [1,2,3]
{1},
{2},
{3}

i=1
add {1}
then add 2 will all of them
{1}
{1, 2}

i=2
add {2}
I have
{1}
{2}
{1, 2}
I add 3 with all of them

2, 6, 14

if numbers are unique then complexity is 2^n

Debugging code,
PrintSubsets(subsets);

private void PrintSubsets(List<HashSet<int>> sets) {
  foreach( var s in sets) {
    s.ForEach(num => Console.Write(" " + num););
    Console.WriteLine();
  }
  Console.WriteLine();    
}
*/

/***************************************************************************
* Title : Subsets
* URL   : https://leetcode.com/problems/subsets
* Date  : 2018-08-06
* Author: Atiq Rahman
* Occasn: InnoWorld 2018-07-22, Charan, update: Den 2018-09-11
* Comp  : O(2^n), O(2^n)
* Status: Accepted
* Notes : Following are tricky and solved (consider handling duplicates is
*  required),
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
*   ToDo, check npp draft if found
*   This also can be implemented recursively
*   
*   Qiagen wants this to be recursive
*   Shallow Copy ref: https://stackoverflow.com/q/9648327
* rel   : https://leetcode.com/problems/subsets-ii/
* meta  : tag-subsets, tag-recursion, tag-csharp-initializer-syntax, tag-company-qiagen,
*   tag-leetcode-medium
***************************************************************************/
public class Solution {
  // top down recursion
  public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
      return subHelper(nums, nums.Length);
    }

    public IList<IList<int>> subHelper(int[] nums, int index) {
      if (index == 0)
        return new List<IList<int>>(new IList<int>[] { new List<int>() });

      var temp = subHelper(nums, index - 1);
      int tempLength = temp.Count;

      for (int i = 0; i < tempLength; i++) {
        temp.Add(new List<int>(temp[i]));
        temp[temp.Count - 1].Add(nums[index - 1]);
      }
      return temp;
    }
  }

  // bottom-up recursion
  public IList<IList<int>> Subsets(int[] nums) {
    return subHelper(nums, nums.Length);
  }

  public IList<IList<int>> subHelper(int[] nums, int index) {
    if (index == 0)
      return new List<IList<int>>(new IList<int>[] { new List<int>() });

    var temp = subHelper(nums, index - 1);
    int tempLength = temp.Count;
    for (int i = 0; i < tempLength; i++) {
      temp.Add(new List<int>(temp[i]));
      temp[temp.Count - 1].Add(nums[index - 1]);
    }
    return temp;
  }

  public IList<IList<int>> subHelper(int[] nums, int index) {
    if (index == 0)
      return new List<IList<int>>( new[] { new List<int>() });

    var temp = subHelper(nums, temp, index - 1);
    int tempLength = temp.Count;
    for (int i = 0; i < tempLength; i++) {
      temp.Add(new List<int>(temp[i]));
      temp[temp.Count - 1].Add(nums[index]);
    }
    return subHelper(nums, index + 1);
  }


  // Fifth: recursion ack Cory
  public IList<IList<int>> Subsets(int[] nums) {
    return subHelper(nums, new List<IList<int>>(), 0);
  }

  public IList<IList<int>> subHelper(int[] nums, IList<IList<int>> temp, int index) {
    if (index == nums.Length)
      return temp;
    if (index == 0)
      temp.Add(new List<int>());

    int tempLength = temp.Count;
    for (int i = 0; i < tempLength; i++) {
      temp.Add(new List<int>(temp[i]));
      temp[temp.Count - 1].Add(nums[index]);
    }
    return subHelper(nums, temp, index + 1);
  }

  // result collection
  public IList<IList<int>> Subsets(int[] nums) {
    var subLists = new List<IList<int>>(new List<int>[] { new List<int>() });

    foreach (var num in nums) {
      int len = subLists.Count;

      for (int i = 0; i < len; i++) {
        subLists.Add(new List<int>(subLists[i]));
        subLists[subLists.Count - 1].Add(num);
      }
    }
    return subLists;
  }


  // fourth: ack: Adam, use less temporary space by insert list into original
  // result collection
  public IList<IList<int>> Subsets(int[] nums) {
    var subLists = new List<IList<int>>(new List<int>[] { new List<int>() } );

    foreach( var num in nums) {
      int len = subLists.Count;

      for (int i=0; i<len; i++) {
        subLists.Add(new List<int>(subLists[i]));
        subLists[subLists.Count-1].Add(num);
      }
    }
    return subLists;
  }

  // third: uses List, no deep copy
  public IList<IList<int>> Subsets(int[] nums) {
    var subLists = new List<IList<int>>(new List<int>[] { new List<int>() } );
    foreach( var num in nums) {
      var newSubsets = new List<IList<int>>();
      subLists.ForEach(s => {
          newSubsets.Add(new List<int>(s));
          newSubsets[newSubsets.Count-1].Add(num);
        });
    }    
    return subLists;
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

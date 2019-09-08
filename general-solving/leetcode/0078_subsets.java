/***************************************************************************
* Title : Subsets
* URL   : https://leetcode.com/problems/subsets
* Date  : 2019-02-20
* Comp  : O(2^n), O(2^n)
* Status: Accepted
* Notes : ack for this recursive idea is cory
*  Probably his preferred is top down, bottom-up is an interpretation from my iterative solution
* meta  : tag-csharp-lang-initializer-syntax, tag-company-qiagen, tag-leetcode-medium
***************************************************************************/
class Solution {
  public List<List<Integer>> subsets(int[] nums) {
    return subHelper(nums, nums.length);
    // call for bottom-up
    // return subHelper(nums, new ArrayList<List<Integer>>(), 0);
  }
  
  // top down recursion
  public List<List<Integer>> subHelper(int[] nums, int index) {
    if (index == 0)
      return new ArrayList<List<Integer>>(Arrays.asList(new ArrayList<Integer>()));

    List<List<Integer>> temp = subHelper(nums, index - 1);
    int tempLength = temp.size();
    for (int i = 0; i < tempLength; i++) {
      temp.add(new ArrayList<Integer>(temp.get(i)));
      temp.get(temp.size() - 1).add(nums[index-1]);
    }
    return temp;
  }

  // bottom-up recursion
  public List<List<Integer>> subHelper(int[] nums, List<List<Integer>> temp, int index) {
    if (index == nums.length)
      return temp;
    if (index == 0)
      temp.add(new ArrayList<Integer>());

    int tempLength = temp.size();
    for (int i = 0; i < tempLength; i++) {
      temp.add(new ArrayList<Integer>(temp.get(i)));
      temp.get(temp.size() - 1).add(nums[index]);
    }
    return subHelper(nums, temp, index + 1);
  }
}

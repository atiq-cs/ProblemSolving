/***************************************************************************************************
* Title : Largest Number
* URL   : https://leetcode.com/problems/largest-number/
* Date  : 2015-10-17
* Comp  : O(n log n)
* Author: Atiq Rahman
* Status: Accepted (Runtime beats 88% C# submissions)
* Notes : This approach is revised for cleaner code, still corner cases might exist
* meta  : tag-algo-sort, tag-leetcode-medium
***************************************************************************************************/

/*
* We implement the comparer part
* Initial approach was to simply check for digits from number left to right
*  - continue as long as digits match
*  - whenever a mismatch is found return -1 if left is large
*   - return 1 otherwise
* if one number becomes zero by dividing return that number

* Later, I had to handle a case when the number can be repeated inside another number, i.e.,
*   4324325, 432
* In case of previous implementation this would return right number
* So re-initialize the numbers when it reaches 0

* Considerations: another approach to solve the problem would be to
*  - convert numbers to strings
*  - iterate over two strings and compare char by char and decide which one should be placed first
* Special Inputs
  max input limit: 2,147,483,647 (more than this will produce a run-time error)

  [21, 2121212122]
  [120, 12, 122, 10, 1, 4321, 432, 43, 99, 9, 998]
  [120, 12]
  [432, 432432432]
  [23, 232323232]
  [232323232, 23]
  [23, 232323232]
  [232323232, 23]
  [232323232, 23]
  [23, 232323233]
  [5454, 540]
  [1]
  [1,2,3,4,5,6,7,8,9,0]
*/

public class NumComparer : IComparer<int>
{
  public int Compare(int x, int y) {
    int tx = x, ty = y;
    if (x == y)
      return 0;
    // max power of 10 in int limit
    int px = 1000000000;
    int py = px;
    while (px > 0 && x / px == 0)
      px /= 10;
    while (py > 0 && y / py == 0)
      py /= 10;
    int tpx = px, tpy = py;

    int resx, resy;
    do
    {
      resx = px == 0 ? 0 : x / px;
      resy = py == 0 ? 0 : y / py;
      if (resx == resy)
      {
        x = x % px; y = y % py;
        px /= 10; py /= 10;
        if (px == 0 && py == 0)
          break;
        if (py == 0)
        {
          y = ty;
          py = tpy;
        }
        if (px == 0)
        {
          x = tx;
          px = tpx;
        }
      }
    } while (resx == resy);

    return resy - resx;
  }
}

public class Solution
{
  public string LargestNumber(int[] nums) {
    NumComparer numComp = new NumComparer();
    Array.Sort(nums, numComp);
    string result = string.Join("", nums.Select(x => x.ToString()).ToArray());

    if (string.IsNullOrEmpty(result.TrimStart('0')))
      return "0";

    return result;
  }
}

// To demonstrate the code locally add following part
public class Demo
{
  private static void Main() {
    Solution sol = new Solution();
    // int[] nums = { 120, 12, 122, 10, 1, 4321, 432, 43, 99, 9, 998 };
    // int[] nums = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };
    // int[] nums = { 120, 12 };
    int[] nums = { 120, 12, 122, 10, 1, 4321, 432, 43, 99, 9, 998 };
    Console.WriteLine(sol.LargestNumber(nums));
  }
}

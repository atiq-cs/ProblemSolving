/***************************************************************************
* Title : Container With Most Water
* URL   : https://leetcode.com/problems/container-with-most-water
* Occasn: JS Meetup Arrays and Strings 2014-08-18
* Date  : 2018-04-18
* Author: Atiq Rahman
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : Sliding window approach (unsorted input data)
*   Why does it work? Why would not we miss a solution especially when input
*   data is not sorted?
*
*   Basically you are just trying to find the furthest taller edge the current
*   one [i] can reach - a further but slightly taller edge, is better than a
*   huge tall edge that is closer, since the max container is limited by each
*   edge [i] itself - being the shorter edge. If [i] is the tallest, it can
*   form no containers with its height.
*   
*   Two-pointers solution, walking from each end, guarantees the shorter edge
*   meets its furthest taller edge. Simple as that.
*   ref: https://leetcode.com/problems/container-with-most-water/discuss/6099/
*   Yet-another-way-to-see-what-happens-in-the-O(n)-algorithm
*   
*   ref: https://articles.leetcode.com/searching-2d-sorted-matrix-part-ii/
* meta  : tag-sliding-window, tag-leetcode-medium
***************************************************************************/
public class Solution
{
  public int MaxArea(int[] height) {
    int low = 0;
    int high = height.Length -1;
    int maxArea = 0;
    
    while (low < high) {
      int area = (high-low) * Math.Min(height[low], height[high]);
      maxArea = Math.Max(maxArea, area);

      if (height[low] < height[high])
        low++;
      else
        high--;
    }
    return maxArea;
  }
}

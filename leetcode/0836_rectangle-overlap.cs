/***************************************************************************
* Title : Rectangle Overlap
* URL   : https://leetcode.com/problems/rectangle-overlap
* Date  : 2018-08-05
* Author: Atiq Rahman
* Comp  : O(1), O(1)
* Occasn: InnoWorld meetup 2018-08-05, Indi presented to somebody
* Status: Accepted
* Notes : Find the intersecting rectangle. Based on that return result.
*   For this problem, if a side of a rectangle falls on a side of the other
*   rectangle's side it is not considered overlap.
*   
*   Probably solved before.
* meta  : tag-math, tag-geometry, tag-leetcode-easy
***************************************************************************/
// leetcode does not support this way, I had to reference the whole namespace
// inside code
//using System.Drawing;   

public class Solution {
  public bool IsRectangleOverlap(int[] rec1, int[] rec2) {
    // Form an intersection rectangle based on provided rectangles
    // rec: A rectangle is represented as a list [x1, y1, x2, y2]
    // where (x1, y1) is top left and (x2, y2) is bottom right
    var intersectBottomLeft = new System.Drawing.Point(Math.Max(rec1[0],
      rec2[0]), Math.Max(rec1[1], rec2[1]));  // max(x1, x3), max(y1, y3)
    var intersectTopRight = new System.Drawing.Point(Math.Min(rec1[2],rec2[2]),
      Math.Min(rec1[3], rec2[3]));            // max(x2, x4), max(y2, y4)

    if (intersectBottomLeft.X >= intersectTopRight.X)
      return false;
    if (intersectBottomLeft.Y >= intersectTopRight.Y)
      return false;
    return true;
  }
}

/***************************************************************************************************
* Title : Merge Intervals
* URL   : https://leetcode.com/problems/merge-intervals
* Date  : 2018-07-01
* Author: Atiq Rahman
* Comp  : O(n lg n), O(n)
* Status: Accepted
* Notes : Given a list of intervals merge intervals which are overlapped and return new list
*
*   Similar to insert interval problem. In that problem we are given intervals in sorted order
*   In that problem the new interval could be any where (before, after, inside/overlapping).
*   Because of the sorting, in this problem all newly appearing intervals are either overlapping or
*   not.
*   
*   Similar to line sweep algo.
*
*   Cast IList to List ref: https://stackoverflow.com/q/2207341
*   Demonstrates use of lambda expression with List.Sort
* rel   : https://leetcode.com/problems/insert-interval
* meta  : tag-intervals, tag-algo-sort, tag-csharp-lambda-exp
***************************************************************************************************/
public class Solution
{
  /// <summary>
  /// Template method to fill in to complete merge on intervals
  /// <remarks>
  /// related ref, Sort vs OrderBy: C# Sort and OrderBy comparison
  ///  https://stackoverflow.com/q/1832684
  /// </remarks>
  /// </summary>
  /// <param name="iIntervals"> Input intervals list to merge </param>
  public IList<Interval> Merge(IList<Interval> iIntervals) {
    // Construct a List from IList as IList does not have Sort
    List<Interval> intervals = new List<Interval>(iIntervals);
    intervals.Sort((Interval a, Interval b) =>
        a.start == b.start? a.end - b.end : a.start-b.start);

    Interval previous = null;
    var result = new List<Interval>();
    foreach(var current in intervals) {
      if (previous != null) {
        if (previous.end < current.start)
          result.Add(previous);
        // overlap found, hence, current interval is extending
        else {
          current.start = Math.Min(previous.start, current.start);
          current.end = Math.Max(previous.end, current.end);
        }
      }
      // at this current point becomes previous
      previous = current;
    }
    if (previous != null)
      result.Add(previous);
    return result;
  }
}

/* The lambda exp can be written as,
  {
    if (a.start==b.start)
      return a.end-b.end;
    return a.start-b.start;
  }
*/

/***************************************************************************
* Title : Insert Interval
* URL   : https://leetcode.com/problems/insert-interval
* Date  : 2018-05-10
* Comp  : O(N), O(N)
* Status: Accepted
* Notes : Given that input intervals are in sorted order of start time
*   3 cases to consider,
*   - no overlap: current iteration interval ends before new interval
*   - overlap: new interval falls inside inside current interval
*   - interval overlaps without completely falling in inside
*   
*   In 2nd case, we add both intervals
*   In 3rd we only update the new Interval
*   Note, in the end, new Interval might not be added if last interval found
*   had started before the new interval. Therefore, in the end we still add the
*   new interval
* 
*   tagged as hard problem; not really hard problem
* meta  : tag-interval, tag-leetcode-hard
***************************************************************************/
using System.Collections.Generic;

public class Solution
{
  /// <summary>
  /// Insert or merge the given interval properly
  /// </summary>
  /// <param name="intervals"> Collection of intervals </param>
  /// <param name="newInt"> The new interval to insert </param>
  /// <returns></returns>
  public IList<Interval> Insert(IList<Interval> intervals, Interval newInt) {
    IList<Interval> result = new List<Interval>();

    foreach(var current in intervals)
      // case 1, current ends before new starts
      if (newInt == null || current.end < newInt.start)
        result.Add(current);
      // new interval is falling inside the current
      // now why would this work?? adding both of 
      // interval.end >= newInterval.start
      // prev cond ensures, current ends after new starts
      // this cond ensures, new ends after current starts
      // example,    ---------x_______x----------___
      //  where x represents new's start and end, _ represents where current ended
      else if (newInt.end < current.start) {
        result.Add(newInt);
        result.Add(current);
        newInt = null;
      }
      // prev cond ensures, new ends after current starts
      // prev prev cond ensures, current ends after new starts
      // not falling inside but overlap
      // example,   -----x------______x
      else {
        newInt.start = Math.Min(current.start, newInt.start);
        newInt.end = Math.Max(current.end, newInt.end);
      }


    if (newInt != null)
      result.Add(newInt);
    return result;
  }
}

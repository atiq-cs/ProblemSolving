/***************************************************************************
* Title : Insert Interval
* URL   : https://leetcode.com/problems/insert-interval
* Date  : 2018-05-10
* Author: Atiq Rahman
* Comp  : O(N), O(N)
* Status: Accepted
* Notes : Given that input intervals are in sorted order of start time
*   3 cases to consider,
*   - current iteration interval ends before new interval
*   - current iteration interval starts after new interval
*   - intervals overlap
*   
*   In 2nd case, we add both intervals
*   In 3rd we only update the new Interval
*   Note, in the end, new Interval might not be added if last interval found
*   had started before the new interval. Therefore, in the end we still add the
*   new interval
* 
*   tagged as hard problem; not really hard problem
* meta  : tag-leetcode-hard
***************************************************************************/
using System.Collections.Generic;

public class Solution {
  public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval) {
    IList<Interval> result = new List<Interval>();
    foreach(Interval interval in intervals) {
      if (newInterval == null || interval.end < newInterval.start)
        result.Add(interval);
      else if (interval.start > newInterval.end) {
        result.Add(newInterval);
        result.Add(interval);
        newInterval = null;
      }
      else {
        newInterval.start = Math.Min(interval.start, newInterval.start);
        newInterval.end = Math.Max(interval.end, newInterval.end);
      }
    }
    if (newInterval != null)
      result.Add(newInterval);
    return result;
  }
}

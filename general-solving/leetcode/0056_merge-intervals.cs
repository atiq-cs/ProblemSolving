/***************************************************************************
* Title : Merge Intervals
* URL   : https://leetcode.com/problems/merge-intervals
* Date  : 2018-07-01
* Author: Atiq Rahman
* Comp  : O(n lg n), O(n)
* Status: Accepted
* Notes : Similar to insert interval problem. Less conditional logic because
*   whole thing is in sorted order whereas in the prior problem the new
*   interval could be any where (before, after, inside/overlapping).
*   Because of the sorting, in this problem all newly appearing intervals are
*   either overlapping or not.
*   
*   Similar to line sweep algo.
* 
*   Cast IList to List ref: https://stackoverflow.com/q/2207341
*   Demonstrates use of lambda expression with List.Sort
* rel   : https://leetcode.com/problems/insert-interval
* meta  : tag-string, tag-kmp, tag-lambda
***************************************************************************/
public class Solution {
  public IList<Interval> Merge(IList<Interval> iIntervals) {
    // Cast IList to List. Otherwise, Sort throws an exception.
    List<Interval> intervals = new List<Interval>(iIntervals);
    intervals.Sort((Interval a, Interval b) => {
        if (a.start==b.start)
          return a.end-b.end;
        return a.start-b.start;
      });
    
    Interval previous = null;
    var result = new List<Interval>();
    foreach(var current in intervals) {
      if (previous != null) {
        if (previous.end < current.start)
          result.Add(previous);
        // overlap found, heance, current interval is extending.
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

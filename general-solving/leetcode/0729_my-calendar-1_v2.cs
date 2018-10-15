/***************************************************************************************************
* Title : My Calendar I
* URL   : https://leetcode.com/problems/my-calendar-i
* Date  : 2018-01
* Author: Atiq Rahman
* Comp  : O(n^2) where number of queries approximately equals to number of
*   bookings = n
* Status: Accepted
* Notes : Briefly the problem statement looks like,
*   MyCalendar.book(10, 20); // returns true
*   MyCalendar.book(15, 25); // returns false
*   MyCalendar.book(20, 30); // returns true
*   
*   Calendar has booking entries. Each booking entry is described by an open
*   half interval [start, end). It starts from 'start' and ends before 'end'. A
*   new booking's interval cannot intersect with the entries in the calendar.
*   
*   Consider 5 overlapping cases for two bookings [s1, e1) and [s2, e2)
*   left overlap    s1   e2
*   full overlap   s1/s2 e1/e2
*   right overlap   s2   e1
*   both overlap (outside)  s1  e1
*   both overlap (inside)   s2  e2
*   
*   Consider no overlapping 2 cases,
*   no overlap (left)   s1  e2
*   no overlap (right)  s2  e1
*   
*   If we say, max = Max (s1, s2) and min = Min (e1, e2) then,
*   there is no overlap when max >= min
*   
* meta  : tag-math, tag-leetcode-easy
***************************************************************************************************/
public class MyCalendar
{
  private List<Booking> bookings;

  public class Booking {
    public int start { get; set; }
    public int end { get; set; }
    public Booking(int start, int end) { this.start = start; this.end = end; }
  }

  public MyCalendar() {
    bookings = new List<Booking>();
  }
  
  public bool Book(int start, int end) {
    if (IsEmptyIntersection(start, end) == false)
      return false;
    bookings.Add(new Booking(start, end));
    return true;
  }

  private bool IsEmptyIntersection(int start, int end) {
    foreach( Booking book in bookings) {
      int startMax = Math.Max(start, book.start);
      int endMin = Math.Min(end, book.end);
      if (startMax < endMin)
        return false;
    }
    return true;
  }
}

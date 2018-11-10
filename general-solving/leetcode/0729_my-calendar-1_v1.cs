/***************************************************************************
* Title : My Calendar I
* URL   : https://leetcode.com/problems/my-calendar-i
* Date  : 2018-01-06
* Author: Atiq Rahman
* Comp  : O(n^2)
* Status: Accepted
* Notes : Detailed note is at '729_my-calendar-1_v2.cs'
*   This first version has slightly more code than v2. However, might be easier
*   to understand, self-explanatory code. Similar to interval problem.
*
* meta  : tag-math, tag-leetcode-easy
***************************************************************************/
public class MyCalendar {
  public class Booking {
    public int start { get; set; }
    public int end { get; set; }
    public Booking(int start, int end) { this.start = start; this.end = end; }
  }
  
  public List<Booking> bookings;

  public MyCalendar() {
    bookings = new List<Booking>();
  }
  
  public bool Book(int start, int end) {
    if (! IsEmptyIntersection(start, end))
      return false;
    
    bookings.Add(new Booking(start, end));
    return true;
  }
  
  private bool IsEmptyIntersection(int start, int end) {
    foreach( Booking book in bookings) {
      // start lying inside
      if (book.start <= start && start < book.end)
        return false;
      // start not lying inside but end lying inside
      if (book.start < end && end <= book.end)
        return false;
      // start and end don't lie inside, the range specified in book lies inside instead
      if (start < book.start && book.end < end)
        return false;
    }
    return true;
  }
}

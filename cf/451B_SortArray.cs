/***************************************************************************************************
* Title : Sort the Array
* URL   : http://codeforces.com/problemset/problem/451/B
* Occasn: Codeforces Round #258 (Div. 2)
* Date  : 2017-11-01
* Comp  : O(n) 78ms, Space O(n), 11300 KB
* Author: Atiq Rahman
* Status: Accepted
* Notes : Naive: sort the array and find diff sequence to reverse
*   Approach O(n),
*   Finding the starting and ending index of the segment that is in reverse
*   order.
*
*   Input numbers are distinct integers, not equal
*   Judge has some large inputs, good for testing.
*
* meta  : tag-algo-sort, tag-implementation, tag-easy
***************************************************************************************************/
using System;

class RSSolution {  // Reverse segment Solution Class
  private int n;
  private int[] A;
  private int start;
  private int end;

  public void TakeInput() {
    n = int.Parse(Console.ReadLine());
    A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
  }

  /*
   * Returns true if a reverse interval that fits the requirements is found
   * Sets class members: start, end
   * 
   * Explanation of the Algorithm:
   * find the index from which numbers are not in sorted order anymore
   * From that index, keep searching and find the index till which numbers are
   * not in reverse sorted order.
   * 
   * Check if found segment of the array that is in reverse sorted array falls
   * within the range of the original array
   */
  private bool GetReverseInterval() {
    int i;
    // all a[i] are distinct < or <= should work
    for (i=0; i < n-1 && A[i] < A[i + 1]; i++);
    start = i;
    // a[i] are distinct
    for (i=start; i < n-1 && A[i] > A[i + 1]; i++);
    end = i;
    // verify if rest of the array is sorted
    // index end is verified by previous loop; start from end+1
    for (i = end+1; i < n - 1 && A[i] < A[i + 1]; i++);
    if (i < n - 1)  // not sorted
      return false;
    // check if found interval falls inside the array
    // first part of the condition checks if the first element in the reverse
    // segment is smaller than the next item which lies right after the segment
    // Second part checks if previous element lying right before the segement
    // is less than the last element in the segment
    return (end+1==n || A[start] < A[end + 1]) && (start==0 || A[start-1] < A[end]);
  }

  public void Run() {
    if (GetReverseInterval()) {
      Console.WriteLine("yes");
      start++; end++; // convert to 1-based index
      Console.WriteLine(start + " " + end);
    }
    else
      Console.WriteLine("no");
  }
}

public class CFSolution {
  private static void Main() {
    RSSolution revSegmentDemo = new RSSolution();
    revSegmentDemo.TakeInput();
    revSegmentDemo.Run();
  }
}

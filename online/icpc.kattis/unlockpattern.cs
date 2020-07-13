/***************************************************************************
* Title       : Unlock Pattern
* URL         : https://open.kattis.com/problems/unlockpattern
* Occasion    : The 3rd ProgNova Programming Contest by NYU CS
* Date        : 2017-10-15
* Complexity  : O(n), where n is number of pivots in the grid, n = row * column
* Status      : Accepted
* Notes       : Traverse each node starting from 2 to 9 and add the distances
*   with previous node. Properly display the output specifying number of digits
*   to display for fixed point floating number
*   
*   Lesson from this problem of ProgNova Contest **
*   - Programming language barrier/differences for floating point specification
*    on output. Pay attention to the number of digits displayed after
*    the decimal point.
*   cpp version of interest (tried in beginning, not sure AC) https://ideone.com/WKihuH
* Ref         : https://prognova17.kattis.com/
* meta        : tag-oj-kattis, tag-math, tag-easy
***************************************************************************/
using System;

public class Point {
  public int x;
  public int y;

  public Point(int r, int c) {
    y = r;
    x = c;
  }
}

class UnlockPattern {
  // like global vars
  const int RowLimit = 3;
  const int ColumnLimit = 3;

  // our private data members
  int[][] grid;
  Point[] points;

  public UnlockPattern() {
    grid = new int[RowLimit][];
    for (int i = 0; i < RowLimit; i++)
      grid[i] = new int[ColumnLimit];

    points = new Point[RowLimit * ColumnLimit];
  }

  // representation should be taken, process input
  public void TakeInput() {
    // i = row iterator
    for (int i = 0; i <3; i++) {
      string[] tokens = Console.ReadLine().Split();
      // j = column iterator
      for (int j = 0; j < ColumnLimit; j++) {
        int num = grid[i][j] = int.Parse(tokens[j]) - 1;
        points[num] = new Point(i, j);
      }
    }
  }

  public double GetPatternLength() {
    double length = 0.0;
    // we start calculating from second index
    // second index gets the distance from first one
    // 3rd one gets from 2nd and so on..
    for (int i = 1; i < RowLimit * ColumnLimit; i++) {
      int x1 = points[i-1].x;
      int y1 = points[i-1].y;
      int x2 = points[i].x;
      int y2 = points[i].y;
      length += Math.Sqrt((x2-x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    }
    return length;
  }
}

public class Solution {
  public static void Main() {
    UnlockPattern unlockPattern = new UnlockPattern();
    unlockPattern.TakeInput();
    Console.WriteLine("{0:F10}", unlockPattern.GetPatternLength());
  }
}

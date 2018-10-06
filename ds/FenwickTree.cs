/***************************************************************************
* Title : Binary Indexed Tree
* URL   : http://citeseerx.ist.psu.edu/viewdoc/download?doi=10.1.1.14.8917&
*   rep=rep1&type=pdf
* Date  : 2018-09
* Author: Atiq Rahman
* Comp  : O(lg N)
* Notes : Why Fenwick Tree (BIT)?
*   - Can update and compute prefix sum in lg N time.
*   - Uses less memory than RMQ
*   
*   In this implementation, 1 based index, 0 is the root of all nodes, not
*   touched
*   Current implementation uses an array of long to pass tests with large
*   numbers (https://codeforces.com/contest/296/problem/C)
*   
* Ref   : SOFTWARE—PRACTICE AND EXPERIENCE, VOL. 24(3), 327–336 (MARCH 1994)
*   "A New Data Structure for Cumulative Frequency Tables" by peter m. fenwick
*   In Paper link above we got a nice figure of an example BIT.
*
*   https://www.topcoder.com/community/data-science/data-science-tutorials/
*   binary-indexed-trees/ provides an example how a sum is computed for
*   index = 13, [13] + [12] + [8]. Example, uses two arrays f and c.
*   Practically we might be able to do only with c. tree[idx] is c[i] in our
*   implementation.
*
*   https://sanugupta.wordpress.com/2014/08/29/binary-indexed-tree-fenwick-tree/
*   average article on the topic
* meta  : tag-tree
***************************************************************************/
using System;

public class FenwickTree {
  long[] nums;
  int Size;

  public FenwickTree(int n) {
    Size = n+1;
    nums = new long[Size];
  }

  private int LSB(int x) { return x & -x; }
  // Lookup cumulative value
  public long Sum(int i) {
    if (i< 0 || i > Size)
      return -1;
    long sum = 0;
    while (i > 0) {
      sum += nums[i];
      i &= (i-1);
    }
    return sum;
  }

  public void Add(int i, long k) {
    if (i<1)
      throw new ArgumentException();
    while (i < Size) {
      nums[i] += k;
      i += LSB(i);
    }
  }

  // not used
  // range based addition of values
  public void Add(int l, int r, int k) {
    if (l < 1 || r > Size)
      throw new ArgumentException();
    int i = l;
    while (i<=r) {
      nums[i] += k;
      i += LSB(i);
    }
    /* this is wrong apprach: because LSB of 9 is not gonna be same as 8's
    int nextLSB = i;
    for (i = r + 1; i < Size && i < nextLSB; i++)
      nums[i] -= k; */
    // correct approach would be
    i = r+1;
    while (i<Size) {
      nums[i] -= k;
      i += LSB(i);
    }
  }

  public void ShowResult() {
    var sb = new System.Text.StringBuilder();
    for (int i = 1; i < Size; i++)
      sb.Append(" " + Sum(i));
    Console.WriteLine(sb.ToString());
  }
}

/* Debugging stuff..
public void PrintArray() {
  Console.WriteLine("vals:");
  foreach( var num in nums)
    Console.Write(" " + num);
  Console.WriteLine();
  Console.WriteLine("nums array:");
  for (int i=1; i<Size; i++)
    Console.Write(" " + Sum(i));
  Console.WriteLine();
}*/

/*
Interesting input add 1 to range 4 -> 8
16 3 3
1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16
1 2 1
1 3 2
2 3 4
4 8
1 2
1 3
2 3
*/

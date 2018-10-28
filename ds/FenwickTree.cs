/***************************************************************************************************
* Title : Binary Indexed Tree
* URL   : http://citeseerx.ist.psu.edu/viewdoc/download?doi=10.1.1.14.8917&rep=rep1&type=pdf
* Date  : 2018-09
* Author: Atiq Rahman
* Comp  : O(lg N)
* Notes : Why Fenwick Tree (BIT)?
*   - Can update and query Range Sum in lg N time
*   - Uses less memory than RMQ
*   
*   In the beginning implementation I did is 1 based index, 0 was the root of all nodes, hence, I
*   decided not to touch that index. Then, I updated it to utilize index 0 as well. See method
*   documentation.
*   
*   Can use an array of long to pass tests with large numbers
*     (https://codeforces.com/contest/296/problem/C)
*   
* ref   : SOFTWARE—PRACTICE AND EXPERIENCE, VOL. 24(3), 327–336 (MARCH 1994)
*   "A New Data Structure for Cumulative Frequency Tables" by peter m. fenwick (paper link: URL)
*   In Paper link (p#3) above we got a nice figure of an example BIT.
*
*   https://www.topcoder.com/community/data-science/data-science-tutorials/binary-indexed-trees/
*   provides an example how a sum is computed for index = 13, [13] + [12] + [8]. Example, uses two
*   arrays f and c.
*   Practically we might be able to do only with c. tree[idx] is c[i] in our implementation.
*
*   https://sanugupta.wordpress.com/2014/08/29/binary-indexed-tree-fenwick-tree/ average article on
*   the topic
* meta  : tag-fenwick-tree, tag-binary-indexed-tree, tag-ds-core
***************************************************************************************************/
using System;

public class FenwickTree {
  int[] accumNums;    // change to long if bigger range is required
  // original input numbers array
  int[] nums;

  // auxillary methods
  private int LSB(int x) { return x & -x; }

  /// <summary>
  /// Build/Init data structure for given array.
  /// Please note that input array is not copied straight forward. Instead, accumNums is updated
  /// to contain cumulative sum index by index. In the end, nums property contains the updated
  /// values.
  /// </summary>
  /// <param name="a">array of input numbers</param>
  public FenwickTree(int[] a) {
    this.accumNums = new int[a.Length];    // change to long if required
    this.nums = new int[accumNums.Length];
    for (int i = 0; i < accumNums.Length; i++)
      Update(i, a[i]);
  }

  /// <summary>
  /// Updating value at an index means updating cumulative values for indices following i (after i).
  /// For BIT, we update the siblings which takes of updating in lg N time for all following indices
  /// 
  /// To get the sibling of i, we do,
  ///   i = i + LSB(i)
  /// Example,  
  /// When i = 1, sibling is 2 (ref: Paper, p#3). Hence, LSB(i) = 2-1 = 1
  ///
  /// <remarks> To avoid an infinite loop when i=0 we initialize it to be off by 1 and use
  /// respective previous index. Please note that changing LSB to,
  /// <code> ((x+1) & -(x+1)) - 1 </code>
  /// does not make a difference.
  /// </remarks>  
  /// </summary>
  /// <param name="i">Index at which to update the value</param>
  /// <param name="val">New value for specified index</param>
  public void Update(int i, int val) {  // change to long if required
    if (i < 0)
      throw new ArgumentException();
    int k = val - nums[i];
    nums[i] = val;
    i++;
    while (i <= accumNums.Length) {
      accumNums[i-1] += k;
      i += LSB(i);
    }
  }

  /// <summary>
  /// Get cumulative sum of values from index 0 to i.
  /// This means gettings sum of parent nodes one by one all the way above till i=0 since 0 is the
  /// root of tree. Beautiful bitwise optimization here is to drop the least significant bit annd
  /// get the parent of a node.
  /// For example, to get Sum for index 15, we have following order of parents (ref: paper, p#3),
  /// - 15
  /// - 14
  /// - 12
  /// - 8
  /// - 0
  /// 
  /// when i = 15 = 0b00001111, -15 = 0b11110001
  /// Hence, LSB(i) = 1, subtract this from 15 and we get the parent, 15 - 1 = 14
  /// A short expression is to AND with (i-1).
  /// 
  /// <remarks> To avoid an infinite loop when i=0 we initialize it to be off by 1 and use
  /// respective previous index. Please note that changing LSB to,
  /// <code> ((x+1) & -(x+1)) - 1 </code>
  /// does not make a difference.
  /// </remarks>  
  /// </summary>
  /// <param name="i">Index</param>
  public int Sum(int i) {
    if (i < 0 || i >= accumNums.Length)
      return 0;
    i++;
    int sum = 0;    // change to long if required
    while (i > 0) {
      sum += accumNums[i-1];
      i &= (i-1);
    }
    return sum;
  }

  public int SumRange(int i, int j) {
    return Sum(j) - Sum(i - 1);
  }

  // not tested, stil 1 based
  // range based addition of values
  public void RangeUpdate(int l, int r, int k) {
    if (l < 1 || r > Size)
      throw new ArgumentException();
    int i = l;
    while (i<=r) {
      accumNums[i] += k;
      i += LSB(i);
    }
    /* this is wrong apprach: because LSB of 9 is not gonna be same as 8's
    int nextLSB = i;
    for (i = r + 1; i < Size && i < nextLSB; i++)
      nums[i] -= k; */
    // correct approach would be
    i = r+1;
    while (i<Size) {
      accumNums[i] -= k;
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

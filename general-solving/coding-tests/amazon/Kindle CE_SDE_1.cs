/***************************************************************************
* Title : Find Closest Points
* URL   : 
* Date  : 2019-01-09
* Author: Atiq Rahman
* Comp  : O(n lg n), O(X); n = size of input, X = size of output
* Status: Accepted
* Notes : Find X closest points from N destination inputs
*   If we don't have to handle large inputs then it looks like,
*     return a[0] * a[0] + a[1] * a[1] - b[0] * b[0] - b[1] * b[1];
*
* meta  : tag-charp-lambda-exp, tag-algo-sort, tag-company-amazon
***************************************************************************/
using System; // I had to add this line
using System.Collections.Generic;

// Amazon's crappy default documentation
// IMPORT LIBRARY PACKAGES NEEDED BY YOUR PROGRAM
// SOME CLASSES WITHIN A PACKAGE MAY BE RESTRICTED
// DEFINE ANY CLASS AND METHOD NEEDED
// CLASS BEGINS, THIS CLASS IS REQUIRED
public class Solution {
  // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
  public List<List<int>> ClosestXdestinations(int numDestinations,
                          int[,] mdAllLocations,
                          int numDeliveries) {
    var allocations = ConvertMultiDimensionalToJagged<int>(mdAllLocations);
    Array.Sort(allocations, (a, b) =>
    {
      // handle overflow with larger data type
      long d1 = a[0] * a[0] + a[1] * a[1];
      long d2 = b[0] * b[0] + b[1] * b[1];
      return d1 > d2 ? 1 : d1 == d2 ? 0 : -1;
    });

    return ConvertArrayToList(allocations, numDeliveries);
  }
  // METHOD SIGNATURE ENDS

  /// <summary>
  /// Convert to expected list type and limit upto count
  /// </summary>
  /// <param name="count"> how many to take</param>
  private List<List<int>> ConvertArrayToList(int[][] allocations, int count) {
    var result = new List<List<int>>(count);
    for (int i = 0; i < count; i++)
      result.Add(new List<int>(new int[] { allocations[i][0], allocations[i][1] }));
    return result;
  }
}

/*
Example,
Input:
(1,-3) = 10
(1, 2) = 5
(3, 4) = 25
1

Output: (1,2)
*/

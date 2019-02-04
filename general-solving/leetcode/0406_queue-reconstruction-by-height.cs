/***************************************************************************************************
* Title : Queue Reconstruction by Height
* URL   : https://leetcode.com/problems/queue-reconstruction-by-height/
* Date  : 2019-02-03
* Comp  : O(n^2), O(n)
* Status: Accepted
* Notes : Reconstruct based height, at least k people should be in front of the element
*
*   comp analysis: sort n lg n, n^2 to insert them in worst-case
*   ToDo, try to achieve better comp
*   
*   Can be solved using priority queue as well, to retrieve items in order but it does not improve
*   the comp for insertion.
* ref: https://leetcode.com/problems/queue-reconstruction-by-height/discuss/221383/C%2B%2B-super-simple-solution-beats-100
*  List Insert
*   https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.insert
* meta  : tag-algo-sort, tag-algo-greedy, tag-ds-queue, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  int N, numProps;    // replaces numCols and numRows

  public int[,] ReconstructQueue(int[,] mdPeople) {
    var people = ConvertMultiDimensionalToJagged<int>(mdPeople);
    Array.Sort(people, (a, b) => a[0] == b[0] ? a[1] - b[1] : (b[0] - a[0]));

    var result = new List<int[]>();
    foreach (var p in people)
      // this problem seems to ensure, p[1] <= result.Count, No Exception
      result.Insert(p[1], p);

    return ConvertJaggedToMultiDimensional<int>(result);
  }

  // changes parameter type, and returns instead of throwing an exception when N = 0
  private T[,] ConvertJaggedToMultiDimensional<T>(List<T[]> jaggedArray) {
    N = jaggedArray.Count;  // class member
    if (N == 0)
      return new T[0, 2];

    numProps = jaggedArray[0].Length;  // class member
    // same code ...
  }
}

/*
[]
 don't throw exception
*/

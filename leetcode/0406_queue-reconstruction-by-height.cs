/***************************************************************************************************
* Title : Queue Reconstruction by Height
* URL   : https://leetcode.com/problems/queue-reconstruction-by-height/
* Date  : 2019-02-03
* Comp  : O(n^2), O(n)
* Status: Accepted
* Notes : Reconstruct based on height, at least k people should be in front of the element
*
*   If we put the higher heights in front of lower ones and then insert on position (k) it will work
*   because we already have k higher height people in front due to sorting.
*   Consider example,
*    {1, 0}, {2, 0}
*   sorted,
*    {2, 0}, {1, 0}
*    
*    Then, we insert {2, 0} in first position; hence, result,
*     {2, 0}
*    Then we insert {1, 0}, result,
*     {1, 0}, {2, 0}
*   The large exampe is worked out at the bottom.
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
  // replaces numCols and numRows
  int N;        // number of people
  int numProps; // Properties of each person: height and number of people in front >= height

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
    // same code as in `utils.cs` ...
  }
}

/*
[]
 don't throw exception

Given
 {7, 0}, {4,4}, {7, 1}, {5, 0}, {6, 1}, {5, 2}

After sorting,
 {7, 0}, {7, 1}, {6, 1}, {5,0}, {5, 2}, {4, 4}

we have 6 items here, as we insert (shows below result list as we develop),
i=0,
 {7, 0},
i=1,
 {7, 0}, {7, 1},
i=2,
 {7, 0}, {6, 1}, {7, 1}
i=3,
 {5, 0}, {7, 0}, {6, 1}, {7, 1}
i=4,
 {5, 0}, {7, 0}, {5, 2}, {6, 1}, {7, 1}
i=5, k=4, means insert in position 4 (0-based index so 4 people are in front of it),
 {5, 0}, {7, 0}, {5, 2}, {6, 1}, {4, 4}, {7, 1}

In each step above, it never violates the property

*/

/***************************************************************************
* Title : Spiral Matrix II
* URL   : https://leetcode.com/problems/spiral-matrix-ii
* Occasn: JS Meetup Arrays and Strings 2014-08-18
* Date  : 2018-04-19
* Author: Atiq Rahman
* Comp  : O(N^2)
* Status: Accepted
* Notes : The problem asks to generate a matrix putting numbers from 1 to N*N
*   in spiral order. 1 is put in top left cell and N*N is put in center.
*   Consider N*N matrix as a collection of (N+1)/2 Rectangle nested one inside
*   another. For odd values of N, inner most square-rectangle has 1*1 dimension.
*   
*   Most important part for my solution had been to compute the equation for
*   start value for square.
*   
*   We consider the variable index to represent which square rectangle we are
*   currently solving. index = 0 means we are in the outer most rectangle
*   index = 1 means we are in the immediate rectangle inside the outer-most
*   square. For each square, (index,index) represents the top left cell.
*
*   n is given.
*   For each square, Width = Height = n - index * 2
*   
*   When index = 0, start value = 1
*   index = 1, sv = 4 * (n-1)
*   index = 2, sv = 4 * (n-1) + 4 * (n-1) - 8
*                 = 4 * 2 * (n-1) - 8 * 1
*   index = 3, sv = 4 * (n-1) + 4 * (n-1) - 8 + 4 * (n-1) - 8*2
*                 = 4 * 3 * (n-1) - 8 * (1+2)
*   index = 4, sv = 4 * (n-1) + 4 * (n-1) -8 + 4 * (n-1) - 8*2 + 4 * (n-1)- 8*3
*                 = 4 * 4 * (n-1) - 8 * (1+2+3)
*   When, index = n, sv = 4 * index * (n-1) - 8 * (1+2+3+....+(index-1))
*   
*   For the top row, offset from starting value is difference between value of
*   iteration variable and index.
*   We process the bottom row from left to right just like the top row (values
*   are decreasing).
*   Starting value in that row is offset from start value by,
*     3 * (length of square - 1)
*
* meta  : tag-recursion, tag-math, tag-leetcode-medium
***************************************************************************/
public class Solution {
  private int n, m;
  private int[][] jaggedArray;

  public int[,] GenerateMatrix(int n) {
    // Jagged array and its dimensions are initialized
    this.n = m = n;
    jaggedArray = new int[n][];
    for (int i=0; i<n; i++)
      jaggedArray[i] = new int[n];
    // Solution driver
    GenerateMatrixHelper(0);
    return ConvertJaggedToMultiDimensional<int>(jaggedArray);  // ref 'utils.cs'
  }
  
  // Recursive implementation, uses jaggedArray class member as input-output
  void GenerateMatrixHelper(int index) {
    if (index >= (n+1)/2)
      return ;
    // compute top left value of current (index+1)-th rectangle
    int startVal = (n-index) * (index<<2) + 1;
    // process one rectangle at a time
    for (int i=index; i<n-index; i++) {
      // process top row
      jaggedArray[index][i] = startVal + (i-index);
      // process left most column, ignore indices which already had been filled
      if (i>index && i<n-index-1)
        jaggedArray[i][index] = startVal + 4 * (n-index*2-1) - (i-index);
      // process bottom row
      jaggedArray[n-index-1][i] = startVal + 3 * (n-index*2-1) - (i-index);
      // process right most column
      if (i>index && i<n-index-1)
        jaggedArray[i][n-index-1] = startVal + n - (index<<1) + (i-index) -1;
    }    
    GenerateMatrixHelper(index+1);
  }
}

/*
Draft,
N = 7

[[1, 2, 3, 4, 5, 6, 7],
[24,25,26,27,28,29, 8],
[23,48,41,42,43,30, 9],
[22,47,64,49,44,31,10],
[21,46,47,46,45,32,11],
[20,37,36,35,34,33,12],
[19,18,17,16,15,14,13]]
*/

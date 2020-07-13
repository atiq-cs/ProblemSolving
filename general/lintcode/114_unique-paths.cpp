/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/unique-paths/
* Date  : 2015-06-22
* Author: Atiq Rahman
* Status: Accepted
* Comp  : O(n^2)
* Notes : Cannot test memoization on lintcode, their run of the solution is independent of input

*   Count of unique path for a m,n depends on m-1, n and m, n-1
* meta  : tag-algo-dp
***************************************************************************************************/
#include <algorithm>

class Solution {
public:
  /**
   * @param n, m: positive integer (1 <= n ,m <= 100)
   * @return an integer
   */
  int uniquePaths(int m, int n) {
    // wirte your code here
    // iterative solution
    
    int MAX_DIM = std::max(m,n);
    int grid_path_count[101][101];
    
    // initialize
    for (int i=1; i<=MAX_DIM; i++)
      grid_path_count[1][i] = grid_path_count[i][1] = 1;
    
    // simple DP
    for (int row = 2; row <=MAX_DIM; row++)
      for (int col = 2; col <=MAX_DIM; col++)
        grid_path_count[row][col] = grid_path_count[row-1][col] + grid_path_count[row][col-1];
    
    return grid_path_count[m][n];
  }
};

/*
TLE, recursive solution,

Base cases,
if (m == 0 || n==0)
  return 0;
if (m == 1 || n==1)
  return 1;
if (m==2)
  return n;
if (n==2)
  return m;

Recursive case
return uniquePaths(m-1, n)+uniquePaths(m, n-1);
*/

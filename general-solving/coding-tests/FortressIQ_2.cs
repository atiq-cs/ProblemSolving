/***************************************************************************************************
* Title : Number of paths in a matrix (p#2)
* Occasn: FortressIQ Senior C# Developer
* Date  : 2018-03-05
* Author: Atiq Rahman
* Comp  : O(n * m), O(n * m)
* Status: Accepted
* Notes : Dynamic Programming Logic,
*   A cell can be reached from two non-empty adjacents cells from UP or from LEFT
*   Base Case, first column and first row cells can only have single path from source if there are
*   no obstacles
*   
*   Memory Optimzation, Possible to do in O(N) instead of O(N^2) if we only save last row; ToDo
*
*   Handle following,
*   Dynamic Programming - paths contain obstacles
*   Integer arithmetic - modulus
* meta  : tag-algo-dp, tag-company-FortressIQ, tag-coding-test
***************************************************************************************************/
public class FortressIQ_Solution {
  static int numberOfPaths(int[][] grid) {    
    // Declare and Initialize Variables.
    // Simplified Input: all arrays in the jagged array have same size for this
    //  problem.
    if (grid.Length == 0 || grid[0].Length==0)
      return 0;
    int n = grid.Length;
    int m = grid[0].Length;
    
    int[][] PathCount = new int[n][];
    for (int r=0; r<n; r++)
      PathCount[r] = new int[m];
    // Our jagged array 'PathCount' is initialized by compiler to contain Zeros
    // We can explicitly initialize the array for readability if required.

    // Each cell in first row with 1 without having obstacle after first cell
    // has single path to reach it.
    for (int i=0; i<m && grid[0][i]==1; i++)
      PathCount[0][i] = 1;

    // Each cell in first column with 1 without having obstactle after first
    // cell has single path to reach it.
    for (int r=0; r<n && grid[r][0]==1; r++)
      PathCount[r][0] = 1;
    
    const int modulusValue = (int)1e9 + 7;
    // Dynamic Programming Code Block to count number of solutions
    for (int r=1; r<n; r++)
      for (int c=1; c<m; c++)
        // By rule of Associative for remainder
        PathCount[r][c] = grid[r][c] * (PathCount[r-1][c]%modulusValue +
          PathCount[r][c-1]%modulusValue) % modulusValue;
    return PathCount[n-1][m-1];
  }
  
  static void Main(String[] args) {
    string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
    TextWriter tw = new StreamWriter(@fileName, true);

    int res;
    int a_rows = 0;
    int a_cols = 0;
    a_rows = Convert.ToInt32(Console.ReadLine());
    a_cols = Convert.ToInt32(Console.ReadLine());

    int[][] a = new int[a_rows][];
    for(int a_i = 0; a_i < a_rows; a_i++) {
      string[] a_temp = Console.ReadLine().Split(' ');
      a[a_i] = Array.ConvertAll(a_temp,Int32.Parse);

    }

    res = numberOfPaths(a);
    tw.WriteLine(res);

    tw.Flush();
    tw.Close();
  }
}

/*
Some inputs,
3
4
1 1 1 1
1 1 1 1
1 1 1 1

1
3
1 1 1
1
5
1 1 1 0 1
3
3
1 1 1
1 1 1

1
3
0 0 0
3
1
0
0
0
3
3
1 1 1
1 1 1
1 0 1
1
5
1 1 1 0 1

3
3
1 1 1
1 0 1
1 1 1

1
1
0
2
2
0 0
0 1
4
4
1 1 1 0
1 0 1 0
1 1 1 0
1 1 1 1
3
3
1 0 0
0 1 0
0 0 1
2
2
1 0
0 1
3
3
1 1 1
1 0 1
1 1 1


2
2
1 0
0 1

2
2
1 1
1 0
2
2
0 1
1 1
2
2
1 0
1 1
2
2
0 0
1 1
*/

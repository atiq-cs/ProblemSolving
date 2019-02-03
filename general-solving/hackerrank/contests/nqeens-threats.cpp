/***************************************************************************
* Title : Find max number of threats
* URL   : 
* Comp  : ToDo
* Author: Atiq Rahman
* Status: Accepted
* Notes : Upwork coding contest
*   Simple approach that worked
*   Max threats for n queens problem
*   First implementation is DP, however this is not a good DP Problem
*
* meta  : tag-coding-contest, tag-algo-dp
****************************************************************************/
/// <summary>
/// Find max number of threats given n queens
/// <remarks>
/// brute force instead of DP
/// </remarks>
/// </summary>
/// <param name="a"> List of queens, a[i] represents column number of queen in row i </param>
int maxThreats(vector<int> a) {
  int n = a.size();
  int max_threats = 0;

  // check for each queen, queen in row i
  for (int i = 0; i<n; i++) {
    int num_threats = 0;
    // for each queen
    // check row, max 1 queen in single row

    // check column, can be multiple queens in same column
    // find the first queen
    // our queen's postion
    int col_value = a[i];

    // next 2 for loops find threats for the column
    // need to find queens from (i-1, col) to (0, col)
    for (int row = i - 1; row >= 0; row--) {
      if (a[row] == col_value) {
        num_threats++;
        break;
      }
    }
    // need to find queens from (i+1, col) to (n-1, col)
    for (int row = i + 1; row<n; row++) {
      if (a[row] == col_value) {
        num_threats++;
        break;
      }
    }

    // these loops can be simplified..
    // check diag, 2 parts
    // first part
    for (int row = i - 1; row >= 0; row--) {
      if (a[row] == col_value - row + i) {
        num_threats++;
        break;
      }
    }

    for (int row = i - 1; row >= 0; row--) {
      if (a[row] == col_value + row - i) {
        num_threats++;
        break;
      }
    }

    for (int row = i + 1; row<n; row++) {
      if (a[row] == col_value - row + i) {
        num_threats++;
        break;
      }
    }

    for (int row = i + 1; row<n; row++) {
      if (a[row] == col_value + row - i) {
        num_threats++;
        break;
      }
    }

    // get max
    max_threats = std::max(num_threats, max_threats);

  }

  return max_threats;
}

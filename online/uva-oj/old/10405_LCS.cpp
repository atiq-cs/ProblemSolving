/***************************************************************************************************
* Title : LCS
* URL   : 10405
* Notes : New reference for this problem's solution is 'demos/algo/dp/lcs.cs'
*   Do not look at this solution. No gonna upgrade this one.
*   Only find LCS length
*   Special Case is if a line is only newline then output is zero
*   ToDo, move algo core for DP
* meta  : tag-dp-lcs
***************************************************************************************************/
#include <cstring>
#include <cstdio>
using namespace std;


int c[1005][1005];     // Calculate scoring for common subsequence
char x[1005], y[1005];


int LCS() {
  int i, j, m, n;
  m = strlen(x);
  n = strlen(y);

  for (i = 0; i < m; i++)
    c[i][0] = 0;

  for (j = 1; j < n; j++)
    c[0][j] = 0;

  for (i = 0; i < m; i++)
    for (j = 0; j < n; j++)
      if (x[i] == y[j]) {
        c[i + 1][j + 1] = c[i][j] + 1;
      }
      else if (c[i + 1][j] >= c[i][j + 1]) {
        c[i + 1][j + 1] = c[i + 1][j];
      }
      else {
        c[i + 1][j + 1] = c[i][j + 1];
      }


  return c[m][n];
}


int main() {
  int maxLength;

  while (gets(x) && gets(y)) {
    if (x[0] == '\0' || y[0] == '\0')
      maxLength = 0;
    else
      maxLength = LCS();

    printf("%d\n", maxLength);
  }

  return 0;
}

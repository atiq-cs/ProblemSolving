/***************************************************************************************************
* Title : Oil Deposit
* URL   : 572
* Status: Accepted
* Comp  : O (V+E)
* Notes : Get a oil and remove it recursive remove it's adjacent oil cups...
* meta  : tag-graph-dfs, tag-backtracking, tag-recursion
***************************************************************************************************/
#include<stdio.h>

short m,n;
char oil[110][110];

void remove_oil(int y, int x) {
  oil[y][x] = '*';

  if (x - 1 >= 0 && y - 1 >= 0 && oil[y - 1][x - 1] == '@')
    remove_oil(y - 1, x - 1);

  if (y - 1 >= 0 && oil[y - 1][x] == '@')
    remove_oil(y - 1, x);

  if (x + 1 < n && y - 1 >= 0 && oil[y - 1][x + 1] == '@')
    remove_oil(y - 1, x + 1);

  if (x + 1 < n && oil[y][x + 1] == '@')
    remove_oil(y, x + 1);

  if (x + 1 < n && y + 1 < m && oil[y + 1][x + 1] == '@')
    remove_oil(y + 1, x + 1);

  if (y + 1 < m && oil[y + 1][x] == '@')
    remove_oil(y + 1, x);

  if (x - 1 >= 0 && y + 1 < m && oil[y + 1][x - 1] == '@')
    remove_oil(y + 1, x - 1);

  if (x - 1 >= 0 && oil[y][x - 1] == '@')
    remove_oil(y, x - 1);
}


int main() {
  int i, j, no;
  
  void remove_oil(int x, int y);

  while (scanf("%hd",&m) && m) {
    scanf("%hd",&n);
    for (i=0;i<m;i++)
      scanf("%s",oil[i]);

    no = 0;
    for (i=0;i<m;i++)
      for (j=0;j<n;j++)
        if (oil[i][j] == '@') {
          remove_oil(i, j);
          no ++;
        }

    printf("%hd\n",no);
  }

  return 0;
}

// cpp version, requires following headers
// only IO part modified, every thing else same..
#include<iostream>
#include<cstdio>
using namespace std;

int main() {
  while (cin >> m && m) {
    cin >> n;

    int i, j, no = 0;

    for (i = 0; i < m; i++)
      cin >> oil[i];

    for (i = 0; i < m; i++)
      for (j = 0; j < n; j++)
        if (oil[i][j] == '@') {
          remove_oil(i, j);
          no++;
        }

    cout << no << endl;
  }

  return 0;
}

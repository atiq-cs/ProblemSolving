/*******************************************************************************************************************
  Problem Name:  Oil Deposit
  Type:    Recursion, BFS, Backtracking..
  Description:  Get a oil and remove it recursive remove it's adjacent oil cups... 
*******************************************************************************************************************/
#include<iostream>
#include<cstdio>
using namespace std;

short m,n;
char oil[110][110];

int main() {
  
  void remove_oil(int x, int y);

  freopen("572.in","r",stdin);

  while (cin>>m && m) {
    cin>>n;

    int i, j, no=0;

    for (i=0;i<m;i++) {
      cin>>oil[i];
//      cout<<oil[i]<<endl;
    }
    for (i=0;i<m;i++)
      for (j=0;j<n;j++)
        if (oil[i][j] == '@') {
//          cout<<"Sending i: "<<i<<"j:  "<<j<<endl;
          remove_oil(i, j);
          no ++;
        }

    cout<<no<<endl;
  }
  return 0;
}

void remove_oil(int y, int x) {
//  cout<<"Position x:  "<<x<<"  Position y:  "<<y<<endl;
  oil[y][x] = '*';

  if (x-1 >= 0 && y-1 >= 0 && oil[y-1][x-1] == '@') {
//    cout<<"Case 0"<<endl;
    remove_oil(y-1, x-1);
  }

  if (y-1>=0 && oil[y-1][x] == '@') {
//    cout<<"Case 1"<<endl;
    remove_oil(y-1, x);
  }

  if (x+1 < n && y-1 >= 0 && oil[y-1][x+1] == '@') {
//    cout<<"Case 2"<<endl;
    remove_oil(y-1, x+1);
  }

  if (x+1 < n && oil[y][x+1] == '@') {
//    cout<<"Case 3"<<endl;
    remove_oil(y, x+1);
  }

  if (x+1 < n && y+1 < m && oil[y+1][x+1] == '@') {
//    cout<<"Case 4"<<endl;
    remove_oil(y+1, x+1);
  }

  if (y+1 < m && oil[y+1][x] == '@') {
//    cout<<"Case 5"<<endl;
    remove_oil(y+1, x);
  }

  if (x-1 >= 0 && y+1 < m && oil[y+1][x-1] == '@') {
//    cout<<"Case 6"<<endl;
    remove_oil(y+1, x-1);
  }

  if (x-1 >= 0 && oil[y][x-1] == '@') {
//    cout<<"Case 7"<<endl;
    remove_oil(y, x-1);
  }

  return;
}

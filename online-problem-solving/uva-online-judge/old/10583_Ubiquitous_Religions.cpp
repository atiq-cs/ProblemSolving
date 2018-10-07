/*******************************************************
*    Problem Name:  Ubiquitous Religions
*    Problem ID:        UVA 10583
*    Occassion:        Offline Solving
*    Description:      Have to find out the maximum number of sets possilbe, solved           having little modification to UVA 10608
*
*    Algorithm:        Union Find
*    Special Case:      N/A
*    Judge Status:      Accepted
*    Author:            Atiqur Rahman
*******************************************************/
//#include <iostream>
#include <cstdio>
//#include <cmath>
#include <cstring>
//#include <new>
//#include <vector>
//#include <queue>
//#include <map>
//#include <algorithm>
//#include <iomanip>//for cout formatting
//#define  INF 2147483648
//#define EPS 1e-8
using namespace std;

void makeSet(int n);
int findSet(int i);
void Union(int x, int y);
int findMaxNoMembers(int n);

int sets[50005], rank[50005];
bool exist[50005];

int main() {
//  freopen("10583_in.txt", "r", stdin);
  int i, no_groups, n, m, a, b, cases=0;

  // Union Find Algorithm Implementation
  
  while (scanf("%d %d", &n, &m) && (n || m)) {
    makeSet(n);
    
    while (m--) {
      scanf("%d %d", &a, &b);
      Union(findSet(a), findSet(b));
    }
/*    for (i=1; i<=n; i++) {
      printf("%d  %d   %d\n", i, sets[i], exist[i]);
    }
    putchar('\n');*/
    no_groups=findMaxNoMembers(n);
    printf("Case %d: %d\n", ++cases, no_groups);
  }
  
  return 0;
}

void makeSet(int n) {
  int i;
  for (i=1; i<=n; i++) {
    sets[i] = i;
    rank[i] = 0;
    exist[i] = true;
  }
}

int findSet(int i) {
    if (sets[i] == i)
      return i;
    else
      return findSet(sets[i]);
}

void Union(int x, int y) {
  if (x != y) {
  if (rank[x]>rank[y]) {
    sets[y] = x;
  }
  else {
    sets[x] = y;
    if (rank[x]==rank[y])
      rank[y]++;
  }
  }
}

int findMaxNoMembers(int n) {
  int counter=0, i, root;

  for (i=1; i<=n; i++) {
    root = findSet(i);
    if (exist[root] == true) {
      exist[root] = false;
      counter++;
    }
  }
  return counter;
}

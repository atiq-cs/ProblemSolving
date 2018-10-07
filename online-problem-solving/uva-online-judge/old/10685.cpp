/*******************************************************
*    Problem Name:  Friends
*    Problem ID:        UVA 10608
*    Occassion:        Offline Solving
*    Description:      Have to find out the maximum number of elements
*    Algorithm:        Union Find
*    Special Case:      N/A
*    Judge Status:      Accepted
*    Author:            Atiqur Rahman
*******************************************************/
//#include <iostream>
#include <cstdlib>
#include <cstdio>
//#include <cmath>
#include <cstring>
//#include <new>
//#include <vector>
//#include <queue>
#include <map>
//#include <algorithm>
//#include <iomanip>//for cout formatting
//#define  INF 2147483648
//#define EPS 1e-8
using namespace std;

class chain {
  char str[40];
public:
  chain() {  }
  chain(char *s) { strcpy(str,s); }
  char *get() {  return str; }
  void show() { puts(str); }
};

bool operator<(chain a, chain b) {
  return (strcmp(a.get(), b.get())<0);
}

void makeSet(int n);
int findSet(int i);
void Union(int x, int y);
int findMaxNoMembers(int n);

int sets[31005],no_child[31005], rank[31005];

int main() {
//  freopen("10685_in.txt", "r", stdin);
  int i, no_groups, n, m, a, b;
  char str[40];

  map<chain, int> creature;
  map<chain, int>::iterator p;
  // Union Find Algorithm Implementation

  while (scanf("%d %d", &n, &m) && (m || n)) {
    creature.clear();
    makeSet(n);
    for (i=0; i<n; i++) {
      scanf("%s", str);
    //  puts(str);
      creature.insert(pair<chain, int>(chain(str), i+1));
    }
    
    while (m--) {
      scanf("%s", str);
      p = creature.find(str);
      a = p-> second;

      scanf("%s", str);
      p = creature.find(str);
      b = p-> second;

    //  printf("inserting %d %d\n", a, b);
      Union(findSet(a), findSet(b));
    }
  /*  for (i=1; i<=n; i++) {
      printf("%d  %d   %d\n", i, sets[i], no_child[i]);
    }
    putchar('\n');*/
    no_groups=findMaxNoMembers(n);
    printf("%d\n", no_groups);
  }
  
  return 0;
}

void makeSet(int n) {
  int i;
  for (i=1; i<=n; i++) {
    sets[i] = i;
    rank[i] = 0;
    no_child[i] = 1;
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
    no_child[x] += no_child[y];
  }
  else {
    sets[x] = y;
    no_child[y] += no_child[x];
    if (rank[x]==rank[y])
      rank[y]++;
  }
  }
}

int findMaxNoMembers(int n) {
  int max, i;

  for (max=no_child[1],i=2; i<=n; i++) {
    if (max < no_child[i])
      max = no_child[i];
  }
  return max;
}

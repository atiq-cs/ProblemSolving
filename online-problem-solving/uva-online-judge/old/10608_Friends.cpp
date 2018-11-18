/***************************************************************************************************
* Title : Friends
* URL   : 10608
* Author: Atiq Rahman
* Status: Accepted
* Notes : Have to find out the maximum number of elements
* rel   : UVA 10685, 10583
* meta  : tag-graph-mst, tag-union-find
***************************************************************************************************/
#include <cstdio>
#include <cstring>
using namespace std;

void makeSet(int n);
int findSet(int i);
void Union(int x, int y);
int findMaxNoMembers(int n);

int sets[31005],no_child[31005], rank[31005];

int main() {
  int i, no_groups, t, n, m, a, b;
  scanf("%d", &t);
  
  while (t--) {
    scanf("%d %d", &n, &m);
    makeSet(n);
    
    while (m--) {
      scanf("%d %d", &a, &b);
      Union(findSet(a), findSet(b));
    }
    no_groups=findMaxNoMembers(n);
    printf("%d\n", no_groups);
  }
  
  return 0;
}

// Union Find Algorithm Implementation
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

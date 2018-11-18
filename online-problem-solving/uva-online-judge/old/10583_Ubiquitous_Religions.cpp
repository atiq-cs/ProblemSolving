/***************************************************************************************************
* Title : Ubiquitous Religions
* URL   : 10583
* Status: Accepted
* Notes : Have to find out the maximum number of sets possilbe, solved having little modification to
*   UVA 10608
* rel   : UVA#10608
* meta  : tag-graph-mst, tag-union-find
***************************************************************************************************/
#include <cstdio>
#include <cstring>
using namespace std;

int sets[50005], rank[50005];
bool exist[50005];

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

int main() {
  int i, no_groups, n, m, a, b, cases = 0;

  // Union Find Algorithm Implementation  
  while (scanf("%d %d", &n, &m) && (n || m)) {
    makeSet(n);

    while (m--) {
      scanf("%d %d", &a, &b);
      Union(findSet(a), findSet(b));
    }

    no_groups = findMaxNoMembers(n);
    printf("Case %d: %d\n", ++cases, no_groups);
  }

  return 0;
}

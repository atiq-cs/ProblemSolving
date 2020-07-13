/***************************************************************************************************
* Title : Ubiquitous Religions
* URL   : 10583
* Status: Accepted
* Notes : Have to find out the maximum number of sets possilbe, solved having little modification to
*   UVA 10608
* rel   : UVA#10608
* meta  : tag-graph-mst, tag-ds-dsf, tag-algo-union-find, tag-ds-core
***************************************************************************************************/
#include <cstdio>
#include <cstring>
using namespace std;

int sets[50005], rank[50005];
bool exist[50005];

// Utilizes DSF but excludes "no_child" array
// findSet and Union are at 'ds/dsf.cpp'
// modifies makeSet to initialize exist array as well..
void makeSet(int n) {
  int i;
  for (i=1; i<=n; i++) {
    // ... ..
    exist[i] = true;
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

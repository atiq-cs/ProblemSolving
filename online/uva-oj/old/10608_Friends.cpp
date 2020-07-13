/***************************************************************************************************
* Title : Friends
* URL   : 10608
* Author: Atiq Rahman
* Status: Accepted
* Notes : Have to find out the maximum number of elements in largest group quoted below,
*   "Your task is to count how many people there are in the largest group of friends."
* rel   : UVA 10685, 10583
* meta  : tag-graph-mst, tag-ds-dsf, tag-algo-union-find, tag-ds-core
***************************************************************************************************/
#include <cstdio>
#include <cstring>
using namespace std;

// ref at 'ds/dsf.cpp'
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

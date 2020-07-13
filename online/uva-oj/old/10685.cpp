/***************************************************************************************************
* Title : Nature
* URL   : 10685
* Author: Atiq Rahman
* Status: Accepted
* Notes : Have to find out the maximum number of elements
* rel   : 10608, 10583
* meta  : tag-graph-mst, tag-ds-dsf, tag-algo-union-find, tag-ds-core
***************************************************************************************************/
#include <cstdlib>
#include <cstdio>
#include <cstring>
#include <map>
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

// ref at 'ds/dsf.cpp'
void makeSet(int n);
int findSet(int i);
void Union(int x, int y);
int findMaxNoMembers(int n);

int sets[31005],no_child[31005], rank[31005];

int main() {
  int i, no_groups, n, m, a, b;
  char str[40];

  map<chain, int> creature;
  map<chain, int>::iterator p;

  while (scanf("%d %d", &n, &m) && (m || n)) {
    creature.clear();
    makeSet(n);
    for (i=0; i<n; i++) {
      scanf("%s", str);
      creature.insert(pair<chain, int>(chain(str), i+1));
    }
    
    while (m--) {
      scanf("%s", str);
      p = creature.find(str);
      a = p-> second;

      scanf("%s", str);
      p = creature.find(str);
      b = p-> second;

      Union(findSet(a), findSet(b));
    }
    no_groups=findMaxNoMembers(n);
    printf("%d\n", no_groups);
  }
  
  return 0;
}

/***************************************************************************************************
* Title : Nature
* URL   : 10685
* Author: Atiq Rahman
* Status: Accepted
* Notes : Have to find out the maximum number of elements
* rel   : 10608
* meta  : tag-graph-mst, tag-union-find
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

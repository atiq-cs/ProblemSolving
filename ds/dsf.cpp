/***************************************************************************************************
* Title : Disjoint Set Forests
* URL   : check ref
* Date  : 2017-05 (approx)
* Author: Atiq Rahman
* Comp  : O(m α n)
* Notes : Disjoint Set Forests
*   Union Find Algorithm Implementation
*
* ref   : C.L.R.S 3rd ed, Ch#21, p#571
* rel   : uva#10608, uva#10685, uva#10583
* meta  : tag-ds-dsf, tag-algo-union-find, tag-ds-core
***************************************************************************************************/
void makeSet(int n) {
  int i;
  for (i = 1; i <= n; i++) {
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
    if (rank[x] > rank[y]) {
      sets[y] = x;
      no_child[x] += no_child[y];
    }
    else {
      sets[x] = y;
      no_child[y] += no_child[x];
      if (rank[x] == rank[y])
        rank[y]++;
    }
  }
}

int findMaxNoMembers(int n) {
  int max, i;

  for (max = no_child[1], i = 2; i <= n; i++) {
    if (max < no_child[i])
      max = no_child[i];
  }
  return max;
}

/***************************************************************************************************
* Title : 
* URL   : 336
* Notes : This is not my code, it's probably historically here.. Check original source file
***************************************************************************************************/
#include < stdio.h >

int m[30][30];
int n, pn;
int nodes[30];
int tail, head;
int queue[30];
int v[30];

int search(int id) {
  int i;
  for (i = 0; i < n; i++)
    if (nodes[i] == id)
      return i;
  for (i = 0; i <= n; i++) {
    m[n][i] = 0;
    m[i][n] = 0;
  }

  nodes[n] = id;

  return n++;
}

void visit(int start, int ttl) {
  int t, count, j;
  tail = 0;
  head = 0;
  count = 1;
  queue[tail++] = start;

  for (j = 0; j < n; j++)
    v[j] = -1;
  v[start] = 0;

  while (tail != head) {

    t = queue[head++];
    if (v[t] < ttl)
      for (j = 0; j < n; j++)
        if (v[j] < 0 && m[t][j]) {
          v[j] = v[t] + 1;
          queue[tail++] = j;
          count++;
        }
  }

  printf("Case %d: %d nodes not reachable from node %d with TTL = %d.\n", ++pn, n - count, nodes[start], ttl);

}

int main() {
  int i, j, e1, e2;
  while (1 == scanf("%d", &j)) {
    if (j == 0)
      break;
    n = 0;
    for (i = 1; i <= j; i++) {
      scanf("%d %d", &e1, &e2);
      e1 = search(e1);
      e2 = search(e2);
      m[e1][e2] = 1;
      m[e2][e1] = 1;
    }

    while (1) {
      scanf("%d %d", &e1, &e2);
      if (e1 == 0 && e2 == 0)
        break;
      e1 = search(e1);
      visit(e1, e2);
    }
  }
  return 0;
}

/***************************************************************************************************
* Title :
* URL   : 336
* Notes : My queue implementation seems okay since the solution is accepted by UVA OJ
* meta  : tag-graph-bfs, tag-ds-queue
***************************************************************************************************/
#include <cstdio>
#include <map>
using namespace std;

struct qtype{
  int value;
  qtype* next;
};

// Linux queue, calling my friends used to call me linux
class lQueue {
  // by default elements are private
  qtype *start, *end;

public:
  lQueue();
  void Enqueue(int data);
  bool isEmpty();
  int Dequeue();
  ~lQueue();
};

lQueue::lQueue() {
  start = NULL;
  end = NULL;
}

void lQueue::Enqueue(int data) {
  // if no data in the queue Linked List
  if ((int *)start == NULL) {
    start = new qtype;
    start->value = data;
    start->next = NULL;
    end = start;
  }
  else {
    end->next = new qtype;
    end = end->next;
    end->value = data;
    // To not do this is a critical mistake
    end->next = NULL;
  }
}

bool lQueue::isEmpty() {
  if (start == NULL)
    return true;
  else
    return false;
}

int lQueue::Dequeue() {
  if (isEmpty()) {
    return -1;
  }
  else {
    int tmp = start->value;
    qtype *fmem = start;
    start = start->next;
    delete fmem;
    return tmp;
  }
}

lQueue::~lQueue() {
  delete start;
}

int Adj[100][100], len[100], VertexNo;


int BFS_visit(int source, int range) {
  int d[50], reachable = 0, u, i, v;

  memset(d, 255, VertexNo * sizeof(int));
  d[source] = 0;

  lQueue Q;
  Q.Enqueue(source);

  while (!Q.isEmpty()) {
    u = Q.Dequeue();
    if (d[u] <= range) {
      reachable++;
      for (i = 0; i < len[u]; i++) {
        v = Adj[u][i];
        if (d[v] < 0) {
          d[v] = d[u] + 1;
          Q.Enqueue(v);
        }
      }
    }
    else
      break;
  }
  return reachable;
}

int main () {
  int u, v, i, uI, vI, TTL, unreachable, NC, sq=1;
  map<int, int> mp;
  map<int, int>::iterator p;
  
  while (scanf("%d", &NC) && NC) {
    // Initialization
    mp.clear();
    memset(len, 0, sizeof(len));
    VertexNo = 0;

    // Input adjacency lists and build
    for (i=0; i<NC; i++) {
      scanf("%d %d", &u, &v);

      if (u == v) {
        p = mp.find(u);
        if (p == mp.end())
          mp.insert(pair<int, int>(u, VertexNo++));
      }
      else {
        p = mp.find(u);
        if (p == mp.end()) {
          uI = VertexNo;
          mp.insert(pair<int, int>(u, VertexNo++));
        }
        else
          uI = p->second;

        p = mp.find(v);
        if (p == mp.end()) {
          vI = VertexNo;
          mp.insert(pair<int, int>(v, VertexNo++));
        }
        else
          vI = p->second;

        Adj[vI][len[vI]++] = uI;
        Adj[uI][len[uI]++] = vI;
      }
    }
    // take queries and BFS visit.
    while (scanf("%d %d", &v, &TTL) && (v || TTL)) {
      unreachable = VertexNo - BFS_visit(mp[v], TTL);
      printf("Case %d: %d nodes not reachable from node %d with TTL = %d.\n",
        sq++, unreachable, v, TTL);
    }
  }
  return 0;
}

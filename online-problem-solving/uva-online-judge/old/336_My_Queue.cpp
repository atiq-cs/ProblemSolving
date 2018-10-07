/*
  My queue is correct
  This problem is accepted by UVA oj
*/

#include <cstdio>
#include <map>
using namespace std;
struct qtype{
  int value;
  qtype* next;
};

class lQueue {    //Linux queue
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
    end->next = NULL;    // This was a severe mistake I forgot to add this line and my program was faulty
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
    //cout<<"Queue is empty! Cannot perform delete."<<endl;
    return -1;
  }
  else {
  //  cout<<"passed"<<endl;
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

int main () {
  int BFS_visit(int source, int range);
//  freopen("336_in.txt", "r", stdin);

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
      //debug
    //  printf("inserting u: %d, v: %d\n", u, v);

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
/*
    // debug map
    p = mp.begin();
    while (p != mp.end()) {
      printf("first: %d, second: %d\n", p->first, p->second);
      p++;
    }
    // Debug print adj list
    for (int j=0; j<VertexNo; j++) {
      for (int k = 0; k<len[j]; k++) {
        printf("  %d", Adj[j][k]);
      }
      putchar('\n');
    }
*/
    // Take queries and BFS visit.
    while (scanf("%d %d", &v, &TTL) && (v || TTL)) {
      unreachable = VertexNo - BFS_visit(mp[v], TTL);
      printf("Case %d: %d nodes not reachable from node %d with TTL = %d.\n", sq++, unreachable, v, TTL);
    }
  }
  return 0;
}

int BFS_visit(int source, int range) {
  int d[50], reachable =0, u, i, v;

  memset(d, 255, VertexNo * sizeof(int));
/*  for (i=0; i<10; i++)
    printf("(%d) %d  ", i, d[i]);
  putchar('\n');*/
  d[source] = 0;

  lQueue Q;
  Q.Enqueue(source);

  while (!Q.isEmpty()) {
    u = Q.Dequeue();
//    printf("u: %d\n",u);
    if (d[u] <=range) {
      reachable++;
      for (i=0; i<len[u]; i++) {
        v = Adj[u][i];
        if (d[v]<0) {
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

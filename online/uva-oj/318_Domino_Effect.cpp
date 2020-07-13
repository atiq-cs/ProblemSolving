/***************************************************************************************************
* Title : Domino Effect
* URL   : http://uva.onlinejudge.org/external/3/318.html
* Author: Atiq Rahman
* Date  : 2015-05-20
* Status: Accepted
* Notes : Category: single source shortest path, destination is not specified
*   Dijkstra ref, Introduction to Algorithms
*   by Thomas H. Cormen and Charles E. Leiserson and Ronald L. Rivest and Clifford Stein (C.L.R.S)
*   p#658,
*   
*   Handles all special cases required to solve the domino problem
*   Judge Notes,
*    uva-judge- Judge is C++11 4.8.2 - GNU C++ Compiler with options: -lm -lcrypt -O2 -std=c++11
*     -pipe -DONLINE_JUDGE
*   main function should return 0, include cstring for memset
*   tju-judge- Judge is gcc 4.5.2, old, does not support C++11 all features
*
*   Class graph: undirected
*   Uses dynamic size of adjacency list
*   memory is manually allocated and cleaned up like a gentle man
*
* Ack   : on a special case, Yonghui Wu (http://www.cs.fudan.edu.cn/en/?page_id=2269)
* rel   : 'spoj\SPOJ_TRVCOST.cpp'
* meta  : tag-graph-dijkstra, tag-sssp
***************************************************************************************************/
#include <cstring>  // for memset
#include <sstream>
#include <vector>
#include <iostream>
#include <algorithm>
#include <queue>
#include <iomanip>  // for precision

#define INT_INF  0x7fffffff
#define NIL -1

void handleIO();

typedef struct Graph_Vertex_Type {
  int index;
  int distance;
  int predecessor;
} Vertex;


typedef struct Domino_Effects_Result {
  double cost;
  std::vector<int> dominoes;
} DominoEffectsResult;


class Graph {
private:
  int GRAPH_MAX_NUM_VERTEX;
  int nV;
  int nE;
  int **edge_cost;
  std::vector<Vertex> vertex;
  void initialize_SSSP(int source);
  std::vector<std::vector<int>> adj_list;

public:
  Graph(int max_vertex);
  ~Graph();
  void set_VE(int n, int m);
  void add_edge(int u, int v, int c);
  bool edge_relax(int u, int v, int w);
  void init();
  void ss_dijkstra(int source);
  DominoEffectsResult get_de_result();
};

void handleIO() {
  Graph graph(500);    // 500 is max size as specified by problem description
  int n, m;
  int seq = 1;

  while (std::cin >> n >> m && (n || m)) {
    if (m == 0 && n > 1)
      n = 1;

    // must be called before init
    graph.set_VE(n, m);
    graph.init();
    for (int i = 0; i < m; i++) {
      int u, v, c;  // start vertex u, end vertex and cost of the edge
      std::cin >> u >> v >> c;
      graph.add_edge(u-1, v-1, c);  // -1 to get 0 based index
    }

    // input for single graph done
    // run dijkstra
    graph.ss_dijkstra(0);
    // get output
    DominoEffectsResult de_res = graph.get_de_result();
    std::cout << "System #"<<seq++<< std::endl;
    if (de_res.dominoes.size() == 1) {
      std::cout << "The last domino falls after " << std::fixed << std::setprecision(1) << de_res.cost << \
        " seconds, at key domino " << de_res.dominoes[0]+1 << "." << std::endl;
    }
    else {
      std::cout << "The last domino falls after " << std::fixed << std::setprecision(1) << de_res.cost << \
        " seconds, between key dominoes " << de_res.dominoes[0]+1 << " and " << de_res.dominoes[1]+1 << "." << std::endl;
    }
    std::cout << std::endl;
  }
}

// Entry Point
int main() {
  handleIO();
  return 0;
}

// Graph class definition begins
// Constructor
Graph::Graph(int max_vertex):
GRAPH_MAX_NUM_VERTEX(max_vertex),
adj_list(GRAPH_MAX_NUM_VERTEX),
vertex(GRAPH_MAX_NUM_VERTEX)
{
  vertex.clear();
  adj_list.clear();
  edge_cost = new int*[GRAPH_MAX_NUM_VERTEX];

  for (int i = 0; i < GRAPH_MAX_NUM_VERTEX; i++) {
    edge_cost[i] = new int[GRAPH_MAX_NUM_VERTEX];
    // memset here not required as we are doing it explicitly everytime using init method
    // memset(edge_cost[i], 0, GRAPH_MAX_NUM_VERTEX*sizeof(int));
    std::vector<int> adj(GRAPH_MAX_NUM_VERTEX);
    adj_list.push_back(adj);
    Vertex tmp = {i, 0, 0};
    vertex.push_back(tmp);
  }
}

// Graph destructor
Graph::~Graph()
{
  // Clean the memory heap like a gentle man
  for (int i = 0; i < GRAPH_MAX_NUM_VERTEX; i++) {
    delete edge_cost[i];
  }
  delete edge_cost;
}

// init requires set_VE
void Graph::init() {
  for (int i = 0; i < nV; i++) {
    memset(edge_cost[i], 0, nV*sizeof(int));
    adj_list[i].clear();
  }
}

void Graph::set_VE(int n, int m) {
  nV = n;
  nE = m;
}

void Graph::add_edge(int u, int v, int c) {
  adj_list[u].push_back(v);
  adj_list[v].push_back(u);
  edge_cost[u][v] = edge_cost[v][u] = c;
}

/* Our single source shortest path algorithm - dijkstra
*/
void Graph::ss_dijkstra(int source) {
  initialize_SSSP(source);

  // lambda function
  auto comp = [](Vertex u, Vertex v) { return u.distance > v.distance; };
  std::priority_queue<Vertex, std::vector<Vertex>, decltype(comp)> queue(comp);

  /* for a connected graph we don't need to push all vertices
  for (int i = 0; i < nV; i++)
    queue.push(vertex[i]); */

  queue.push(vertex[0]);

  while (queue.empty() == false) {
    int u = queue.top().index; queue.pop();
    // ignore vertices that don't have cost updated
    // as we will be inserting same vertices multiple times
    if (vertex[u].distance != INT_INF)
      for (auto v : adj_list[u]) {
        int w = edge_cost[u][v];
        if (edge_relax(u, v, w))    // our alternative to decrease-key in priority queue
          queue.push(vertex[v]);
      }
  }
}

/* C.L.R.S p#648
  INITIALIZE-SINGLE-SOURCE
  for each vertex v of G.V
    v.distance = inf
    v.predecssor = NIL
  source.distance = 0
*/
void Graph::initialize_SSSP(int source) {
  for (int i = 0; i < nV; i++) {
    vertex[i].distance = INT_INF;
    vertex[i].predecessor = NIL;
  }
  vertex[source].distance = 0;
  vertex[source].predecessor = NIL;
}

// page 649
bool Graph::edge_relax(int u, int v, int w) {
  int total_cost = vertex[u].distance + w;
  if (vertex[v].distance > total_cost) {
    vertex[v].distance = total_cost;
    vertex[v].predecessor = u;
    return true;
  }
  return false;
}
// Graph class definition ends

// DominoEffectsResult class definition begins
DominoEffectsResult Graph::get_de_result() {
  // Attempt to get maximum and second maximum as this would relate with the domino falling in lengthiest time
  int max_index_first = -1;
  int max_index_second = -1;

  // get the first max
  max_index_first = 0;
  for (int i = 1; i < nV; i++)
    if (vertex[max_index_first].distance < vertex[i].distance && vertex[i].distance != INT_INF)
      max_index_first = i;

  /*  Case 1: max distance has no edge with the min, then max is the result
    Case 2: max has an edge so take the min that shares an edge and that is not predecessor of max
  */

  DominoEffectsResult deResult = { };
  // get the second max
  if (nV > 1) {
    max_index_second = adj_list[max_index_first][0];
    bool second_index_found = false;
    /* 1. if total cost via u is greater or equal to others then u is min
       2. if cost via u is equal to max's distance then it's not min
       */
    for (auto u: adj_list[max_index_first])
      if (vertex[u].distance + edge_cost[u][max_index_first] >= vertex[max_index_second].distance + \
        edge_cost[max_index_second][max_index_first] && u != max_index_first && u != \
        vertex[max_index_first].predecessor && vertex[max_index_first].distance != vertex[u].distance + \
        edge_cost[u][max_index_first] && vertex[u].distance != INT_INF) {
        max_index_second = u;
        second_index_found = true;
      }

    // There is no min, solution is as simple as that
    if (second_index_found == false) {
      deResult.cost = (double) vertex[max_index_first].distance;
      deResult.dominoes.push_back(max_index_first);
      return deResult;
    }
  }
  else {
    deResult.cost = 0.0;
    deResult.dominoes.push_back(max_index_first);
    return deResult;
  }

  /* if we are here, there is min
    if min's distance can be equal to max's distance; however that  is handled by the equation
  */
  deResult.cost = ((double) vertex[max_index_first].distance + vertex[max_index_second].distance + \
    edge_cost[max_index_first][max_index_second]) / 2.0;
  if (max_index_second > max_index_first) {
    deResult.dominoes.push_back(max_index_first);
    deResult.dominoes.push_back(max_index_second);
  }
  else {
    deResult.dominoes.push_back(max_index_second);
    deResult.dominoes.push_back(max_index_first);
  }
  return deResult;
}

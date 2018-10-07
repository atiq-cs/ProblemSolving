/*
*  Problem Title:  Breadth First Search
*  Problem Link:  No problem solved using this algo yet
*  Problem Type:  Graph Thoery
*  Alogirthm  :
*  Author    :  Atiqur Rahman
*  Email    :  mdarahman@cs.stonybrook.edu
*  Date    :  May 31, 2015
*  Desc    :
*          BFS ref: Introduction to Algorithms, page 595,
                     by Thomas H. Cormen and Charles E. Leiserson and Ronald L. Rivest and Clifford Stein
                     Simple dijkstra problem, hoping no special case

*  Status    :  Need to be tested well, will be in release condition after solving several problems of online
                        judges
*/

#include <cstring>  // for memset
#include <sstream>
//#include <cmath>
#include <vector>
#include <iostream>
#include <algorithm>
#include <queue>
#include <iomanip>  // for precision

#define INT_INF    0x7fffffff
enum COLOR_ENUM {WHITE, GRAY, BLACK};
#define NIL -1
// Comment before submission to judge
#define FILE_IO  TRUE

#ifdef FILE_IO
#include <fstream>
#endif

void handleIO();

/* Class graph: undirected
Uses dynamic size of adjacency list
*/
typedef struct Graph_Vertex_Type {
    int distance;
    int predecessor;
    char color;
} Vertex;

/*
    Graph only requires adjacency list
    edge cost 2d array is not required

    Graph can be constructed in such a way that a max size can be defined
    and same graph object can be used to perform graph algorithms as we have done previously in
    dijkstra algorithm implementation

    However, for this implementation I try to be more logical, let the OS and compiler handle those low
    level details
*/
class Graph {
private:
    int nV;
    int nE;
    std::vector<Vertex> vertex;
    std::vector<std::vector<int>> adj_list;

public:
    Graph(int n, int m);
    ~Graph() {}
    void add_edge(int u, int v, int c);
    void BFS(int source);
    // int get_path_cost(int source, int destination);
};

int main() {
    handleIO();
    return 0;
}

void handleIO() {
#ifdef FILE_IO
    std::string problem = "bfs";
    std::ifstream inFile(problem + "_in.txt");
    std::streambuf *cinbuf = std::cin.rdbuf(); //save old buf
    std::cin.rdbuf(inFile.rdbuf()); //redirect std::cin to inFile!

    std::ofstream outFile(problem + "_out.txt");
    std::streambuf *coutbuf = std::cout.rdbuf();
    std::cout.rdbuf(outFile.rdbuf());
#endif

    // for each input graph
    //  assign input graph to the graph object
    //  run bfs


#ifdef FILE_IO
    std::cin.rdbuf(cinbuf);
    inFile.close();
    std::cout.rdbuf(coutbuf);
    outFile.close();
#endif
}

//===============================================================================================================//
//                                          Graph class definition begins
//===============================================================================================================//
// Constructor
Graph::Graph(int n, int m) :
nV(n), nE(m),
adj_list(nV),
vertex(nV)
{
}

/*
    For undirected graph,
        We add v into u's list
        Also add u into v's list
*/
void Graph::add_edge(int u, int v, int c) {
    adj_list[u].push_back(v);
    adj_list[v].push_back(u);
}

/*
    Elementary Graph Algorithms
    Breadth First Search
    Given source traverse in breadth first order

    BFS (G, s)
    1 for each vertex u ε G.V - {s}
    2   u.color = WHITE
    3   u.d = INF
    4   u.p = NIL

    5 s.color = GRAY
    6 s.d = 0
    7 s.p = NIL

    8 Q = \Phi
    9 ENQUEUE(Q, s)
    10 while Q not empty
    11   u = DEQUEUE(Q)
    12   for each v ε G:Adj[u]
    13      if v.color == WHITE
    14      v.:color = GRAY
    15      v.d = u.d + 1
    16      v.p = u
    17      ENQUEUE(Q, v)
    18 u.color = BLACK
*/
void Graph::BFS(int source) {
    // initialization part
    for (int u = 0; u < nV; u++) {
        vertex[u].color = WHITE;
        vertex[u].distance = INT_INF;
        vertex[u].predecessor = u;
    }

    std::queue<int> queue;     //ref: http://en.cppreference.com/w/cpp/container/queue/queue
    queue.push(source);

    while (queue.empty() == false) {
        int u = queue.front(); queue.pop();

        for (auto v : adj_list[u]) {
            if (vertex[v].color == WHITE) {
                vertex[v].color = GRAY;
                vertex[v].distance = vertex[u].distance+1;
                vertex[v].predecessor = u;
                queue.push(v);
            }
        }
        vertex[u].color = BLACK;
    }
}

/*/ Get cost from source
int Graph::get_path_cost(int source, int destination) {
    if (source == destination)
        return 0;
    if (destination >= nV || vertex[destination].distance == INT_INF || vertex[destination].distance == 0)
        return -1;
    return vertex[destination].distance;
}*/

//===============================================================================================================//
//                                          Graph class definition ends
//===============================================================================================================//

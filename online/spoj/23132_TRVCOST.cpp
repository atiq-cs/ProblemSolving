/*
* Problem   :    Travelling cost
* URL       :    http://www.spoj.com/problems/TRVCOST/
* Alogirthm :    Graph problem, single source shortest path, destination is specified
* Author    :    Atiq Rahman
* Email     :    atiqcs 'at' outlook 'dot' com
* Date      :    May 31, 2015
* Desc      :
*                Dijkstra ref: Introduction to Algorithms, page 658,
                  by Thomas H. Cormen and Charles E. Leiserson and Ronald L. Rivest and Clifford Stein
                  Simple dijkstra problem, hoping no special case
*                Decision: we choose a 2d matrix to maintain cost instead of using a map
*                    This makes memory requirement of our implementation O(V^2)
*                     A useful alternative is to use map to store the cost using the edge as key
*                    However, note that access time of items in a map is log(N)
*                     ref: http://stackoverflow.com/questions/16068151/c-stl-map-is-access-time-o1
*                     We would only use map when memory is a serious issue and mapping for non-sequential items
* Judge Notes
*  uva-judge :    g++ 4.8.2, C++11 - GNU C++ Compiler with options: -lm -lcrypt -O2 -std=c++11 -pipe -DONLINE_JUDGE
*                 main function should return 0, include cstring for memset
*  tju-judge :  gcc 4.5.2, old, does not support C++11 all features
*  spoj      :  g++ 4.9.2, C++ 14
* Status    :  Accepted [memory used: 3.2M, time: 0.0]
* meta      :  tag-graph-dijkstra, tag-sssp
*/

#include <cstring>    // for memset
#include <sstream>
#include <vector>
#include <iostream>
#include <algorithm>
#include <queue>
#include <iomanip>    // for precision

#define INT_INF    0x7fffffff
#define NIL -1
// Comment before submission to judge
#define FILE_IO    TRUE

#ifdef FILE_IO
#include <fstream>
#endif

void handleIO();

/* Class graph: undirected
Uses dynamic size of adjacency list
memory is manually allocated and cleaned up like a gentle man

*/
typedef struct Graph_Vertex_Type {
    int index;
    int distance;
    int predecessor;
} Vertex;

typedef struct Edge_Edge_Type {
    int u;
    int v;
    int c;
} Edge;


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
    int get_path_cost(int source, int destination);
};

int main() {
    handleIO();
    return 0;
}

void handleIO() {
#ifdef FILE_IO
    std::string problem = "trvcost";
    std::ifstream inFile(problem + "_in.txt");
    std::streambuf *cinbuf = std::cin.rdbuf(); //save old buf
    std::cin.rdbuf(inFile.rdbuf()); //redirect std::cin to inFile!

    std::ofstream outFile(problem + "_out.txt");
    std::streambuf *coutbuf = std::cout.rdbuf();
    std::cout.rdbuf(outFile.rdbuf());
#endif

    Graph graph(502);        // 500 is max size as specified by problem description
    int seq = 1;
    int nE;    // nE = m
    while (std::cin >> nE) {
        int nV = 0;    // have to find it from edge inputs
        std::vector<Edge> edge_list;
        // take input, nE number of edges
        for (int i = 0; i < nE; i++) {
            int u, v, c;    // start vertex u, end vertex and cost of the edge
            // save all edges, we are waiting till we find nV
            std::cin >> u >> v >> c;
            nV = std::max(nV, std::max(u, v));
            edge_list.push_back({u, v, c});
        }
        // we got last index in nV
        nV++;    // 0-based index therefore should be incremented index

        // must be called before init
        graph.set_VE(nV, nE);
        graph.init();
        for (int i = 0; i < nE; i++)
            graph.add_edge(edge_list[i].u, edge_list[i].v, edge_list[i].c);

        // get source
        int source;
        std::cin >> source;
        graph.ss_dijkstra(source);

        int num_dest;    // number of destination locations
        std::cin >> num_dest;
        for (int i = 0; i < num_dest; i++) {
            int destination;
            std::cin >> destination;
            int cost = graph.get_path_cost(source, destination);
            if (cost == -1)
                std::cout << "NO PATH" << std::endl;
            else
                std::cout <<cost<< std::endl;
        }
    }

#ifdef FILE_IO
    std::cin.rdbuf(cinbuf);
    inFile.close();
    std::cout.rdbuf(coutbuf);
    outFile.close();
#endif
}

// Graph class definition begins
// Constructor
Graph::Graph(int max_vertex) :
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
        Vertex tmp = { i, 0, 0 };
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

    queue.push(vertex[source]);

    while (queue.empty() == false) {
        int u = queue.top().index; queue.pop();
        // ignore vertices that don't have cost updated
        // as we will be inserting same vertices multiple times
        if (vertex[u].distance != INT_INF)
            for (auto v : adj_list[u]) {
                int w = edge_cost[u][v];
                if (edge_relax(u, v, w))        // our alternative to decrease-key in priority queue
                    queue.push(vertex[v]);
            }
    }
}

/* page 648
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

// Get cost from source
int Graph::get_path_cost(int source, int destination) {
    if (source == destination)
        return 0;
    if (destination >= nV || vertex[destination].distance == INT_INF || vertex[destination].distance == 0)
        return -1;
    return vertex[destination].distance;
}

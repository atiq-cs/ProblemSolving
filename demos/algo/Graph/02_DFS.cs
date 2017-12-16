/***************************************************************************
*   Problem Name:   DFS implementation
*   Problem URL :   related problem: http://acm.timus.ru/problem.aspx?space=1&num=1471
*   Date        :   
*
*   Algo, DS    :   Simple Sum
*   Desc        :   Arithmetic
*
*   Complexity  :   O(1)
*   Author      :   Atiq Rahman
*   Status      :   
*   Notes       :   This is initial implementation
*                   This has to be improved further by testing with more problems
***************************************************************************/

using System;
using System.Collections.Generic;

enum COLOR { WHITE, GRAY, BLACK };

struct Vertex {
    public int distance;
    // int predecessor;
    public Byte color;
    /* public Vertex(Byte local_color) {
        color = local_color;
        // value of distance is invalid if color is white
        distance = 0;
    }*/
}

public class Graph { 
    int nV;
    // int nE;
    // we need adj_matrix for fast access to weigth
    int[][] adj_matrix;
    List<int>[] adj_list;
    Vertex[] vertex;
    int dest;
    int time;   // used in dfs

    public Graph(int n) {
        nV = n;
        vertex = new Vertex[nV];
        // init adj_matrix
        // create uniform array using syntax for jagged array ref: http://stackoverflow.com/questions/12567329/multidimensional-array-vs
        adj_matrix = new int[nV][];

        // init adj_list, List ref: https://msdn.microsoft.com/en-us/library/6sh2ey19(v=vs.110).aspx
        adj_list = new List<int>[nV];

        for (int i = 0; i < nV; i++)
        {
            adj_matrix[i] = new int[nV];
            adj_list[i] = new List<int>();
            vertex[i].color = (Byte) COLOR.WHITE;
        }
        time = 0;
    }

    public void add_edge(int u, int v, int w)
    {
        adj_list[u].Add(v);
        adj_list[v].Add(u);

        adj_matrix[u][v] = w;
    }

    // run for single DFS forest instead of running DFS from all nodes
    // the modified version of dfs return distance between u and v
    void dfs(int u) {
        dfs_visit(u);
    }

    void dfs_visit(int u) {
        time++;
        vertex[u].distance = time;
        vertex[u].color = (Byte) COLOR.GRAY;
        if (u == dest)
            return;

        foreach (int v in adj_list[u]) {
            if (vertex[v].color == (Byte)COLOR.WHITE) { 
                // v.predecssor = u
                dfs_visit(v);
                if (v == dest)
                    break;
            }
        }

        vertex[u].color = (Byte) COLOR.BLACK;
        // not required for our algo
        time++;
    }

    public int get_distance(int u, int v) {
        dest = v;
        dfs(u);
        return vertex[v].distance;
    }
}

public class Sum
{
    // main method handles the IO and prints output for each input set
    private static void Main()
    {
        // input n
        int n;
        Int32.TryParse(Console.ReadLine(), out n);

        Graph tree_graph = new Graph(n);

        // Take input - n nodes weighted
        for (int i = 0; i < n-1; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            int u, v, w;
            Int32.TryParse(tokens[0], out u);
            Int32.TryParse(tokens[1], out v);
            Int32.TryParse(tokens[2], out w);

            tree_graph.add_edge(u,v,w);
        }

        // input m
        int m;
        Int32.TryParse(Console.ReadLine(), out m);

        for (int i = 0; i < m; i++)
        {
            // read each query
            string[] tokens = Console.ReadLine().Split();
            int u, v;
            Int32.TryParse(tokens[0], out u);
            Int32.TryParse(tokens[1], out v);

            int d = tree_graph.get_distance(u, v);
            Console.WriteLine(d);
        }
    }
}

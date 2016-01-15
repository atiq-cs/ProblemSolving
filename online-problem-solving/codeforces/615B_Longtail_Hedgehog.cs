/***************************************************************************
*   Problem     :  Longtail Hedgehog
*   URL         :  http://codeforces.com/contest/615/problem/B
*   Date        :  Jan 12, 2016
*
*   Algo, DS    :  Dynamic Programming
*   Desc        :  Linear DP with DFS
*   Complexity  :  O(V+E)
*   Author      :  Atiq Rahman
*   Status      :  Accepted
*   Notes       :  Numbers of points are strictly increasing, such a simple
*                   solution has been possible because of this relaxation
*                   A DFS implementation also solves this problem
*                       ref: https://github.com/sreezin
*   meta        :  tag-dynamic-programming, tag-dfs
***************************************************************************/

using System;
using System.Collections.Generic;

public class Solution {
    private static void Main() {
        GraphDemo graph_demo = new GraphDemo();
        graph_demo.TakeInput();
        Console.WriteLine(graph_demo.fun_dp());
    }
}

public class GraphDemo {
    int[] degreeCount;
    long[] maxDist;
    List<int>[] AdjList;
    int nV;

    public void TakeInput() {
        string[] tokens = Console.ReadLine().Split();
        nV = int.Parse(tokens[0]);
        int nE = int.Parse(tokens[1]);
        degreeCount = new int[nV];
        maxDist = new long[nV];
        AdjList = new List<int>[nV];
        for (int i = 0; i < nV; i++)
            AdjList[i] = new List<int>();

        for (int i = 0; i < nE; i++) {
            tokens = Console.ReadLine().Split();
            int u = int.Parse(tokens[0])-1;
            int v = int.Parse(tokens[1])-1;
            if (u == v)
                continue;
            degreeCount[u]++;
            degreeCount[v]++;
            if (u > v)
                AdjList[u].Add(v);
            else
                AdjList[v].Add(u);
        }
    }

    public long fun_dp() {
        for (int v = 1; v < nV; v++)
            foreach (int u in AdjList[v])
                if (maxDist[v] < maxDist[u] + 1)
                    maxDist[v] = maxDist[u] + 1;

        long maxOutcome = 0;
        for (int v = 0; v < nV; v++)
            maxOutcome = Math.Max(maxOutcome, (maxDist[v] + 1) * degreeCount[v]);
        return maxOutcome;
    }
}

/*
	Statement of proofs:
	My queue is correct.
	My adjacency list works perfectly.
	My BFS is correct.

	And I got accepted by UVA online judge
	There are problems with judge input file (such as number of nodes more than that it is described).

*/

#include <cstdio>
#include <map>
#include <queue>
using namespace std;


int Adj[100][100], len[100], VertexNo;

int main () {
	int BFS_visit(int source, int range);
//	freopen("336_in.txt", "r", stdin);

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
		//	printf("inserting u: %d, v: %d\n", u, v);

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
	int d[40], reachable =0, u, i, v;

	memset(d, 255, VertexNo * sizeof(int));
/*	for (i=0; i<10; i++)
		printf("(%d) %d  ", i, d[i]);
	putchar('\n');*/
	d[source] = 0;

	queue<int> Q;
	Q.push(source);

	while (!Q.empty()) {
		u = Q.front();
		Q.pop();
//		printf("u: %d\n",u);
		if (d[u] <=range) {
			reachable++;
			for (i=0; i<len[u]; i++) {
				v = Adj[u][i];
				if (d[v]<0) {
					d[v] = d[u] + 1;
					Q.push(v);
				}
			}
		}
		else
			break;
	}
	return reachable;
}

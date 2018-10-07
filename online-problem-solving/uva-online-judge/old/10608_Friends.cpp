/*******************************************************
*		Problem Name:	Friends
*		Problem ID:				UVA 10608
*		Occassion:				Offline Solving
*		Description:			Have to find out the maximum number of elements
*		Algorithm:				Union Find
*		Special Case:			N/A
*		Judge Status:			Accepted
*		Author:						Atiqur Rahman
*******************************************************/
//#include <iostream>
#include <cstdio>
//#include <cmath>
#include <cstring>
//#include <new>
//#include <vector>
//#include <queue>
//#include <map>
//#include <algorithm>
//#include <iomanip>//for cout formatting
//#define	INF 2147483648
//#define EPS 1e-8
using namespace std;

void makeSet(int n);
int findSet(int i);
void Union(int x, int y);
int findMaxNoMembers(int n);

int sets[31005],no_child[31005], rank[31005];

int main() {
//	freopen("10608_in.txt", "r", stdin);
	int i, no_groups, t, n, m, a, b;

	// Union Find Algorithm Implementation
	scanf("%d", &t);
	
	while (t--) {
		scanf("%d %d", &n, &m);
		makeSet(n);
		
		while (m--) {
			scanf("%d %d", &a, &b);
			Union(findSet(a), findSet(b));
		}
/*		for (i=1; i<=n; i++) {
			printf("%d  %d   %d\n", i, sets[i], no_child[i]);
		}
		putchar('\n');*/
		no_groups=findMaxNoMembers(n);
		printf("%d\n", no_groups);
	}
	
	return 0;
}

void makeSet(int n) {
	int i;
	for (i=1; i<=n; i++) {
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
	if (rank[x]>rank[y]) {
		sets[y] = x;
		no_child[x] += no_child[y];
	}
	else {
		sets[x] = y;
		no_child[y] += no_child[x];
		if (rank[x]==rank[y])
			rank[y]++;
	}
	}
}

int findMaxNoMembers(int n) {
	int max, i;

	for (max=no_child[1],i=2; i<=n; i++) {
		if (max < no_child[i])
			max = no_child[i];
	}
	return max;
}

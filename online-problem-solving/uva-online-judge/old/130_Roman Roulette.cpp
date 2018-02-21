/*******************************************************
*		Problem Name:			Roman Roulette
*		Problem ID:				130
*		Occassion:				Offline Solving
*
*		Algorithm:				Simulation
*		Special Case:			Panditi (more efficient korte etc gelei vezal)
*		Judge Status:			Accepted
*		Author:					Atiqur Rahman
*******************************************************/
#include <cstdio>
#include <vector>
using namespace std;

vector<int> person(100);

int main () {

	freopen("130_in.txt", "r", stdin);

	int josephus_execute(int n, int k, int initPos);
	int survivor, n, k, init;

	while (scanf("%d %d", &n, &k) && (n || k)) {
		for (init=0; init<n; init++) {
			survivor = josephus_execute(n, k, init);
			if (survivor == 1) {
				printf("%d\n", init+1);
			//	getchar();
				break;
			}
		}
	}
	
	return 0;
}

int josephus_execute(int n, int k, int initPos) {
	int i, no_S, curPos, buryPos;

	person.clear();
	for (i=0; i<n; i++)
		person.push_back(i+1);

	no_S = n;
	curPos = (initPos + k -1) % no_S;
	
//	printf("init : %d\n", initPos);
	
	for (i=0; i<n-1; i++) {
	//	printf("Erasing %d in pos %d\n", person[curPos], curPos);
		person.erase(person.begin()+curPos);
		no_S--;
		
		buryPos = (curPos + k-1) % no_S;
		
	//	printf("inserting %d from pos %d\n", person[buryPos], buryPos);
		person.insert(person.begin()+curPos, person[buryPos]);
		if (buryPos>=curPos)
			buryPos++;
		person.erase(person.begin()+buryPos);
	/*	for (int j=0; j<no_S; j++)
			printf("  %d",person[j]);
		putchar('\n');*/
		curPos = buryPos%no_S;
	}
//	puts("Passed");
	return person[0];
}


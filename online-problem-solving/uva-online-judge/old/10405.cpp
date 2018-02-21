/*
/*******************************************************
*		Problem Name:	LCS
*		Problem ID:				10405
*		Occassion:				Offline Solving
*
*		Algorithm:				Only find LCS length
*		Special Case:			If a line is only newline then output zero
*		Judge Status:			
*		Author:						Atiqur Rahman
*******************************************************/
*/

#include <cstring>
#include <cstdio>
using namespace std;
int LCS ();

int c[1005][1005];	   // Calculate scoring for common subsequence
char x[1005], y[1005];

//enum directions{DIAG=1, Up, Left};
//directions dir[m+1][n+1];			// Keeping the directions


int main () {
	int maxLength;

	while (gets(x) && gets(y)) {
		if (x[0]=='\0' || y[0]=='\0')
			maxLength = 0;
		else
			maxLength = LCS();
		printf("%d\n", maxLength);
	}
	
	return 0;
}

int LCS () {
	int i,j, m, n;
	m = strlen(x);
	n = strlen(y);
	for (i=0; i<m; i++)
		c[i][0] = 0;

	for (j=1; j<n; j++)
		c[0][j] = 0;

	for (i=0; i<m; i++)
		for (j=0; j<n; j++) {
			if (x[i] == y[j]) {
				c[i+1][j+1] = c[i][j] + 1;
			//	dir[i+1][j+1] = DIAG;
			}
			else if (c[i+1][j]>=c[i][j+1]) {
				c[i+1][j+1] = c[i+1][j];
				//	dir[i+1][j+1] = Up;
			}
			else {
				c[i+1][j+1] = c[i][j+1];
			//	dir[i+1][j+1] = Left;
			}
		}

	return c[m][n];
}

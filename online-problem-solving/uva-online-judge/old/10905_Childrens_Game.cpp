/***********************************************************************
*		Problem Name:	Children's Game
*		Problem ID:		10905
*		Occassion:		Offline Solving
*
*		Algorithm:			Sorting the strings
*		Special Case:		Integers are at most 90 digits... So array size is a matter
*		Judge Status:		Accepted
*		Author:				Atiqur Rahman
***********************************************************************/
//#include <iostream>
#include <cstdio>
#include <cstring>
//#include <new>
//#include <vector>
//#include <queue>
//#include <map>
#include <algorithm>
//#include <iomanip>//for cout formatting
//#define	INF 2147483648
//#define EPS 1e-8
using namespace std;

int cmp (const void *va, const void *vb);

char comb1[300], comb2[300];

int main() {
//	freopen("10905_in.txt", "r", stdin);

	char num[60][150];
	short N, i;

	while (scanf("%hd", &N) && N) {
		for (i=0; i<N; i++)
			scanf("%s", num[i]);
/*		puts("Before:");
		for (i=0; i<N; i++)
			printf(" %s", num[i]);
		putchar('\n');*/
		
		qsort (num, N, sizeof(num[0]), cmp);
		for (i=0; i<N; i++)
			printf("%s", num[i]);
		putchar('\n');
	}	
	return 0;
}

int cmp (const void *va, const void *vb) {
	char *str1 = (char *)va;
	char *str2 = (char *)vb;
	int i;

//	printf("original: str1: %s, str2: %s\n", str1, str2);
	strcpy(comb1, str1);
	strcpy(&comb1[strlen(comb1)], str2);
	
	strcpy(comb2, str2);
	strcpy(&comb2[strlen(comb2)], str1);
	
//	printf("len1: %d, len2: %d\n", strlen(comb1), strlen(comb2));
//	printf("xy: %s, yx: %s\n", comb1, comb2);
		
	for (i=0; i<strlen(comb1); i++) {
		if (comb1[i]>comb2[i])
			return -1;
		else if (comb1[i]<comb2[i])
			return 1;
	}
	if (i == strlen(comb1))
		return -1;
}

/*
	Notes: There are no leading zeroes in input
	Problem is only they said integers but these integer range is not given and they are at most 90 digits long
	
	The function must return an integer less than, equal to,  or
     greater than zero to indicate if the first argument is to be
     considered less than, equal to, or greater than  the  second
     argument.

	qsort makes a swap only if cmp returns 1;

		memset(arrayName, 255, )	
		cout.setf (ios::fixed, ios::floatfield);
		cout.setf(ios::showpoint);
		cout<<setprecision(2)<<sum_c + eps<<endl;

*/

/*******************************************************
*		Problem Name:	Chess Queen
*		Problem ID:		11538
*		Occassion:		BUET NCPC Contest
*
*		Algorithm:			
*		Special Case:		Very Mathematical
*		Judge Status:		Accepted
*		Author:				Atiqur Rahman
*******************************************************/
//#include <iostream>
#include <cstdio>
//#include <cmath>
//#include <cstring>
//#include <new>
//#include <vector>
//#include <queue>
//#include <map>
//#include <algorithm>
//#include <iomanip>//for cout formatting
//#define	INF 2147483648
//#define EPS 1e-8
using namespace std;

int main() {
	freopen("_in.txt", "r", stdin);

	long long M, N, sum, mulF, mulI;
	
	while (scanf("%lld %lld", &M, &N)) {
		mulF = (n-1) * 4;
		mulI = (n-1) * 3;
		sum = 0;
		if (n%2) {
			while (mulF>0) {
				sum += mulF * mulI;
				mulI += 2;
				mulF -= 8;
			}
			sum += mulI;
		}
		else {
			while (mulF>-5) {
				sum += mulF * mulI;
				mulI += 2;
				mulF -= 8;
			}
		}
		printf("%lld", sum);
	}

	
	return 0;
}

/*
		memset(arrayName, 255, )	
		cout.setf (ios::fixed, ios::floatfield);
		cout.setf(ios::showpoint);
		cout<<setprecision(2)<<sum_c + eps<<endl;

*/

/*
	tju contest problem
	acm: 10918
	Link: http://www.algorithmist.com/index.php/UVa_10918
*/
#include <iostream>
using namespace std;

int main () {
	
	int n,i;
	int domino[32] = {1,3};

//	freopen("F_in.txt","r",stdin);
	
	for (i=2; i<32; i++)
		domino[i] = 4 * domino[i-1] - domino[i-2];

	while (cin>>n && n != -1) {
		if (n%2)
			cout<<"0"<<endl;
		else
			cout<<domino[n/2]<<endl;
	}

	return 0;
}

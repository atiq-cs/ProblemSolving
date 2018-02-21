#include <iostream>
using namespace std;

int main () {
	char c;
	bool f= false;
	//freopen("272_in.txt","r",stdin);
	//cout.put('A');

	while ((c=getchar()) != EOF) {
		if (!f && c=='"') {
			cout.put('`');
			cout.put('`');
			f = true;
		}
		else if (f && c=='\"') {
			cout.put('\'');
			cout.put('\'');
			f = false;
		}
		else
			cout.put(c);
	}
	//fclose(stdin);
	return 0;
}


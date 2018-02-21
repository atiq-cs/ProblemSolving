#include <stdio.h>

int GCD[502] = {0, 0};

int main () {
	int i,j;
	const int limit = 501;
	int n;

	int get_GCD(int a, int b);

	for (i=2; i<limit; i++) {
		GCD[i] = GCD[i-1];
		for (j=1; j < i; j++)
				GCD[i] += get_GCD(i,j);
		//getchar();
		//printf("%d: %d\n",i,GCD[i]);
	}

	freopen("11417_in.txt", "r",stdin);
	
	while(scanf("%d", &n) && n) {
		printf("%d\n", GCD[n]);
	}

	fclose(stdin);
	return 0;
}

int get_GCD(int a, int b) {
	int tmp;
	while (a) {
		tmp = a;
		a = b%a;
		b = tmp;
	}
	return b;
}

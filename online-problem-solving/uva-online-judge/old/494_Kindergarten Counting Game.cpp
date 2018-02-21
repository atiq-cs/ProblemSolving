/*
	Problem Name: Kindergarten Counting Game
	Algorithm      : Native word counting
*/

#include<stdio.h>
#include<ctype.h>

main() {
	char c;
	int l=0,nw=0;

	while ((c=getchar())!=EOF) {
		if (isalpha(c)) {
			if (!l) {
				nw++;	
				l=1;
			}
		}
		else if (c=='\n') {
			printf("%d\n",nw);
			l=0;
			nw = 0;
		}
		else {
			l=0;
		}
	}
	return 0;
}

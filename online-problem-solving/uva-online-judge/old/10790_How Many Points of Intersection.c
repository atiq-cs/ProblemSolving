/*
* Date: 2006-05-29
* meta: tag-easy, tag-math
*/
#include<stdio.h>

void main() {
	long long a,b;
	int i=0;

	while(scanf("%lld %lld",&a,&b)) {
	  i++;
	  if (!a && !b)
      break;
	  printf("Case %d: %lld\n",i,a*b*(a-1)*(b-1)/4);
	}
}

/*
  Problem Name: Skew Binary
  Type        : Uva Problem
  Description: It's a very easy problem, just summing powers skew binary numbers are found.
    It's not a base convertion problem.

*/

#include<stdio.h>
#include<string.h>
#include<math.h>

main () {
  char num[1000];
  long res;
  int len,i;

  while (gets(num) && (num[0]!='0' || num[1]!='\0')) {
    len =strlen (num);
    for (res=0,i=0;i<len;i++) {
      res += (num[i] - '0') * (pow((double)2,(double)(len-i)) - 1);
    }
    printf("%ld\n",res);
  }
  return 0;
}
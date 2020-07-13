/***************************************************************************************************
* Title : Children's Game
* URL   : 10905
* Author: Atiq Rahman
* Notes : Sorting the strings
*   Integers are at most 90 digits... So array size is a matter
*   Regarding inputs,
*   There are no leading zeroes in input
*   Problem is only they said integers but these integer range is not given and they are at most 90 digits long
*
*   The function must return an integer less than, equal to,  or
*   greater than zero to indicate if the first argument is to be
*   considered less than, equal to, or greater than  the  second
*   argument.
*
*   qsort makes a swap only if cmp returns 1;
* meta  : tag-combinatorics, tag-math, tag-order-stat
***************************************************************************************************/
#include <cstdio>
#include <cstring>
#include <algorithm>
using namespace std;

char comb1[300], comb2[300];

int cmp(const void *va, const void *vb) {
  char *str1 = (char *)va;
  char *str2 = (char *)vb;
  int i;

  strcpy(comb1, str1);
  strcpy(&comb1[strlen(comb1)], str2);

  strcpy(comb2, str2);
  strcpy(&comb2[strlen(comb2)], str1);

  for (i = 0; i < strlen(comb1); i++) {
    if (comb1[i] > comb2[i])
      return -1;
    else if (comb1[i] < comb2[i])
      return 1;
  }

  if (i == strlen(comb1))
    return -1;
}

int main() {
  char num[60][150];
  short N, i;

  while (scanf("%hd", &N) && N) {
    for (i=0; i<N; i++)
      scanf("%s", num[i]);
    
    qsort (num, N, sizeof(num[0]), cmp);
    for (i=0; i<N; i++)
      printf("%s", num[i]);
    putchar('\n');
  }

  return 0;
}

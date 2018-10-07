/*******************************************************
*    Problem Name:  Group Reverse
*    Problem ID:  11192
*    Occassion:  Offline Solving
*
*    Algorithm:  Simple
*    Special Case:    
*    Judge Status:  
*    Author:    Atiqur Rahman
*******************************************************/
#include <stdio.h>
#include <string.h>

int main() {
  char str[110], tmp[110];
  int len, i, j, grouplen, n;

  while (scanf("%d", &n) && n) {
    scanf("%s", str);
    len = strlen(str);
    grouplen = len / n;
    for (i=0; i<n; i++) {
      for (j=0; j<grouplen; j++) {
        tmp[grouplen-j-1] = str[i*grouplen+j];
      }
      tmp[j] = '\0';
      printf("%s", tmp);
    }
    putchar('\n');
  }
  return 0;

}



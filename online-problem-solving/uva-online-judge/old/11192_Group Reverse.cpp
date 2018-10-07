/*******************************************************
*    Problem Name:  Group Reverse
*    Problem ID:  11192
*    Occassion:  Offline Solving
*
*    Algorithm:  Simple
*    Special Case:  Nothing
*    Judge Status:  Accepted
*    Runtime:    0.004
*    Author:    Atiq Rahman
*******************************************************/
#include <cstdio>
#include <cstring>
using namespace std;


int main() {
//  freopen("11192_in.txt", "r", stdin);

  char str[110], tmp[110];
  int len, i, j, grouplen, n;

  while (scanf("%d", &n) && n) {
    scanf("%s", str);
    len = strlen(str);
    grouplen = len / n;
    for (j=grouplen, i=0; i<len; i++) {
      tmp[--j] = str[i];
      if (! (j%grouplen))
        j += grouplen * 2;
    }
    tmp[len] = '\0';
    puts(tmp);
  }
  return 0;

}


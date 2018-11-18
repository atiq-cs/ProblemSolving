/***************************************************************************************************
* Title : Group Reverse
* URL   : 11192
* Notes : simple
*   Runtime,    0.004
* meta  : tag-string-palindrome
***************************************************************************************************/
#include <cstdio>
#include <cstring>
using namespace std;

int main() {
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

// first version probably not optimized, not sure if Accepted, tag-lang-c
int main() {
  char str[110], tmp[110];
  int len, i, j, grouplen, n;

  while (scanf("%d", &n) && n) {
    scanf("%s", str);
    len = strlen(str);
    grouplen = len / n;

    for (i = 0; i < n; i++) {
      for (j = 0; j < grouplen; j++)
        tmp[grouplen - j - 1] = str[i * grouplen + j];

      tmp[j] = '\0';
      printf("%s", tmp);
    }

    putchar('\n');
  }

  return 0;
}

/***************************************************************************************************
* Title : 
* URL   : 11151
* Notes : 
* meta  : tag-string-palindrome, tag-lang-c
***************************************************************************************************/
#include<stdio.h>
#include<string.h>

int main() {
  short t, i, ln, j;
  char str[260], rev[260];
  scanf("%hd%*c", &t);

  for (i = 0; i < t; i++) {
    gets(str);
    ln = strlen(str);

    for (j = 0; j < ln; j++)
      rev[ln - j - 1] = str[j];
    rev[ln] = '\0';

    for (j = 0; j < ln; j++)
      if (rev[j] == str[j])
        break;

    if (j)
      printf("%hd\n", j - 1);
    else if (!strcmp(rev, str))
      printf("%hd\n", ln);
  }

  return 0;
}

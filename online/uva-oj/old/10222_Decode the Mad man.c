/***************************************************************************************************
* URL   : 10222
* Status: Accepted
* Notes : 
* meta  : tag-string, tag-hash-table, tag-lang-c
***************************************************************************************************/
#include<stdio.h>
#include<ctype.h>

void main() {
  char c;

  while ((c = getchar()) != EOF) {
    c=tolower(c);
    if (c==']')
      c='p';
    else if (c=='[') c='o';
    else if (c=='p') c='i';
    else if (c=='o') c='u';
    else if (c=='i') c='y';
    else if (c=='u') c='t';
    else if (c=='y') c='r';
    else if (c=='t') c='e';
    else if (c=='r') c='w';
    else if (c=='e') c='q';
    else if (c==39) c='l';
    else if (c==';') c='k';
    else if (c=='l') c='j';
    else if (c=='k') c='h';
    else if (c=='j') c='g';
    else if (c=='h') c='f';
    else if (c=='g') c='d';
    else if (c=='f') c='s';
    else if (c=='d') c='a';
    else if (c=='/') c='<';
    else if (c=='.') c='m';
    else if (c==',') c='n';
    else if (c=='m') c='b';
    else if (c=='n') c='v';
    else if (c=='b') c='c';
    else if (c=='v') c='x';
    else if (c=='c') c='z';

    putchar(c);
  }
}

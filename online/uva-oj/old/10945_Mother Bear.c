/***************************************************************************************************
* Title : 
* URL   : 10945
* Notes : Think simple
* meta  : tag-string-palindrome
***************************************************************************************************/
#include<stdio.h>
#include<string.h>
#include<ctype.h>

void main()
{
  char sen[200],pld[200];
  short i,len,top;

  while(gets(sen)) {
    if (sen[0]=='D' && sen[1]=='O' && sen[2]=='N' && sen[3]=='E' && sen[4]=='\0')
      break;

    len=strlen(sen);
    top=0;
    for (i=0;i<len;i++)
      if (isalpha(sen[i]))
        pld[top++]=tolower(sen[i]);

    pld[top]=NULL;
    for (i=0;i<top/2;i++)
      if (pld[i]!=pld[top-i-1])
        break;

    if (i==top/2)
      printf("You won't be eaten!\n");
    else
      printf("Uh oh..\n");
  }
}

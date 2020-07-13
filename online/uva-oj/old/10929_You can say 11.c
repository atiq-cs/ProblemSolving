/***************************************************************************************************
* Title : 
* URL   : 10929
* Notes : 
* meta  : tag-big-integer
***************************************************************************************************/
#include<stdio.h>
#include<string.h>

void main() {
  char num[1001];
  short len,i;
  unsigned m11;

  while(gets(num)) {
    len=strlen(num);
    if (len==1 && num[0]=='0')
      break;

    m11=0;
    for (i=0;i<len;i++)
      m11=(num[i]-'0'+m11*10)%11;

    if (m11)
      printf("%s is not a multiple of 11.\n",num);
    else
      printf("%s is a multiple of 11.\n",num);
  }
}

/*
  Problem Name: The Decoder
  Type normal encoding of strings
*/

#include<stdio.h>

void main()
{
  char c,k;
  while ((c=getchar())!=EOF)
  {
    if (c=='\n') k=c;
    else k=c-7;
    putchar(k);
  }
}
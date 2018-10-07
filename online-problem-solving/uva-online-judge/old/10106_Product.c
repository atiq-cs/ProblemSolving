/*
  Problem Name: Product
  Algorithm      : Big Integer Multiplication
*/

#include<stdio.h>
#include<string.h>

void main()
{
     char a[251],b[251],m[502],ra[502];
     short la,lb,i,j,max,ml,ad,carry,lt,dif;

     while(gets(a))
     {
         gets(b);
         la=strlen(a);
         lb=strlen(b);

         for (i=0;i<la+lb;i++)
         {
             m[i]=0;
             ra[i]=0;
         }
         lt=0;
         /*Multiplication*/
         for (i=lb-1;i>=0;i--)
         {
          carry=0;lt=0;
             for (j=la-1;j>=0;j--)
             {
                 ml=(b[i]-48)*(a[j]-48)+carry;
                 /*printf("ml: %hd\n",ml);*/
                 if (ml==10)
                 {
                     m[lt]=0;
                     carry=1;
                 }
                 else
                 {
                     m[lt] = ml%10;
                     carry=ml/10;
                 }
                 lt++;
                 /*printf("m: %c\n",m[lt-1]+48);*/
             }
             if (carry) {m[lt++]=carry;carry=0;
                 /*printf("m c: %c\n",m[lt-1]+48);*/}

             /*Addition*/
             /*printf("i: %hd lt: %hd\n",i,lt);*/
             dif=lb-i-1;
             for (j=dif;j<lt+dif;j++)
             {
                 ad=ra[j]+m[j-dif]+carry;
                 /*printf("lt: %hd ad: %hd ra: %c j: 
%hd\n",lt,ad,(ra[j]+48),j);*/
                 if (ad>9)
                 {
                     ra[j]=ad-10;
                     carry=1;
                 }
                 else
                 {
                     ra[j]=ad;
                     carry=0;
                 }
             }
             if (carry) {ra[j++]=carry;
                 /*printf("ad c: %hd\t %c %hd\n\n",ad,(ra[j-1]+48),j);*/}
         }
         lt=0;
         for (i=j-1;i>=0;i--)
         {
           if (ra[i]!=0) lt=1;
           if (lt) putchar(ra[i]+48);
         }
         if (!lt) putchar('0');
         putchar('\n');
     }
}

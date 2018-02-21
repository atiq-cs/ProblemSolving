/*
	Problem Name: Integer Inquiry
	Type: Calculate for the Big Integer Numbers
*/

#include<stdio.h>
#include<string.h>

void main()
{
    char m[101],ra[111];
    short max=0,p,ad,i,lm,carry;

        for (i=0;i<111;i++)
            ra[i]=0;

    while(gets(m) && m[0]!='0' || m[1]!='\0')
    {
            lm=strlen(m);carry=0;
	for (i=0;i<lm;i++)
            {
                p=lm-1-i;
	       ad=ra[i]+(m[p]-48)+carry;
                /*printf("lt: %hd ad: %hd ra: %c j: 
%hd\n",lt,ad,(ra[j]+48),j);*/
                if (ad>9)
                {
                    ra[i]=ad-10;
                    carry=1;
                }
                else
                {
                    ra[i]=ad;
                    carry=0;
                }
            }
            if (carry)
	   {
	   	if (ra[i]==9) ra[i++]=0;
		ra[i++]+=1;
	   }
	   i--;
	   max=i>max?i:max;
	   /*printf("max: %hd\n",max);*/
     }
        for (i=max;i>=0;i--)
               putchar(ra[i]+48);
        putchar('\n');
}
/*Hands locked*/
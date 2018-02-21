/*
	Problem Name: Stacks of flapjacks
	Operation:       Flipping, sequential reverse
	Description: In this problem to arrange element we hava to flip to bottom twice.
		once for the item to take it to top then flip to bottom
*/

#include<stdio.h>
#include<stdlib.h>

int main()
{
       int i=0,st[31],j=0,k,ps,max,gr,tm,f,l;
       char c,ln[4]={'\0','\0','\0','\0'};

       for (k=0;k<31;k++)			/*Initialization*/
               st[k]=0;
       while ((c=getchar())!=EOF)
       {
               if (c==' ')
               {
                       ln[i]=NULL;
                       st[j++]=atoi(ln);
                       i=0;
               }
               else ln[i++]=c;
               putchar(c);
               if (c=='\n')
               {
                       ln[i]=NULL;
                       st[j++]=atoi(ln);
                       i=0;
                       gr=j-1;
                       while(gr>0)
                       {
                               f=0;
                               for (max=st[gr],k=gr-1;k>=0;k--)
                               {
                                       if (max<st[k])					/*Finds the greatest element in the stack*/
                                       {
                                               max=st[k];f=1;			/*Reducing run-time checking if arranged*/
                                               ps=k;
                                       }
                               }

                               if (f)									/*If a greatest element is found*/
                               {
                                       if (ps)							/*If the greatest element is not in bottom*/
                                       {
									       printf("%d ",(j-ps));		/*Replace the great in bottom & flips both*/
										   for (k=0;k<(ps+1)/2;k++)
										   {
                                               tm=st[k];
                                               st[k]=st[ps-k];
                                               st[ps-k]=tm;
										   }
										   for (k=0;k<(gr+1)/2;k++)
										   {
                                               tm=st[k];
                                               st[k]=st[gr-k];
                                               st[gr-k]=tm;
										   }
                                       }
                                       else								/*Replace to bottom & flip*/
                                       {
											for (k=0;k<(gr+1)/2;k++)
											{
                                               tm=st[k];
                                               st[k]=st[gr-k];
                                               st[gr-k]=tm;
											}
                                       }
                                       printf("%d ",j-gr);
                               }
                               else									/*Checking if already arranged*/
                               {
                                       for (k=gr;k>0;k--)
                                       {
                                               l=1;
                                               for (tm=k-1;tm>=0;tm--)
                                                       if (st[k]<st[tm]) {
														   l=0;break;
													   }
                                               if (!l) break;		/*Breaking from unnecessary loop*/
                                       }
                                       if (l) break;
                               }
                               gr--;
                       }
                       printf("0\n");
                       j=0;
                       for (k=0;k<31;k++)
                               st[k]=0;
               }
       }
	   return 0;
}

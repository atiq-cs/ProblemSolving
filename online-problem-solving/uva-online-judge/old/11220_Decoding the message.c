#include<stdio.h> 
#include<ctype.h> 

main() { 
   int n,i,l,nw,pos; 
   char c,t; 

   scanf("%d",&n); 
   getchar();

   for (i=0;i<n;i++) { 
      l=0; 
      nw=0; 
      pos=0; 
      t='\0'; 
      if (i) putchar('\n'); 
      printf("Case #%d:\n",i+1); 
      while((c=getchar())) { 
         if (c=='\n') { 
            if (t=='\n') { 
               break; 
            } 
            else putchar('\n'); 
            l=0; 
            nw=0; 
         } 
         else if (isalpha(c)) { 
            if (!l) { 
               if (!nw) putchar(c); 
               nw++;    
               l=1; 
               pos = 1; 
            } 
            else { 
               pos++; 
               if (pos==nw) putchar(c); 
            } 
         } 
         else if (c==EOF) break; 
         else { 
            if (pos<nw && pos) { 
               nw--; 
               pos=0; 
            } 
            l=0; 
         } 
         t=c; 
      } 
   } 
   return 0;
} 

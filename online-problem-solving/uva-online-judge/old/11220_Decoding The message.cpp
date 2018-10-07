// Ac

#include<stdio.h> 
#include<string.h> 

int main(void) 
{ 
   char string[3000]; 
   char string1[110][50]; 
   char *p; 
   int l,count,test,res=1,j=0,k,c=0; 
  //freopen("in_11220.txt","r",stdin);
   scanf("%d\n",&test); 
    
   while(test--) 
   { 
      j=k=0; 
      while(gets(string)) 
      { 
         count=1; 
         p=strtok(string,"' '"); 
         if(p==NULL) 
            break; 
         if(p) 
         { 
            l=strlen(p); 
            if(l>=count) 
               string1[j][k++]=p[count-1]; 
            else 
               count--; 
         } 
         while(p=strtok(NULL,"' '")) 
         { 
            if(p) 
            { 
               count++; 
               l=strlen(p); 
               if(l>=count) 
                  string1[j][k++]=p[count-1]; 
               else 
                  count--; 
            } 
         } 
         string1[j][k]='\0'; 
         j++; k=0; 
      } 
      if(c) printf("\n"); c=1;
    printf("Case #%d:\n",res++); 
      for(l=0;l<j;l++)  printf("%s\n",string1[l]); 
      //printf("\n"); 
   } 
//fclose(stdin);
   return 0; 
} 

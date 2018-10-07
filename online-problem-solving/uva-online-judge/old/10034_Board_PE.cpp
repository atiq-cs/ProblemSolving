#include<stdio.h>
#include<math.h>
main()
{
  int t[100][2],nr[101],n,m,i,j,k;
  unsigned long c;
  float cost[101][101];
  float x[101],y[101],x1,y1;
  float min,temp;

  scanf("%lu",&c);
  while(c) {
    min=0.0;c--;
    scanf("%d",&n);
    for(i=1;i<=n;i++) {
      scanf("%f %f",&x1,&y1);
      x[i]=x1*10;y[i]=y1*10;
    }

    for(i=1;i<=n;i++)
      cost[i][i]=0.0;
    for(i=1;i<=n;i++)
      for(j=i+1;j<=n;j++) {
        cost[i][j]=(x[i]-x[j])*(x[i]-x[j])+(y[i]-y[j])*(y[i]-y[j]);
        cost[j][i]=cost[i][j];
      }
    for(i=2;i<=n;i++)
      nr[i]=1;
    nr[1]=0;

    for(i=1;i<n;i++) {
      m=-2;
      for(j=2;j<=n;j++) {
        if(nr[j]!=0 && m==-2)
          m=j;
        if(nr[j]!=0)
          if(cost[j][nr[j]]<cost[m][nr[m]]) m=j;
      }
      temp=cost[m][nr[m]]*100;
      temp=sqrt(temp);
      min=min+temp ;
      nr[m]=0;
      for(k=2;k<=n;k++) {
        if(nr[k]!=0)
          if(cost[k][nr[k]]>cost[k][m]) nr[k]=m;
      }
    }
    printf("%.2f",min/100);
    if(c!=0) printf("\n\n");
  }
}

/***************************************************************************************************
* Title : A Node Too Far
* Author: Md Abdul Kader (Sreezin)
* URL   : 336
* Date  : 2018-11-13
* Comp  :
* Status: Accepted
* Notes : here, for historical reason, unmodified code of MAK
***************************************************************************************************/
#include<cstdio>
#include<cmath>
#include<cstdlib>
#include<cstring>
#include<string>
#include<cctype>
#include<iostream>
#include<stack>
#include<set>
#include<map>
#include<queue>
#include<vector>
#include<algorithm>
using namespace std;
#define INF  1147483647
#define EPS  0.000000001
#define MAX(a,b)  ((a>b)?a:b)
#define MIN(a,b)  ((a<b)?a:b)
#define SET(NAME,FROM,TO,BY)   {for(int _i=FROM;_i<=TO;_i++) NAME[_i]=BY;}
#define CLEAR(A,N)  (memset(A,0,(N)*sizeof(A[0])))

/*
#ifndef ONLINE_JUDGE
 typedef __int64 LL;
 #define ID "%I64d"
 typedef unsigned __int64 ULL;
 #define UID "%I64u"
#else if
 typedef long long LL;
 #define ID "%lld"
 typedef unsigned long long ULL;
 #define UID "%llu"
#endif
*/


map<int,int> m;
map<int,int>::iterator it;
vector<int> vec[40];
int nnode=0,cost[40],color[40];

void reset(){

  int i;
  for(i=0;i<nnode;i++)
    vec[i].clear();
  m.clear();
  nnode=0;
  

}
void bfs(int s){

  queue<int> q;
  int i,p;
  cost[s]=0;
  q.push(s);
  color[s]=1;
  while(!q.empty()){
  
    p=q.front();
    q.pop();

    for(int i=0;i<vec[p].size();i++)
      if(color[vec[p][i]]==0)
      {
        cost[vec[p][i]]=cost[p]+1;
        q.push(vec[p][i]);
        color[vec[p][i]]=1;
      }
  }


}
int unreachable(int len){

  int i,c=0;
  
  for(i=0;i<nnode;i++)
    if(cost[i]>len)
      c++;
    return c;
}
int main()
{
  //freopen("in.txt","rt",stdin);
  int n,a,b,len,cas=0,i;
  while(scanf("%d",&n)==1&&n){
  
    reset();

    for(i=0;i<n;i++){
      scanf("%d%d",&a,&b);
    
      it=m.find(a);
      if(it==m.end())      
        m[a]=nnode++;
      
      it=m.find(b);
      if(it==m.end())      
        m[b]=nnode++;

      vec[m[a]].push_back(m[b]);
      vec[m[b]].push_back(m[a]);
    }
    while(scanf("%d%d",&n,&len)==2&&( n || len)){
    
      SET(cost,0,nnode,INF);
      
      CLEAR(color,nnode);
      bfs(m[n]);
      printf("Case %d: %d nodes not reachable from node %d with TTL = %d.\n",++cas,unreachable(len),n,len);
    
    }
    
  
  
  }  
return 0;
}

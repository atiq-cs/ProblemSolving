#include<iostream>
#include<cstdio>
#ifndef ONLINE_JUDGE
typedef __int64 LL;
 //#define lld %I64
#else if
 typedef long long LL;
 //#define lld I64d
#endif

using namespace std;

const int limit = 1000000;
LL prime[limit] = {2};
int top = 1;
bool isPrime[limit];


int main (){
  void Seive_generate_prime(int size);
  Seive_generate_prime(limit);
  
  LL n;
  LL factor[100];
  bool f= true;

  while (scanf("%I64d",&n) && n >= 0) {
    int i;
    int top = 0;

    if (f)
      f = false;
    else
      cout<<endl;

    for (i = 0; prime[i] * prime[i] <= n; i++) {
      if (n % prime[i] == 0) factor[top++] = prime[i];
      while (n % prime[i] == 0) {
        n /= prime[i];
      }
    }
    if (n > 1)
      factor[top++] = n;
    for (i = 0; i<top; i++)
      printf("    %I64d\n",factor[i]);
  }
  /*for (int i=0; i< 100; i++)
    cout<<"i: "<<prime[i]<<endl;*/
  return 0;
}

void Seive_generate_prime(int size){
  memset(isPrime, 1, sizeof(bool)*size);
  int i,j;


  for (i=3; i <= size; i += 2)
    if (isPrime[i] == true) {
      //cout<<"here1"<<endl;
      for (j=i*i; j>0 && j<=size; j += 2*i) {
        isPrime[j] = false;
        //cout<<"cutting j: "<<j<<endl;  
        
      }
      
      //cout<<"here2"<<endl;
      prime[top++] = i;
      //cout<<i<<endl;
    }
}

/*
#include<iostream>
#include<cstdio>
using namespace std;

const int limit = 10000000;
long long prime[limit] = {2};
int top = 1;
bool isPrime[limit];


int main (){
  void Seive_generate_prime(int size);
  Seive_generate_prime(limit);
  
  long long n;
  long long factor[100];
  bool f= true;

  while (scanf("%lld",&n) && n >= 0) {
    int i;
    int top = 0;

    if (f)
      f = false;
    else
      cout<<endl;

    for (i = 0; prime[i] * prime[i] <= n; i++) {
      if (n % prime[i] == 0) factor[top++] = prime[i];
      while (n % prime[i] == 0) {
        n /= prime[i];
      }
    }
    if (n > 1)
      factor[top++] = n;
    for (i = 0; i<top; i++)
      printf("    %lld\n",factor[i]);
  }
  /*for (int i=0; i< 100; i++)
    cout<<"i: "<<prime[i]<<endl;*/
  return 0;
}

void Seive_generate_prime(int size){
  memset(isPrime, 1, sizeof(bool)*size);
  int i,j;


  for (i=3; i <= size; i += 2)
    if (isPrime[i] == true) {
      //cout<<"here1"<<endl;
      for (j=i*i; j>0 && j<=size; j += 2*i) {
        isPrime[j] = false;
        //cout<<"cutting j: "<<j<<endl;  
        
      }
      
      //cout<<"here2"<<endl;
      prime[top++] = i;
      //cout<<i<<endl;
    }
}


*/
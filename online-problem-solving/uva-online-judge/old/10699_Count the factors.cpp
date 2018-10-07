/*
  Problem Name    :     Count the factors
  Description of solving  :     Prime factor generating problem. Also used DP here
               Using DP I generated all the prime numbers upto the square root of maximum limit(1000000), then I 
               used for loop to determine which are the prime factors of given number,
               The problem was that the prime factor greater than square root I could not handle (In this perspective I would have
               to use more efficient prime generator algorithm like bitwise sieve). I simply divided by every prime factors the given number
               if the result is prime and not 1 then I added 1. 
               Thus came the result
  Judge Status    :    CE
*/

#include<iostream>
#include<cmath>
using namespace std;

const int limit = 1000,size = 172;          //Because there are only 168 prime numbers within 1000
int pr[size]={2};

main () {
  
  int i;

  int gen_prime_dp();
  int number_primes = gen_prime_dp();

  for (i=0;i<number_primes;i++)
    cout<<pr[i]<<"\t";
  cout<<" "<<number_primes<<endl;*/

  int n,sq,no_factor;
  bool flag;

  while(cin>>n && n) {
    flag = true;
    sq = (int) sqrt(n);
    no_factor = 0;
    cout<<n;
    for (i=0;pr[i]<=sq;) {
      if (!(n%pr[i])) {
        if (flag) {
          no_factor ++;
          flag = false;
        }
        //cout<<"divisible by: "<<pr[i]<<endl;
        n /= pr[i];
      }
      else {
        i++;
        flag = true;
      }
    }

    sq = (int) sqrt(n);
    for (flag=true,i=0;pr[i]<=sq;i++)
      if (!(n%pr[i])) {
        flag = false;
        break;
      }


    if (flag && n!=1) no_factor++;
    cout<<" : "<<no_factor<<endl;
  }
  return 0;
}

int gen_prime_dp() {
  int i=1,j,en;

  for (j=3;i <= size;j+=2) {
    for (en=0;en<i;en++)
      if (!(j%pr[en])) break;
    if (en==i) pr[i++]=j;
     }

  return i;
}

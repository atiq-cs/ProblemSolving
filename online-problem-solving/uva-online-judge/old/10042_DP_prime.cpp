/**********************************************************************************************************
	Problem Name:	Smith Numbers
	Judge Status:		Accepted  	(C++  	0.730  	2008-12-25 15:40:53)
	Description:		Technique: "If we divide a number with all its prime factors upto square root  of that number then if result still greater than one then the result is also a prime number"
**********************************************************************************************************/

#include <cstdio>
#include <cmath>
#include <cstdlib>
using namespace std;

unsigned sum_digits(long long n);
void generate_prime (long long n);

long long prime_array[40000] = {2};

int main() {
//    freopen("10042_in.txt", "r", stdin);
	unsigned i, sumf, sumN, t, T, fr, check_prime;
    long long en, n;

    generate_prime(40000);
    scanf("%u",&T);
    for (t=0; t<T; t++) {
        scanf("%lld",&n);
        for (n++;;n++) {
                sumN = sum_digits(n);
        //        printf("sum of digits of %lld: %u\n", n, sumN);
                sumf = 0;
                en = n;
                check_prime = 0;
        		for(i=0;prime_array[i]<=sqrt(n);i++) {
                    fr = 0;
                    while (en%prime_array[i] == 0) {
                        fr++;
                        en /= prime_array[i];
                    }
                    if (fr) {
                        sumf += fr * sum_digits(prime_array[i]);
                        check_prime += fr;
             //           printf("matched %d times for %d sumf %d and en: %d, n %lld\n", fr, prime_array[i], sumf,en, n);
                    }
        		}
                if (en>1) {
                        check_prime++;
                        sumf += sum_digits(en);
                    //    printf("sumf: %d en: %d\n", sumf, en);
                }
                if (check_prime>1 && sumf == sumN) {
                   printf("%lld\n", n);
                   break;
                }
        	}
    }
	return 0;
}

unsigned sum_digits(long long n) {
    unsigned int sum = 0;
    while (n) {
          sum += n %10;
    //      printf("before n: %lld\n", n);
          n = n/10;
    //      printf("after n: %lld\n", n);

    }
    return sum;
}

void generate_prime (long long n) {
	unsigned ind=1,j;
	long long i;
	bool pf=0;
	for (i=3;;i++) {
		for (j=0;j<ind && prime_array[j] <= sqrt(i);j++) {
			if (!(i % prime_array[j])) {
				//if (i==511) cout<<"got: "<<prime_array[j]<<endl;
				pf =1;
				break;
			}
		}
		if (!pf) {
			prime_array [ind++] = i;
		//	cout<<" "<<prime_array[ind-1];
		}
		else pf = 0;
		if (n  < ind) break;
	}
}


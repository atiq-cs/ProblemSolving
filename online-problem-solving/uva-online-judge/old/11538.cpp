/*
	BUET NCPC 2008
	Judge status:	AC
	Solved long after the contest time
*/

#include <cstdio>
using namespace std;

int main () {
    long long res, m, n, tmp;
   
    while (scanf("%lld %lld", &m, &n) && (m || n)) {
        if (m<n) {
            tmp = m;
            m = n;
            n = tmp;
        }
        res = 2 * (2 * n * (n * n -1)/3 + (m-n-1) * n * (n-1)) + m*n*(m+n-2);
        printf("%lld\n", res);
    }
    return 0;
}

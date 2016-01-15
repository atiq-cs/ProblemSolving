/*
*	Problem Name:	Summing the N series
*	Problem No	:	https://www.hackerrank.com/challenges/summing-the-n-series
*   Domain      :   Mathematics/Fundamentals
*	Problem Type:	Basic Math
*	Alogirthm	:   math
*	Author		:	Atiqur Rahman
*	Desc		:	Apply big mod technique
*
*	Status		:	Accepted
*/

#include <iostream>

int main() {
	unsigned long long n;
	unsigned long long cp = 1000000007;
	unsigned long long res = 0;

	int testcase; std::cin >> testcase;

	while (testcase--) {
		std::cin >> n;
		res = (n % cp) * (n % cp) % cp;
		std::cout << res << std::endl;
	}
	return 0;
}

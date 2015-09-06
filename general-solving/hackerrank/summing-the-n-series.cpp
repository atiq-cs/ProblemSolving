/*
*	Problem Name:	Summing the N series
*	Problem No	:	https://www.hackerrank.com/challenges/summing-the-n-series
*   Domain      :    Mathematics/Fundamentals
*	Problem Type:	Data Type Handling
*	Alogirthm	:   math
*	Author		:	Atiqur Rahman
*	Desc		:	Apply big mod technique
*
*	Status		:	Accepted
*/

#include <iostream>
#include <string>
#include <sstream>
#include <cmath>
using namespace std;

void handleIO();


int main() {
	handleIO();
	return 0;
}

void handleIO() {
	int testcase;
	unsigned long long n;
	unsigned long long cp = 1000000007;
	unsigned long long res = 0;

	cin >> testcase;

	while (testcase--) {
		cin >> n;
		res = (n % cp) * (n % cp) % cp;
		cout << res << endl;
	}
}

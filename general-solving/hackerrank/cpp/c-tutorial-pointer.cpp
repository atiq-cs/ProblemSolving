/*
*	Problem Name:	Functions
*	Problem No	:	https://www.hackerrank.com/challenges/c-tutorial-pointer
*   Domain      :   C++/Intro
*	Problem Type:	
*	Alogirthm	:   
*	Author		:	Atiqur Rahman
*	Status		:	Accepted
*	Desc		:	a should contain sum, b contains absolute difference between them
*/

#include <iostream>
#include <cstdlib>  // abs

void update(int *a, int *b) {
	int tmp = *a;
	*a += *b;
	*b = abs(tmp - *b);
}

int main() {
	int a, b;
	int *pa = &a, *pb = &b;

	std::cin >> a >> b;
	update(pa, pb);
	std::cout << a << std::endl << b;

	return 0;
}

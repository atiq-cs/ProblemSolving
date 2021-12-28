/*
*	Problem Name:	Find Digits
*	Problem No	:	https://www.hackerrank.com/challenges/find-digits
*   Domain      :   Algorithms/Implementation
*	Problem Type:	
*	Alogirthm	:   
*	Author		:	Atiqur Rahman
*	Status		:	Accepted
*	Desc		:	Simple approach
*	Notes		:	This one apparently uses the OOP template
*/

#include <iostream>

class DivisionCountFinder {
private:
	int num;
public:
	void setValue(int n);
	int getCount();
};

void handleIO();

int main() {
	handleIO();
	return 0;
}

void handleIO() {
	DivisionCountFinder dcfObj;
	int T;
	int num;

	std::cin >> T;
	for (int i = 0; i < T; i++) {
		std::cin >> num;
		dcfObj.setValue(num);
		std::cout << dcfObj.getCount() << std::endl;;
	}
}

void DivisionCountFinder::setValue(int n) {
	num = n;
}

int DivisionCountFinder::getCount() {
	int n = num;
	int count = 0;
	while (n) {
		int d = n % 10;
		n /= 10;
		if (d && num%d == 0)
			count++;
	}
	return count;
}

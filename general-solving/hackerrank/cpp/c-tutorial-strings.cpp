/*
*	Problem Name:	Strings
*	Problem No	:	https://www.hackerrank.com/challenges/c-tutorial-strings
*   Domain      :   C++/Strings
*	Problem Type:	
*	Alogirthm	:   
*	Author		:	Atiqur Rahman
*	Status		:	Accepted
*	Notes		:	Safety check on line 23 is recommended, whether any of the strings in empty
*/

#include <iostream>
#include <string>

int main() {
	std::string a, b;
	std::cin >> a >> b;

	std::cout << a.length() << " " << b.length() << std::endl;
	std::cout << a + b << std::endl;

	std::swap(a[0], b[0]);
	std::cout << a << " " << b << std::endl;

	return 0;
}

/*
*	Problem Name:	STL Sets
*	Problem No	:	https://www.hackerrank.com/challenges/cpp-sets
*   Domain      :    C++/STL
*	Problem Type:	Use of STL
*	Alogirthm	:   
*	Author		:	Atiqur Rahman
*	Status		:	Accepted
*	Note		:	ref: http://en.cppreference.com/w/cpp/container/set
*					Block required in case 3
*/

#include <algorithm>
#include <iostream>
#include <set>

void handleIO();

int main() {
	handleIO();
	return 0;
}

void handleIO() {
	int Q; std::cin >> Q;

	std::set<int> myset;

	for (int i = 0; i<Q; i++) {
		// Take input case and number
		int case_num, number; std::cin >> case_num >> number;

		// for each case perform operation
		switch (case_num) {
		case 1:	// insert
			myset.insert(number);
			break;
		case 2:	// erase
			myset.erase(number);
			break;
		case 3:	// find
		// without this block I cannot declare the position variable
		{
			auto position = myset.find(number);
			if (position != myset.end())
				std::cout << "Yes " << std::endl;
			else
				std::cout << "No" << std::endl;
		}
		break;
		default:
			break;
		}
	}
}

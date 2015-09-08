/*
*	Problem Name:	StringStream
*	Problem No	:	https://www.hackerrank.com/challenges/c-tutorial-stringstream
*   Domain      :   C++/Strings
*	Problem Type:	
*	Alogirthm	:   
*	Author		:	Atiqur Rahman
*	Status		:	Accepted
*	Desc		:	This implementation demonstrates how we can use sstream to parse integers which are delimited
*						by comma or any other symbol
*	Notes		:	ref, http://stackoverflow.com/questions/1894886/parsing-a-comma-delimited-stdstring
*					ss.peek is the knowledge I acquired
*/

#include <sstream>
#include <vector>
#include <iostream>

std::vector<int> parse_integers(std::string str) {
	std::stringstream ss(str);
	std::vector<int> num_list;

	int i;
	while (ss >> i) {
		num_list.push_back(i);
		if (ss.peek() == ',')
			ss.ignore();
	}
	return num_list;
}

int main() {
	std::string str;
	std::cin >> str;
	std::vector<int> integers = parse_integers(str);

	for (int i = 0; i < integers.size(); i++) {
		std::cout << integers[i] << "\n";
	}

	return 0;
}

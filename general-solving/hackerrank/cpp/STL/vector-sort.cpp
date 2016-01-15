/*
*	Problem Name:	Vector Sort
*	Problem No	:	https://www.hackerrank.com/challenges/vector-sort
*   Domain      :    C++/STL
*	Problem Type:	Use of STL, vector
*	Alogirthm	:   
*	Author		:	Atiqur Rahman
*	Status		:	Accepted
*	Note		:	hackerrank supports auto iteration of vector
*/

#include <iostream>
#include <vector>
#include <algorithm>

void handleIO();

int main() {
	handleIO();
	return 0;
}

void handleIO() {
	int N;
	std::cin >> N;

	std::vector<int> v(N);

	for (int i = 0; i<N; i++)
		std::cin >> v[i];

	std::sort(v.begin(), v.end());

	for (auto item : v)
		std::cout << item << " ";
	std::cout << std::endl;
}

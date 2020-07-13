/***************************************************************************************************
* Title : Vector Erase
* URL   : https://www.hackerrank.com/challenges/vector-erase
* Author: Atiq Rahman
* Status: Accepted
* Notes : C++/STL: This is a nice problem to teach vector erase
* meta  : tag-lang-cpp
***************************************************************************************************/
#include <iostream>
#include <vector>

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

  // erase item on the position, convert to 0 based index
  int position;
  std::cin >> position;
  v.erase(v.begin() + position - 1);

  // erase item from starting position till ending position (exclusive)
  // convert to 0 based index
  int start, end;
  std::cin >> start >> end;
  v.erase(v.begin() + start - 1, v.begin() + end - 1);

  std::cout << v.size() << std::endl;

  for (auto item : v)
    std::cout << item << " ";
  std::cout << std::endl;
}

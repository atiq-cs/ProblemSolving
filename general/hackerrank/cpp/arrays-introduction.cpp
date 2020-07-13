/***************************************************************************************************
* Title : Arrays Introduction
* URL   : https://www.hackerrank.com/challenges/arrays-introduction
* Author: Atiq Rahman
* Status: Accepted
* Notes : Restrict from the temptation of using pointer arithmetic
* meta  : tag-lang-cpp
***************************************************************************************************/
#include <iostream>
#include <string>
#include <sstream>
#include <cmath>

void handleIO();

int main() {
  handleIO();
  return 0;
}

void handleIO() {
  int N;
  std::cin >> N;

  int* arr = new int[N];
  for (int i = 0; i<N; i++)
    std::cin >> arr[i];

  for (int i = N - 1; i >= 0; i--)
    std::cout << arr[i] << " ";
  std::cout << std::endl;

  delete[] arr;
}

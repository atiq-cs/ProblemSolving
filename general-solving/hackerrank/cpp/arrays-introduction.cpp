/*
*  Problem Name:  Arrays Introduction
*  Problem No  :  https://www.hackerrank.com/challenges/arrays-introduction
*   Domain      :    C++/Introduction/Arrays
*  Problem Type:  
*  Alogirthm  :   
*  Author    :  Atiqur Rahman
*  Status    :  Accepted
*  Note    :  Restrict from the temptation of using pointer arithmetic
*/

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

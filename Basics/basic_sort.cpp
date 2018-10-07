/*
*  Problem Title:   Basic Sorting Algorithms
*  Author    :  Atiq Rahman
*  Email    :  atiqcs 'at' outlook 'dot' com
*  Date    :  May 24, 2015
*  Desc    :  
*          Selection sort
*          Bubble sort
*          Insertion sort
*/

#include <iostream>
#include <vector>

/* selection sort
  finds the minimum each time and put it on appropriate index swapping only once
*/
void selection_sort(std::vector<int> &A) {
  for (int j = 0; j < (int) A.size() - 1; j++) {
    int iMin = j;
    for (int i = j + 1; i < (int) A.size(); i++)
      if (A[i] < A[iMin])
        iMin = i;
    if (iMin != j)
      std::swap(A[iMin], A[j]);
  }
}

/* bubble sort
  finds the maximum each time and put it on appropriate index swapping all of them
  Best-case performance - theta(n)
*/
void bubble_sort(std::vector<int> &A) {
  int n = (int) A.size();
  bool swapped = false;
  do {
    swapped = false;
    for (int i = 1; i < n; i++)
      if (A[i - 1] > A[i]) {
        std::swap(A[i - 1], A[i]);
        swapped = true;
      }
    n--;
  } while (swapped);
}

/* selection sort 
using array
array passed to function is passed by reference, ref:
http://stackoverflow.com/questions/7454990/why-cant-we-pass-arrays-to-function-by-value

void selection_sort(int A[], int n) {
  for (int j = 0; j < n - 1; j++) {
    int iMin = j;
    for (int i = j + 1; i < n; i++)
      if (A[i] < A[iMin])
        iMin = i;
    if (iMin != j)
      std::swap(A[iMin], A[j]);
  }
}*/

/* selection sort
take an index from beginning to end and sort upto the index by inserting an item
*/
void insertion_sort(std::vector<int> &A) {
  for (int i = 1; i < (int)A.size(); i++) {
    int j = i;
    while (j>0 && A[j - 1] > A[j]) {
      std::swap(A[j - 1], A[j]);
      j--;
    }
  }
}

/* We demonstrate the sort functions we implemented above */
int main() {
  // selection sort demo
  std::vector<int> A = { 7, 8, 70, 5, 2, -1 };
  std::cout << "Before sort, A: ";

  // print the vector
  for (auto item : A)
    std::cout << " " << item;
  std::cout << std::endl;

  selection_sort(A);

  std::cout << "After selection sort, A: ";

  // print the vector
  for (auto item : A)
    std::cout << " " << item;
  std::cout << std::endl;

  // bubble sort demo
  A = { 7, 8, 70, 5, 2 };
  std::cout << "Before sort, A: ";

  // print the vector
  for (auto item : A)
    std::cout << " " << item;
  std::cout << std::endl;

  bubble_sort(A);

  std::cout << "After bubble sort, A: ";

  // print the vector
  for (auto item : A)
    std::cout << " " << item;
  std::cout << std::endl;

  // insertion sort demo
  A = { 7, 8, 70, 5, 2, -2 };
  std::cout << "Before sort, A: ";

  // print the vector
  for (auto item : A)
    std::cout << " " << item;
  std::cout << std::endl;

  insertion_sort(A);

  std::cout << "After insertion sort, A: ";

  // print the vector
  for (auto item : A)
    std::cout << " " << item;
  std::cout << std::endl;
  return 0;
}

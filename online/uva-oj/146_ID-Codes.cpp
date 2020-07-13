/***************************************************************************************************
* Title : ID Codes
* URL   : https://uva.onlinejudge.org/external/1/146.html
* Date  : 2015-10-25
* Comp  : O(n log n)
* Status: Accepted
* Notes : An implementation of next-permutation (see demo). Complexity is n log n due to `sort`
*
*   C++ version of 'general-solving/leetcode/0031_next-permutation.cs' considering following cases
*   - inputs are chars instead of integer
*   - otherwise problem is similar to spoj problem
* meta  : tag-next-permutation, tag-permutation, tag-uva-easy
***************************************************************************************************/
#include<iostream>
#include<algorithm>
#include<string>

bool has_next_permutation(std::string& str) {
  // iterate in reverse, find the index before which item is less
  int i = str.length() - 1;
  while (i > 0 && str[i - 1] >= str[i])
    i--;

  // find the item that is immediately greater than nums[i-1] and swap
  if (i > 0) {
    int j = str.length() - 1;
    while (str[i - 1] >= str[j])
      j--;
    std::swap(str[i - 1], str[j]);
  }

  if (i == 0)
    return false;
  for (int j = i, k = str.length() - 1; j < k; j++, k--)
    std::swap(str[j], str[k]);
  return true;
}

int main() {
  std::string str;

  while (std::cin >> str && str[0] != '#')
    if (has_next_permutation(str))
      std::cout << str << std::endl;
    else
      std::cout << "No Successor" << std::endl;

  return 0;
}


int main_v2() {
  std::string str;

  // Take input
  while (std::cin >> str && str[0] != '#') {
    // check if it is sorted in descending order
    bool has_successor = false;
    for (int i = 0; i < str.length() - 1; i++)
      if (str[i] < str[i + 1]) {
        has_successor = true;
        break;
      }

    if (has_successor == false)
      std::cout << "No Successor" << std::endl;
    else {
      // find the point from reverse direction where two characters are in ascending order      
      int sort_start_index = str.length() - 1;  // stores the index where to start sorting from
      for (; sort_start_index > 0; sort_start_index--)
        if (str[sort_start_index - 1] < str[sort_start_index])
          break;

      // sort the string starting from the index we found
      std::sort(str.begin() + sort_start_index, str.end());

      // index of the char which is immediate greater in ascii in the sorted part, store the index in j
      int second_char_index = sort_start_index;
      // get previous char index which we have to swap with
      int first_char_index = second_char_index - 1;
      for (; second_char_index < str.length(); second_char_index++)
        if (str[first_char_index] < str[second_char_index])
          break;

      std::swap(str[first_char_index], str[second_char_index]);
      std::cout << str << std::endl;
    }
  }

  return 0;
}

// Initial efficient C implementation, O(n^2)
// Preserved for historical significance
#include<cstring>
#include<cstdio>

int main_v1() {
  char str[1000], t;
  int len, i, j, k;

  // Take input
  while (std::cin >> str && str[0] != '#') {
    len = strlen(str);
    // check if it is sorted in descending order
    for (i = 0; i<len - 1; i++)
      if (str[i]<str[i + 1])
        break;

    if (i == len - 1)
      std::cout << "No Successor" << std::endl;
    else {
      // find the point from reverse direction where two characters in ascending order
      for (t = len - 1; t; t--)
        if (str[t - 1]<str[t])
          break;

      i = t;

      for (j = i; j<len - 1; j++) {
        for (k = j + 1; k<len; k++) {
          if (str[j]>str[k]) {
            t = str[j];
            str[j] = str[k];
            str[k] = t;
          }
        }
      }

      // get previous char index which we have to swap with is i-1
      // find the index of the char which is greater in ascii in the sorted part, store the index in j
      for (j = i; j<len; j++)
        if (str[i-1]<str[j])
          break;

      i--;
      t = str[i];
      str[i] = str[j];
      str[j] = t;
      std::cout << str << std::endl;
    }
  }

  return 0;
}

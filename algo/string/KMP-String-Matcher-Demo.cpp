/***************************************************************************
* Title : String Matching - Knuth–Morris–Pratt algorithm
* URL   :
* Date  : 2015-07-10
* Author: Atiq Rahman
* Comp  : O(m+n)
* Notes : Driver program for KMP
* meta  : tag-string, tag-kmp
***************************************************************************/
#include <iostream>
#include <algorithm>
#include <string>
#include <vector>
// #include <array>   // same to 2d array memory allocation does not support a variable size

// matches P against itself and computes prefix table pf (π)
std::vector<int> compute_prefix_function(std::string p) {
  std::vector<int> pf(p.length(), -1);

  int k = -1;
  for (int i = 1; i < p.length(); i++) {
    while (k>-1 && p[k + 1] != p[i])
      k = pf[i];

    if (p[k + 1] == p[i])
      k++;

    pf[i] = k;
  }
  return pf;
}

// Matching function based on prefix table
void kmp_matcher(std::string p, std::string t) {
  std::vector<int> pf = compute_prefix_function(p);
  int m = p.length();
  int q = -1;
  for (int i = 0; i<t.length(); i++) {
    while (q>-1 && p[q + 1] != t[i])
      q = pf[q];
    if (p[q + 1] == t[i])
      q++;
    if (q == m - 1) {
      std::cout << "Pattern found with shfit " << (i-q) << std::endl;
      q = pf[q];
    }
  }
}

// KMP Demo
int main() {
  // takes a sample stirng and pattern
  // std::string p = "ababaa"; 
  // std::string p = "ababab";
  std::string p = "abcabcabc";
  //std::string p = "abcdeabcdef";
  std::string t = "fasdabcdeabcdeabcdefg";
  //std::string p = "abc";
  //std::string t = "dabc";

  kmp_matcher(p, t);
  // std::cout << "Length of is: " << longest_common_substr(s, t) << "." << std::endl;

  return 0;
}

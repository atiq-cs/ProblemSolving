/***************************************************************************************************
* Title : Power Strings
* URL   : https://uva.onlinejudge.org/external/102/p10298.pdf
* Date  : 
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : class less template
*   TODO simplify logic/code
*
*  note for `get_power`
*   modified version of kmp_matcher
*   This approach is failing for index list starting with
*   1, 0, -1 and 2, 0, -1
*   Example strings,
*   aapaaapa
*   abaaababaaab
*
* meta  : tag-string, tag-string-matching, tag-kmp
***************************************************************************************************/
#include <iostream>
#include <algorithm>
#include <string>
#include <vector>

// 'compute_prefix_function' is at 'algo/string/KMP-String-Matcher-Demo.cpp'

int get_power(std::vector<int> pf, int len) {
  if (pf.size() == 0)
    return 0;
  if (pf.size() == 1)
    return 1;

  int max_len_index = pf.size() - 1;
  for (int i = max_len_index - 1; i >= 0; i--) {
    if (pf[max_len_index] < pf[i])
      max_len_index = i;
  }

  std::vector<int> index_list;
  while (max_len_index > -1) {
    index_list.push_back(max_len_index);
    max_len_index = pf[max_len_index];
  }
  index_list.push_back(max_len_index);

  int diff = index_list[0] - index_list[1];
  auto pos = index_list.begin() + 1;
  int n = 1;

  // check index difference
  while (pos < index_list.end()) {
    // find the next element each time
    int item = *pos - diff;
    pos = std::find(pos + 1, index_list.end(), *pos - diff);

    if (pos == index_list.end()) {
      if (index_list.size() >= 3)
        if (index_list[index_list.size() - 3] >= 1 && index_list[index_list.
            size() - 2] == 0 && index_list[index_list.size() - 1] == -1)
          return -1;
      return 1;
    }

    n++;
    if (pos == index_list.end() - 1)
      break;
    // first search
  }

  // check size of vector, it should be n/diff where n is length of string
  if (len == n * diff)
    return n;

  return 1;
}

void handleIO() {
  std::string line;

  while (std::cin >> line && line != ".") {
    std::vector<int> pf = compute_prefix_function(line);
    int n = get_power(pf, line.length());
    if (n == -1) {
      // have to apply a different technique
      std::string textd(line.substr(1, line.size() - 1));
      textd += line;
      textd += line[0];
      auto pos = textd.find(line);
      if (pos == std::string::npos)
        n = 1;
      else
        n = line.length() / (pos + 1);
    }
    std::cout << n << std::endl;
  }
}

int main() {
  handleIO();
  return 0;
}

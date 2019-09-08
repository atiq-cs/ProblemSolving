/***************************************************************************************************
* Title : Code Theft
* URL   : https://uva.onlinejudge.org/external/115/p11557.pdf
* Comp  : O(nm)
* Status: Accepted
* Notes :
*   The contending chinese solution is O(n * (n+m)) which contains my initial understanding and
*   explanation, is at, https://gist.github.com/atiq-cs/5de4752e8997161639c17422e1001a1d

*   Returns length of the longest common substring
*   Based on reference but different in following ways,
*   - Each line here is a character
*   - Preprocessed for taking care of empty lines
*
*   Demonstrates STL generic collection type def
* meta  : tag-dp-lcs
***************************************************************************************************/
#include <iostream>
#include <algorithm>
#include <string>
#include <vector>

typedef std::vector<std::string> code_fragment;

// trim and reduce ref,
// http://stackoverflow.com/questions/1798112/removing-leading-and-trailing-spaces-from-a-string
std::string trim(const std::string& str,
  const std::string& whitespace = " ") {
  const auto strBegin = str.find_first_not_of(whitespace);
  if (strBegin == std::string::npos)
    return ""; // no content

  const auto strEnd = str.find_last_not_of(whitespace);
  const auto strRange = strEnd - strBegin + 1;

  return str.substr(strBegin, strRange);
}

std::string reduce(const std::string& str,
  const std::string& fill = " ",
  const std::string& whitespace = " ")
{
  // trim first
  auto result = trim(str, whitespace);

  // replace sub ranges
  auto beginSpace = result.find_first_of(whitespace);

  while (beginSpace != std::string::npos) {
    const auto endSpace = result.find_first_not_of(whitespace, beginSpace);
    const auto range = endSpace - beginSpace;

    result.replace(beginSpace, range, fill);

    const auto newStart = beginSpace + fill.length();
    beginSpace = result.find_first_of(whitespace, newStart);
  }

  return result;
}

// Same as Algorithms/longest_common_substring.cpp
// Except we changed string.length with vector.size method
int longest_common_substr(code_fragment s, code_fragment t) {
  std::vector<std::vector<int>> len(s.size(), std::vector<int>(t.size()));  // default 0 initialization
  int max_len = 0;

  for (int i = 0; i < (int) s.size(); i++)
    for (int j = 0; j < (int)t.size(); j++) {
      if (s[i] == t[j]) {
        if (i == 0 || j == 0)     // otherwise we try to access negative index
          len[i][j] = 1;
        else
          len[i][j] = len[i - 1][j - 1] + 1;
        max_len = std::max(max_len, len[i][j]);
      }
    }
  return max_len;
}

void handleIO() {
  int n = 0;

  while (std::cin >> n) {
    std::vector<code_fragment> fragments(n);
    std::vector<std::string> file_names(n);

    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    // n file names and n code fragments
    for (int i = 0; i < n; i++) {
      // input file name
      std::getline(std::cin, file_names[i]);

      // input code fragment
      std::string line;
      while (std::getline(std::cin, line) && line != "***END***") {
        std::string tline = reduce(line);
        if (tline.length() > 0)
          fragments[i].push_back(tline);
      }
    }

    // input repo code fragment
    code_fragment repo_fragment;
    std::string line;
    while (std::getline(std::cin, line) && line != "***END***") {
      std::string tline = reduce(line);
      if (tline.length() > 0)
        repo_fragment.push_back(tline);
    }

    int maxLen = 0;
    std::vector<int> lc_match(n);
    // compare repo code fragment with each code fragment
    for (int i = 0; i < n; i++) {
      lc_match[i] = longest_common_substr(fragments[i], repo_fragment);
      maxLen = std::max(maxLen, lc_match[i]);
    }

    if (maxLen == 0)
      std::cout <<0<< std::endl;
    else {
      std::cout << maxLen;
      for (int i = 0; i < n; i++) {
        auto len_match = lc_match[i];
        if (len_match == maxLen)
          std::cout << " " << file_names[i];
      }
      std::cout << std::endl;
    }
  }
}

int main() {
  handleIO();
  return 0;
}

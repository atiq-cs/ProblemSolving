/***************************************************************************
* Title : Sort Characters By Frequency
* URL   : https://leetcode.com/problems/sort-characters-by-frequency
* Date  : 2019-02-08 (update)
* Comp  : O(n lg n), O(1)
* Status: Accepted
* Notes : Temp bloomberg original draft
*  bloomberg -> bbeglmoor
*  bloomberg -> bbooeglmr
*  
*  started on date 2018-06-07
*
*  A shorthand construct such as,
*   () -> expr
*  does not seem to be available for C++ lambda expression.
* meta  : tag-algo-sort, tag-cpp-lambda-exp, tag-hash-table, tag-company-bloomberg
***************************************************************************/
#include<string>
#include<iostream>
#include<algorithm>

class Sorting {
private:
  string frequencySort(string str) {
    int freq['z' - ' ' + 1] = { 0 };

    for (char ch : str)
      freq[ch - ' ']++;

    std::sort(str.begin(), str.end(), [freq](char a, char b) {
        return freq[a - ' '] == freq[b - ' '] ? a < b : freq[b - ' '] < freq[a - ' '];
      });
    return str;
  }

public:
  void Run() {
    std::string str = "bloomberg";
    std::string result = Sort(str);
    if (result != "bbooeglmr")
      std::cout << "Incorrect result " << result << std::endl;
  }
};


int main() {
  Sorting demo;
  demo.Run();
  return 0;
}

/***************************************************************************
* Title : T
* URL   : http://www.spoj.com/problems/XXX
* Date  : 
*
* Author: Atiq Rahman
* Status: 
* Notes : This version used to try http://www.spoj.com/PUJ2013/problems/NEXT/
*   However, judge seems to have issues for problems in that section
*   Throws an error when I submit.
* meta  : tag-xxx, tag-judge-SPOJ
***************************************************************************/
#include <iostream>

class Solution {
public:
  void Run () {
    int T;
    std::cin >> T;

    while (T-->0) {
      int seq;
      std::string str;
      std::cin >> seq >> str;

      if (doSomething(str))
        std::cout << seq << " " << str << std::endl;
      else
        std::cout << seq << " BIGGEST" << std::endl;
    }  
  }
  
private:
  bool doSomething(std::string& nums) {
    // code..
  }
};

int main() {
  Solution demo;
  demo.Run();
  return 0;
}

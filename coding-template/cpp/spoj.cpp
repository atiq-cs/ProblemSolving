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
* meta  : tag-xxx
***************************************************************************/

#include <iostream>

class Permutation {
public:
  void Run () {
    int T;
    std::cin >> T;

    while (T-->0) {
      int seq;
      std::string str;
      std::cin >> seq >> str;

      if (NextPermutation(str))
        std::cout << seq << " " << str << std::endl;
      else
        std::cout << seq << " BIGGEST" << std::endl;
    }  
  }
  
private:
  bool NextPermutation(std::string& nums) {
    // func from 'uva-online-judge/146_ID_Codes_v03.cpp'
  }
};

int main() {
  Permutation demo;
  demo.Run();
  return 0;
}

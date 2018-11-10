/***************************************************************************************************
* Title : STL Map
* URL   : https://www.hackerrank.com/challenges/cpp-maps
* Author: Atiq Rahman
* Status: Accepted
* Notes : Use of STL
*   Block required in case 1 & 3
*   Could not make case 1 any shorter than this
* ref   : http://en.cppreference.com/w/cpp/container/map
* meta  : tag-string, tag-lang-cpp
***************************************************************************************************/
#include <algorithm>
#include <iostream>
#include <string>
#include <map>

void handleIO();

int main() {
  handleIO();
  return 0;
}

void handleIO() {
  int Q; std::cin >> Q;

  std::map<std::string, int> mymap;

  for (int i = 0; i<Q; i++) {
    // Take input case, student name and student marks
    int case_num, mark; std::string name;
    std::cin >> case_num >> name;

    // for each case perform operation
    switch (case_num) {
    case 1:  // insert
      std::cin >> mark;
      // without this block I cannot declare the position variable
      {
        auto it = mymap.find(name);
        if (it == mymap.end())
          mymap[name] = mark;
        else
          mymap[name] += mark;

      }
      break;
    case 2:  // erase
      mymap.erase(name);
      break;
    case 3:  // find
        // without this block I cannot declare the position variable
    {
      auto it = mymap.find(name);
      if (it == mymap.end())
        std::cout << 0 << std::endl;
      else
        std::cout << (int)it->second << std::endl;
    }
    break;
    default:
      break;
    }
  }
}

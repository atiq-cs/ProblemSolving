/*
    C++ 11 features
    use of auto with containers such as map

    Book map page number: 909
        Map examples
* meta : tag-company-bloomberg
*/

#include <iostream>
#include <string>
#include <map>

int _p02_disable_main() {
  std::map<std::string, int> students{
    { "atique", 50054 },
    { "sabhin", 50055 }
   };

  /* to modify use reference */
  for (auto &x : students) {
    std::cout << "name: " << x.first << " id: " << x.second << std::endl;
    x.second++;
  }

  // example for emplace
  students.emplace("abhi", 50054);

  /*
  iterator can modify too

  for (auto it = begin(students); it != end(students); ++it) {
  std::cout << "name: " << it->first << " id: " << it->second << std::endl;
  it->second++;
  }*/

  // for reading reference is not required
  for (auto x : students) {
    std::cout << "name: " << x.first << " id: " << x.second << std::endl;
  }

  int vx = 10;
  int &rx = vx;
  std::cout << "value now: " << rx << std::endl;
  vx = 20;
  std::cout << "value now: " << rx << std::endl;
  int cx = 500;
  rx = cx;
  std::cout << "value now: " << rx << std::endl;
  cx = 100;
  std::cout << "value now: " << rx << std::endl;

  // use of map, bloomberg
  std::map < std::string, std::string > myMap;
  std::cout << "value is " << myMap["hello"] << std::endl;
  myMap["hello"] = "welcome";
  std::cout << "value is " << myMap["hello"] << std::endl;

  myMap["world"] = "goodbye";

  // iterate map using iterator
  for (auto it = myMap.begin(); it != myMap.end(); it++)
    std::cout << "key " << it->first << " value " << it->second << std::endl;

  // using for each, try to modify using iterator
  for (auto& item : myMap)
    item.second += " super ";

  // using for each
  for (auto& item : myMap)
    std::cout << "key " << item.first << " value " << item.second << std::endl;
  return 0;
}

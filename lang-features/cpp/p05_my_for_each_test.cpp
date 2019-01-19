/*
  Author  :  Atique
  GOal  :  Test for_each myself
*/
#include <iostream>
#include <vector>
#include <algorithm>

void myFunction(int i) {
  std::cout << "test "<< i << std::endl;
}

class containterTest {
public:
  void operator() (int i) { std::cout << "got int " << i << std::endl; }

};

int main() {
  std::vector<int> myVector;
  containterTest testObj;

  for (auto x : { 3, 7, 5, 11, 13 }) {
    myVector.push_back(x);
  }

  std::for_each(begin(myVector), end(myVector), testObj);
  return 0;
}

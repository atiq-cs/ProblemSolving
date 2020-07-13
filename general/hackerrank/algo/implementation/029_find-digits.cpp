/***************************************************************************************************
* Title : Find Digits
* URL   : https://www.hackerrank.com/challenges/find-digits
* Author: Atiq Rahman
* Status: Accepted
* Notes : Simple approach, This one apparently uses my old OOP template
* meta  : tag-implementation, tag-easy
***************************************************************************************************/
#include <iostream>

class DivisionCountFinder {
private:
  int num;
public:
  void setValue(int n);
  int getCount();
};

void handleIO();

int main() {
  handleIO();
  return 0;
}

void handleIO() {
  DivisionCountFinder dcfObj;
  int T;
  int num;

  std::cin >> T;
  for (int i = 0; i < T; i++) {
    std::cin >> num;
    dcfObj.setValue(num);
    std::cout << dcfObj.getCount() << std::endl;;
  }
}

void DivisionCountFinder::setValue(int n) {
  num = n;
}

int DivisionCountFinder::getCount() {
  int n = num;
  int count = 0;
  while (n) {
    int d = n % 10;
    n /= 10;
    if (d && num%d == 0)
      count++;
  }
  return count;
}

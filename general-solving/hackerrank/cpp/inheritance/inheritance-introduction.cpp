/***************************************************************************
* Title : Inheritance Introduction
* URL   : https://www.hackerrank.com/challenges/inheritance-introduction
* Date  : 2015-09
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : Intro to inheritance (OOP)
* meta  : tag-string, tag-lang-cpp
***************************************************************************/
#include <iostream>
using namespace std;

class Triangle {
public:
  void triangle() {
    cout << "I am a triangle\n";
  }
};

class Isosceles : public Triangle {
public:
  void isosceles() {
    cout << "I am an isosceles triangle\n";
  }
  //Write your code here.
  void description() {
    cout << "In an isosceles triangle two sides are equal\n";
  }
};

int main() {
  Isosceles isc;
  isc.isosceles();
  isc.description();
  isc.triangle();
  return 0;
}

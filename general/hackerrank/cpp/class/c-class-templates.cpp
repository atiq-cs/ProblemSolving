/***************************************************************************
* Title : Class
* URL   : https://www.hackerrank.com/challenges/classes-objects
* Date  : 2015-10
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : CPP Templates, Generic type implementation
* meta  : tag-cpp-template
***************************************************************************/
#include <iostream>
#include <sstream>
#include <string>
using namespace std;

template <class T>
class AddElements {
  T element;
public:
  AddElements(T arg) { element = arg; }
  T add(T arg) { return element + arg; }
  T concatenate(T arg) { return element + arg; }
};

/************** Provided *****************/
int main() {
  int n, i;
  cin >> n;
  for (i = 0; i<n; i++) {
    string type;
    cin >> type;
    if (type == "float") {
      double element1, element2;
      cin >> element1 >> element2;
      AddElements<double> myfloat(element1);
      cout << myfloat.add(element2) << endl;
    }
    else if (type == "int") {
      int element1, element2;
      cin >> element1 >> element2;
      AddElements<int> myint(element1);
      cout << myint.add(element2) << endl;
    }
    else if (type == "string") {
      string element1, element2;
      cin >> element1 >> element2;
      AddElements<string> mystring(element1);
      cout << mystring.concatenate(element2) << endl;
    }
  }
  return 0;
}

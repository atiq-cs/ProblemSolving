/***************************************************************************
* Title : Class
* URL   : https://www.hackerrank.com/challenges/c-tutorial-class
* Date  : May 2015
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : OOP
* meta  : tag-lang-cpp
***************************************************************************/
#include <iostream>
#include <sstream>
#include <string>
using namespace std;
/*
Enter code for class Student here.
Read statement for specification.
*/

class Student {
private:
  int age;
  string first_name;
  string last_name;
  int standard;

public:
  // sets
  void set_age(int x) { age = x; }
  void set_first_name(string name) { first_name = name; }
  void set_last_name(string name) { last_name = name; }
  void set_standard(int x) { standard = x; }

  // gets
  int get_age(void) { return age; }
  string get_first_name(void) { return first_name; }
  string get_last_name(void) { return last_name; }
  int get_standard(void) { return standard; }

  // to string
  string to_string(void) { return std::to_string(age) + "," + first_name + "," + last_name + "," + std::to_string(standard); }
};

/************** Provided *****************/
int main() {
  int age, standard;
  string first_name, last_name;

  cin >> age >> first_name >> last_name >> standard;

  Student st;
  st.set_age(age);
  st.set_standard(standard);
  st.set_first_name(first_name);
  st.set_last_name(last_name);

  cout << st.get_age() << "\n";
  cout << st.get_last_name() << ", " << st.get_first_name() << "\n";
  cout << st.get_standard() << "\n";
  cout << "\n";
  cout << st.to_string();

  return 0;
}

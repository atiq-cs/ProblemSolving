/*
*  Problem Title:  Problem Title
*  Problem Link:  https://www.hackerrank.com/challenges/problem-title
*  Problem Type:  from Data Structure, Algorithm etc..
*  Alogirthm  :
*  Author    :  Atiq Rahman
*  Email    :  
*  Date    :  , 2015
*  Desc    :
*
* Judge Notes
* Judge Notes
*  uva-judge  :  g++ 4.8.2, C++11 - GNU C++ Compiler with options: -lm -lcrypt -O2 -std=c++11 -pipe -DONLINE_JUDGE
*          main function should return 0, include cstring for memset
*   tju-judge  :  gcc 4.5.2, old, does not support C++11 all features
*  spoj    :  g++ 4.9.2, C++ 14
*  Status    :  Accepted / On progress / Wrong Answer
*/


#include <string>
#include <sstream>
#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
// Comment before submission to judge
#define FILE_IO  TRUE

#ifdef FILE_IO
#include <fstream>
#endif
using namespace std;

void handleIO();

class ClassName {
private:
  string str;
  int num;
public:
  void initClass();
};

int mainT() {
  handleIO();
  return 0;
}

void handleIO() {
#ifdef FILE_IO
  std::string problem = "Problem Number";
  std::ifstream inFile(problem + "_in.txt");
  std::streambuf *cinbuf = std::cin.rdbuf(); //save old buf
  std::cin.rdbuf(inFile.rdbuf()); //redirect std::cin to inFile!

  std::ofstream outFile(problem + "_out.txt");
  std::streambuf *coutbuf = std::cout.rdbuf();
  std::cout.rdbuf(outFile.rdbuf());
#endif

  ClassName classObj;
  string varName;

  while (cin >> varName) {
    classObj.initClass();
  }

#ifdef FILE_IO
  std::cin.rdbuf(cinbuf);
  inFile.close();
  std::cout.rdbuf(coutbuf);
  outFile.close();
#endif
}

class ClassName {
private:
  string str;
  int num;
public:
  void initClass();
};

void ClassName::initClass() {
  num = 0;
}

/*
Set fixed point example
std::cout << "Fixed point number: " << std::fixed << std::setprecision(1) << num << std::endl;
*/

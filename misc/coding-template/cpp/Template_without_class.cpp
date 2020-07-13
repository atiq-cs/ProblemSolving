/*
*  Problem Title:  Problem Title
*  Problem Link:  https://www.hackerrank.com/challenges/problem-title
*  Problem Type:  Data Type Handling
*  Alogirthm  :
*  Author    :  Atiq Rahman
*  Desc    :  Generated from this problem https://www.hackerrank.com/challenges/summing-the-n-series
*
*  Status    :  Good
*/


#include <string>
#include <sstream>
#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
//#define FILE_IO  TRUE

#ifdef FILE_IO
#include <fstream>
#endif
using namespace std;

void handleIO();

int main() {
  handleIO();
  return 0;
}

void handleIO() {
#ifdef FILE_IO
  ofstream outFile("ProblemNo_out.txt");
  streambuf *psbuf = outFile.rdbuf(), *backup;
  backup = cout.rdbuf();     // back up cout's streambuf
  cout.rdbuf(psbuf);
#endif

  ClassName classObj;
  string varName;

  while (cin >> varName) {
    classObj.initClass();
  }
#ifdef FILE_IO
  cout.rdbuf(backup);
  outFile.close();
#endif
}

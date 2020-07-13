/***************************************************************************
* Title : Classes and Objects
* URL   : https://www.hackerrank.com/challenges/classes-objects
* Date  : 2015-10
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : OOP
* meta  : tag-cpp
***************************************************************************/
#include <iostream>
#include <sstream>
#include <string>
using namespace std;

class Student {
private:
  int score[5];
public:
  void Input();
  int CalculateTotalScore();

};

void Student::Input() {
  for (int i = 0; i<5; i++)
    cin >> score[i];
}

int Student::CalculateTotalScore() {
  int totalScore = 0;
  for (int i = 0; i<5; i++)
    totalScore += score[i];
  return totalScore;
}

/************** Provided *****************/
int main() {
  int n;
  cin >> n;
  Student s[n];
  for (int i = 0; i<n; i++)
    s[i].Input();
  int count = 0;
  int krish_score = s[0].CalculateTotalScore();
  for (int i = 1; i<n; i++)
  {
    int total = s[i].CalculateTotalScore();
    if (total>krish_score)
      count++;
  }
  cout << count;
  return 0;
}

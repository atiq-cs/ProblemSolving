/***************************************************************************
* Problem Name: Inheritance Introduction
* Problem URL : https://www.hackerrank.com/challenges/inheritance-introduction
* Date        : Sept 2015
* Complexity  : 
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Intro to inheritance
* meta        : tag-inheritance
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

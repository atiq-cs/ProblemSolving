/***************************************************************************
* Problem Name: Multi Level Inheritance
* Problem URL : https://www.hackerrank.com/challenges/multi-level-inheritance-cpp
* Date        : Sept 2015
* Complexity  : 
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : simple multi-level inheritance
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
};

class Equilateral : public Isosceles {
public:
    void equilateral() {
        cout << "I am an equilateral triangle\n";
    }
};

int main() {
    Equilateral eqr;
    eqr.equilateral();
    eqr.isosceles();
    eqr.triangle();
    return 0;
}

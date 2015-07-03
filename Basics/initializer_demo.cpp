/*
*	Problem     :   Demonstrating use of initializer list in C++ 11
*	Author		:	Atiqur Rahman
*	Email		:	mdarahman@cs.stonybrook.edu
*	Date		:	June 28, 2015
*	Desc		:
*					Using initializer list with primitive types
*                    use with string, vector, maps
*                     and class members
*/

#include <iostream>
#include <vector>
#include <map>
#include <string>
#include <array>

class test_initializer_class
{
private:
    // int x[4];        // does not support initializer list anyway
    std::array<int, 4> x;
public:
    test_initializer_class() : x({ { 0, 1, 2, 3 } }) {}
    void print() {
        // ranged for loop is supported for array
        for (auto item : x) {
            std::cout << " item = " << item << std::endl;
        }
    }
};

int main() {
    // use of auto variable
    auto x = 10;
    std::cout << " x = " << x << std::endl;

    // C++11 brace-init: use of curly brace to initialize variable
    // ref: http://www.informit.com/articles/article.aspx?p=1852519
    int a{ x };
    std::cout << "int a = " << a << std::endl;

    // use of parenthesis to initialize variable
    int c(x);
    std::cout << "int c = " << c << std::endl;

    //  universal initialization notation
    // for string
    std::string s{ "hello" };
    std::cout << "string s = " << s << std::endl;

    std::string s2{ s }; //copy construction
    std::cout << "string s2 = " << s2 << std::endl;

    std::vector <std::string> vs{ "alpha", "beta", "gamma" };
    std::map<std::string, std::string> stars
        { { "Superman", "+1 (212) 545-7890" },
        { "Batman", "+1 (212) 545-0987" } };

    double *pd = new double[3] {0.5, 1.2, 12.99};

    test_initializer_class ti;
    ti.print();

    return 0;
}

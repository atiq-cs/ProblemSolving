/*
* Title : Permute a string
* Author: Atiq Rahman
* Date  : June 20, 2015
* Desc  : Generate Permutations for a given string 
*     Permutation using recursion *
*     The idea has been tested to solve http://www.lintcode.com/en/problem/permutations/
*     Have to test it by solving more problems
*     Permutation idea:
*     - Take items before index fixed
*     - Take items after index one by one and swap to get a different order
* meta  : tag-permutation, tag-algo-ds-core
*/
#include <iostream>
#include <string>

void permute(std::string &str, int index) {
    // if provided index from main call is wrong, this case will take care of that
    if (index >= str.length())
        return;
    if (index == str.length() - 1) {
        std::cout << str << std::endl;
        return;
    }

    // first one does not need swapping, as swapping an item with itself produces the same result
    permute(str, index + 1);
    for (int i = index+1; i < str.length(); i++) {
        std::swap(str[index], str[i]);
        permute(str, index+1);
        std::swap(str[index], str[i]);
    }
}

// We demonstrate the Permutation we implemented above
int main() {
    // Permute C++ demo

    // take a sample stirng
    std::string str = "ABCDEF";
    // if we want to start permuation froma different index, change the index from 0 to something else
    permute(str, 0);

    return 0;
}

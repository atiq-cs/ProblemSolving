/***************************************************************************
* Title : ID Codes
* URL   : https://uva.onlinejudge.org/external/1/146.html
* Date  : Oct 25, 2015
*
* Author: Atiq Rahman
* Comp  :  O(n)
* Status: Accepted
* Notes : C++ version of 'general-solving/leetcode/0031_next-permutation.cs'
*          considering following cases
*          - inputs are chars instead of integer
*          - otherwise problem is similar to spoj problem
* meta  : tag-next-permutation, tag-permutation, tag-UVA-Judge
***************************************************************************/

#include<iostream>
#include<algorithm>
#include<string>

bool has_next_permutation(std::string& str) {
    // iterate in reverse, find the index before which item is less
    int i = str.length() - 1;
    while (i > 0 && str[i - 1] >= str[i])
        i--;
    // find the item that is immediately greater than nums[i-1] and swap
    if (i>0) {
        int j = str.length() - 1;
        while (str[i - 1] >= str[j])
            j--;
        std::swap(str[i-1], str[j]);
    }
    if (i == 0)
        return false;
    for (int j = i, k = str.length() - 1; j < k; j++, k--)
        std::swap(str[j], str[k]);
    return true;
}

int main() {
    std::string str;

    while (std::cin >> str && str[0] != '#') {
        if (has_next_permutation(str))
            std::cout << str << std::endl;
        else
            std::cout << "No Successor" << std::endl;
    }

    return 0;
}

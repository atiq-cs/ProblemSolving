/*
*	Problem Title:  String Matching Algorithm - Knuth–Morris–Pratt algorithm
*	Author		:	Atiqur Rahman
*	Email		:	mdarahman@cs.stonybrook.edu
*	Date		:	July 10, 2015
*	Desc		:
*					
*                   Build Prefix Table
*                     each index of the prefix table keeps tracks of the previous index where it matches
*                   Match String
*                   
*                   KMP on youtube: https://www.youtube.com/watch?v=5i7oKodCRJo
*                    
*   Reference   :   Introduction to Algorithms, Coreman Chapter 32, page 1005
*   Related Problems:   https://www.hackerrank.com/challenges/string-similarity
                        http://a2oj.com/Category.jsp?ID=29
*   Complexity  :   O (m+n)
*/

#include <iostream>
#include <algorithm>
#include <string>
#include <vector>
// #include <array>     // same to 2d array memory allocation does not support a variable size

/* matches P against itself and computes prefix 
    pf is the pi to implement prefix function
*/
std::vector<int> compute_prefix_function(std::string p) {
    std::vector<int> pf(p.length(), -1);

    int k = -1;
    for (int q = 1; q < p.length(); q++) {
        while (k>-1 && p[k + 1] != p[q])
            k = pf[q];

        if (p[k + 1] == p[q])
            k++;
        pf[q] = k;
    }
    return pf;
}

/*
    Match part
*/
void kmp_matcher(std::string p, std::string t) {
    std::vector<int> pf = compute_prefix_function(p);
    int m = p.length();
    int q = -1;
    for (int i = 0; i<t.length(); i++) {
        while (q>-1 && p[q+1] != t[i])
            q = pf[q];
        if (p[q+1] == t[i])
            q++;
        if (q == m-1)
        {
            std::cout << "Pattern found with shfit " << (i+1-m) << std::endl;
            q = pf[q];
        }
    }
}

/* KMP Demo */
int main() {
    // takes a sample stirng and pattern
    // std::string p = "ababaa"; 
    // std::string p = "ababab";
    std::string p = "abcabcabc";
    //std::string p = "abcdeabcdef";
    std::string t = "fasdabcdeabcdeabcdefg";
    //std::string p = "abc";
    //std::string t = "dabc";

    kmp_matcher(p, t);

    // std::cout << "Length of is: " << longest_common_substr(s, t) << "." << std::endl;

    return 0;
}

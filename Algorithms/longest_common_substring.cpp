/*
*	Problem Title:  Longest common substring
*	Author		:	Atiqur Rahman
*	Email		:	mdarahman@cs.stonybrook.edu
*	Date		:	July 2, 2015
*	Desc		:
*					Dynamic Programming implementation of LCSubstring
*                   ref: https://en.wikipedia.org/wiki/Longest_common_substring_problem 
*
*                   Other examples: Initializes 2d array/vector with default 0 values
*                    
*   Related Problems:   This also solves http://www.lintcode.com/en/problem/longest-common-substring/
*   Complexity  :   O (mn)
*/

#include <iostream>
#include <algorithm>
#include <string>
#include <vector>
// #include <array>     // same to 2d array memory allocation does not support a variable size

/*
    Returns length of the longest common substring
*/
int longest_common_substr(std::string s, std::string t) {
    std::vector<std::vector<int>> len(s.length(), std::vector<int>(t.length()));    // default 0 initialization
    int max_len = 0;

    for (int i = 0; i < s.length(); i++)
        for (int j = 0; j < t.length(); j++)
            if (s[i] == t[j]) {
                if (i == 0 || j == 0)       // otherwise we try to access negative index
                    len[i][j] = 1;
                else
                    len[i][j] = len[i - 1][j - 1] + 1;
                max_len = std::max(max_len, len[i][j]);
            }

    return max_len;
}

/* Longest common substring Demo */
int main() {
    // take two sample stirngs
    std::string s = "abcde";
    std::string t = "fasdfbce";
    std::cout << "Length of LCSubstr is: " << longest_common_substr(s, t) << "." << std::endl;

    return 0;
}

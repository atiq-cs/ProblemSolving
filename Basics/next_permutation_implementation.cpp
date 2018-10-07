/*
*  Problem Title:  Implementing next_permutation
*  Author    :  Atiq Rahman
*  Email    :  atiqcs 'at' outlook 'dot' com
*  Date    :  June 23, 2015
*  Desc    :
*          This algorithm is tested by solving https://uva.onlinejudge.org/external/1/146.html
*                    For reference please have a look at online-problem-solving/uva-online-judge/146_ID_Codes.cpp
*                    If you are looking for C implementation look here:
*                           online-problem-solving/uva-online-judge/146_ID_Codes_nasty_C.cpp

*   Complexity  :   n log (n), (because of sorting used in line 41)
*/

#include <iostream>
#include <algorithm>
#include <string>

/*
    Implementing next permutation
*/
std::string next_permutation(std::string str) {
    // check if it is sorted in descending order
    bool has_successor = false;
    for (int i = 0; i < (int) str.length() - 1; i++)
        if (str[i] < str[i + 1]) {
            has_successor = true;
            break;
        }

    if (has_successor == false)
        return "";

    // find the point from reverse direction where two characters are in ascending order            
    int sort_start_index = str.length() - 1;    // stores the index where to start sorting from
    for (; sort_start_index > 0; sort_start_index--)
        if (str[sort_start_index - 1] < str[sort_start_index])
            break;

    // sort the string starting from the index we found
    std::sort(str.begin() + sort_start_index, str.end());

    // find the index of the char which is greater in ascii in the sorted part, store the index in j
    int second_char_index = sort_start_index;
    // get previous char index which we have to swap with
    int first_char_index = second_char_index - 1;
    for (; second_char_index<(int)str.length(); second_char_index++)
        if (str[first_char_index]<str[second_char_index])
            break;

    std::swap(str[first_char_index], str[second_char_index]);
    std::cout << str << std::endl;
    return str;
}

/* We demonstrate the Permutation we implemented above */
int main() {
    // basic permutation demo

    // take a sample stirng
    std::string str = "aabbcc";
    // if we want to start permutation froma different index, change the index from 0 to something else
    std::string next_str = next_permutation(str);
    if (next_str.empty())
        std::cout << "There is no next permutation available for " << str << "." << std::endl;
    else
        std::cout<<"Next permutation of " << str << " is " << next_str <<std::endl;

    // take a sample stirng that has no permutation
    str = "cba";
    // if we want to start permutation from a different index, change the index from 0 to something else
    next_str = next_permutation(str);
    if (next_str.empty())
        std::cout << "There is no next permutation available for " << str << "." << std::endl;
    else
        std::cout << "Next permutation of " << str << " is " << next_str << std::endl;

    return 0;
}

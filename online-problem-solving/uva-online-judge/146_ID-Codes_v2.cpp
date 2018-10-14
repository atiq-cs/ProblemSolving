/*
    Problem Link :  https://uva.onlinejudge.org/external/1/146.html
    Problem Name :  ID Codes
    Algorithm    :  Next permutation
    Notes        :  An implementation of next-permutation
                    See demo: 

    Complexity   :  O(n log n)
    Status       :  Accepted
    Desc         :  Complexity is n log n considering a sort used in the procedure
    tag          :  tag-next-permutation, tag-permutation, tag-UVA-Judge
*/

#include<iostream>
#include<algorithm>
#include<string>

int main() {
    std::string str;

    // Take input
    while (std::cin >> str && str[0] != '#') {
        // check if it is sorted in descending order
        bool has_successor = false;
        for (int i = 0; i<str.length()-1; i++)
            if (str[i] < str[i + 1]) {
                has_successor = true;
                break;
            }

        if (has_successor == false)
            std::cout << "No Successor" << std::endl;
        else {
            // find the point from reverse direction where two characters are in ascending order            
            int sort_start_index = str.length() - 1;    // stores the index where to start sorting from
            for (; sort_start_index > 0; sort_start_index--)
                if (str[sort_start_index - 1] < str[sort_start_index])
                    break;

            // sort the string starting from the index we found
            std::sort(str.begin() + sort_start_index, str.end());

            // index of the char which is immediate greater in ascii in the sorted part, store the index in j
            int second_char_index = sort_start_index;
            // get previous char index which we have to swap with
            int first_char_index = second_char_index - 1;
            for (; second_char_index<str.length(); second_char_index++)
                if (str[first_char_index]<str[second_char_index])
                    break;

            std::swap(str[first_char_index], str[second_char_index]);
            std::cout << str << std::endl;
        }
    }

    return 0;
}

/*
    Problem Link :  https://uva.onlinejudge.org/external/1/146.html
    Problem Name :  ID Codes
    Algorithm    :  Next permutation
    Notes        :  This is the nasty C implementation by me, preserved for historical significance,
                    might be useful if you are looking for efficient C implementation

    Complexity   :  O(n)
    Status       :  Accepted
*/

#include<iostream>
#include<cstring>
#include<cstdio>

int main() {
    char str[1000], t;
    int len, i, j, k;

    // Take input
    while (std::cin >> str && str[0] != '#') {
        len = strlen(str);
        // check if it is sorted in descending order
        for (i = 0; i<len - 1; i++)
            if (str[i]<str[i + 1])
                break;

        if (i == len - 1)
            std::cout << "No Successor" << std::endl;
        else {
            // find the point from reverse direction where two characters in ascending order
            for (t = len - 1; t; t--)
                if (str[t - 1]<str[t]) break;

            i = t;

            for (j = i; j<len - 1; j++) {
                for (k = j + 1; k<len; k++) {
                    if (str[j]>str[k]) {
                        t = str[j];
                        str[j] = str[k];
                        str[k] = t;
                    }
                }
            }

            // get previous char index which we have to swap with is i-1
            // find the index of the char which is greater in ascii in the sorted part, store the index in j
            for (j = i; j<len; j++)
                if (str[i-1]<str[j]) break;

            i--;
            t = str[i];
            str[i] = str[j];
            str[j] = t;
            std::cout << str << std::endl;
        }
    }
    return 0;
}

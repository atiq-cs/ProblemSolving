/***************************************************************************
* Problem Name: The making of a cake
* Problem URL : https://www.codechef.com/KOL15MOS/problems/KOL1504
* Occasion    : ACM-ICPC Asia-Kolkata Onsite Mirror Contest 2015 
* Date        : Dec 26 2015
* Complexity  : O(n) Time and O(n) Space
* Author      : Atiq Rahman
* Status      : Accepted
* Desc        :  
* Notes       : Requires O(n) for reading items, algorithm requires O(1) after posa and
*                 fa have been processed.
*
* meta        : tag-anagram
***************************************************************************/

#include <iostream>
#include <string>
#include <cstdlib>
#include <vector>

bool swap_possible_freq(std::vector<int> &a, std::vector<int> &b) {
    for (int i = 0; i<26; i++)
        if (a[i] != b[i])
            return false;
    return true;
}

bool swap_possible_dist(std::vector<int> &a, std::vector<int> &b, int dist) {
    for (int i = 0; i<26; i++)
        if (abs(a[i] - b[i]) % dist != 0)
            return false;
    return true;
}

int main() {
    int T; std::cin >> T;
    while (T-- > 0) {
        int N, D; std::cin >> N >> D;
        std::string stra; std::cin >> stra;
        std::string strb; std::cin >> strb;

        std::vector<int> fa(26, 0);
        std::vector<int> fb(26, 0);
        std::vector<int> posa(26, 0);
        std::vector<int> posb(26, 0);

        for (int i = 0; i<N; i++) {
            char ch = stra[i];
            if (ch == ' ')
                continue;
            fa[ch - 'a']++;
            posa[ch - 'a'] += i;
        }
        for (int i = 0; i<N; i++) {
            char ch = strb[i];
            if (ch == ' ')
                continue;
            fb[ch - 'a']++;
            posb[ch - 'a'] += i;
        }

        if (swap_possible_freq(fa, fb) && swap_possible_dist(posa, posb, D))
            std::cout << "Yes" << std::endl;
        else
            std::cout << "No" << std::endl;
    }

    return 0;
}

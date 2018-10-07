/*
* Problem   : Demonstrating use of C++ 11 unordered_set ( alike java hash set)
* Author    : Atiq Rahman
* Email     : atiqcs 'at' outlook 'dot' com
* Date      : July 2, 2015
* Desc      : Use of unordered set
*              iteration over the et 
  ref: http://stackoverflow.com/questions/1349734/why-on-earth-would-anyone-use-set-instead-of-unordered-set
*             When should we use C++ unordered set?
                - Order is not required
                - Many insert operations (amortized running time is O(1)), average running time for look up O(1)
                        is preferred than log n
                - Large number of elements
                - Lexicographical comparison
* Complexity : O(1) lookup
* meta       : tag-hashtable, tag-easy
*/


#include <iostream>
#include <string>
#include <unordered_set>

// our alternative of hash set etc is unordered_set
// if all the characters of the string has unique characters return true
bool is_unique(std::string str) {
    std::unordered_set<int> char_set;
    for (auto ch : str) {
        auto find_index = char_set.find(ch);
        // if not found insert
        if (find_index == char_set.end())
            char_set.insert(ch);
        else
            return false;
    }
    return true;
}

/* We demonstrate the is_unique we implemented above using unordered_set */
int main() {
    std::string str = "abcdef";
    if (is_unique(str))
        std::cout << "String " << str << " is unique." << std::endl;
    else
        std::cout << "String " << str << " is not unique." << std::endl;

    str = "abcdedf";
    if (is_unique(str))
        std::cout << "String " << str << " is unique." << std::endl;
    else
        std::cout << "String " << str << " is not unique." << std::endl;

    return 0;
}

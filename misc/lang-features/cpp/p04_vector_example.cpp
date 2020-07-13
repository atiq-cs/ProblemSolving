/*
    C++ 11 features
    use of auto with vector container

    vector iterator examples
        modifying value using iterator
*/

#include <iostream>
#include <string>
#include <vector>

int _p03_disable_main()
{
    std::vector<int> v{ 100, 200 };

    /* to modify use reference */
    for (auto &x : v) {
        std::cout << "num: " << x << std::endl;
        x++;
    }

    /*  iterator can modify too  */

    for (auto it = begin(v); it != end(v); ++it) {
        std::cout << "std: " << *it << std::endl;
        *it = *it + 1;
    }

    for (auto x : v) {
        std::cout << "num: " << x << std::endl;
    }

    return 0;
}

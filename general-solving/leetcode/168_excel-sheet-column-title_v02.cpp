/***************************************************************************
* Problem Name: Excel Sheet Column Title
* Problem URL : https://leetcode.com/problems/excel-sheet-column-title/
* Date        : Oct 22 2015
* Complexity  : log_26(n) Time
* Author      : Atiq Rahman
* Notes       : Nutanix modification on this problem
* meta        : tag-binary-tree, tag-nutanix
***************************************************************************/
/*
  Problem description
  -------------------
    /dev/sda  - index 0
    /dev/sdb  - index 1
    ..
    /dev/sdz - index 25
    /dev/sdba - index 26
    ..

    Question: write a function that maps a given index to a device name.

    0 - a
    1 - b
    ..
    25 - z
    26 - ba    26 * 1 + 0  =>  ba
    27 - bb    26 * 1 + 1
    51 - bz    26 * 1 + 25
*/

/*
    It seemed the make the problem description more consistent I made it like this
        with permission,
 Assumes the problem as
    a - 0
    ..
    z - 25
    aa - 26
    ab - 27
    ...
    az - 51
    ba - 52 = 26 * 2 + 0
    bz - 77
    ca - 78
    za - 676 = 26 * 26
    zz - 701
    aaa - 702

    and that had been hard to implement

    so let's follow his description


    a = 0
    z = 25
    ba = 26
    bz = 51
    ca = 52
    ..
    za = 650

    650 / 26 = 25 = z

    zz = 675
    baa = 676
    676 / 26 = 26 mod = a
    26 / 26 = 1 mod = a
    1 % 26 = b
    bbz = 701
*/

class Solution {
private:
    std::string mapped_str;

public:
    std::string get_map(int n) {
        mapped_str = "";
        get_map_rec(n);
        return mapped_str;
    }

private:
    void get_map_rec(int n) {
        if (n == 0)
            return;

        get_map_rec(n / 26);
        mapped_str += (char)(n % 26 + 'a');
    }
};

// demo
int main() {
    Solution sol;
    int n; std::cin >> n;
    std::string res = sol.get_map(n);
    std::cout << res << " -> " << n << std::endl;
    return 0;
}

/*
    Other analysis that I could not have the energy to solve any more
    consider the first problem where aa = 26
    aa = 26 * b + 1 * a should had been mapped to 26 * 1 + 1 = 27 but it is 26
    az = 26 * b + 1 * a should had been 26 + 26 = 52 but it is 51

    aaa = 26 * 26 * a + 26 * b + 1 * c  should had been mapped to 26 * 26 * 1 + 26 * 1 + 1 = 703

    aaaa = 26 * 26 * 26 * a + 26 * 26 * b + 26 * c + 1 * d

    702 = 26 * 26 * 1 + 26 * 1 +

    702 / 26 = 27, mod = 0, last char
    27 / 26 = 1, mod = 1, second to last
    1 / 26 = 0, mod = 1 first char

    za = 26 * 26 + 1 * 1 = 677 but it is 676
    this can be interpreted as,
    za = 26 * 26 * 1 + 26 * 1

    676 / 26 = 26, mod = 1, last char
    26 / 26 = 1, mod = 0, first char
    1 / 26, mod = 1,
    May be there is a pattern that could be used to solve this as well..
     but that is a to do for later time
*/
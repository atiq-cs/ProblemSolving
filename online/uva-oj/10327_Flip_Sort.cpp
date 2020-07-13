/***************************************************************************
* Title : Flip Sort
* URL   : https://uva.onlinejudge.org/external/103/10327.pdf
* Date  : 2014-03-26
* Author: Atiq Rahman
* Comp  : O(N * M)
* Status: Accepted
* Notes : in code comment
* meta  : 
***************************************************************************/
#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class FlipSortUVA {
private:
  int find_largest_num_index(const vector<int> &rnum_list) {
    int max_index = 0;
    for (int i = 1; i < (int)rnum_list.size(); i++) {
      if (rnum_list[i] >= rnum_list[max_index]) {
        max_index = i;
      }
    }
    return max_index;
  }

public:
  void FindMinExchange() {
    // Take Input
    int N = 0;

    // Take number of test cases
    while (cin >> N) {
      vector<int> num_list;
      for (int i = 0; i < N; i++) {
        int x;
        cin >> x;
        num_list.push_back(x);
      }
      int total_min_flip = 0;
      while (num_list.size() > 1) {
        int largest_pos = find_largest_num_index(num_list);
        vector<int>::iterator result_pos = num_list.begin() + largest_pos;
        num_list.erase(result_pos);
        // num_list.size() - largest_pos is equal to number of flips required
        // to move the element to its proper last position
        total_min_flip += num_list.size() - largest_pos;
      }
      cout << "Minimum exchange operations : " << total_min_flip << endl;
    }
  }
};

int main() {
  FlipSortUVA FSObj;
  FSObj.FindMinExchange();
  return 0;
}

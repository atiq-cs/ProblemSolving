/***************************************************************************************************
* Title : Testing the CATCHER
* URL   : https://uva.onlinejudge.org/external/2/231.pdf
* Date  : 
* Comp  : O(n lg n)
* Status: Accepted
* Notes : Based on '231_TestingTheCatcher_lis_algo2_v1'
*  ToDo move to algo-core for DP
* rel   : leetcode/0300_lis_algo2.cs *
* ref   : https://ideone.com/IWlJlm
* meta  : tag-math, tag-algo-dp, tag-algo-bsearch, tag-dp-lis
***************************************************************************************************/
#include <iostream>
#include <vector>

#define LIMIT 1000005

std::vector<int> lis;
int A[LIMIT];

int BSearch(int item, int start, int end);
int GetLISLength(int n);

int GetLISLength(int n) {
  int limit = -1;
  lis.clear();

  for (int i = 0; i<n; i++) {
    // get lower bound
    int j = BSearch(A[i], 0, limit) + 1;

    if (j == lis.size()) {
      lis.push_back(A[i]);
      limit++;
    }

    // update lis if item is greater
    else if (lis[j] < A[i])
      lis[j] = A[i];
  }
  return limit+1;
}

int BSearch(int item, int start, int end) {
  int mid = (start + end) / 2;

  if (start > end)
    return end;
  else if (lis[mid] > item)
    return BSearch(item, mid + 1, end);
  else
    return BSearch(item, start, mid - 1);
}


int main() {
  int sq = 1, d, n;
  bool prev = true;

  while (true) {
    std::cin >> d;
    // new input sequence starting with -1 marks the end of input
    if (prev && (d == -1))
      break;
    else if (prev) {
      // beginning of an input set
      prev = false;
      n = 0;
      A[n++] = d;
    }
    // input sequence ends with -1
    else if (d == -1) {
      if (sq > 1)
        std::cout << std::endl;

      // end of an input set
      prev = true;
      std::cout << "Test #" << sq++ << ":" << std::endl <<
        "  maximum possible interceptions: " << GetLISLength(n) << std::endl;
    }
    else {
      A[n++] = d;
    }
  }

  return 0;
}

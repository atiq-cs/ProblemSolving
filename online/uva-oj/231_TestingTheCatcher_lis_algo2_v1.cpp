/***************************************************************************************************
* Title : Testing the CATCHER
* URL   : https://uva.onlinejudge.org/external/2/231.pdf
* Date  : 
* Comp  : O(n lg n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Credits: Jane Alam Jan
*   Modified a bit to make it more understable
*   ToDo, move BSearch to algo core as lower_bound(*)
*
*   Heart of this Solution is this function that implements lis DP using Binary Search
*   C.L.R.S p#397: Ex-15.4-6
*   Maintains candidate subsequence by linking them through the input sequence
*
*   Result subsequence is in decreasing order
*   old c version included at the bottom
* ref   : https://ideone.com/IWlJlm
* rel   : 481
* meta  : tag-math, tag-algo-dp, tag-dp-lis
***************************************************************************************************/
#include <iostream>

// int.MaxValue: 2^31 - 1
#define INF   0x7FFFFFFF
// int.MinValue: -2^31
#define NINF  0x80000000
#define LIMIT 1000005

int lis[LIMIT];
int A[LIMIT];


int GetLISLength(int n) {
  int limit = 0;
  lis[0] = INF;

  for (int i = 0; i<n; i++) {
    // get lower bound
    int j = BSearch(A[i], 0, limit) + 1;
    // returned lower bound gave -INF
    // which means we found a new small number to add to resultant subsequence
    if (lis[j] == NINF)
      limit = j;
    // update lis if item is greater
    if (lis[j] < A[i])
      lis[j] = A[i];
    else if (lis[j] == A[i])
      for (int k = j+1; ; k++)
        if (lis[j] != lis[k]) {
          lis[k] = A[i];
          if (limit < k)
            limit = k;
          break;
        }
  }
  return limit;
}

/*
 * Modified Binary Search to return immediate smaller one if item looked up is
 * not found.
 *
 * DP array (solution subsequence) is in decreasing order (for this problem)
 */
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
      lis[n] = NINF;
      prev = true;
      std::cout << "Test #" << sq++ << ":" << std::endl <<
        "  maximum possible interceptions: " << GetLISLength(n) << std::endl;
    }
    else {
      lis[n] = NINF;
      A[n++] = d;
    }
  }

  return 0;
}


// c version, variable and method names are slightly different
// tag-lang-c
int main_v0() {
  int sq = 1, d, top;
  bool prev = true;

  while (true) {
    scanf("%d", &d);
    if (prev && (d == -1))
      break;

    else if (prev) {
      // beginning of an input set
      prev = false;
      top = 0;
      data[top++] = d;
    }
    else if (d == -1) {
      if (sq > 1)
        putchar('\n');
      // end of an input set
      LIS[top] = -INF;
      prev = true;
      printf("Test #%d:\n  maximum possible interceptions: %d\n", sq++, get_length_lis(top));
    }
    else {
      LIS[top] = -INF;
      data[top++] = d;
    }
  }

  return 0;
}

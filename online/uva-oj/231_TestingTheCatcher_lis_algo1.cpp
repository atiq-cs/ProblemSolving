/***************************************************************************
* Title : Testing the CATCHER
* URL   : https://uva.onlinejudge.org/external/2/231.pdf
* Date  : 2008-09-08 (update 2016-09-25)
* Author: Atiq Rahman
* Status: Accepted
* Comp  : O(n^2)
* Notes : n^2 version - a modified version of simple LIS algo
*   Slightly modified LIS to work for Longest Decreasing Subsequence
* meta  : tag-dp-lis, tag-algo-dp
***************************************************************************/
#include <iostream>
using namespace std;

int run_lis(int m[], int n) {
  int a[10000];   // contains length
  for (int i = 0; i<n; i++) // initialize
    a[i] = 1;

  for (int i = 0; i<n; i++)
    for (int j = i + 1; j<n; j++)
      if ((m[i] > m[j]) && (a[j]<a[i] + 1))
        a[j] = a[i] + 1;

  int j = 0;
  for (int i = 1; i<n; i++)
    if (a[i]>a[j])
      j = i;

  return a[j];
}

int main() {
  int seq_no = 0, item = 0;
  int m[10000];

  while (cin >> item && item != -1) {
    if (seq_no != 0)
      cout << endl;
    seq_no++;

    int i = 0;
    do
      m[i++] = item;
    while (cin >> item && item != -1);

    cout << "Test #" << seq_no << ":" << endl << "  maximum possible interceptions: " << run_lis(m, i) << endl;
  }

  return 0;
}

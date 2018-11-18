/***************************************************************************************************
* URL   : 10487
* Status: Accepted
* Notes : Assumes that two numbers are distinct (they are not equal (Nor))
*   Uses algorithm::sort
* meta  : tag-algo-bsearch
***************************************************************************************************/
#include <iostream>
#include <algorithm>
using namespace std;

int num[1001], q, horizon;
long long sum[1000];

long long abs_value(long long value) {
  if (value < 0)
    return -value;
  return value;
}

int binary_search(int data, int start, int end) {
  long long abs_value(long long value);
  
  int mid = (start + end) / 2;

  if (start == end) {
    if (start > 0 && num[start-1]<data && data<num[start])
      return (abs_value((long long) num[start-1] - data) <= abs_value((long long)
        num[start] - data)?(start-1):start);
    else if (start < horizon && num[start]<data && data<num[start+1])
      return (abs_value((long long)num[start] - data)<=abs_value((long long)
        num[start+1] - data)?start:(start+1));
  }
  if (num[mid] == data)
    return mid;
  else if (num[mid]<data) {
    if (mid == end)
      return binary_search(data, mid, end);
    else
      return binary_search(data, mid + 1, end);
  }
  else {
    if (start == mid)
      return binary_search(data, start, mid);
    else
      return binary_search(data, start, mid -1);
  }
}

int binary_search_sum(int data, int start, int end) {
  long long abs_value(long long value);
  
  int mid = (start + end) / 2;

  if (start == end) {
    if (start >0 && sum[start-1]<data && data<sum[start])
      return (abs_value((long long) sum[start-1] - data)<abs_value((long long) sum[start] - data)?(start-1):start);
    else if (start < horizon && sum[start]<data && data<sum[start+1])
      return (abs_value((long long)sum[start] - data)<abs_value((long long)sum[start+1] - data)?start:(start+1));
  }
  if (sum[mid] == data)
    return mid;
  else if (sum[mid]<data) {
    if (mid == end)
      return binary_search_sum(data, mid, end);
    else
      return binary_search_sum(data, mid + 1, end);
  }
  else {
    if (start == mid)
      return binary_search_sum(data, start, mid);
    else
      return binary_search_sum(data, start, mid -1);
  }
}

int cmp (const void *va, const void *vb) {
  int *a = (int *) va;
  int *b = (int *) vb;
  
  return (*a-*b);
}

int main() {
  int m, n, i, j, pos, num2, sq = 0;
  long long data;

  while (cin >> n && n) {
    cout << "Case " << ++sq << ":" << endl;
    for (i = 0; i < n; i++)
      cin >> num[i];

    qsort(num, n, sizeof(int), cmp);

    cin >> m;
    for (i = 0; i < m; i++) {
      cin >> q;

      for (j = 0; j < n - 1; j++) {
        data = q - num[j];
        if (data < num[j + 1])
          num2 = num[j + 1];
        else if (num[n - 1] < data)
          num2 = num[n - 1];
        else {
          horizon = n - 1;
          pos = binary_search(data, j + 1, horizon);
          num2 = num[pos];
        }

        sum[j] = num[j] + num2;
      }

      // check comment on qsort at bottom
      sort(sum, sum + n - 1);

      horizon = n - 2;

      if (q < sum[0])
        pos = 0;
      else if (sum[horizon] < q)
        pos = horizon;
      else
        pos = binary_search_sum(q, 0, horizon);

      cout << "Closest sum to " << q << " is " << sum[pos] << "." << endl;
    }
  }
  return 0;
}

/*
  qsort does not work for the following input,
  5
  1
  2
  3
  4
  5
  1
  6
  0

  really?
*/

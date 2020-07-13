/***************************************************************************************************
* Title : Points in Figures: Rectangles, Circles, Triangles
* URL   : 481
* Comp  : O (n lg n)
* Notes : no edge test-cases
* rel   : 231, 497
* ref   : wikipedia
* meta  : tag-math, tag-algo-lis, tag-lang-cpp
***************************************************************************************************/
#include <vector>
using namespace std;

int a[1000005];
 
// Finds longest strictly increasing subsequence. O(n log k) algorithm.
template<typename T> vector<int> find_lis(vector<T> &a) {
  vector<int> b, p(a.size());
  int u, v;
 
  if (a.size() < 1)
    return b;
 
  b.push_back(0);
 
  for (int i = 1; i < (int)a.size(); i++) {
    if (a[b.back()] < a[i]) {
      p[i] = b.back();
      b.push_back(i);
      continue;
    }
 
    for (u = 0, v = b.size()-1; u < v;) {
      int c = (u + v) / 2;
      if (a[b[c]] < a[i]) u=c+1; else v=c;
    }
 
    if (a[i] < a[b[u]]) {
      if (u > 0) p[i] = b[u-1];
      b[u] = i;
    }  
  }
 
  for (u = b.size(), v = b.back(); u--; v = p[v])
    b[u] = v;

  return b;
} 

#include <cstdio>

int main() {
  unsigned i;
  int top=0, lisLen;
  
  while (scanf("%d",&a[top++]) != EOF);

  vector<int> seq(a, a+top);
  vector<int> lis = find_lis(seq);
 
  lisLen = lis.size();
  printf("%d\n-\n",lisLen);
  
  for (i = 0; i < lisLen; i++)
    printf("%d\n", seq[lis[i]]);
 
  return 0;
}

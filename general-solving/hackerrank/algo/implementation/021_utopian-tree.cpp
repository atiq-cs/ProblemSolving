/***************************************************************************
* Title       : Utopian Tree
* URL         : https://www.hackerrank.com/challenges/utopian-tree
* Date        : Dec 17, 2015
* Domain      : algorithms/implementation
* Complexity  : 
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : 
* meta        : tag-tree, tag-implementation
***************************************************************************/
#include <iostream>
using namespace std;

int height(int n) {
  if (n==0)
    return 1;
  if (n==1)
    return 2;
  
  if (n%2)
    return height(n-1)*2;
  else
    return height(n-1)+1;
}

int main() {
  int T;
  cin >> T;
  while (T--) {
    int n;
    cin >> n;
    cout << height(n) << endl;
  }
}

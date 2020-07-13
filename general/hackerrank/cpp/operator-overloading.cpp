/***************************************************************************
* Title : Operator Overloading
* URL   : https://www.hackerrank.com/challenges/operator-overloading
* Date  : Nov 2015
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : easy problem, cpp warmpup
* meta  : tag-strings, tag-lang-cpp
***************************************************************************/
#include <iostream>
#include <vector>
#include <string>

class Matrix {
public:
  vector< vector<int> > a;
};

/*further thought: can the overloading declared inside the class? */
Matrix operator+(Matrix& lhs, Matrix& rhs) {
  Matrix res;
  for (int i = 0; i<lhs.a.size(); i++) {
    vector<int> row;
    for (int j = 0; j<lhs.a[0].size(); j++)
      row.push_back(lhs.a[i][j] + rhs.a[i][j]);
    res.a.push_back(row);
  }
  return res;
}

/************** Provided *****************/
int main() {
  int cases, k;
  cin >> cases;
  for (k = 0; k<cases; k++) {
    Matrix x;
    Matrix y;
    Matrix result;
    int n, m, i, j;
    cin >> n >> m;
    for (i = 0; i<n; i++) {
      vector<int> b;
      int num;
      for (j = 0; j<m; j++) {
        cin >> num;
        b.push_back(num);
      }
      x.a.push_back(b);
    }
    for (i = 0; i<n; i++) {
      vector<int> b;
      int num;
      for (j = 0; j<m; j++) {
        cin >> num;
        b.push_back(num);
      }
      y.a.push_back(b);
    }
    result = x + y;
    for (i = 0; i<n; i++) {
      for (j = 0; j<m; j++) {
        cout << result.a[i][j] << " ";
      }
      cout << endl;
    }
  }
  return 0;
}

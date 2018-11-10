/*******************************************************
* Title : Find largest subsquare
* URL   : http://www.geeksforgeeks.org/given-matrix-o-x-find-largest-subsquare-surrounded-x/
* Occasn: Christmas Day
* Date  : 2014-12-25
* Author: Atiq Rahman
* Notes : Naive Solution
*   This source includes a cpp template modification example
*   To handle IO error for non-existent files
* meta  : tag-coding-practice
*******************************************************/
#include <iostream>
#include <fstream>
#include <cmath>
#include <string>
#include <new>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

class SquareFinder {
  int dim;
  vector<string> mat;
  // could have declared as bool, but doesn't matter
  vector<vector<int>> horiz_count;
  vector<vector<int>> vert_count;

  void ComputeAdditionalMatrices();
  int find_matrix_size(int row, int col);

public:
  SquareFinder();
  ~SquareFinder();
  void FindLargestMatrix();
};

SquareFinder::SquareFinder() /*:
  horiz_count(10, vector<int>(10, 0)),
  vert_count(10, vector<int>(10, 0))*/ {
  // Initiaze used variables
  dim = 0;
}

SquareFinder::~SquareFinder() {
  // free allocated space
  mat.clear();

  for (vector<int>iV : horiz_count)
    iV.clear();
  horiz_count.clear();

  for (vector<int>iV : vert_count)
    iV.clear();
  vert_count.clear();
}

void SquareFinder::ComputeAdditionalMatrices() {
  // initialize additional matrices
  for (int y = 0; y < dim; y++) {
    vector<int> temp;
    for (int x = 0; x < dim; x++) {
      temp.push_back(0);
    }
    horiz_count.push_back(temp);
    vert_count.push_back(temp);
  }

  for (int y = 0; y < dim; y++)
    for (int x = 0; x < dim; x++) {
      if (mat[y][x] == '0') {
        horiz_count[y][x] = 0;
        vert_count[y][x] = 0;
      }
      else {
        if (x == 0)
          horiz_count[y][x] = 1;
        else
          horiz_count[y][x] = horiz_count[y][x-1] + 1;

        if (y == 0)
          vert_count[y][x] = 1;
        else
          vert_count[y][x] = vert_count[y-1][x] + 1;
      }
    }
}

int SquareFinder::find_matrix_size(int row, int col) {
  if (mat[row][col] == '0')
    return 0;

  int N = dim;
  int max_square_length = min(N-col, N-row);
  for (int i = max_square_length; i > 1; i--) {
    if (horiz_count[row][col + i - 1] < i)
      continue;
    if (vert_count[row + i - 1][col] < i)
      continue;
    if (horiz_count[row + i - 1][col + i - 1] < i)
      continue;
    if (vert_count[row + i - 1][col + 1 - 1] < i)
      continue;
    return i;
  }
  return 1;
}

void SquareFinder::FindLargestMatrix() {
  // End of input indicated by a dimension of 0
  while (cin >> dim && dim) {
    vector<vector<int>> res_size(dim, vector<int>(dim, 0));
    mat.clear();
    string line;
    // indexing will be mat[row][column]
    for (int i = 0; i < dim; i++) {
      cin >> line;
      if (line.length() > (size_t) dim) {
        cout << "Incorrect number of columns in matrix!" << endl;
      }
      mat.push_back(line);
    }

    // Computer horiz count and vert count
    ComputeAdditionalMatrices();

    int maxXIndex = 0;
    int maxYIndex = 0;
    for (int y = 0; y < dim; y++)
      for (int x = 0; x < dim; x++) {
        res_size[y][x] = find_matrix_size(y, x);
        if (res_size[y][x] == dim) {
          maxXIndex = x;
          maxYIndex = y;
          break;
        }
        else if (res_size[y][x] > res_size[maxYIndex][maxXIndex]) {
          maxXIndex = x;
          maxYIndex = y;
        }
      }

    // output result
    cout << "Maximum size found: " << res_size[maxYIndex][maxXIndex] << endl;

    // clear additional arrays
    for (vector<int>iV : horiz_count)
      iV.clear();
    horiz_count.clear();

    for (vector<int>iV : vert_count)
      iV.clear();
    vert_count.clear();
  }
}

int __disable_main() {
#ifdef  SA_DEBUG
  // set problem number here; it helps setting correct input and output file
  string problem_id("01_find_largest_subsquare");

  string in_file_path(problem_id);  in_file_path += "_in.txt";
  string out_file_path(problem_id);  out_file_path += "_out.txt";

  // Redirect cin to in file
  // ref for this solution:   http://stackoverflow.com/questions/10150468/how-to-redirect-cin-and-cout-to-files
  ifstream subinput(in_file_path);
  streambuf* orig_cin = NULL;
  if (subinput) {
    orig_cin = cin.rdbuf();      //save old buf
    cin.rdbuf(subinput.rdbuf());  //redirect std::cin to in.txt!
  }
  else {
    cout << "Cannot open input file for reading. Probably " << in_file_path << " does not exist." << endl;
    return 0;
  }

  // Redirect cout to out file
  ofstream suboutput(out_file_path);
  streambuf *orig_cout = NULL;
  if (suboutput) {
    orig_cout = cout.rdbuf(); //save old buf
    cout.rdbuf(suboutput.rdbuf()); //redirect std::cout to out.txt!
  }
  else {
    cout << "Coutld not open output file " << out_file_path << " for reading." << endl;
    return 0;
  }

#endif

  // Code here
  SquareFinder SFMObj;
  SFMObj.FindLargestMatrix();

  return 0;
}

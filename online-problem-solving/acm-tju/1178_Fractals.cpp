/*
* Title : Fractal
* URL   : http://acm.tju.edu.cn/toj/showp1178.html
* Algo  : Divide and conquer
* Email : atiqcs 'at' outlook 'dot' com
* Date  : March 7, 2015
* Desc  :
*
* Note  : Got compilation error due to not declaration string
*                 Using initializer list
*                 Judge is gcc 4.5.2, old, does not support C++11 all features
* Status: Accepted
* meta :   tag-recursion
*/

#include <cstring>
#include <sstream>
#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
// Comment before submission to judge
//#define FILE_IO    TRUE

// My own file template for C++
#ifdef FILE_IO
#include <fstream>
#endif
using namespace std;

// my function 
void handleIO();

// Class that handles all fractal generation, storage and properties
class BoxFractal {
private:
    const int NumMaxFractals;
    vector<int> SizeMaxFractals;
    char ***grid;
    int num;
    void generate_rec(int n, int row, int col);

public:
    BoxFractal();
    ~BoxFractal();
    void print(int n);
    void convert_grid_to_string();
    void span_grids();
    void generate();
};

int main() {
    handleIO();
    return 0;
}

void handleIO() {
#ifdef FILE_IO
    ofstream outFile("1178_out.txt");
    streambuf *psbuf = outFile.rdbuf(), *backup;
    backup = cout.rdbuf();     // back up cout's streambuf
    cout.rdbuf(psbuf);
#endif

    BoxFractal boxfractal;
    boxfractal.generate();
    boxfractal.span_grids();
    boxfractal.convert_grid_to_string();
    int n;

    while (cin >> n && n != -1) {
        boxfractal.print(n);
        cout << "-"<<endl;
    }
#ifdef FILE_IO
    cout.rdbuf(backup);
    outFile.close();
#endif
}

/*
    Constructor for the class
    Initializes size of fractals
    Allocates memory for exactly 7 fractals to facilitate fastest output of result
*/
BoxFractal::BoxFractal() : NumMaxFractals(7),
grid(NULL) {
    /*Requires C++ 11, judge does not support C++ 11*/
    // SizeMaxFractals = { 1, 3, 9, 27, 81, 243, 729 };
    // for old compiler
    SizeMaxFractals.push_back(1); SizeMaxFractals.push_back(3);
    SizeMaxFractals.push_back(9); SizeMaxFractals.push_back(27);
    SizeMaxFractals.push_back(81); SizeMaxFractals.push_back(243);
    SizeMaxFractals.push_back(729);

    grid = new char**[NumMaxFractals];
    for (int i = 0; i < NumMaxFractals; i++) {
        grid[i] = new char*[SizeMaxFractals[i]];
        for (int row = 0; row < SizeMaxFractals[i]; row++) {
            grid[i][row] = new char[SizeMaxFractals[i] + 1];    // 1 for null termination
            memset(grid[i][row], ' ', SizeMaxFractals[i]);
            grid[i][row][SizeMaxFractals[i]] = '\0';
        }
    }

}

// Destructor, we exiting program
BoxFractal::~BoxFractal() {
    // Clean the memory heap like a gentleman
    for (int i = 0; i < NumMaxFractals; i++) {
        for (int row = 0; row < SizeMaxFractals[i]; row++)
            delete grid[i][row];
        delete grid[i];
    }
    delete grid;
}

// any kind of generation parameters
void BoxFractal::generate() {
    generate_rec(NumMaxFractals, 0, 0);
}

// The heart of the solution: implementation of our recurrence relation
void BoxFractal::generate_rec(int n, int row, int col) {
    if (n == 1) {
        grid[NumMaxFractals-1][row][col] = 'X';
        return;
    }
    int c = (int)pow(3, n - 2);
    
    // Top Left
    generate_rec(n - 1, row, col);
    // Top Right
    generate_rec(n - 1, row, col + 2*c);
    // Middle box
    generate_rec(n - 1, row+c, col+c);

    // Bottom Left
    generate_rec(n - 1, row+2*c, col);
    // Bottom Right
    generate_rec(n - 1, row+2*c, col+2*c);
}

/* Clean out any trailing spaces after each of the line in fractal grid
    Idea is to find the last occurrence of 'X' and then put a null
    termination character after it
*/
void BoxFractal::convert_grid_to_string() {
    for (int i = 0; i < NumMaxFractals; i++)
        for (int row = 0; row < SizeMaxFractals[i]; row++) {
            // in each row, find the last X in the string
            for (int col = SizeMaxFractals[i] - 1; col >=0 ; col--) {
                // put a null terminating symbol after that index
                if (grid[i][row][col] == 'X') {
                    if (col<SizeMaxFractals[i])
                        grid[i][row][col + 1] = '\0';
                    break;
                }
            }
        }
}

/* after generating the max fractal we propagate it to previous grids */
void BoxFractal::span_grids() {
    for (int i = 0; i < NumMaxFractals - 1; i++)
        for (int row = 0; row < SizeMaxFractals[i]; row++)
            for (int col = 0; col < SizeMaxFractals[i]; col++)
                grid[i][row][col] = grid[NumMaxFractals - 1][row][col];
}

/* simple function to output the result */
void BoxFractal::print(int n) {
    if (n < 1 || n>7)
        return;
    int size = (int)pow(3, n-1);

    for (int i = 0; i < size; i++) {
        cout << grid[n-1][i]<<endl;
    }
}

/***************************************************************************************************
* Title : Pre, in and post
* URL   : 10701
* Author: Atiq Rahman (during DU CS Undergrad)
* Status: Accepted
* Notes : first runtime error for 26 for 52 string size or node no (mistake)
*   second RE for 60 in 52 (judge's problem)
*   third compilation error because of global variable declaration after main function
*
*   Recursively placing root to right gives the output result
* meta  : tag-ds-binary-tree, tag-traversal, tag-recursion
***************************************************************************************************/
#include <iostream>
#include <cstring>
using namespace std;

char preord[500], inord[500];
int root_pos;    // position of root in preorder string
int tmp, i;      // to save space declared globally

void make_post(int start, int end) {
  /*************************************************
  cout<<"debug string: "<<inord<<endl;
  cout<<"start: "<<start<<" end: "<<end<<endl;
  cout<<"pre root position:  "<<root_pos<<endl<<endl;
  getchar();
  *************************************************/

  if (start >= end) {      // Termination case
    if (start == end)    //  we should not increment when no tree is found left or right
      root_pos++;  
    return;
  }

  int pos;

  for (pos = start; preord[root_pos] != inord[pos]; pos++);  // get the root's position in inorder string

  root_pos++;

  // move root to right to maintain order left, right, root for postorder output
  tmp = inord[pos];

  for (i=pos; i<end;i++)
    inord[i] = inord[i+1];

  inord[i] = tmp;

//  modify left
  make_post(start, pos - 1);

//  modify right
  make_post(pos, end - 1);
}

int main() {
  int testCases;
  scanf("%d", &testCases);
  int testi;

  for (testi = 0; testi < testCases; testi++) {
    //  initialize root position for every input
    scanf("%*d %s %s", preord, inord);
    root_pos = 0;
    make_post(0, strlen(inord) - 1);
    puts(inord);
  }

  return 0;
}

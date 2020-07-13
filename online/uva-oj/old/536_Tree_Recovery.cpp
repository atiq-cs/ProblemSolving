/***************************************************************************************************
* Title : Tree Recovery
* URL   : https://uva.onlinejudge.org/external/5/p536.pdf
* Status: Accepted
* Comp  : O (V+E)
* Notes : During CSE DU Undergrad, approx 2008,
*   Recursively placing root to right gives the output result
* meta  : tag-binary-tree, tag-preorder, tag-inorder, tag-post-order, tag-recursion
***************************************************************************************************/
#include <iostream>
#include <cstring>
using namespace std;

char preord[30], inord[30];
int root_pos;    // position of root in preorder string

int main () {
  void make_post(int start, int end);
  
  while ((scanf("%s %s",preord, inord)) == 2) {
    // initialize root position for every input
    root_pos = 0;
    make_post(0, strlen(inord)-1);
    puts(inord);
  }

  fclose(stdin);
  return 0;
}

/*
 * Modifies binary tree so that root is moved a position right after the right
 * subtree
 * Recursively doing this ensures that we get a string representation of post
 * order traversal in the original inorder traversal string
 *
 * Input: preord, inord
 * Output: inord
 */
void make_post(int start, int end) {
  // Base case
  if (start >= end) {
    // We should not increment when no sub-tree is found on left side or right
    // side.
    if (start == end)
      root_pos++;  
    return;
  }

  int pos = start;
  // preord[start] is root when make_post is called first time
  // get root node's position in inorder traversal
  for (; preord[root_pos] != inord[pos]; pos++);
  root_pos++;

  // move the root to right to maintain order left, right, root for postorder output
  int tmp = inord[pos]; // save root
  int i = pos;
  // move right subtree before root and put root afterwards from temp variable
  for (; i<end;i++)
    inord[i] = inord[i+1];
  inord[i] = tmp;

  // modify left
  make_post(start, pos - 1);
  // modify right
  make_post(pos, end - 1);
}


// Copy of above code with debug prints
void make_post_debug(int start, int end) {
  cout<<"debug string: "<<inord<<endl;
  cout<<"start: "<<start<<" end: "<<end<<endl;
  cout<<"pre root position:  "<<root_pos<<endl<<endl;
  getchar();

  if (start >= end) {
    if (start == end)
      root_pos++;
    return;
  }

  int pos;
  for (pos = start; preord[root_pos] != inord[pos]; pos++);
  root_pos++;

  cout<<"pos: "<<pos<<endl;
  tmp = inord[pos];

  for (i = pos; i<end; i++)
    inord[i] = inord[i + 1];

  inord[i] = tmp;

  cout<<"inord: "<<inord<<endl;
  make_post(start, pos - 1);
  cout<<"exit recursion left"<<endl;

  make_post(pos, end - 1);
  cout<<"exit recursion right"<<endl;
}

/***************************************************************************************************
* Title : Tri Tiling
* Occasn: tju contest
* URL   : 10918
* Notes : 
* ref   : http://www.algorithmist.com/index.php/UVa_10918
* meta  : tag-algo-dp
***************************************************************************************************/
#include <iostream>
using namespace std;

int main() {  
  int n,i;
  int domino[32] = {1,3};

  for (i=2; i<32; i++)
    domino[i] = 4 * domino[i-1] - domino[i-2];

  while (cin>>n && n != -1)
    if (n%2)
      cout<<"0"<<endl;
    else
      cout<<domino[n/2]<<endl;

  return 0;
}

/*
  Problem Name: Testing the CATCHER
  Algorithm      : Longest Decreasing Subsequence
*/

#include <iostream>
using namespace std;

int main () {
    int m[10000],i,j;
    int a[10000];
    
    int tmp = 0, n = 0;

    while(cin>>m[0]) {
        if (m[0] == -1) break;
        if (tmp) cout<<endl;
        tmp++;
        
        i=1;
        while(1)
        {
            cin>>m[i];
            if(m[i]==-1) break;
            i++;
        }
        n=i;
        for (i = 0; i<n;i++) a[i] = 1;
        for (i = 0; i<n;i++) {
            for (j=i+1;j<n;j++) {
                if ((m[i] > m[j]) && (a[j]<a[i] + 1)) {
                    a[j] = a[i] + 1;
                }
            }
        }
        for (j=0,i=1;i<n;i++) {
            if (a[i]>a[j]) j = i;
        }
        cout<<"Test #"<<tmp<<":"<<endl<<"  maximum possible interceptions: "<<a[j]<<endl;
    }
    return 0;
}

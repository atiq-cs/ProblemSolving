#include<iostream>
#include<iomanip>
using namespace std;

main () {
  long t,i,n,j;
  double sum_c,a0,a1,an1,c[100000], eps = 1e-8;

  freopen("10014.in","r",stdin);
  cin>>t;
  for (i=0;i<t;i++) {
    cin>>n>>a0>>an1;
    for (j=0;j<n;j++) {
      cin>>c[j];
    }
    a1 = (n * a0) / (n+1) + an1/ (n+1);
    for (sum_c=0,j=0;j<n;j++) {
      sum_c += (n-j)*c[j];
    }
    sum_c *= 2;
    sum_c /= (n+1);

    sum_c = a1 - sum_c;
    
    if (i) cout<<endl;
    cout.setf (ios::fixed, ios::floatfield);
    cout.setf(ios::showpoint);

    cout<<setprecision(2)<<sum_c + eps<<endl;
  }
  return 0;
}

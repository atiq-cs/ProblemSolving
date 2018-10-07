/*
  Problem ID:  10487
  Judge status:  Accepted
  Author: Atiq Rahman
  Assumes
  Two numbers are distinct that is they are not equal (Nor)
 */
#include <iostream>
#include <algorithm>
using namespace std;

int num[1001],q, horizon;
long long sum[1000];


int main () {
  int Bin_Search(int data, int start, int end);
  int Bin_Search_Sum(int data, int start, int end);
  int cmp (const void *va, const void *vb);  

  int m,n,i,j, pos, num2,sq=0;
  long long data;

  freopen("10487_in.txt","r",stdin);
  
  while (cin>>n && n) {
    cout<<"Case "<<++sq<<":"<<endl;
    for (i=0; i<n; i++)
      cin>>num[i];
    
    qsort(num, n, sizeof (int), cmp);
    /*for (i=0; i<n; i++)
      cout<<"num "<<i<<" "<<num[i]<<endl  ;
    //*/
    
    cin>>m;
    for (i=0; i<m; i++) {
      cin>>q;
      for (j=0; j<n-1; j++) {
        data = q - num[j];
        //cout<<"data "<<data<<endl;
        if (data<num[j+1]) {
          num2 = num[j+1];
        }
        else if (num[n-1]<data) {
          num2 = num[n-1];
        }
        else {
          horizon = n-1;
          pos = Bin_Search(data, j+1, horizon);
          num2 = num[pos];
          /*cout<<"pos "<<pos<<"\t";
          cout<<"num2 "<<num2<<endl;
          //*/
        }
        sum[j] = num[j] + num2;
      }
      /*
      for (j=0; j<n-1; j++)
        cout<<"sum "<<j<<": "<<sum[j]<<endl;//*/

      sort(sum, sum + n-1);
      /*
        qsort does not work for the following input:
        5
        1
        2
        3
        4
        5
        1
        6
        0
      */

      /*
      for (j=0; j<n-1; j++)
        cout<<"sum "<<j<<": "<<sum[j]<<endl;//*/

      horizon = n-2;

      if (q<sum[0]) {
        pos = 0;
      }
      else if (sum[horizon]<q) {
        pos = horizon;
      }
      else
        pos = Bin_Search_Sum(q, 0, horizon);
      
      cout<<"Closest sum to "<<q<<" is "<<sum[pos]<<"."<<endl;
    }
  }
  fclose(stdin);
  return 0;
}

long long abs_value(long long value) {
  if (value < 0)
    return -value;
  return value;
}

int Bin_Search(int data, int start, int end) {
  long long abs_value(long long value);
  
  int mid = (start + end) / 2;

  /*
  cout<<"data "<<data;
  cout<<"\tstart "<<start;
  cout<<"\tend "<<end<<endl;
  getchar();
  //*/
  if (start == end) {
    if (start > 0 && num[start-1]<data && data<num[start])
      return (abs_value((long long) num[start-1] - data)<=abs_value((long long) num[start] - data)?(start-1):start);
    else if (start < horizon && num[start]<data && data<num[start+1])
      return (abs_value((long long)num[start] - data)<=abs_value((long long)num[start+1] - data)?start:(start+1));
  }
  if (num[mid] == data)
    return mid;
  else if (num[mid]<data) {
    if (mid == end)
      return Bin_Search(data, mid, end);
    else
      return Bin_Search(data, mid + 1, end);
  }
  else {
    if (start == mid)
      return Bin_Search(data, start, mid);
    else
      return Bin_Search(data, start, mid -1);
  }
}

int Bin_Search_Sum(int data, int start, int end) {
  long long abs_value(long long value);
  
  int mid = (start + end) / 2;

  /*
  cout<<"data "<<data;
  cout<<"\tstart "<<start;
  cout<<"\tend "<<end<<endl;
  getchar();
  //*/
  if (start == end) {
    if (start >0 && sum[start-1]<data && data<sum[start])
      return (abs_value((long long) sum[start-1] - data)<abs_value((long long) sum[start] - data)?(start-1):start);
    else if (start < horizon && sum[start]<data && data<sum[start+1])
      return (abs_value((long long)sum[start] - data)<abs_value((long long)sum[start+1] - data)?start:(start+1));
  }
  if (sum[mid] == data)
    return mid;
  else if (sum[mid]<data) {
    if (mid == end)
      return Bin_Search_Sum(data, mid, end);
    else
      return Bin_Search_Sum(data, mid + 1, end);
  }
  else {
    if (start == mid)
      return Bin_Search_Sum(data, start, mid);
    else
      return Bin_Search_Sum(data, start, mid -1);
  }
}

int cmp (const void *va, const void *vb) {
  int *a = (int *) va;
  int *b = (int *) vb;
  
  return (*a-*b);
}

/*
    Problem Link: https://uva.onlinejudge.org/external/115/11557.pdf
    Solution Link:
     This is the chinese solution acquired from: http://blog.csdn.net/accelerator_/article/details/38783651
        referred by Yonghui Wu (http://www.cs.fudan.edu.cn/en/?page_id=2269)
    Generates 


    Complexity:
      Generates Pattern string from the input code  fragment of repository n times:
        P[1...m], P[2...m], P[3...m], P[4...m], ....., P[m..m]
       and afterwards, it runs KMP using each of this prefix with code fragments.
      Running time of KMP is theta (n)
      The solution is running KMP m times
      Running time: theta (nm) where n is size of code fragments and m is size of repo code fragment

    Note: this code has a function named hash which will conflict with C++11's library function
            You need to use a old compiler or change name of this function for successful compilation

     Flaws:
         This code gets Accepted on UVA! Shit! However, the way it matches with maximum length of matching
            does not seem correct!
         Not really very good coding style, some parts are hard to understand
*/

#include <cstdio>
#include <cstring>
#include <vector>
#include <string>
#include <iostream>
#include <vector>
using namespace std;  
  
typedef unsigned long long ull;  
  
const ull X = 123;  
const int N = 105;  
  
int n, next[1000005];  
string name[N];  
string s;  
vector<int> ans;  
vector<ull> code[N];  


void hash(string s, int u) {  
    string ss = "";  
    int l = 0, r = s.length() - 1, len = s.length();
    
    while (s[l] == ' ' && l < len) l++;
    
    while (s[r] == ' ' && r >= 0) r--;  
    
    for (int i = l; i <= r; i++) {  
        ss += s[i];  
        while (s[i] == ' ' && s[i + 1] == ' ' && i < r)
            i++;  
    }  
    
    if (ss == "")
        return;
    ull ans = 0;  
    
    for (int i = ss.length() - 1; i >= 0; i--)  
        ans = ans * X + ss[i];  
    
    code[u].push_back(ans);  
}  

/*
    Builds hash code for each string and put into code[i]
*/
void build(int i) {
    code[i].clear();  
    
    while (getline(cin, s) && s != "***END***")
        hash(s, i);  
    
}  
  
vector<ull> T;  

/*
    KMP algorithm - Prefix Build
    T contains pattern string constructed from code[i]
*/
void getnext() {  
    int N = T.size();  
    next[0] = next[1] = 0;  
    int j = 0;
    
    for (int i = 2 ; i <= N; i++) {  
        while (j && T[i - 1] != T[j])
            j = next[j];
        
        if (T[i - 1] == T[j])
            j++;  
        
        next[i] = j;  
    }  
}  

/*
    KMP algorithm - Find
    code[n] is code fragment/TEXT
    T is pattern (the code might confuse, but trust me.. )
*/

int find() {  
    int ans = 0;  
    int N = code[n].size(), m = T.size(), j = 0;  
    for (int i = 0; i < N; i++) {  
        while (j && code[n][i] != T[j])
            j = next[j];  

        if (code[n][i] == T[j])
            j++;  

        ans = max(ans, j);

        if (j == m)
            return m;
    }
    
    return ans;  
}  
  
/* find length of longest common substring
    using KMP
*/
  int cal(int u) {  
    int ans = 0;  
    // sz1 is the size of fragment u (how many lines of code are there... )
    int sz1 = code[u].size();
    
    /* 
        Create segments from code fragment i
        code[i] and each time run KMP
            to match with the pattern from the repository
            with segments of code[i]

        so basically it is running KMP sz1/m times
        which is basically no improvement from my solution
    */
    for (int i = 0; i < sz1; i++) {  
        T.clear();
        // push into T all the lines of code starting with index i
        for (int j = i; j < sz1; j++)  
            T.push_back(code[u][j]);

        // build prefix for input T
        getnext();  
        ans = max(ans, find());  
    }  
    return ans;  
}  

/*
    All strings are hashed and put into array of vectors code
*/
void solve() {
    int Max = 0;
    ans.clear();
    for (int i = 0; i < n; i++) {
        /* length of match with fragment i */
        int tmp = cal(i);
        if (tmp > Max) { 
            Max = tmp;  
            ans.clear();  
            ans.push_back(i);  
        }
        /*  Is this really correct?
            It will get not only max but others which might be smaller than max
            But this code is getting accepted... Need to contact UVA judge...
        */
        else if (tmp == Max)
            ans.push_back(i);
    }  
    cout << Max;  
    if (Max) {  
        for (int i = 0; i < ans.size(); i++)  
            cout << " " << name[ans[i]]; 
    }  
    cout << endl;  
}  

// ##### Entry function Main ###### //
    while (cin >> n) {  
        getchar();
        for (int i = 0; i < n; i++) {  
            getline(cin, name[i]);  
            build(i);
        }
        build(n);  
        solve();  
    }

    return 0;  
// ########################## //

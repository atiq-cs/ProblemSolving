/*
	Problem Name: All in All
	Algorithm      : LCS compatible
*/

#include<iostream>
#include<cstring>
#include<cstdio>
using namespace std;

main()
{
	int lns,lnt,i,pos;
	char s[1000000],t[1000000];

	while (scanf("%s %s",s,t)==2) {
		pos = 0;
		lns = strlen (s);
		lnt = strlen (t);
		for (i=0;i<lnt;i++) {
			if (pos<lns)
			if (t[i]==s[pos]) pos++;
		}
		cout<<(pos==lns ? "Yes":"No")<<endl;
	}
	return 0;
}

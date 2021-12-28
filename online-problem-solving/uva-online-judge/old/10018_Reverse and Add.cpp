/*
	Problem Name: Reverse and Add
	Algorithm      : Native
*/

#include<iostream>
using std::cin;
using std::cout;
using std::endl;

main()
{
	unsigned p,a,b;
	short n,np;
	cin>>n;

	for (short i=0;i<n;i++)
	{
		cin>>p;
		np=0;
		while(1)
		{
			a=p;b=0;
			while(a)
			{
				b=b*10+a%10;
				a/=10;
			}
			if (p==b) break;
			p+=b;
			np++;
		}
		cout<<np<<" "<<b<<endl;
	}
	return 0;
}

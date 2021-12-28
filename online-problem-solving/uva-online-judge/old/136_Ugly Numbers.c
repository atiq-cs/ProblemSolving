/*
	Problem Name: Ugly Numbers
	Solution: DP
	Description: Print final 1500th ugly number
  Update: this has moved to
    "online-problem-solving/uva-online-judge/136_UglyNumbers.cpp"
  Date: 2006-06-24
*/
#include <stdio.h>

int main() {
	int i, j;
	int ugly[1500];
	ugly[0] = 1;

	for(i = 1; i < 1500; i++)
	{
		ugly[i] = 900000000;
		for(j = 0; j < i; j++)
		{
			if(ugly[j] * 2 > ugly[i - 1])
			{
				if(ugly[j] * 2 < ugly[i]) ugly[i] = ugly[j] * 2;
			}
			else if(ugly[j] * 3 > ugly[i - 1])
			{
				if(ugly[j] * 3 < ugly[i]) ugly[i] = ugly[j] * 3;
			}
			else if(ugly[j] * 5 > ugly[i - 1])
			{
				if(ugly[j] * 5 < ugly[i]) ugly[i] = ugly[j] * 5;
			}
		}
	}
	printf("The 1500'th ugly number is %d.\n",ugly[1499]);
	return 0;
}

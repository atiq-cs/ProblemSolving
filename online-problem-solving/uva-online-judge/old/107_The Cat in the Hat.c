/*
	Problem Name: The Cat in the Hat
	Algorithm      : Series, Logarithmic solution
	Update: this has moved to
  "online-problem-solving/uva-online-judge/107_The Cat in the Hat.cpp"

*/

#include<stdio.h>
#include<math.h>

int main()
{
	int Height,Number_Workers,root,Number_Not_Working,Sum_Height;
	double Ratio;

	while ( scanf ("%d %d", &Height, &Number_Workers ) )
	{
		if (!Height && !Number_Workers) break;
		if(Height >= Number_Workers)
		{
			if (Number_Workers==1)
			{
				root = 1;
				Number_Not_Working = log(Height)/log(2)+0.5;
			}
			else
			{
				Ratio = log ( (double)Height )/log ( (double)Number_Workers ) ;
				for ( root=1; root<=Number_Workers; root++ )
					if ( fabs( pow( (double)root,Ratio )-(double)root-1.0 ) < 0.001 ) break;
				Number_Not_Working=(Number_Workers - 1) / (root-1);
			}
			Sum_Height = root * (Height - Number_Workers) + Height;
			printf("%d %d\n",Number_Not_Working,Sum_Height);
		}
	}
	return 0;
}

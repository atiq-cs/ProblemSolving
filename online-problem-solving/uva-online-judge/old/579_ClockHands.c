/*
	Problem Name: ClockHands
	Algorithm:	Normal Degree Calculation
*/

#include<stdio.h>

main()
{
	char time;
	float Hand_hour,Hour,Hand_minute,Minute,Angle_between;

	for (;;)
	{
		scanf ("%f",&Hour);
		scanf("%c",&time);
		scanf ("%f",&Minute);
		
		Hand_hour=30*Hour;
		Hand_minute=5.5*Minute;
		if (!Hand_hour && !Hand_minute) break;
		if (Hand_hour>Hand_minute) Angle_between = Hand_hour - Hand_minute;
		else Angle_between = Hand_minute - Hand_hour;

		if (Angle_between>180) Angle_between = 360 - Angle_between;
		printf ("%.3f\n",Angle_between);
	}
	return 0;
}

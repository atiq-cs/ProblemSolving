/*Problem 10432 Polygon inside a circle
		Author S. L,
		007.exe@gmail.com
*/

#include<stdio.h>
#include<math.h>

main () {
	double r,n,area;
	const double PI2 = 4 * acos (0);			/*Determining value of 2 * PI using cos*/
	/*printf("%lf",acos(0));*/
	while(scanf("%lf %lf",&r,&n)!=EOF) {
		area = n * r * r * sin (PI2 / n) / 2;		/*The area of triangle is: 1/2 ab sinC and all math functions use radian values*/
		printf("%.3lf\n",area);
	}
	return 0;
}

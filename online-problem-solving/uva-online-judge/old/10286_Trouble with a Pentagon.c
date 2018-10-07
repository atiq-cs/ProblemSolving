/*
  Problem Name: Trouble with a Pentagon
  Algorithm      : Geometry
*/

#include <math.h>
#include <stdio.h>

void main ()
{
    long double p,s;

    while ( scanf ( "%Lf" , &p ) != EOF )
    {
       s=(p*sin(3.141592654*108/180))/sin(3.141592654*63/180);
       printf ( "%.10Lf\n",s) ;
    }
}
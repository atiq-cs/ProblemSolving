/***************************************************************************
* Title : Aggregation
* URL   : hackerrank.com/domains/sql?filters%5Bsubdomains%5D%5B%5D=aggregation
* Date  : 2017-09
* Author: Atiq Rahman
* Status: Accepted
* Notes : MS SQL
* meta  : tag-database-sql
***************************************************************************/
/* 01 revising-aggregations-the-count-function
 * Query a count of the number of cities in CITY having a Population larger
 * than 100,000. */
Select Count(*) from City
Where Population > 100000;

/* 02 revising-aggregations-sum
 * Query a count of the number of cities in CITY having a Population larger
 * than 100,000. */
Select Sum(Population) From City
Where District='California';

/* 03 revising-aggregations-the-average-function Revising Aggregations Averages
 * Query the average population of all cities in CITY where District is
 * California. */
Select Avg(Population) from City
Where District='California';

/* 04 average-population Average Population */
Select FLOOR(avg(Population))
From City;

/* 05 japan-population - Total Population of Japan */
Select sum(Population) From City
Where CountryCode='JPN';

/* 06 population-density-difference Population Density Difference */
Select max(Population)-min(Population) From City;

/* 07 the-blunder
The Blunder - 7th Problem in Aggregation
Notes:
  In step 1, we perform a simple query
  Select avg(Salary)
  from Employees;

  Step 2, I figure out how to use a temporary table to query and run an example
  function 'foo' on it
  With Employee_Numeric As (
      Select CONVERT(varchar, Salary) as mSalary
      from Employees
  )
  Select foo(mSalary)
  from Employee_Numeric;

  Step 3, I figure out how to remove all 0s from the string
  With Employee_Numeric As (
      Select CONVERT(varchar, Salary) as mSalary
      from Employees
  )
  Select avg(REPLACE(mSalary, '0', '')
  from Employee_Numeric;

  Step 4, I find difference of averages in integer
  final
  With Employee_Numeric As (
      Select CONVERT(varchar, Salary) as mSalary, Salary as oSalary
      from Employees
  )
  Select avg(oSalary) - avg(CONVERT(int, REPLACE(mSalary, '0', '')))
  from Employee_Numeric;

  Then I realize problem is asking for a ceiling and to make the ceiling to
  work I have to fist cast those as float in the temporary table, and second
  convert back to int after ceiling on the result. Finally, here it is,

  More computations draft below.
*/
With Employee_Numeric As (
    Select CONVERT(varchar,Salary) as mSalary, CAST(Salary AS FLOAT) as oSalary
    from Employees
)
Select CONVERT(int,CEILING(avg(oSalary) - avg(CONVERT(FLOAT,
REPLACE(mSalary, '0', ''))))) from Employee_Numeric;

/* 08 earnings-of-employees Top Earners
 * The challenge: putting these two side by side cannot put earnings and count
 * ( * ) together
 * However, luckily 2 aggregate functions are allowed side by side */
With Employee_Accumulated As (
    Select employee_id, salary * months as earnings
    from Employee
)
Select Max(earnings), count(*)
from Employee_Accumulated
Where earnings = (Select Max(earnings) from Employee_Accumulated);

/* 09 weather-observation-station-2 Weather Observation Station 2
 * Query the following two values from the STATION table:
  - The sum of all values in LAT_N rounded to a scale of 2 decimal places.
  - Similarly, LONG_W rounded to a scale of 2 decimal places. */
Select CONVERT(DECIMAL(10,2), sum(LAT_N)), CONVERT(DECIMAL(10,2), sum(LONG_W))
From STATION;

/* 10 weather-observation-station-13 Weather Observation Station 13
 * Query the sum of Northern Latitudes (LAT_N) from STATION having values
 * greater than 38.7780 and less than 137.2345. Truncate your answer to 4
 * decimal places. */
Select CONVERT(DECIMAL(10,4), sum(LAT_N)) From STATION
Where LAT_N > 38.7880 AND LAT_N < 137.2345;

/* 11 weather-observation-station-14 Weather Observation Station 14
 * Query the greatest value of Northern Latitudes (LAT_N) from STATION that is
 * less than 137.2345. Truncate to 4 decimal places. */
Select CONVERT(DECIMAL(10,4), max(LAT_N)) From STATION
Where LAT_N < 137.2345;

/* 12 weather-observation-station-15 Weather Observation Station 15
 * Query the Western Longitude (LONG_W) for the largest Northern Latitudes
 * (LAT_N) in STATION that is less than 137.2345. Round to 4 decimal places.
 */
Select CONVERT(DECIMAL(10,4), LONG_W) FROM STATION
WHERE LAT_N IN (
    Select max(LAT_N) From STATION
    Where LAT_N < 137.2345
);

/* 13 weather-observation-station-16 Weather Observation Station 16
 * Query the smallest Northern Latitudes (LAT_N) from STATION that is greater
 * than 38.7780. Round to 4 decimal places. */
Select CONVERT(DECIMAL(10,4), min(LAT_N))
From STATION Where LAT_N > 38.7780;

/* 14 weather-observation-station-17 Weather Observation Station 17
 * Query the Western Longitude(LONG_W) where the smallest Northern Latitudes
 * (LAT_N) from STATION that is greater than 38.7780. Round to 4 decimal places.
 */
Select CONVERT(DECIMAL(10,4), LONG_W)
FROM STATION WHERE LAT_N IN (
    Select min(LAT_N) From STATION
    Where LAT_N > 38.7780
);

/* 15 weather-observation-station-18 Weather Observation Station 18
 * Consider P1(a,b) and P2(c,d) to be two points on a 2D plane.
 - a happens to equal the minimum value in Northern Latitude (LAT_N in STATION).
 - b happens to equal the minimum value in Western Longitude (LONG_W in STATION).
 - c happens to equal the maximum value in Northern Latitude (LAT_N in STATION).
 - d happens to equal the maximum value in Western Longitude (LONG_W in STATION).
 * Query the Manhattan Distance between points P1 and P2 and round it to a scale
 * of 4 decimal places.
 * manhattan ref: https://math.stackexchange.com/q/139600 */
Select CONVERT(DECIMAL(10,4), ABS(Min(LAT_N)-Min(LONG_W))+
 ABS(Max(LAT_N)-Max(LONG_W))) From STATION;

/* 16 weather-observation-station-19 Weather Observation Station 19
 * Consider P1(a,c) and P2(b,d) to be two points on a 2D plane where (a,b) are
 * the respective minimum and maximum values of Northern Latitude (LAT_N) and
 * (c,d) are the respective minimum and maximum values of Western Longitude
 * (LONG_W) in STATION.
 * Query the Euclidean Distance between points P1 and P2. Round answer to
 * display 4 decimal digits. For euclidean, see same ref above */
Select CONVERT(DECIMAL(10,4), SQRT((Min(LAT_N)-Min(LONG_W))*(Min(LAT_N)-
 Min(LONG_W))+(Max(LAT_N)-Max(LONG_W))*(Max(LAT_N)-Max(LONG_W))))
 From STATION;

/* 17 weather-observation-station-20 Weather Observation Station 20
 * A median is defined as a number separating the higher half of a data set
 * from the lower half. Query the median of the Northern Latitudes (LAT_N) from
 * STATION. Round answer to display 4 decimal digits. */
SELECT
CONVERT(DECIMAL(10, 4), (
 (SELECT MAX(LAT_N) FROM
   (SELECT TOP 50 PERCENT LAT_N FROM STATION ORDER BY LAT_N) AS BottomHalf)
 +
 (SELECT MIN(LAT_N) FROM
   (SELECT TOP 50 PERCENT LAT_N FROM STATION ORDER BY LAT_N DESC) AS TopHalf)
) / 2) AS Median;


/* 07 the-blunder draft here,
The Blunder - 7th Problem in Aggregation
Draft computation texts,
2340 
1198 
9009 
2341 
9990 
8011 
2341 
2342 
2343 
2344 
2345 
2346 
2347 
2348 
2349 
9087 
7777 
5500 
2570 
2007 

2340+1198+9009+2341+9990+8011+2341+2342+2343+2344+2345+2346+2347+2348+2349+9087
+7777+5500+2570+2007=80935

76888.25

234 
1198 
99 
2341 
999 
811 
2341 
2342 
2343 
2344 
2345 
2346 
2347 
2348 
2349 
987 
7777 
55 
257 
27 

234 +1198 +99 +2341 +999 +811 +2341 +2342 +2343 +2344 +2345 +2346 +2347 +2348
+2349 +987 +7777 +55 +257 +27 = 35890

1794.5
*/

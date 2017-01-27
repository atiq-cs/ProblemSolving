/***************************************************************************
* Problem Name: Aggregation
* Problem URL : https://www.hackerrank.com/domains/sql/aggregation/
* Author      : Atiq Rahman
* Status      : Accepted
* Desc        : 
* Notes       : All sql solutions from the sub-cateogry select are here
* meta        : tag-sql
***************************************************************************/

/* Revising Aggregations - The Count Function */
Select Count(*)
from City
Where Population > 100000;

/* Revising Aggregations - The Sum Function */
Select Sum(Population)
From City
Where District='California';

/* Revising Aggregations - Averages */
Select Avg(Population)
from City
Where District='California';

/* Average Population */
Select FLOOR(avg(Population))
From City;

/* Total Population of Japan */
Select sum(Population)
From City
Where CountryCode='JPN';

/* Population Density Difference */
Select max(Population)-min(Population)
From City;

/* The Blunder

Notes:
  In step 1, we perform a simple query
  Select avg(Salary)
  from Employees;

  Step 2, I figure out how to use a temporary table to query and run an example function 'foo' on it
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
*/

With Employee_Numeric As (
    Select CONVERT(varchar, Salary) as mSalary, CAST(Salary AS FLOAT) as oSalary
    from Employees
)
Select CONVERT(int,CEILING(avg(oSalary) - avg(CONVERT(FLOAT, REPLACE(mSalary, '0', '')))))
from Employee_Numeric;

/* Top Earners
  The challenge: putting these two side by side
  cannot put earnings and count ( * ) together
  However, luckily 2 aggregate functions are allowed side by side
*/
With Employee_Accumulated As (
    Select employee_id, salary * months as earnings
    from Employee
)
Select Max(earnings), count(*)
from Employee_Accumulated
Where earnings = (Select Max(earnings) from Employee_Accumulated);

/* Weather Observation Station 2 */
Select CONVERT(DECIMAL(10,2), sum(LAT_N)), CONVERT(DECIMAL(10,2), sum(LONG_W))
From STATION;

/* Weather Observation Station 13 */
Select CONVERT(DECIMAL(10,4), sum(LAT_N))
From STATION
Where LAT_N > 38.7880 AND LAT_N < 137.2345;

/* Weather Observation Station 14 */
Select CONVERT(DECIMAL(10,4), max(LAT_N))
From STATION
Where LAT_N < 137.2345;

/* Weather Observation Station 15 */
Select CONVERT(DECIMAL(10,4), LONG_W)
FROM STATION
WHERE LAT_N IN
(
    Select max(LAT_N)
    From STATION
    Where LAT_N < 137.2345
);

/* Weather Observation Station 16 */
Select CONVERT(DECIMAL(10,4), min(LAT_N))
From STATION
Where LAT_N > 38.7780;

/* Weather Observation Station 17 */
Select CONVERT(DECIMAL(10,4), LONG_W)
FROM STATION
WHERE LAT_N IN
(
    Select min(LAT_N)
    From STATION
    Where LAT_N > 38.7780
);

/* Weather Observation Station 18 */
Select CONVERT(DECIMAL(10,4), ABS(Min(LAT_N)-Min(LONG_W))+ABS(Max(LAT_N)-Max(LONG_W)))
From STATION;

/* Weather Observation Station 19 */
Select CONVERT(DECIMAL(10,4), SQRT((Min(LAT_N)-Min(LONG_W))*(Min(LAT_N)-Min(LONG_W))+(Max(LAT_N)-Max(LONG_W))*(Max(LAT_N)-Max(LONG_W))))
From STATION;

/* Weather Observation Station 20 */
SELECT
CONVERT(DECIMAL(10, 4), (
 (SELECT MAX(LAT_N) FROM
   (SELECT TOP 50 PERCENT LAT_N FROM STATION ORDER BY LAT_N) AS BottomHalf)
 +
 (SELECT MIN(LAT_N) FROM
   (SELECT TOP 50 PERCENT LAT_N FROM STATION ORDER BY LAT_N DESC) AS TopHalf)
) / 2) AS Median;

/***************************************************************************
* Problem Name: Basic Select
* Problem URL : https://www.hackerrank.com/domains/sql/select
* Author      : Atiq Rahman
* Status      : Accepted
* Desc        : 
* Notes       : All sql solutions from the sub-cateogry select are here
* meta        : tag-sql
***************************************************************************/

/* Revising the Select Query - 1 */
/* Query all columns for all American cities in CITY with populations larger than 100,000. The CountryCode for America is USA. */
Select *
from City
Where CountryCode='USA' and Population > 100000;

/* Revising the Select Query - 2 */
/* Query the names of all American cities in CITY with populations larger than 120,000. The CountryCode for America is USA. */
Select Name
from City
Where CountryCode='USA' and Population > 120000;

/* Select All */
/* Query all columns for every row in the CITY table */
select * from City;

/* Select by ID */
/* Query all columns for a city in CITY with the ID 1661. */
Select * from City
Where ID=1661;

/* Japanese Cities Detail */
/* Query the details for all the Japanese cities in CITY. The COUNTRYCODE for Japan is JPN. */
Select * from City
Where CountryCode='JPN';

/* Japanese Cities Name */
/* Query the the names of all the Japanese cities in CITY. The COUNTRYCODE for Japan is JPN. */
Select Name from City
Where CountryCode='JPN';

/* Weather Observation Station 1 */
/* Query a list of CITY and STATE from STATION. */
Select CITY, STATE
From STATION
Order By CITY, STATE;

/* Weather Observation Station 3 */
/* Query a list of CITY names from STATION with even ID numbers only. You may
print the results in any order, but must exclude duplicates from your answer. */
Select distinct CITY
From STATION
Where ID % 2 = 0
Order by CITY;

/* Weather Observation Station 4 */
/* Let NUM be the number of CITY entries in STATION, and NUMunique be the number
of unique cities. Query the value of NUM-NUMunique from STATION.

In other words, query the number of non-unique CITY names in STATION by
subtracting the number of unique CITY entries in the table from the total
number of CITY entries in the table. */
Select Count(CITY)-Count(distinct CITY)
From STATION;

/* Weather Observation Station 5 */
/* Query the two cities in STATION with the shortest and longest CITY names,
as well as their respective lengths (i.e.: number of characters in the name).
If there is more than one smallest or largest city, choose the one that comes
first when ordered alphabetically. */
SELECT TOP(1) CITY, LEN(CITY)
FROM STATION
WHERE LEN(CITY) IN (
    Select min(len_City)
    FROM (
        Select LEN(CITY) as len_city
        FROM STATION
    ) as LEN_CITY
)
Order By City;

SELECT CITY, LEN(CITY)
FROM STATION
WHERE LEN(CITY) IN (
Select max(len_City)
FROM (
    Select LEN(CITY) as len_city
    FROM STATION) as LEN_CITY);

/* Higher Than 75 Marks */
Select Name
from Students
Where Marks > 75
order by RIGHT(Name,3), id;

/* Employee Names */
Select name
from Employee
order by name;

/* Employee Salaries */
Select name
from Employee
where salary > 2000 AND months < 10
order by employee_id;

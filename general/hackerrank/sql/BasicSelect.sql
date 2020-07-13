/***************************************************************************
* Title : Basic Select
* URL   : hackerrank.com/domains/sql?filters%5Bsubdomains%5D%5B%5D=select
* Date  : 2017-09
* Author: Atiq Rahman
* Status: Accepted
* Notes : Most of the solutions are done in MS SQL
* meta  : tag-database-sql
***************************************************************************/
/* 01 Revising the Select Query
 * Query all columns for all American cities in CITY with populations larger
 * than 100,000. The CountryCode for America is USA. */
Select * from City
Where CountryCode='USA' and Population > 100000;

/* 02 Revising the Select Query II
 * Query the names of all American cities in CITY with populations larger than
 * 120,000. The CountryCode for America is USA. */
Select Name from City
Where CountryCode='USA' and Population > 120000;

/* 03 Select All */
/* Query all columns for every row in the CITY table */
select * from City;

/* 04 Select by ID */
/* Query all columns for a city in CITY with the ID 1661. */
Select * from City Where ID=1661;

/* 05 Japanese Cities Attributes
 * Query the details for all the Japanese cities in CITY. The COUNTRYCODE for
 * Japan is JPN. */
Select * from City Where CountryCode='JPN';

/* 06 Japanese Cities Name
 * Query the the names of all the Japanese cities in CITY. The COUNTRYCODE for
 * Japan is JPN. */
Select Name from City Where CountryCode='JPN';

/* 07 Weather Observation Station 1 */
/* Query a list of CITY and STATE from STATION. */
Select CITY, STATE From STATION
Order By CITY, STATE;

/* 08 Weather Observation Station 3 */
/* Query a list of CITY names from STATION with even ID numbers only. You may
print the results in any order, but must exclude duplicates from your answer. */
Select distinct CITY From STATION
Where ID % 2 = 0
Order by CITY;

/* 09 Weather Observation Station 4
 * Let NUM be the number of CITY entries in STATION, and NUMunique be number
 * of unique cities. Query the value of NUM-NUMunique from STATION.

 * In other words, query the number of non-unique CITY names in STATION by
 * subtracting the number of unique CITY entries in the table from the total
 * number of CITY entries in the table. */
Select Count(CITY)-Count(distinct CITY)
From STATION;

/* 10 Weather Observation Station 5
 * Query the two cities in STATION with the shortest and longest CITY names,
 * as well as their respective lengths (i.e, number of characters in the name).
 * If there is more than one smallest or largest city, choose the one that comes
 * first when ordered alphabetically. */
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

/* 11 Weather Observation Station 6
 * Query the list of CITY names starting with vowels (i.e., a, e, i, o, or u)
 * from STATION. Result cannot contain duplicates. */
Select CITY From STATION
WHERE CITY like 'a%' OR CITY like 'e%' OR CITY like 'i%' OR CITY like 'o%' OR
CITY like 'u%';

/* 12 Weather Observation Station 7
 * Same as previous Query: however, now match names ending with vowels
 * (i.e., a, e, i, o, or u). */
Select distinct CITY From STATION
WHERE CITY like '%a' OR CITY like '%e' OR CITY like '%i' OR CITY like '%o' OR
CITY like '%u';

/* 13 Weather Observation Station 8
 * Query the list of CITY names from STATION which have vowels
 * (i.e., a, e, i, o, and u) as both their first and last characters. Result
 * cannot contain duplicates. */
Select distinct CITY FROM STATION
Where CITY IN (
    Select CITY From STATION
    WHERE CITY like '%a' OR CITY like '%e' OR CITY like '%i' OR CITY like '%o'
    OR CITY like '%u'
) AND CITY IN (
    Select CITY From STATION
    WHERE CITY like 'a%' OR CITY like 'e%' OR CITY like 'i%' OR CITY like 'o%'
    OR CITY like 'u%'
)
Order By CITY;

/* 14 Weather Observation Station 9
 * Query the list of CITY names from STATION that do not start with vowels.
 * Result cannot contain duplicates. */
Select distinct CITY FROM STATION
Where CITY NOT IN (
    Select CITY
    From STATION
    WHERE CITY like 'a%' OR CITY like 'e%' OR CITY like 'i%' OR CITY like 'o%'
    OR CITY like 'u%'
) Order By CITY;

/* 15 Weather Observation Station 10
 * Query the list of CITY names from STATION that do not end with vowels.
 * Result cannot contain duplicates. */
Select distinct CITY FROM STATION
Where CITY NOT IN (
    Select CITY From STATION
    WHERE CITY like '%a' OR CITY like '%e' OR CITY like '%i' OR CITY like '%o'
    OR CITY like '%u'
) Order By CITY;

/* 16 Weather Observation Station 11
 * Query the list of CITY names from STATION that either do not start with
 * vowels or do not end with vowels. Result cannot contain duplicates. */
Select distinct CITY FROM STATION
Where CITY NOT IN (
    Select CITY From STATION
    WHERE CITY like '%a' OR CITY like '%e' OR CITY like '%i' OR CITY like '%o'
    OR CITY like '%u'
) OR CITY NOT IN (
    Select CITY From STATION
    WHERE CITY like 'a%' OR CITY like 'e%' OR CITY like 'i%' OR CITY like 'o%'
    OR CITY like 'u%'
) Order By CITY;

/* 17 Weather Observation Station 11
 * Query the list of CITY names from STATION that do not start with vowels and
 * do not end with vowels. Result cannot contain duplicates. */
Select distinct CITY FROM STATION
Where CITY NOT IN (
    Select CITY From STATION
    WHERE CITY like '%a' OR CITY like '%e' OR CITY like '%i' OR CITY like '%o'
    OR CITY like '%u'
) AND CITY NOT IN (
    Select CITY From STATION
    WHERE CITY like 'a%' OR CITY like 'e%' OR CITY like 'i%' OR CITY like 'o%'
    OR CITY like 'u%'
) Order By CITY;

/* 18 Higher Than 75 Marks
 * Query the Name of any student in STUDENTS who scored higher than 75 Marks.*/
Select Name from Students
Where Marks > 75
order by RIGHT(Name,3), id;

/* 19 Employee Names
 * Query that prints a list of employee names (i.e.: the name attribute) from
 * the Employee table in alphabetical order.*/
Select name from Employee order by name;

/* 20 Employee Salaries
 * Query that prints a list of employee names (i.e.: the name attribute) for
 * employees in Employee having a salary greater than $2000 per month who have
 * been employees for less than 10 months. Sort your result by ascending
 * employee_id.*/
Select name from Employee
where salary > 2000 AND months < 10
order by employee_id;

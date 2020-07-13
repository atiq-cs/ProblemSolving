/***************************************************************************
* Title : Basic Join
* URL   : hackerrank.com/domains/sql?filters%5Bsubdomains%5D%5B%5D=join
* Date  : 2017-09
* Status: Accepted
* Notes : MS SQL, 3 easy solved, 4 medium to go
* meta  : tag-database-sql
***************************************************************************/
/* 01 asian-population
 * Given the CITY and COUNTRY tables, query the sum of the populations of all
cities where the CONTINENT is 'Asia'. */
Select sum(Population)
From City
Where CountryCode IN (
  Select CountryCode
  From City, Country
  Where City.CountryCode=Country.Code AND Continent='Asia'
);

/* 02 african-cities
 * Given the CITY and COUNTRY tables, query the names of all cities where the
CONTINENT is 'Africa'. */
Select Name
From City
Where CountryCode IN (
  Select CountryCode
  From City, Country
  Where City.CountryCode=Country.Code AND Continent='Africa'
);

/* 03 average-population-of-each-continent
 * Given the CITY and COUNTRY tables, query the names of all the continents
(COUNTRY.Continent) and their respective average city populations
(CITY.Population) rounded down to the nearest integer. */
Select Continent, FLOOR(avg(City.Population))
From City, Country
Where City.CountryCode=Country.Code
Group By Continent;

Select hacker_id, name
from Hackers
WHERE hacker_id IN (
  Select hacker_id
  from Challenges, Submissions, Difficulty
  WHERE Challenges.challenge_id=Submissions.challenge_id AND Difficulty.
    difficulty_level=Challenges.difficulty_level AND Challenges.Score=
    Submissions.Score
);

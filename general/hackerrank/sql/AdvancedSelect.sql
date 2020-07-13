/***************************************************************************
* Title : Advanced Select
* URL   : hckrrnk.com/domains/sql?filters%5Bsubdomains%5D%5B%5D=advanced-select
* Date  : 2018-06
* Author: Atiq Rahman
* Status: Accepted
* Notes : MS SQL, 1 solved, 3 more to go
* meta  : tag-database-sql
***************************************************************************/
/* 01 the-pads
 * first part: an alphabetically ordered list of all names in OCCUPATIONS,
 * immediately followed by the first letter of each profession as a
 * parenthetical
 * second part: Query the number of ocurrences of each occupation in
 * OCCUPATIONS. Sort the occurrences in ascending order. */
Select CONCAT(Name, '(', LEFT(Occupation,1), ')')
from OCCUPATIONS Order By Name;

With OccupTable As (
  Select Count(*) as NumOccup, Occupation as mOccupation
  from OCCUPATIONS
  Group By Occupation)
Select CONCAT('There are a total of ', NumOccup, ' ', LOWER(mOccupation), 's.')
From OccupTable Order By NumOccup, mOccupation;

/***************************************************************************
* Title : Leetcode easy database problems
* URL   : https://leetcode.com/problemset/database/
* Date  : 2019-02-14
* Status: Accepted
* Notes : MS SQL, T-SQL
* meta  : tag-database-sql
***************************************************************************/
/* 183 Customers Who Never Order
 * https://leetcode.com/problems/customers-who-never-order/
 * Suppose that a website contains two tables, the Customers table and the Orders table. Write a
 * SQL query to find all customers who never order anything.
 */
Select Name as Customers
from Customers
where Id NOT IN (
  Select Customers.Id
  from Customers join Orders on Customers.Id = CustomerId
);


/* 175 Combine Two Tables
 * https://leetcode.com/problems/combine-two-tables
 * Even if address entries are null for a particular PersonId include them
 * This is a very nice problem to practice outer join
 */
Select FirstName, LastName, City, State
from Person left outer join Address
ON Person.PersonId = Address.PersonId;

/* This can also be written as */
Select FirstName, LastName, City, State
from Person a left outer join Address b
ON a.PersonId = b.PersonId;

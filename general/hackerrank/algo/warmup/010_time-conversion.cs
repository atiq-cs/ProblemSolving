/***************************************************************************************************
* Title : Time Conversion
* URL   : https://www.hackerrank.com/challenges/time-conversion
* Date  : 2015-09-12
* Notes : Power of DateTime class *, use of time formatting
* Author: Atiq Rahman
* Status: Accepted
* meta  : tag-easy
***************************************************************************************************/
using System;

class HKSolution
{
  static void Main(String[] args) {
    DateTime standard_time = DateTime.Parse(Console.ReadLine());
    Console.WriteLine(standard_time.ToString("HH:mm:ss"));
  }
}

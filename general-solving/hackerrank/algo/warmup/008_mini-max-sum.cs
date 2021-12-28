/***************************************************************************
* Title       : Mini-Max Sum
* URL         : https://www.hackerrank.com/challenges/mini-max-sum
* Date        : Dec 20, 2016
* Domain      : algorithms/implementation
* Complexity  : O(n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Find sum, then min max
*               5 numbers 5 * 10 ^ 9 that exceeds int limit 2147483648
*               it should even excced unsigned int limit 4294967296
*               but it did not with maximum     total of 5000000000
*               I guess input/output is not critical in this problem
* 
* meta        : tag-easy
***************************************************************************/
using System;

class HK_Solution {
  static void Main(String[] args) {
    string[] arr_temp = Console.ReadLine().Split(' ');
    uint[] a = Array.ConvertAll(arr_temp, uint.Parse);
   
    uint sum = 0;
    for (int i=0; i<5; i++)
      sum += a[i];
    uint max_sum = 0;
    uint min_sum = sum;
    for (int i=0; i<5; i++) {
      if (sum-a[i] > max_sum)
        max_sum = sum-a[i];
      if (sum-a[i] < min_sum)
        min_sum = sum-a[i];
    }
    Console.WriteLine(min_sum + " " + max_sum);
  }
}

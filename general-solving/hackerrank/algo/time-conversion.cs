/***************************************************************************
*   Problem Name:   Time Conversion
*   Problem URL :   https://www.hackerrank.com/challenges/time-conversion
*   Date        :   Sept 12, 2015
*
*   Domain      :   algorithms/warmup
*   Desc        :   Power of DateTime class *
*   Complexity  :   
*   Author      :   Atiq Rahman
*   Status      :   Accepted
***************************************************************************/

using System;

class Solution
{
    static void Main(String[] args)
    {
        DateTime standard_time = DateTime.Parse(Console.ReadLine());
        Console.WriteLine(standard_time.ToString("HH:mm:ss"));
    }
}

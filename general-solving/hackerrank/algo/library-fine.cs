/***************************************************************************
*   Problem Name:   Library Fine
*   Problem URL :   https://www.hackerrank.com/challenges/library-fine
*   Date        :   Sept 8, 2015
*
*   Domain      :   algorithms/warmup
*   Desc        :   Trivial Problem
*   Complexity  :   
*   Author      :   Atiq Rahman
*   Status      :   Accepted
***************************************************************************/

using System;
using System.Collections.Generic;

struct LibraryDate
{
    public int day;
    public int month;
    public int year;
}

class Solution
{
    static void Main(String[] args)
    {
        LibraryDate actual_return_date = new LibraryDate();
        string[] tokens = Console.ReadLine().Split();
        actual_return_date.day = int.Parse(tokens[0]);
        actual_return_date.month = int.Parse(tokens[1]);
        actual_return_date.year = int.Parse(tokens[2]);

        LibraryDate expected_return_date = new LibraryDate();
        tokens = Console.ReadLine().Split();
        expected_return_date.day = int.Parse(tokens[0]);
        expected_return_date.month = int.Parse(tokens[1]);
        expected_return_date.year = int.Parse(tokens[2]);

        Console.WriteLine(GetFineAmount(actual_return_date, expected_return_date));
    }
    static int GetFineAmount(LibraryDate actual, LibraryDate expected)
    {
        if (actual.year > expected.year)
            return 10000;
        // critical case 1
        if (actual.year < expected.year)
            return 0;

        if (actual.month > expected.month)
            return (actual.month - expected.month) * 500;
        // critical case
        if (actual.month < expected.month)
            return 0;

        if (actual.day > expected.day)
            return (actual.day - expected.day) * 15;
        return 0;
    }
}

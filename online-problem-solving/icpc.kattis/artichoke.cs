/***************************************************************************
*  Problem Name: Amalgamated Artichokes
*  Problem URL : https://icpc.kattis.com/problems/artichoke
*  source      : 2015 ACM-ICPC World Finals - Marrakech
*  Date        : Oct 13, 2015
*
*  Complexity  : O(n)
*  Author      : Atiq Rahman
*  Status      : Accepted
*  Notes       : It didn't require any fixed point formatting
*                 Similar to leetcode's 'best-time-to-buy-and-sell-stock'
*  meta        : tag-algo-dp, tag-world-final, tag-easy, tag-judge-kattis
***************************************************************************/
using System;

public class Solution
{
    private static void Main() {
        // Take input: 6 int
        string[] tokens = Console.ReadLine().Split();
        double p = double.Parse(tokens[0]);
        double a = double.Parse(tokens[1]);
        double b = double.Parse(tokens[2]);
        double c = double.Parse(tokens[3]);
        double d = double.Parse(tokens[4]);
        int n = int.Parse(tokens[5]);

        double previousPrice = p * (Math.Sin(a * 1 + b) + Math.Cos(c * 1 + d) + 2.0);
        double maxPrice = previousPrice;
        double maxDiff = 0.0;
        // get price for each value of k and take maximum diff
        for (int k = 2; k <= n; k++) {
            double price = p * (Math.Sin(a * k + b) + Math.Cos(c * k + d) + 2.0);
            maxPrice = Math.Max(maxPrice, previousPrice);   // max is the max till current item
            double curDiff = maxPrice - price;              // get diff with max
            maxDiff = Math.Max(maxDiff, curDiff);
            previousPrice = price;
        }
        Console.WriteLine(maxDiff);
    }
}

/*
Drafts: consider example,
3 5 90 4 7

at 5
  max = 3, min = 5
  cur diff = -2, 3-5
  max diff = -2
 
at 90
  max = 5, min = 90
  cur diff = -85, 5-90
  max diff = -2
 
at 4
  max = 90, min = 4
  cur diff = 86, 90-4
  max diff = 86
 
at 7
  max = 90, min = 7
  cur diff = 83, 90-7
  max diff = 86 
*/

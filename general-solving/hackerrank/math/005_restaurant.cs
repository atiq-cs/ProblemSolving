/***************************************************************************
* Problem Name: Restaurant
* Problem URL : https://www.hackerrank.com/challenges/restaurant
* Domain      : Mathematics/Fundamentals
* Date        : Jan 15 2016
* Complexity  : O(logb)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : gcd is the length of largest square possible without leftover
*               piece
* meta        : tag-math
***************************************************************************/
using System;

class Solution {
    static void Main(String[] args) {
        int T = int.Parse(Console.ReadLine());
        while (T-- > 0) {
            string[] tokens = Console.ReadLine().Split();
            long l = long.Parse(tokens[0]);
            long b = long.Parse(tokens[1]);
            long max_dim = gcd(b,l);
            Console.WriteLine(b*l/(max_dim * max_dim));
        }
    }

    /* Borrowed from general-solving/hackerrank/math/004_possible-path.cs
      Critical case for this function when a = 0 or b=0 or less therefore just
      avoiding them for now */
    static long gcd(long a, long b) {
        
        if (a==0)
            return b;
        if (a<1 || b<1)
            return -1;
        return gcd(b%a, a);
    }
}

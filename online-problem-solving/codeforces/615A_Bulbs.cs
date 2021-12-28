/***************************************************************************
*   Problem Name: Bulbs
*   Problem URL : http://codeforces.com/contest/615/problem/0
*   Date        : Jan 8 
*   Occasion    : Codeforces Round #338 (Div. 2)
*   Complexity  : O(N)
*   Author      : Atiq Rahman
*   Status      : Accepted
*   Notes       : Check if all bulbs can be turned on
*   meta        : tag-hashtable
***************************************************************************/
using System;

public class Demo {
    public static void Main() {
        string[] tokens = Console.ReadLine().Split();
        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);
        bool[] bulbs = new bool[m];
        int i = 0;
        for (; i < n; i++) {
            tokens = Console.ReadLine().Split();
            int nItems = int.Parse(tokens[0]);

            for (int j = 1; j <= nItems; j++) {
                int nb = int.Parse(tokens[j]);
                bulbs[nb - 1] = true;
            }
        }

        for (i=0; i < m; i++)
            if (bulbs[i] == false)
                break;
        if (i == m)
            Console.WriteLine("YES");
        else
            Console.WriteLine("NO");
    }
}

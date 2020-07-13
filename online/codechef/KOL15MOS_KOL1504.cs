/***************************************************************************
* Problem Name: The making of a cake
* Problem URL : https://www.codechef.com/KOL15MOS/problems/KOL1504
* Occasion    : ACM-ICPC Asia-Kolkata Onsite Mirror Contest 2015 
* Date        : Dec 26 2015
* Complexity  : O(n) Time and O(n) Space
* Author      : Atiq Rahman
* Status      : Accepted
* Desc        :  
* Notes       : Requires O(n) for reading items, algorithm requires O(1) after posa and
*                 fa have been processed.
*
* meta        : tag-anagram
***************************************************************************/

using System;
using System.Collections.Generic;

public class Test {
    public static void Main() {
        int T = int.Parse(Console.ReadLine());
        while (T-- > 0)
        {
            string[] tokens = Console.ReadLine().Split();
            int N = int.Parse(tokens[0]);
            int D = int.Parse(tokens[1]);
            string stra = Console.ReadLine();
            string strb = Console.ReadLine();

            int[] fa = new int[26];
            int[] fb = new int[26];
            int[] posa = new int[26];
            int[] posb = new int[26];

            Array.Clear(fa, 0, 26);
            Array.Clear(fb, 0, 26);
            Array.Clear(posa, 0, 26);
            Array.Clear(posb, 0, 26);

            int i = 0;
            foreach (char ch in stra)
            {
                if (ch == ' ')
                    continue;
                fa[ch - 'a']++;
                posa[ch - 'a'] += i;
                i++;
            }
            i = 0;
            foreach (char ch in strb)
            {
                if (ch == ' ')
                    continue;
                fb[ch - 'a']++;
                posb[ch - 'a'] += i;
                i++;
            }

            if (swap_possible_freq(fa, fb) && swap_possible_dist(posa, posb, D))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }

    // check if frequency of letters match
    static bool swap_possible_freq(int[] a, int[] b)
    {
        for (int i = 0; i < 26; i++)
            if (a[i] != b[i])
                return false;
        return true;
    }

    // check if distance is reasonable for swap
    static bool swap_possible_dist(int[] a, int[] b, int dist)
    {
        for (int i = 0; i < 26; i++)
            if (Math.Abs(a[i] - b[i]) % dist != 0)
                return false;
        return true;
    }
}

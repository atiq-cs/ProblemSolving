/***************************************************************************
* Problem Name: Chota Mouse and his birthday cake
* Problem URL : https://www.codechef.com/AMR15MOS/problems/AMBDAY
* Occasion    : ACM-ICPC Asia-Amritapuri Onsite Mirror Contest 2015
* Date        : Dec 21 2015
* Complexity  : O(nlong) Time and O(n) Space
* Author      : Atiq Rahman
* Status      : Accepted
* Desc        :  
* Notes       : What does the problem Ask?
*               Unsorted cut positions are given, can we find minimum area created by the cuts?
*
* meta        : tag-math, tag-algo-sort
***************************************************************************/

using System;

public class Test {
    public static void Main() {
        int T = int.Parse(Console.ReadLine());
        while (T-- > 0)
        {
            string[] tokens = Console.ReadLine().Split();
            int N = int.Parse(tokens[0]);
            int H = int.Parse(tokens[1]);
            int W = int.Parse(tokens[2]);

            int[] P = new int[N + 2];
            tokens = Console.ReadLine().Split();
            P[0] = 0;
            for (int i = 1; i < N + 1; i++)
                P[i] = int.Parse(tokens[i - 1]);
            P[N + 1] = W;
            Array.Sort(P);

            int minArea = -1;
            for (int i = 1; i < N + 2; i++) {
                int area = (P[i] - P[i - 1]) * H;
                minArea = minArea == -1 ? area : Math.Min(area, minArea);
            }
            Console.WriteLine(minArea);
        }
    }
}

/***************************************************************************
*   Problem Name:   Staircase
*   Problem URL :   https://www.hackerrank.com/challenges/staircase
*   Date        :   Dec 2015
*   Domain      :   algorithms/warmup
*   Desc        :   Loop
*   Complexity  :   
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Notes       :   
*   meta        :   tag-easy
***************************************************************************/
using System;
using System.Collections.Generic;

class HK_Solution {
    static void Main(String[] args) {
        int n = int.Parse(Console.ReadLine());
        
        for (int i=1; i<=n; i++) {
            for (int j=n-i; j>0; j--)
                Console.Write(" ");
            for (int j=1; j<=i; j++)
                Console.Write("#");
            Console.WriteLine();
        }
    }
}

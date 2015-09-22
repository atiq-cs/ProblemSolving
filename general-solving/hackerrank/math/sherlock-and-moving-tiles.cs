/*
*	Problem Name:	sherlock-and-moving-tiles
*	Problem No	:	https://www.hackerrank.com/challenges/sherlock-and-moving-tiles
*   Domain      :   Mathematics/Fundamentals
*	Problem Type:	Basic Math
*	Alogirthm	:   math
*	Author		:	Atiqur Rahman
*	Desc		:	Simple equation for Area
*
*	Status		:	Accepted
*   Notes       :   Equation takes care when A is max time is 0
*                    If A is 0, then it is t = L*sq(2)/Diff
*                    Had a 'Runtime Error' because judge input double has type in query inputs
*                    Also demonstrates format specified for float
*/

using System;
using System.Collections.Generic;

class Solution {
    static void Main(String[] args) {
        // Read Length, speed 1 and speed 2
        string[] tokens = Console.ReadLine().Split();
        int L = int.Parse(tokens[0]);
        int S1 = int.Parse(tokens[1]);
        int S2 = int.Parse(tokens[2]);

        // Read each query and give answer
        int Q = int.Parse(Console.ReadLine());
        for (int i = 0; i<Q; i++) {
            double A = double.Parse(Console.ReadLine());
            double diff = (double)Math.Abs(S2 - S1);
            double t = Math.Sqrt(2) * (L - Math.Sqrt(A)) / diff;
            Console.WriteLine("{0:F4}", t);
        }
    }
}

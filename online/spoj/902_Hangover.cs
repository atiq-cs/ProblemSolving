/***************************************************************************
*   Problem     :  HangOver
*   URL         :  http://www.spoj.com/problems/HANGOVER/
*                   UVA 2294 (icpc problems archive)
*                   poj 1003
*   Date        :  July 27, 2015
*
*   Algo, DS    :  Simple Sum
*   Desc        :  Arithmetic
*   Complexity  :  O(1) proposed, constant time
*   Author      :  Atiq Rahman
*   Status      :  Not solved, could not stabilize the relation between log and the hangover result
*   Notes       :  This is the last tried version
*   meta        :  tag-math 
***************************************************************************/
using System;

public class Solution {
    private const double eps = 1E-16;
    private static void Main() {
        // get the constant
        // double c = 0.57721566490153286060;
        // double c = 0.57721566490153286060651209008240243104215933593992;
        // Console.WriteLine(c);
        while (true) {
            // take input to num
            double c = 1.5 + 1.0 / 3 - Math.Log(3.0) - 1.0 / 6;
            double n;
            double.TryParse(Console.ReadLine(), out n);
            double hangover_value = 0;
            for (int i = 2; i <= n + 1; i++)
                hangover_value += 1.0 / i;
            Console.WriteLine("hangover value: {0}", hangover_value);
            // take input to num
            double x;
            double.TryParse(Console.ReadLine(), out x);

            if (Math.Abs(x - 0.00) < eps)
                break;

            double c_update = c;
            double result = 0.0;
            double approx_k;
            double diff = eps + 1.0;
            while (diff > eps) {
                //approx_k = Math.Floor(Math.Exp(x + 1.0 - c_update));
                approx_k = Math.Exp(x + 1.0 - c_update);
                Console.WriteLine(approx_k);
                result = Math.Exp(x + 1.0 - c - 1.0 / (2.0 * approx_k));
                Console.WriteLine(result);
                diff = approx_k - result;
                // c -= 1.0 / (2.0 * approx_k);
                c_update = c + 1.0 / (2.0 * approx_k);
            }
            // print sum
            Console.WriteLine("result is: {0}", (result - 1.0));
        }
    }
}

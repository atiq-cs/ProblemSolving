/***************************************************************************
* Problem Name: Minimum Draws
* Problem URL : https://www.hackerrank.com/challenges/minimum-draws
* Domain      : Mathematics/Fundamentals
* Date        : Sept 14 2015
* Complexity  : O(1)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : If you take one more than half of the items
*               it is certain that 1 pair will be in the collection
*               input is given in number of pairs, n
*               output is n+1
* meta        : tag-math
***************************************************************************/

using System;

class Solution {
    static void Main(String[] args) {
        int T = int.Parse(Console.ReadLine());
        while (T-- > 0) {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(n+1);
        }
    }
}

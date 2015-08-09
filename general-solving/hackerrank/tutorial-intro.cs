/***************************************************************************
*   Problem Name:   Search for a item in a sorted array
*   Problem URL :   https://www.hackerrank.com/challenges/fibonacci-modified
*   Domain      :   algorithms/Sorting
*                   https://www.hackerrank.com/domains/algorithms/arrays-and-sorting
*   Desc        :   Binary Search Demo C#
*                   ref: https://msdn.microsoft.com/en-us/library/2cy9f6wb(v=vs.110).aspx
*
*   Complexity  :   O(log n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
***************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    static void Main(string[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int item = 0;
        /* TryParse is better than Parse for exceptions - stackoverflow */
        int.TryParse(Console.ReadLine(), out item);
        int array_size = 0;
        int.TryParse(Console.ReadLine(), out array_size);
        
        string[] tokens = Console.ReadLine().Split();
        int[] num = Array.ConvertAll(tokens, int.Parse);        

        Console.WriteLine(Array.BinarySearch(num, item));
    }
}

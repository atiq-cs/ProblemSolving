/***************************************************************************
*   Problem Name:   Simple Array Sum
*   Problem URL :   https://www.hackerrank.com/challenges/simple-array-sum
*   Date        :   Sept 07, 2015
*   Domain      :   algorithms/warmup
*   Desc        :   Find sum of given integers
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Notes       :   Practicing C# IO
*   meta        :   tag-easy
***************************************************************************/
using System;
using System.Linq;

class HK_Solution
{
    // HackerRank style C# IO
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        Console.WriteLine(arr.Sum()); // linq statement
    }
    /* The regular IO I use
    static void Main(String[] args) {
        int N = int.Parse(Console.ReadLine());

        string[] tokens = Console.ReadLine().Split();
        int sum = 0;
        for (int i = 0; i < N; i++) {
            int num = int.Parse(tokens[i]);
            sum += num;
        }
        Console.WriteLine(sum);
    }*/
}

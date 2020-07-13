/***************************************************************************
*   Problem Name:   Duronto Eagle
*   Problem Link :  http://www.spoj.com/problems/DRNTEAGL/
*   Date        :   Oct 9, 2015
*
*   Algo, DS    :   Euclidean Distance
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Notes       :   Eassy acceptance with cpp code, ref: DRNTEAGL.cpp
*                    But C# code gave Runtime Error in the judge (NZEC)
*                    This hack finally solved the problem
*
*                   This example shows how to deal with malformatted input e.g., unexpected spaces, newlines etc
*   meta        :   tag-easy
***************************************************************************/

using System;
using System.IO;

public class Test
{
    public static int tok_index;

    static int getNextNumber(string[] tokens)
    {
        while (string.IsNullOrEmpty(tokens[++tok_index]));
        return int.Parse(tokens[tok_index]);
    }

    public static void Main()
    {
        StreamReader streamReader = new StreamReader(Console.OpenStandardInput());
        string[] tokens = streamReader.ReadToEnd().Split();
        tok_index = -1;

        int T = getNextNumber(tokens);
        for (int i = 1; i <= T; i++)
        {
            int N = getNextNumber(tokens);
            double maxDistance = -1.0;
            int maxIndex = 1;
            for (int j = 1; j <= N; j++)
            {
                int x = getNextNumber(tokens);
                int y = getNextNumber(tokens);
                double distance = Math.Sqrt((double)(x * x + y * y));
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    maxIndex = j;
                }
            }
            Console.WriteLine("Case {0}: {1}", i, maxIndex);
        }
    }
}

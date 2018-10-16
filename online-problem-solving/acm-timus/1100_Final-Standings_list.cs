/***************************************************************************
*   Problem Name:   Final Standings
*   Problem URL :   http://acm.timus.ru/problem.aspx?space=1&num=1100
*   Date        :   Sept 07, 2015
*
*   Algo, DS    :   Sorting (stable)
*   Desc        :   A stable sort is equivalent to the result that bubble sort gives
*
*   Complexity  :   O(n) where n is the length of the string
*   Author      :   Atiq Rahman
*   Status      :   Accepted (Time: 0.452), Memory (9992 KB)
*   meta        :   tag-algo-sort
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

// access to structure might be faster in variable like access
// ref, http://stackoverflow.com/questions/7484735/c-struct-vs-class-faster
struct Team {
    public int id;
    public int num_solves;
}

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<Team> team_list = new List<Team>();

        Team team;

        for (int i = 0; i < N; i++) {
            string[] tokens = Console.ReadLine().Split();
            team.id = int.Parse(tokens[0]);
            team.num_solves = int.Parse(tokens[1]);

            team_list.Add(team);
        }

        IOrderedEnumerable<Team> sorted_list = team_list.OrderBy(n => n.num_solves, new SolveComparer());
        foreach (Team tm in sorted_list)
        {
            Console.WriteLine("{0} {1}", tm.id, tm.num_solves);
        }
    }

    class SolveComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}

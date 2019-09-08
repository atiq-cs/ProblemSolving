/***************************************************************************************************
* Title : Intro to Tutorial Challenges
* URL   : https://www.hackerrank.com/challenges/tutorial-intro
* Comp  : O(log n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Practicing C#, Binary Search Demo
* ref   : https://msdn.microsoft.com/en-us/library/2cy9f6wb.aspx
* rel   : https://www.hackerrank.com/domains/algorithms/arrays-and-sorting
* meta  : tag-algo-sort, tag-easy
***************************************************************************************************/
using System;

class HKSolution
{
  static void Main(string[] args) {
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

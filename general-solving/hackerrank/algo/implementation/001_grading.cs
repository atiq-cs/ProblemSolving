/***************************************************************************
* Title : Grading Students
* URL   : https://www.hackerrank.com/challenges/grading
* Date  : 2017-09-19
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Simple problem for implementation
*   Found following math functions,
*   - Math.Ceiling()
*   - Math.Round()
*   - Math.Floor()
* meta  : tag-math, tag-implementation, tag-easy
***************************************************************************/
using System;

class HKSolution
{
  static int[] solve(int[] grades){
    int[] result = new int[grades.Length];
    for (int i=0; i<grades.Length; i++) {
      int diff = Math.Abs((int)Math.Ceiling((double)grades[i]/5)*5-grades[i]);
      result[i] = (grades[i]<38 || diff>=3)?grades[i]:(int)Math.Round((double)grades[i]/5)*5;
    }
    return result;
  }

  static void Main(String[] args) {
    int n = Convert.ToInt32(Console.ReadLine());
    int[] grades = new int[n];
    for(int grades_i = 0; grades_i < n; grades_i++){
       grades[grades_i] = Convert.ToInt32(Console.ReadLine());   
    }
    int[] result = solve(grades);
    Console.WriteLine(String.Join("\n", result));
  }
}

/* Draft:
38/5 = 7

67/5 = 

67's next 70 - N
73's next 75 - yes
*/

/***************************************************************************************************
* Title : Chocolate, Problem A
* URL   : http://codecon.bloomberg.com/problemDetails/CONTEST/84/Stony%20Brook%20CodeCon/1425/2015-
*   09-18T22:45:00.000Z
* Date  : 2015-09-18
* Comp  : O(1), O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : linear trivial algo
* meta  : tag-math, tag-easy
***************************************************************************************************/
static public void Main()
{
  int N = int.Parse(Console.ReadLine());   // price of chocolate
  int M = int.Parse(Console.ReadLine());   // number of wrapers per chocolate
  int P = int.Parse(Console.ReadLine());
  while (P-- > 0)
  {
    // get chocolate count
    int Q = int.Parse(Console.ReadLine());   // amount of money
                        // buy chocolate once
    int sumChocolates = Q / N;
    int sumWrappers = sumChocolates;

    while (sumWrappers >= M)
    {
      int newNumChocolates = sumWrappers / M;
      sumWrappers = sumWrappers % M;
      sumChocolates += newNumChocolates;
      sumWrappers += newNumChocolates;
    }
    Console.WriteLine(sumChocolates);
  }
}

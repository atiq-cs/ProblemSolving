/***************************************************************************
*   Problem Name:   Chocolate, Problem A
*   Problem Link :  http://codecon.bloomberg.com/problemDetails/CONTEST/84/Stony%20Brook%20CodeCon
                    /1425/2015-09-18T22:45:00.000Z
*   Date        :   Sept 18, 2015
*
*   Algo, DS    :   Puzzle like math
*   Desc        :   Arithmetic
*
*   Complexity  :   O(1), constant time
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Notes       :   8x8 Chessboard, determine number of moves required for the bishop to reach destination
*                   from target, chessoboard number starts from 1 and ends at 64
*                   How to solve: first map the number to row, column indices,
*                   Afterwards, apply conditions on those row, column pairs
***************************************************************************/
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

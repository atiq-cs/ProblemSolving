/***************************************************************************
* Problem Name: K-based Numbers
* Problem URL : http://acm.timus.ru/problem.aspx?space=1&num=1009
* Date        : Jan 22 2016
* Complexity  : O(N) Time and O(1) Space
* Author      : Atiq Rahman
* Status      : Accepted (46ms)
* Desc        : Easy DP, formula can be derived for first and second terms for
*               each K
* Notes       : For each of the base k, a DP is possible
*                  f(n) = (K-1) * (f(n-1) + f(n-2))
*               The relation looks simple but it took some time to find and
*               verify
* meta        : tag-algo-dp
***************************************************************************/
using System;

public class Solution {
    private static int GetKBasedNumValidAmount(int N, int K) {
        int first = K * (K - 1);
        int second = (K - 1) * (K * K - 1);
        // handle invalid inputs
        if (N < 2 || K < 2 || N + K > 18)
            return -1;
        if (N == 2)
            return first;
        if (N == 3)
            return second;
        int result = -1;

        while (N-- > 3) {
            result = (K - 1) * (first + second);
            first = second;
            second = result;
        }
        return result;
    }

    private static void Main() {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());
        Console.WriteLine(GetKBasedNumValidAmount(N, K));
    }
}

// code v1 OOP looks like this
public class KBaseNumSolution {
    public int GetValidAmount(int N, int K) {
        // copy of the function from above
    }
}

public class Demo {
    public static void Main() {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());
        KBaseNumSolution kSol = new KBaseNumSolution();
        Console.WriteLine(kSol.GetValidAmount(N, K));
    }
}

/*
IO sample
2
10
90

2-digit numbers
from 10 to 99

none of them contain two consecutive 0s

Let's consider base 2
N = 2
10
11

2 2
2 because 2*(2-1) base 2

N = 3
101
110
111

2 3
3

N = 4
1010
1011
1101
1110
1111

2 4
5

N = 5
10101
10110
10111
11010
11011
11101
11110
11111

2 5
8

Summary for K=2
2,3,5,8

3 2
10
11
12
20
21
22

3 2
6 because K * (K-1)

3 3
101
102
110
111
112
120
121
122
201
202
210
211
212
220
221
222

3 3
16

3 4
1010
1011
1012
1020
1021
1022
1101
1102
1110
1111
1112
1120
1121
1122
1201
1202
1210
1211
1212
1220
1221
1222
2010
2011
2012
2020
2021
2022
2101
2102
2110
2111
2112
2120
2121
2122
2201
2202
2210
2211
2212
2220
2221
2222

3 4
44
6, 16, 44, 

2 4
10
11
12
13
20
21
22
23
30
31
32
33

12 because K * (K-1)

3 4
101
102
103
110
111
112
113
120
121
122
123
130
131
132
133
201
202
203
210
211
212
213
220
221
222
223
230
231
232
233
301
302
303
310
311
312
313
320
321
322
323
330
331
332
333

3 4
45

N=2
first one is K*(K-1)
on second one N = 3
second one is, 3 (4-1), 16 (2*(9-1)), 45 (3*(16-1))
(K-1)*(K*K-1)

(K-1)*(K*K-1-K)


difference
K = 2, d = 1  , 1 * (2-1)
K = 3, d = 10 , 2 * (6-1)
K = 4, d = 33 , 3 * ()

3rd term
K = 2
(K-1)*(N[0]+N[1])
K = 3
(K-1)*(N[0]+N[1])
K=4
3 * (57) = 171

verifying 3rd term for K=4
1000
There are total thse many numbers between 1000 and 3333
[math]::pow(4,4)-[math]::pow(4,3)
192

..2..
1010
..1..
1101
..1..
1201
..1..
1301
21

first patterns where it happens
1000
1100
1200
1300

3 * 4
second pattern
1001
1002
1003
2001
3001
3 * 3


3 * 4 + 3*3
= 21

192 - 21 = 171 verified
*/

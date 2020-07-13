/***************************************************************************************************
* Title : Climbing Stairs
* URL   : https://leetcode.com/problems/climbing-stairs/
* Date  : 2015-10-23
* Comp  : O(n), O(1)
* Status: Accepted
* Notes : Will modify solution to use O(n) space when there will be
*   large number of queries
* rel   : https://www.hackerrank.com/challenges/ctci-fibonacci-numbers
* meta  : tag-algo-dp, tag-num-theory-fibonacci, tag-leetcode-easy
***************************************************************************************************/
public class Solution {
  public int ClimbStairs(int n) {
    int fibA = 0, fibB = 1;

    for (int i=0; i<n; i++) {
        int temp = fibB; fibB += fibA; fibA = temp;
    }

    return n<1?fibA:fibB;
  }
}

/*
Mental sketch:
n = 1 {1}
nw = 1

n = 2 {1, 2}, {2}
nw = 2

n = 3 {1, 2, 3}, {2, 3}, {1, 3}
nw = 3

n = 4  {1, 2, 3, 4}, {2, 3, 4}, {2, 4}, {1, 3, 4}, {1, 2, 4}
nw = 5

n = 5  {1, 2, 3, 4, 5}, {1, 3, 4, 5}, {1, 3, 5}, {2, 3, 4, 5}, {2, 4, 5}, {2, 3, 5}, {1, 2, 4, 5}, {1, 2, 3, 5}
nw = 8
*/

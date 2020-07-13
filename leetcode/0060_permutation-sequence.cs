/***************************************************************************************************
* Title : Permutation Sequence
* URL   : https://leetcode.com/problems/permutation-sequence
* Date  : 2015-10-06
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : Given n and k return kth permutation
* meta  : tag-permutation, tag-leetcode-easy
***************************************************************************************************/
public class Solution {
  StringBuilder sb = new StringBuilder();
  List<int> digitList;
  Func<int, int> fact = null;

  public string GetPermutation(int n, int k) {
    fact = x => (x == 0) ? 1 : x * fact(x - 1);

    digitList = new List<int>(n);
    for (int i = 1; i <= n; i++)
      digitList.Add(i);
    GetPermutationRec(n, k);
    return sb.ToString();
  }

  void GetPermutationRec(int n, int k) {
    if (n == 0)
      return;
    if (k == 0) {
      for (int i = n - 1; i >= 0; i--)
        // can replace digitList with i+1 ?
        // nope, digitList array is modified later
        sb.Append(digitList[i]);
      // or
      // sb.Append(string.Join("", digitList));
      return;
    }
    // process one digit on left and go for the rest
    int p = fact(n - 1);
    int digitIndex = (int) Math.Ceiling(((double) k) / p) - 1;

    sb.Append(digitList[digitIndex]);
    digitList.RemoveAt(digitIndex);
    GetPermutationRec(n - 1, k % p);
  }

  /* replaced with lambda 
   * int getfact(int n) {
    if (n == 0)
      return 1;
    return n * getfact(n - 1);
  } */
}

/* Problem - Permutation Sequence
----------------------------------
n! unique permutations

return kth permutation

Examples:
For, n = 1, we have,
1

for, n = 2 we have,
12
21

n = 3,
123
132
213
231
312
321

say k = 4,
 first digitIndex or di = 4 / 6 - 1 = 0

for n = 4,
1123
1132
1213
1231
1312
1321
2134

let's consider for n=4, 4! = 24, we can have different values of k
if k = 1 then always
  first digit index is 0 for k=1 to k= 6
              is 1 for k=7 to k=12
        p = (n-1)! = 6      
first digit can be generalized as
  for ceiling(k/6) as ceiling (7/6)

for n = 4, k=7
second digit is,
    1
2 is removed from list, it contains 1, 3, 4
  find mod, and n = 3, k = 1
    index is 0 for k=1 to k=2
      so digit is 1
     
now n = 2, k = 0

for n=2 and k=2
first digit is coming from, 2/1-1 = 2-1 =1
index 1 has digit 2
*/


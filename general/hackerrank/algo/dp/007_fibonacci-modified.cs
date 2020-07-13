/***************************************************************************************************
* Title : Fibonacci Modified
* URL   : https://www.hackerrank.com/challenges/fibonacci-modified
* Comp  : O(n), for O(logn) look at,
*   http://stackoverflow.com/questions/15093566/is-there-a-better-way-performance-calculate-fibonacci-than-this-one
* Author: Atiq Rahman
* Status: Accepted
*
* Notes : Because BigInteger to String is too slow got TLE using regular approach
*   based on the approach here, ref: http://pastebin.com/F1MDkU2J
*   I created a function to improve the IO overhead situation
*   Used ArrayList instead of List to improve it further
*   However, that improved run time only a little
*
*   This is the best I did with C# in hackerrank by setting a split limit to 1024
*
*   Wit a split limit of 1000 using List and StringBuilder the solution has following time,
*   - Testcase 3: 0.94s
*   - Testcase 6: 0.75s
*
*   Same approach with split of 100 gives us
*   - Testcase 3: 1.1s
*   - Testcase 6: 1.32s
*
*   If we use direct code of ref, it gives
*   - Testcase 3: 1.1s
*   - Testcase 6: 1.31s
*   Time,
*   Testcase 3, 0.75s
*   Testcase 6, 0.89s
*
*   First solution of this problem: fibonacci-modified_v0.cs [timed out]
* meta  : tag-big-integer, tag-algo-dp
***************************************************************************************************/
using System;
using System.Collections;
using System.Numerics;
using System.Text;

class Solution
{
  static void Main() {
    string[] tokens = Console.ReadLine().Split();
    int first;
    Int32.TryParse(tokens[0], out first);
    int second;
    Int32.TryParse(tokens[1], out second);
    int steps;
    Int32.TryParse(tokens[2], out steps);

    if (steps == 1)
    {
      Console.WriteLine(first);
      return;
    }
    if (steps == 2)
    {
      Console.WriteLine(second);
      return;
    }
    BigInteger res = 0;
    BigInteger a = first;
    BigInteger b = second;
    for (int i = 2; i < steps; i++)
    {
      res = a + BigInteger.Pow(b, 2);
      a = b;
      b = res;
    }

    Console.WriteLine(GetBigIntegerString(res));
  }

  static StringBuilder GetBigIntegerString(BigInteger n)
  {
    const int SPLIT_LIMIT = 1024;
    StringBuilder sb = new StringBuilder();
    var ans = new ArrayList();
    var p10 = BigInteger.Pow(10, SPLIT_LIMIT);

    while (n != 0)
    {
      ans.Add(n % p10);
      n /= p10;
    }
    sb.Append(ans[ans.Count - 1].ToString());

    var fmt = new string('0', SPLIT_LIMIT);

    for (var i = ans.Count - 2; i >= 0; i--)
    {
      var str = ans[i].ToString();
      sb.Append(String.Format("{0}{1}", fmt.Substring(0, SPLIT_LIMIT - str.Length), str));
    }

    return sb;
  }
}

/*
   This is the first version of the function where reference is directly followed
   and output is given by WriteLine every time string is formed
    * no string builder
    * no array list
   Running time
    - Testcase 3: 3.43s
    - Testcase 6: 2.83s
*/
static void DisplayBigInteger(BigInteger n)
{
  var ans = new List<BigInteger>();
  var p10 = BigInteger.Pow(10, 100);

  while (n != 0) {
    ans.Add(n % p10);
    n /= p10;
  }
  Console.Write(ans[ans.Count - 1]);
  var fmt = new string('0', 100);

  for (var i = ans.Count - 2; i >= 0; i--) {
    var str = ans[i].ToString();
    Console.Write("{0}{1}", fmt.Substring(0, 100 - str.Length), str);
  }
  Console.WriteLine();
}

 /*
   This is the second version of the function where I tried to speed up using primitive type
    long long, splitting on 19 digits is not good enough for a large big integer.

   I remember test case 6 almost took 3.5s with this approach
*/
static StringBuilder GetBigIntegerString(BigInteger n)
{
  var ans = new List<string>();
  StringBuilder sb = new StringBuilder();
  ulong p10 = 10000000000000000000L;

  const int DIGITS_LIMIT = 19;
  var fmt = new string('0', DIGITS_LIMIT);
  string str = "";
  while (n != 0)
  {
    ulong m = (ulong)(n % p10);
    str = m.ToString();

    if (str.Length == DIGITS_LIMIT)
      ans.Add(str);
    else
      ans.Add(String.Format("{0}{1}", fmt.Substring(0, DIGITS_LIMIT - str.Length), str));

    n /= p10;
  }
  sb.Append(str);
  for (var i = ans.Count - 2; i >= 0; i--)
    sb.Append(ans[i]);

  return sb;
}

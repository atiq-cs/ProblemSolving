/***************************************************************************
* Title : IP Address Validation
* URL   : https://www.hackerrank.com/challenges/ip-address-validation/
* Date  : 2018-04-07
* Author: Atiq Rahman
* Comp  : O(n) to do multiple iterations, space O(n) to store tokens
* Status: Accepted
* Notes : Solved based on bloomberg version which only validates IPv4
*   This one validates IPv6 as well
*   If input string is neither ipv4 nor ipv6 print Invalid
*   Uses C++ istringstream to tokenize;
*   Example ref, https://atiqcs.wordpress.com/2018/01/27/cpp-fundamentals/
*   Example input at the bottom of the source
*   
*   demonstrates hex number string to int conversion
*   ref, Int32.TryParse Method (String, NumberStyles, IFormatProvider, Int32)
*   https://msdn.microsoft.com/en-us/library/zf50za27.aspx
* meta  : tag-easy, tag-company-bloomberg, tag-string, tag-tokenize
***************************************************************************/
using System;
using System.Globalization;   // hex convert

public class IPValidation {
  private bool IsIPv4(string ip)
  {
    string[] tokens = ip.Split('.');
    if (tokens.Length != 4)
      return false;
    foreach (var token in tokens)
      if (int.TryParse(token, out int n) == false || n>255 || n<0)
        return false;
    return true;
  }

  private bool IsIPv6(string ip)
  {
    string[] tokens = ip.Split(':');
    if (tokens.Length != 8)
      return false;
    int n = -1;
    foreach (var token in tokens)
      if (token.Length>4 || int.TryParse(token, NumberStyles.HexNumber, new
        CultureInfo("en-US"), out n) == false)
        return false;
    return true;
  }

  public void Run()
  {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      string str = Console.ReadLine();
      if (IsIPv4(str))
        Console.WriteLine("IPv4");
      else if (IsIPv6(str))
        Console.WriteLine("IPv6");
      else
        Console.WriteLine("Neither");
    }
  }
}

public class HK_Solution {
  public static void Main() {
    IPValidation demo = new IPValidation();
    demo.Run();
  }
}

/*
4
This line has junk text.
121.18.19.20
2001:0db8:0000:0000:0000:ff00:0042:8329
2001:0db8:0000:0000:0000:fff00:0042:8329
*/

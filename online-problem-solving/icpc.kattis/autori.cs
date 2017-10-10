/***************************************************************************
* Title       : Autori
* URL         : https://open.kattis.com/problems/autori
* Occasion    : Croatian Open Competition in Informatics 2009/2010, contest #4
* Date        : Sept 29 2017
* Complexity  : 
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : easy
* meta        : tag-kattis, tag-easy, tag-string
***************************************************************************/
using System;
using System.Text;

public class Solution {
  private static void Main() {
    string[] tokens = Console.ReadLine().Split('-');
    StringBuilder shortVariation = new StringBuilder();
    foreach (string str in tokens)
      shortVariation.Append(str[0]);
    Console.WriteLine(shortVariation);
  }
}

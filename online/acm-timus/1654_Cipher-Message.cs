/***************************************************************************
* Problem Name:   Cipher Message
* Problem URL :   http://acm.timus.ru/problem.aspx?space=1&num=1654
* Date        :   Sept 07, 2015
*
* Algo, DS    :   Stack
* Desc        :   Arithmetic
*
* Complexity  :   O(n) where n is the length of the string
* Author      :   Atiq Rahman
* Status      :   Accepted (Time: 0.078), Memory (7692KB)
* meta        :   tag-stack
***************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string enc_str = Console.ReadLine();
        string dec_str = GetDecryptedMessage(enc_str);
        Console.WriteLine(dec_str);
    }

    static string GetDecryptedMessage(string str)
    {
        Stack chStack = new Stack();

        foreach (char ch in str) {
            if (chStack.Count > 0 && (char) chStack.Peek() == ch)
            {
                chStack.Pop();
            }
            else {
                chStack.Push(ch);
            }
        }

        char[] ch_str = (from o in chStack.ToArray()
                         select (char)o).ToArray();

        Array.Reverse(ch_str);

        return new string(ch_str); ;
    }
}

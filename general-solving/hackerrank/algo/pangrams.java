/***************************************************************************
*   Problem Name:   A Very Big Sum
*   Problem URL :   https://www.hackerrank.com/challenges/pangrams
*   Date        :   Aug 26, 2015
*
*   Domain      :   algorithms/strings

*   Desc        :   Panagrams are strings containing every letter of the alphabel
*
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Note        :   Shows how solution can be implemented in java for comparison
***************************************************************************/

import java.io.*;
import java.util.*;

public class Solution {
    public static Boolean isAnagram(String line_str) {
        char[] line = line_str.toCharArray();
        
        int[] letters = new int[26];
        for (int i=0; i<26; i++)
            letters[i] = 0;
        
        for (int i=0; i<line.length; i++) {
            if (Character.isUpperCase(line[i]))
                letters[line[i]-65] = 1;
            else if (Character.isLowerCase(line[i]))
                letters[line[i]-97] = 1;
        }

        for (int i=0; i<26; i++)
            if (letters[i] == 0)
                return false;
        return true;
    }

    public static void main(String[] args) throws Exception {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution. */
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String line_str = br.readLine();
        
        if (isAnagram(line_str))
            System.out.println("pangram");
        else
            System.out.println("not pangram");        
    }
}

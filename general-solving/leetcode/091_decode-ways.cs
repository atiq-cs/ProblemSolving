/***************************************************************************
* Problem Name: Decode Ways
* Problem URL : https://leetcode.com/problems/decode-ways/
* Date        : Oct 23 2015
* Complexity  : O(n)
* Author      : Atiq Rahman
* Status      : Accepted (beat 47%)
* Notes       : 
* meta        : tag-dynamic-programming
***************************************************************************/

public class Solution {
    public int NumDecodings(string s) {
        int fibA = 0;
        int fibB = 1;
        for (int i=0; i<s.Length; i++) {
            // 0 not following 1/2 is invalid, otherwise 0 anywhere invalid
            if ((i==0 && s[i]=='0') || (i>0 && (s[i-1] != '1' && s[i-1] != '2') && s[i]=='0')) {
                fibB = 0;
                break;
            }

            if (i>0) {
                // check if next char is 0 then 10/20 has to be dealed
                if (i<s.Length-1 && (s[i]=='1' || s[i]=='2') && s[i+1]=='0')
                    continue;       // in this case don't assign: fibA = fibB
                if (canFormPair(s[i-1], s[i])) {
                    int temp = fibB;
                    fibB += fibA;
                    fibA = temp;
                }
                else
                    fibA = fibB;
            }
            else
                fibA = fibB;
        }
        return s.Length==0?fibA:fibB;
    }
    
    bool canFormPair(char s, char t) {
        if (s>='3' || s=='0')
            return false;
        if (s=='2' && t>'6')
            return false;
        if ((s=='1' || s=='2') && t=='0')
            return false;
        return true;
    }
}

/***************************************************************************
* Problem Name: Excel Sheet Column Title
* Problem URL : https://leetcode.com/problems/excel-sheet-column-title/
* Date        : Oct 7 2015
* Complexity  : log_26(n) Time
* Author      : Atiq Rahman
* Status      : Accepted (beats 79%)
* Notes       : For Nutanix problem description and cpp solution have a look at
*                      168_excel-sheet-column-title_v02.cpp
* meta        : tag-binary-tree
***************************************************************************/

public class Solution {
    public class Solution {
        StringBuilder result;
        public string ConvertToTitle(int n)
        {
            result = new StringBuilder();
            ConvertRec(n);
            return result.ToString();
        }

        void ConvertRec(int n)
        {
            if (n == 0)
                return;

            if (n % 26 == 0) {
                ConvertRec((n - 26) / 26);
                result.Append('Z');
            }
            else {
                ConvertRec(n / 26);
                result.Append((char)(n % 26 + 'A' - 1));
            }
        }
    }
}

/*
* Mapping is as following
*  26 -> Z
*  27 -> AA
*  52 -> AZ
*  53 -> BA
*  
* If we try to map this problem with Base converseion
*  First n%26 - is the last 
* Line 27 - ensures that if n is multiple of 26 then
*  Z should be appended
*/

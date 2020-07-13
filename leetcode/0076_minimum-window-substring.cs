/***************************************************************************
* Title : Minimum Size Subarray Sum
* URL   : https://leetcode.com/problems/minimum-window-substring
* Date  : 2018-09-23
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : Find minimum length sub-string that contains all characters from
*   given pattern string.
*   All chars here does not mean the set but all count should be present
*   
*   Problem is assuming that we cover all chars from given pattern/needle
*   string- consider a frequency dictionary than char set
*   
* ref   : HashSet ctor ref: https://docs.microsoft.com/en-US/dotnet/api/
*   system.collections.generic.hashset-1.-ctor (not used in final solution
*   but look at first version)
* meta  : tag-sliding-window, tag-two-pointers, tag-leetcode-hard
***************************************************************************/
public class Solution {
  public string MinWindow(string haystack, string needle) {
    // build char freqs for needle
    var needleCharsFreq = new Dictionary<char, int>();
    foreach (var ch in needle)
      if (needleCharsFreq.ContainsKey(ch))
        needleCharsFreq[ch]++;
      else
        needleCharsFreq.Add(ch, 1);

    // initialization
    string minStr = "";
    bool gotAllChars = false;
    var WindowCharsFreq = new Dictionary<char, int>();
    // int minLength = s.Length;    // use minStr.Length instead

    for (int i=0, start=0; i<haystack.Length; i++) {
      var ch = haystack[i];   // readability
      // keep adding till current window does not contain all of 'em..
      if (needleCharsFreq.ContainsKey(ch)) {
        // add current char
        if (WindowCharsFreq.ContainsKey(ch))
          WindowCharsFreq[ch]++;
        else
          WindowCharsFreq.Add(ch, 1);

        // update got chars flag
        if (gotAllChars == false)
          gotAllChars = hasAllChars(needleCharsFreq, WindowCharsFreq);

        // trigger trimming from start if all chars found
        if (gotAllChars) {
          ch = haystack[start];   // this loop can be optimized
          while (WindowCharsFreq.ContainsKey(ch)==false || WindowCharsFreq[ch] > needleCharsFreq[ch]) {
            start++;
            if (WindowCharsFreq.ContainsKey(ch))
              WindowCharsFreq[ch]--;
            ch = haystack[start];
          }
          if (string.IsNullOrEmpty(minStr) || minStr.Length > i - start + 1)
            minStr = haystack.Substring(start, i-start+1);
        }
      }
      // else ignore that char..
    }
    return minStr;
  }

  private bool hasAllChars(Dictionary<char, int> expected, Dictionary<char, int> whatWeHave) {
    foreach( var entry in expected )
      if (whatWeHave.ContainsKey(entry.Key)==false || whatWeHave[entry.Key] < entry.Value)
        return false;
    return true;
  }
}

/* Example inputs,
"aa"
"aa"
"a"
"aa"
""
""
"ABCABC"
"CAB"

and draft initial,
Try KMP alike approach..

abbccbbabc

all we need is unique set cover,
{a, b, c}

 - we get a new one we add
 - we get one that we already have

say we got,
i=0,
a

coverCount = 1

i=1,
ab
coverCount = 2

i=2,
abb
coverCount = 2

i=3,
abbc
len = 4
coverCount = 3

first time we got a cover..

i=4,
abbcc
len = 5
coverCount = 3

i=5,
abbccb
len = 6
coverCount = 3
try to trim first part where prev b was found..

i=6,
abbccbb
len = 7
coverCount = 3
try to trim first part where prev b was found..

i=7,
abbccbba
len = 7
coverCount = 3
try to trim first part where prev b was found..

exact KMP cannot be applied

How to know where to default back?

say we also have count stuff for each char encountered..

can't fill n^2 space with o(n) algorithm..

What I have though is O(26) at each index... to check and know everything we want..

at any index I can do constant number of comparisons and tell whether we have a cover..

question is how do we choose the indices..

- till we have not covered we keep adding..

can I tell if have any cover in O(N)? yes..

need a good algorithm for backing up... the way KMP backs up to start matching from where it matters..

how can we do that for this problem??

abbccbbabc

after a cover is found removing first char.. keep removing them as long as ..
abbccbba becomes cbba


simply saying,
after a cover is found.. try to find a cover removing its first char..

abbcaabbcc

And draft second,
----------
Input: S = "ADOBECODEBANC", T = "ABC"
Output: "BANC"

ADOBEC
ADOBECODEBA
found match now reduce
CODEBA
CODEBANC
found match now reduce
BANC

is this an efficient way of rolling back?

because 

say we keep just a count..

feels like we have a dictionary we can utilize frequency count

ADOBECODEBANC
ABC
*/

/*
 * First version, before understanding that it's not expecting a charset cover
 * but a dictionary cover..
 * Problem is assuming that we cover all chars from given pattern/needle string
 * : consider a frequency dictionary than char set
*/
public class Solution {
  public string MinWindow(string haystack, string needle) {
    if (haystack.Length < needle.Length)
      return "";
    var needleCharsFreq = new HashSet<char>(needle);  // ctor ref above
    int start = 0;
    // int minLength = s.Length;
    string minStr = "";
    bool gotAllChars = false;
    var WindowCharsFreq = new Dictionary<char, int>();

    for(int i=0; i<haystack.Length; i++) {
      var ch = haystack[i];
      // keep adding till current window does not contain all of em..
      if (needleCharsFreq.Contains(ch)) {
        // add to dictionary
        if (WindowCharsFreq.ContainsKey(ch))
          WindowCharsFreq[ch]++;
        else
          WindowCharsFreq.Add(ch, 1);
        if (gotAllChars == false)
          gotAllChars = hasAllChars(needleCharsFreq, WindowCharsFreq);

        if (gotAllChars) {
          ch = haystack[start];
          while (WindowCharsFreq.ContainsKey(ch)==false || WindowCharsFreq[ch] > 1) {
            start++;
            if (WindowCharsFreq.ContainsKey(ch))
              WindowCharsFreq[ch]--;
            ch = haystack[start];
          }
          if (string.IsNullOrEmpty(minStr) || minStr.Length > i - start + 1) {
            minStr = haystack.Substring(start, i-start+1);
          }
        }
      }
      // else ignore that char..
    }
    return minStr;
  }
  
  private bool hasAllChars(HashSet<char> chars, Dictionary<char, int> freq) {
    foreach( var ch in chars )
      if (freq.ContainsKey(ch)==false || freq[ch] < 1)
        return false;
    return true;
  }
}

/***************************************************************************************************
* Title : Text Justification
* URL   : https://leetcode.com/problems/text-justification/
* Occasn: leetcode meetup, Polaris Ave, Mtn Vw
* Date  : 2019-03-24
* Comp  : O(n), O(m) n = |words|, m = |words in line|
*  Runtime: 8 ms, faster than 6.19%
*  Memory Usage: 35 MB, less than 23.46%
* Author: Atiq Rahman
* Status: Accepted
* Notes : Figure what how spaces would be distributed and it is solved
*   first word is added simply
*   from next one we start pre-pending spaces
*    We got 2 pointers i and j,
*   i = index of first word in current line
*   j = index of next to last word in current line
*   j-i is number of words we have in current line
*   j-i-1 is m = |slots for spaces|
*   lineLength var adds a space for each slot already hence it additionally occupies j-i-1
*   Therefore, to get number of spaces for each slot we need to find length for all words in current
*   line. After subtracting spaces, that is lineLength-(j-i-1)
*   When we subtract this length from maxWidth we get total num of spaces which is,
*    maxWidth-(lineLength-m) = maxWidth-lineLength+m
*   now to get distributed count for each slot we divide m
*    (maxWidth-lineLength+m) / m
*   We add 1 in the beginning because we wanna distribute one more for the slots upto mod. Please
*   substitute m with value from above
*   To understand by example consider test case 1 from draft at botton
* meta  : tag-string, tag-two-pointers, tag-leetcode-hard
***************************************************************************************************/
import java.util.*;
import java.lang.StringBuilder;

class Solution {
  public List<String> fullJustify(String[] words, int maxWidth) {
    int lineLength = -1;
    StringBuilder sb = new StringBuilder();
    List<String> result = new LinkedList<String>();

    int i = 0;
    for (int j=0; j<words.length; j++) {
      String word = words[j];
      int totalLength = lineLength + word.length() + 1;
      if (totalLength > maxWidth) {
        // handle single word
        if (j==i+1)
          sb.append(String.format("%1$-"+maxWidth+ "s", words[i]));
        // multiple words, print in 3 stages
        else {
          int numSpaces = (maxWidth-lineLength+j-i-1) / (j-i-1)+1;
          int mod = (maxWidth-lineLength+j-i-1) % (j-i-1);
          // add first word
          sb.append(words[i]);
          // add words till where modular remainder spaces has to be distributed
          for (int k=i+1; k<=i+mod; k++)
            sb.append(String.format("%1$"+numSpaces+ "s", "") + words[k]);
          numSpaces--;
          // distribution for mod spaces has ended
          for (int k=i+mod+1; k<j; k++)
            sb.append(String.format("%1$"+numSpaces+ "s", "") + words[k]);
        }

        lineLength = word.length();
        i = j;

        result.add(sb.toString());
        sb.setLength(0);
      }
      else
        lineLength += word.length() + 1;
    }

    if (i<words.length)
      for (int k=i; k<words.length; k++)
        sb.append((k==i?"" : " ") + words[k]);
    result.add(String.format("%1$-"+maxWidth+ "s", sb.toString()));

    return result;
  }

  // optional driver main method and some test-cases
  public static void main(String[] args) {
    System.out.println("result " + new Solution().fullJustify(new String[] {"What","must","be",
      "acknowledgment","shall","be"}, 16));
  }
}

/*
  some test cases,
    System.out.println("result " + new Solution().fullJustify(new String[] {"ask","not","what","your","country","can","do","for","you","ask","what","you","can","do","for","your","country"}, 16));
    System.out.println("result " + new Solution().fullJustify(new String[] {"This", "is", "an", "example", "of", "text", "justification."}, 16));
    System.out.print("result " + new Solution().fullJustify(new String[] {"I", "am", "a", "great","Samrat."}, 16));
*/
